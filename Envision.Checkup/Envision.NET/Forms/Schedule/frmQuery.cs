using System;
using System.Data;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using Infragistics.Win;
using Infragistics.Win.UltraWinSchedule;
using Infragistics.Win.UltraWinTree;

namespace RIS.Forms.Schedule
{
	#region frmQuery class
	/// <summary>
	/// Dialog which displays the result of a database query.
	/// </summary>
	public class frmQuery : System.Windows.Forms.Form
	{
		#region Member variables
		private Infragistics.Win.UltraWinTree.UltraTree ultraTree1;
		private System.ComponentModel.Container components = null;
		private WinScheduleDatabaseSupportBase _databaseSupport;
		private QueryType _queryType;
		#endregion Member variables

		#region Constructor
		/// <summary>
		/// Creates a new instance of the <see cref="frmQuery"/> class.
		/// </summary>
		/// <param name="databaseSupport">The <see cref="WinScheduleDatabaseSupport"/> instance which contains the data for the query.</param>
		/// <param name="queryType">The QueryType constant which defines the type of query.</param>
		public frmQuery( WinScheduleDatabaseSupportBase databaseSupport, QueryType queryType )
		{
			this._databaseSupport = databaseSupport;
			this._queryType = queryType;
			this.InitializeComponent();
			this.InitializeUI();
		}
		#endregion Constructor

		#region InitializeUI
		/// <summary>
		/// Initializes the user interface.
		/// </summary>
		private void InitializeUI()
		{
			this.ultraTree1.Override.ShowExpansionIndicator = ShowExpansionIndicator.CheckOnDisplay;

			switch ( this._queryType )
			{
				case QueryType.AllOwners:
				{
					this.Text = "Query - All Owners";

					//	Assign the data source
					this.ultraTree1.DataSource = this.GetOwnersTable();
				}
				break;

				case QueryType.AllAppointments:
				{
					this.Text = "Query - All Appointments";

					//	Assign the data source
					this.ultraTree1.DataSource = this.GetAppointmentsTable();
				}
				break;

				case QueryType.AppointmentsByOwner:
				{
					this.Text = "Query - Appointments By Owner";

					DataSet dataSet = new DataSet();
					DataTable ownersTable = this.GetOwnersTable();
					DataTable appointmentsTable = this.GetAppointmentsTable();

					dataSet.Tables.Add( ownersTable );
					dataSet.Tables.Add( appointmentsTable );

					dataSet.Relations.Add( "AppointmentData", ownersTable.Columns["Key"], appointmentsTable.Columns["OwnerKey"], false );

					this.ultraTree1.SetDataBinding( dataSet, "OwnerData" );

					if ( this.ultraTree1.Nodes.Count > 0 )
						this.ultraTree1.Nodes[0].Expanded = true;

				}
				break;
			}

			if ( this.ultraTree1.Nodes.Count > 0 )
				this.AutoSizeColumns();
		}
		#endregion InitializeUI

		#region FormatOwners
		/// <summary>
		/// Formats the display for columns in the 'Owners' ColumnSet
		/// </summary>
		private void FormatOwners( UltraTreeColumnSet columnSet )
		{
			//	Iterate the columns and format the bool columns; also,
			//	assign the editor appropriate to the data type
			for ( int i = 0; i < columnSet.Columns.Count; i ++ )
			{
				UltraTreeNodeColumn column = columnSet.Columns[i];
				if ( column.DataType == typeof(bool) )
				{
					CheckEditor checkEditor = new CheckEditor();
					checkEditor.CheckAlign = ContentAlignment.MiddleCenter;
					column.Editor = checkEditor;
				}
			}
		}
		#endregion FormatOwners

		#region FormatAppointments
		/// <summary>
		/// Formats the display for columns in the 'Appointments' ColumnSet
		/// </summary>
		private void FormatAppointments( UltraTreeColumnSet columnSet )
		{
			columnSet.AllowCellSizing = LayoutSizing.Both;

			//	Iterate the columns and format the DateTime columns; also,
			//	assign the editor appropriate to the data type
			for ( int i = 0; i < columnSet.Columns.Count; i ++ )
			{
				UltraTreeNodeColumn column = columnSet.Columns[i];
				if ( column.DataType == typeof(DateTime) )
					column.Format = System.Globalization.CultureInfo.CurrentCulture.DateTimeFormat.ShortDatePattern;
				else
				if ( column.DataType == typeof(bool) )
				{
					CheckEditor checkEditor = new CheckEditor();
					checkEditor.CheckAlign = ContentAlignment.MiddleCenter;
					column.Editor = checkEditor;
				}
				else
				if ( column.DataType == typeof(Color) )
					column.Editor = new ColorPickerEditor();

				if ( column.Key == "Description" )
					column.CellWrapText = DefaultableBoolean.True;
			}
		}
		#endregion FormatAppointments

		#region AutoSizeColumns
		/// <summary>
		/// Calls PerformAutoResize on all single-line columns
		/// </summary>
		private void AutoSizeColumns()
		{
			foreach( UltraTreeColumnSet columnSet in this.ultraTree1.ColumnSettings.ColumnSets )
			{
				foreach( UltraTreeNodeColumn column in columnSet.Columns )
				{
					if ( column.CellWrapText != DefaultableBoolean.True )
						column.PerformAutoResize( ColumnAutoSizeMode.AllNodes );
				}
			}
		}
		#endregion AutoSizeColumns

		#region GetAppointmentsTable
		/// <summary>
		/// Returns a DataTable which contains the Appointment data.
		/// Unlike the database table, the value of the 'AllProperties'
		/// field is broken out into the corresponding Appointment properties.
		/// </summary>
		private DataTable GetAppointmentsTable()
		{
			//	Get a reference to the actual database table, and create
			//	a new table which will contain the Appointment properties
			DataTable databaseTable = this._databaseSupport.Appointments;
			DataTable newTable = new DataTable("AppointmentData");

			//	Note that we have access to any Appointment property when
			//	we break out the contents of the 'AllProperties' field, so
			//	the structure of the table can be arbitrary, depending on
			//	the application's requirements.
			newTable.Columns.Add( "Subject", typeof(string) );
			newTable.Columns.Add( "StartDateTime", typeof(DateTime) );
			newTable.Columns.Add( "EndDateTime", typeof(DateTime) );
			newTable.Columns.Add( "Description", typeof(string) );
			newTable.Columns.Add( "Location", typeof(string) );
			newTable.Columns.Add( "OwnerKey", typeof(string) );
			newTable.Columns.Add( "AllDayEvent", typeof(bool) );
			newTable.Columns.Add( "Locked", typeof(bool) );
			newTable.Columns.Add( "Visible", typeof(bool) );
			newTable.Columns.Add( "IsRecurringAppointmentRoot", typeof(bool) );
			newTable.Columns.Add( "HasReminder", typeof(bool) );
			newTable.Columns.Add( "BarColor", typeof(Color) );

			for ( int i = 0; i < databaseTable.Rows.Count; i ++ )
			{
				//	Get a reference to the DataRow
				DataRow row = databaseTable.Rows[i];

				//	Get the contents of the 'AllProperties' field; if it is
				//	not a byte array (which should never happen, since that
				//	implies data corruption), skip this row so we don't hurt
				//	ourselves.
				object rawAppointmentData = row["AllProperties"];
				if ( rawAppointmentData is byte[] == false )
					continue;

				//	Get the byte array
				byte[] appointmentBytes = rawAppointmentData as byte[];

				//	Create an Appointment from the byte array, using the
				//	Appointment's static 'FromBytes' method.
				Appointment appointment = Appointment.FromBytes( appointmentBytes );

				//	If the 'FromBytes' method returned null, the data could not
				//	be streamed out into an Appointment, so skip this row.
				if ( appointment == null )
					continue;

				//	Create an object array, populated with the appointment
				//	properties of interest.
				object[] appointmentData = new object[]
				{
					appointment.Subject,
					appointment.StartDateTime,
					appointment.EndDateTime,
					appointment.Description,
					appointment.Location,
					appointment.OwnerKey,
					appointment.AllDayEvent,
					appointment.Locked,
					appointment.Visible,
					appointment.IsRecurringAppointmentRoot,
					appointment.HasReminder,
					appointment.BarColor
				};

				//	Add a row to the new table to represent this Appointment.
				newTable.Rows.Add( appointmentData );
			}

			return newTable;

		}
		#endregion GetAppointmentsTable

		#region GetOwnersTable
		/// <summary>
		/// Returns a DataTable which contains the Owner data.
		/// Unlike the database table, the value of the 'AllProperties'
		/// field is broken out into the corresponding Owner properties.
		/// </summary>
		private DataTable GetOwnersTable()
		{
			//	Get a reference to the actual database table, and create
			//	a new table which will contain the Appointment properties
			DataTable databaseTable = this._databaseSupport.Owners;
			DataTable newTable = new DataTable("OwnerData");

			//	Note that we have access to any Owner property when
			//	we break out the contents of the 'AllProperties' field, so
			//	the structure of the table can be arbitrary, depending on
			//	the application's requirements.
			newTable.Columns.Add( "Key", typeof(string) );
			newTable.Columns.Add( "Name", typeof(string) );
			newTable.Columns.Add( "EmailAddress", typeof(string) );
			newTable.Columns.Add( "Locked", typeof(bool) );
			newTable.Columns.Add( "Visible", typeof(bool) );

			for ( int i = 0; i < databaseTable.Rows.Count; i ++ )
			{
				//	Get a reference to the DataRow
				DataRow row = databaseTable.Rows[i];

				//	Get the contents of the 'AllProperties' field; if it is
				//	not a byte array (which should never happen, since that
				//	implies data corruption), skip this row so we don't hurt
				//	ourselves.
				object rawOwnerData = row["AllProperties"];
				if ( rawOwnerData is byte[] == false )
					continue;

				//	Get the byte array
				byte[] ownerBytes = rawOwnerData as byte[];

				//	Create an Owner from the byte array, using the
				//	Owner's static 'FromBytes' method.
				Owner owner = Infragistics.Win.UltraWinSchedule.Owner.FromBytes( ownerBytes );

				//	If the 'FromBytes' method returned null, the data could not
				//	be streamed out into an Owner, so skip this row.
				if ( owner == null )
					continue;

				//	Create an object array, populated with the owner
				//	properties of interest.
				object[] ownerData = new object[]
				{
					owner.Key,
					owner.Name,
					owner.EmailAddress,
					owner.Locked,
					owner.Visible
				};

				//	Add a row to the new table to represent this Owner.
				newTable.Rows.Add( ownerData );
			}

			return newTable;

		}
		#endregion GetOwnersTable

		#region Windows Form Designer generated code

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			Infragistics.Win.UltraWinTree.UltraTreeColumnSet ultraTreeColumnSet1 = new Infragistics.Win.UltraWinTree.UltraTreeColumnSet();
			this.ultraTree1 = new Infragistics.Win.UltraWinTree.UltraTree();
			((System.ComponentModel.ISupportInitialize)(this.ultraTree1)).BeginInit();
			this.SuspendLayout();
			// 
			// ultraTree1
			// 
			this.ultraTree1.ColumnSettings.RootColumnSet = ultraTreeColumnSet1;
			this.ultraTree1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.ultraTree1.Name = "ultraTree1";
			this.ultraTree1.Size = new System.Drawing.Size(616, 266);
			this.ultraTree1.TabIndex = 0;
			this.ultraTree1.ColumnSetGenerated += new Infragistics.Win.UltraWinTree.ColumnSetGeneratedEventHandler(this.ultraTree1_ColumnSetGenerated);
			// 
			// frmQuery
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(616, 266);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.ultraTree1});
			this.Name = "frmQuery";
			this.Text = "Query";
			((System.ComponentModel.ISupportInitialize)(this.ultraTree1)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// Handles the UltraTree's ColumnSetGenerated event.
		/// </summary>
		private void ultraTree1_ColumnSetGenerated(object sender, Infragistics.Win.UltraWinTree.ColumnSetGeneratedEventArgs e)
		{
			UltraTreeColumnSet columnSet = e.ColumnSet;

			switch ( this._queryType )
			{
				case QueryType.AllAppointments:
				{
					this.FormatAppointments( columnSet );
				}
				break;

				case QueryType.AllOwners:
				{
					this.FormatOwners( columnSet );
				}
				break;

				case QueryType.AppointmentsByOwner:
				{
					if ( columnSet.Key != null && columnSet.Key.Length > 0 )
					{
						if ( columnSet.Key == "OwnerData" )
							this.FormatOwners( columnSet );
						else
						if ( columnSet.Key == "AppointmentData" )
							this.FormatAppointments( columnSet );
					}
				}
				break;
			}
		}

	}
	#endregion frmQuery class


	#region QueryType enumeration
	/// <summary>
	/// Constants which define different queries available to the end user.
	/// </summary>
	public enum QueryType
	{
		/// <summary>
		/// Constant which represents a database query which returns
		/// all Owners in the Owners collection.
		/// </summary>
		AllOwners,

		/// <summary>
		/// Constant which represents a database query which returns
		/// all Appointments in the Appointments collection.
		/// </summary>
		AllAppointments,

		/// <summary>
		/// Constant which represents a database query which returns
		/// Owners with their Appointments as a child table.
		/// </summary>
		AppointmentsByOwner,

	}
	#endregion QueryType enumeration
}
