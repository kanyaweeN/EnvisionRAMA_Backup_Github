using System;
using System.Data;
using System.Data.OleDb;
using System.Windows.Forms;
using RIS.Common.Common;
using RIS.BusinessLogic;

namespace RIS.Forms.EmployeeSchedule
{
    #region WinScheduleDatabaseSupportBase class
    /// <summary>
    /// Base class for the WinSchedule database access classes.
    /// </summary>
    /// <remarks>
    /// The <b>WinScheduleDatabaseSupportBase</b> class is an abstract class which
    /// defines properties that return instances of the OleDB-related classes that
    /// are necessary to connect to a database. The 'ConnectionString' property,
    /// which must be overridden in a derived class, defines the connection string
    /// specific to that type of database. The DataAdapterForOwners and
    /// DataAdapterForAppointments properties, which also must be overridden in a
    /// derived class, define the OleDbCommand instances which control the selection,
    /// updating, and deletion of records in their respective tables.
    /// </remarks>
    public abstract class WinScheduleDatabaseSupportBase : IDisposable
    {
        #region Constants

        /// <summary>
        /// Template for the SQL SELECT statement for Owners.
        /// </summary>
        public static string SELECT_OWNERS_TEMPLATE = "SELECT EMP_ID,([FNAME]+' '+[LNAME]) AS Owner,ALLPROPERTIES,VISIBLE FROM {0} WHERE EMP_ID="+new GBLEnvVariable().UserID+"";

        /// <summary>
        /// Template for the SQL SELECT statement for Appointments.
        /// </summary>
        protected const string SELECT_APPOINTMENTS_TEMPLATE = "SELECT * FROM {0};";

        /// <summary>
        /// Defines the name of the table that contains the Owner data.
        /// </summary>
        public const string OWNERS_TABLE_NAME = "HR_EMP";

        /// <summary>
        /// Defines the name of the table that contains the Appointment data.
        /// </summary>
        public const string APPOINTMENTS_TABLE_NAME = "GBL_EMPSCHEDULE";

        /// <summary>
        /// The maximum number of bytes allowed for an appointment. Note that this
        /// is a function of the database table, and should not be changed here.
        /// </summary>
        public const int MAX_APPOINTMENT_BYTES = 1024;

        #endregion Constants

        #region Member variables

        protected OleDbConnection _oleDbConnection = null;
        protected OleDbDataAdapter _oleDbDataAdapterForOwners = null;
        protected OleDbDataAdapter _oleDbDataAdapterForAppointments = null;
        private DataSet _dataSet = null;
        private bool _hasOwnerChanges = false;
        private bool _hasAppointmentChanges = false;

        #endregion Member variables

        #region Connection
        /// <summary>
        /// Returns the OleDbConnection with which to connect to the data source.
        /// An attempt is made to open the connection the first time the property
        /// is accessed.
        /// </summary>
        protected OleDbConnection Connection
        {
            get
            {
                if (this._oleDbConnection == null)
                {
                    this._oleDbConnection = new OleDbConnection();
                    this._oleDbConnection.ConnectionString = this.ConnectionString;

                    try
                    {
                        this._oleDbConnection.Open();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Could not connect to data source: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

                return this._oleDbConnection;
            }
        }
        #endregion Connection

        #region ConnectionString
        /// <summary>
        /// Returns the connection string to be assigned to the ConnectionString
        /// property of the OleDbConnection referenced by the <see cref="Connection"/>
        /// property. Must be overridden in derived classes to return a valid connection
        /// string for the type of database associated with the derived class.
        /// </summary>
        protected abstract string ConnectionString { get; }
        #endregion ConnectionString

        #region DataAdapterForOwners
        /// <summary>
        /// Returns the OleDbDataAdapter to be used for Owner data.
        /// </summary>
        /// <remarks>
        /// The OleDbDataAdapter instance referenced by this property is "lazily" created,
        /// i.e., object creation is deferred until the property is requested. When the
        /// object is created, the InsertCommand, UpdateCommand and DeleteCommand properties
        /// are all set to new instances of OleDbCommand objects, and those instances are
        /// configured appropriately.
        /// </remarks>
        protected abstract OleDbDataAdapter DataAdapterForOwners { get; }

        #endregion DataAdapterForOwners

        #region DataAdapterForAppointments
        /// <summary>
        /// Returns the OleDbDataAdapter to be used for Owner data.
        /// </summary>
        /// <remarks>
        /// The OleDbDataAdapter instance referenced by this property is "lazily" created,
        /// i.e., object creation is deferred until the property is requested. When the
        /// object is created, the InsertCommand, UpdateCommand and DeleteCommand properties
        /// are all set to new instances of OleDbCommand objects, and those instances are
        /// configured appropriately.
        /// </remarks>
        protected abstract OleDbDataAdapter DataAdapterForAppointments
        {
            get;
        }
        #endregion DataAdapterForAppointments

        #region DataSet
        /// <summary>
        /// Returns the DataSet which holds the Owner and Appointment data.
        /// </summary>
        public DataSet DataSet
        {
            get
            {
                if (this._dataSet == null)
                    this._dataSet = new DataSet("dbo");

                OleDbDataAdapter dataAdapter = null;
                if (this._dataSet.Tables.Contains(WinScheduleDatabaseSupportBase.OWNERS_TABLE_NAME) == false)
                {
                    dataAdapter = this.DataAdapterForOwners;
                    try { dataAdapter.Fill(this._dataSet, WinScheduleDatabaseSupportBase.OWNERS_TABLE_NAME); }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }

                    this._dataSet.Tables[WinScheduleDatabaseSupportBase.OWNERS_TABLE_NAME].RowChanged += new DataRowChangeEventHandler(this.OnRowChanged);
                    this._dataSet.Tables[WinScheduleDatabaseSupportBase.OWNERS_TABLE_NAME].RowDeleted += new DataRowChangeEventHandler(this.OnRowChanged);

                }


                if (this._dataSet.Tables.Contains(WinScheduleMSSQLServerSupport.APPOINTMENTS_TABLE_NAME) == false)
                {
                    dataAdapter = this.DataAdapterForAppointments;
                    dataAdapter.Fill(this._dataSet, WinScheduleDatabaseSupportBase.APPOINTMENTS_TABLE_NAME);
                    this._dataSet.Tables[WinScheduleDatabaseSupportBase.APPOINTMENTS_TABLE_NAME].RowChanged += new DataRowChangeEventHandler(this.OnRowChanged);
                    this._dataSet.Tables[WinScheduleDatabaseSupportBase.APPOINTMENTS_TABLE_NAME].RowDeleted += new DataRowChangeEventHandler(this.OnRowChanged);
                }

                return this._dataSet;
            }
        }
        #endregion DataSet

        #region Owners
        /// <summary>
        /// Returns the DataTable which contains the Owner data.
        /// </summary>
        public DataTable Owners
        {
            get { return this.DataSet.Tables[WinScheduleDatabaseSupportBase.OWNERS_TABLE_NAME]; }
        }
        #endregion Owners

        #region Appointments
        /// <summary>
        /// Returns the DataTable which contains the Appointment data.
        /// </summary>
        public DataTable Appointments
        {
            get { return this.DataSet.Tables[WinScheduleMSSQLServerSupport.APPOINTMENTS_TABLE_NAME]; }
        }
        #endregion Appointments

        #region UpdateOwnersTable
        /// <summary>
        /// Commits any outstanding changes to owner data to the DataTable.
        /// </summary>
        public void UpdateOwnersTable()
        {
            if (this.HasOwnerChanges == false)
                return;

            this.DataAdapterForOwners.Update(this.DataSet, WinScheduleDatabaseSupportBase.OWNERS_TABLE_NAME);
            this._hasOwnerChanges = false;
        }
        #endregion UpdateOwnersTable

        #region UpdateAppointmentsTable
        /// <summary>
        /// Commits any outstanding changes to appointment data to the DataTable.
        /// </summary>
        public void UpdateAppointmentsTable()
        {
            if (this.HasAppointmentChanges == false)
                return;

            this.DataAdapterForAppointments.Update(this.DataSet, WinScheduleMSSQLServerSupport.APPOINTMENTS_TABLE_NAME);
            this._hasAppointmentChanges = false;
        }
        #endregion UpdateAppointmentsTable

        #region OnRowChanged
        /// <summary>
        /// Handles the RowUpdated event for the data tables. We use this
        /// to receive a notification when a row has been modified or deleted,
        /// so that we can track the dirty state of the tables.
        /// </summary>
        private void OnRowChanged(object sender, DataRowChangeEventArgs e)
        {
            if (this.DataSet.Tables.Contains(WinScheduleMSSQLServerSupport.APPOINTMENTS_TABLE_NAME) &&
                 sender == this.DataSet.Tables[WinScheduleMSSQLServerSupport.APPOINTMENTS_TABLE_NAME])
                this._hasAppointmentChanges = true;
            else
                if (this.DataSet.Tables.Contains(WinScheduleMSSQLServerSupport.OWNERS_TABLE_NAME) &&
                     sender == this.DataSet.Tables[WinScheduleMSSQLServerSupport.OWNERS_TABLE_NAME])
                    this._hasOwnerChanges = true;
        }
        #endregion OnRowUpdated

        #region HasOwnerChanges
        /// <summary>
        /// Returns whether the Owners table has changes which have not
        /// been committed to the database.
        /// </summary>
        public bool HasOwnerChanges
        {
            get { return this._hasOwnerChanges; }
        }
        #endregion HasOwnerChanges

        #region HasAppointmentChanges
        /// <summary>
        /// Returns whether the Appointments table has changes which have not
        /// been committed to the database.
        /// </summary>
        public bool HasAppointmentChanges
        {
            get { return this._hasAppointmentChanges; }
        }
        #endregion HasAppointmentChanges

        #region IDisposable
        /// <summary>
        /// Implements the IDisposable interface's Dispose method.
        /// </summary>
        void IDisposable.Dispose()
        {
            if (this._oleDbConnection != null)
            {
                this._oleDbConnection.Close();
                this._oleDbConnection.Dispose();
                this._oleDbConnection = null;
            }

            if (this._oleDbDataAdapterForAppointments != null)
            {
                this._oleDbDataAdapterForAppointments.Dispose();
                this._oleDbDataAdapterForAppointments = null;
            }

            if (this._oleDbDataAdapterForOwners != null)
            {
                this._oleDbDataAdapterForOwners.Dispose();
                this._oleDbDataAdapterForOwners = null;
            }

            if (this._dataSet != null)
            {
                this._dataSet.Dispose();
                this._dataSet = null;
            }
        }

        /// <summary>
        /// Releases all resources used by this <see cref="WinScheduleMSSQLServerSupport"/> instance.
        /// </summary>
        public void Dispose()
        {
            ((IDisposable)this).Dispose();
        }

        #endregion IDisposable
    }
    #endregion WinScheduleDatabaseSupportBase class

    #region WinScheduleMSSQLServerSupport class
    /// <summary>
    /// Handles communication between the WinSchedule data binding layer
    /// and a SQL Server database.
    /// </summary>
    /// <remarks>
    /// The WinScheduleMSSQLServerSupport class exposes properties that simplify the coding
    /// that is necessary to bind the UltraCalendarInfo component's Appointments and Owners
    /// collections to a SQL Server database.
    /// </remarks>
    public class WinScheduleMSSQLServerSupport : WinScheduleDatabaseSupportBase
    {
        #region Constants

        /// <summary>
        /// Defines the connection string; takes the following 5 parameters:
        /// 
        /// Parameter {0} = UserId
        /// Parameter {1} = Password
        ///	Parameter {2} = DatabaseName
        ///	Parameter {3} = ServerName
        ///	Parameter {4} = WorkstationId
        /// </summary>
        //private const string DATABASE_CONNECTION_STRING_TEMPLATE = @"Provider=SQLOLEDB.1;Initial Catalog=RISN;Data Source=RIS-PCS\SQLEXPRESS;Integrated Security=SSPI";
        // private const string DATABASE_CONNECTION_STRING_TEMPLATE = @"Provider=SQLOLEDB.1;Initial Catalog=RISN;Data Source=RIS-PCS\SQLEXPRESS;Integrated Security=SSPI";  
        private static string constr = System.Configuration.ConfigurationManager.AppSettings["connStr"];
        private string DATABASE_CONNECTION_STRING_TEMPLATE = @"Provider=SQLOLEDB.1;" + constr;
        //server=RIS-PCS\SQLEXPRESS; database=RISN; integrated security=SSP
        /// <summary>
        /// The value of the 'User ID' parameter of the connection string.
        /// </summary>
        //private const string DATABASE_USER_ID = "";

        /// <summary>
        /// The value of the 'Password' parameter of the connection string.
        /// </summary>
        //private const string DATABASE_PASSWORD = "";

        /// <summary>
        /// The value of the 'Initial Catalog' parameter of the connection string.
        /// </summary>
        private const string DATABASE_NAME = "RISN";

        /// <summary>
        /// The value of the 'DataSource' parameter of the connection string.
        /// </summary>
        private const string DATABASE_SERVER_NAME = "RIS-PC/SQLEXPRESS";

        /// <summary>
        /// The number of bytes in the 'AllProperties' database field.
        /// Note that this value MUST not be changed unless the actual
        /// database field is also changed to the same value.
        /// </summary>
        private const int ALLPROPERTIES_FIELD_SIZE = 2048;

        /// <summary>
        /// The number of bytes in the 'Subject' database field.
        /// Note that this value MUST not be changed unless the actual
        /// database field is also changed to the same value.
        /// </summary>
        private const int SUBJECT_FIELD_SIZE = 200;

        #endregion Constants

        #region ConnectionString
        /// <summary>
        /// Returns a connection string specific to the SQL Server database
        /// associated with this instance.
        /// </summary>
        protected override string ConnectionString
        {
            get
            {
                string workstationId = SystemInformation.ComputerName;
                string connectionString = string.Format(DATABASE_CONNECTION_STRING_TEMPLATE, workstationId);
                return connectionString;
            }
        }
        #endregion ConnectionString

        #region DataAdapterForOwners
        /// <summary>
        /// Returns the OleDbDataAdapter to be used for Owner data.
        /// </summary>
        /// <remarks>
        /// The OleDbDataAdapter instance referenced by this property is "lazily" created,
        /// i.e., object creation is deferred until the property is requested. When the
        /// object is created, the InsertCommand, UpdateCommand and DeleteCommand properties
        /// are all set to new instances of OleDbCommand objects, and those instances are
        /// configured appropriately.
        /// </remarks>
        protected override OleDbDataAdapter DataAdapterForOwners
        {
            get
            {
                if (this._oleDbDataAdapterForOwners == null)
                {
                    this._oleDbDataAdapterForOwners = new OleDbDataAdapter();

                    string qry = "SELECT UNIT_ID,SUPPORT_USER FROM HR_EMP WHERE EMP_ID=" + new GBLEnvVariable().UserID + " AND SUPPORT_USER='Y'";
                    ProcessGetGBLLookup emp = new ProcessGetGBLLookup(qry);
                    emp.Invoke();
                    DataTable dtemp = emp.ResultSet.Tables[0];
                    if (dtemp.Rows.Count > 0)
                    {
                        int _unit = Convert.ToInt32(dtemp.Rows[0]["UNIT_ID"].ToString());
                        SELECT_OWNERS_TEMPLATE = "SELECT EMP_ID,(ISNULL([FNAME],'')+' '+ISNULL([LNAME],'')) AS Owner,ALLPROPERTIES,VISIBLE FROM {0} WHERE UNIT_ID="+_unit+"";
                    }
                    else
                    {
                        SELECT_OWNERS_TEMPLATE = "SELECT EMP_ID,(ISNULL([FNAME],'')+' '+ISNULL([LNAME],'')) AS Owner,ALLPROPERTIES,VISIBLE FROM {0} WHERE EMP_ID=" + new GBLEnvVariable().UserID + "";
                    }


                    //	Configure the SELECT command
                    string selectCommandText = string.Format(WinScheduleMSSQLServerSupport.SELECT_OWNERS_TEMPLATE, WinScheduleMSSQLServerSupport.OWNERS_TABLE_NAME);
                    this._oleDbDataAdapterForOwners.SelectCommand = new OleDbCommand(selectCommandText, this.Connection);

                    //	Configure the INSERT command
                    //OleDbCommand insertCommand = new OleDbCommand();
                    //string commandTextTemplate = "INSERT INTO {0}(OwnerKey, AllProperties, Name, Visible) VALUES (?, ?, ?, ?); SELECT OwnerKey, AllProperties, Name, Visible FROM {0} WHERE (OwnerKey= ?)";
                    //insertCommand.CommandText = string.Format( commandTextTemplate, WinScheduleMSSQLServerSupport.OWNERS_TABLE_NAME );
                    //insertCommand.Connection = this.Connection;
                    //insertCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("OwnerKey", System.Data.OleDb.OleDbType.VarChar, 50, "OwnerKey"));
                    //insertCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("AllProperties", System.Data.OleDb.OleDbType.VarBinary, 256, "AllProperties"));
                    //insertCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("Name", System.Data.OleDb.OleDbType.VarChar, 50, "Name"));
                    //insertCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("Visible", System.Data.OleDb.OleDbType.Boolean, 1, "Visible"));
                    //insertCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("Select_OwnerKey", System.Data.OleDb.OleDbType.VarChar, 50, "OwnerKey"));
                    //this._oleDbDataAdapterForOwners.InsertCommand = insertCommand;

                    //	Configure the UPDATE command
                    //OleDbCommand updateCommand = new OleDbCommand();
                    //commandTextTemplate = @"UPDATE {0} SET OwnerKey = ?, AllProperties = ?, Name = ?, Visible = ? WHERE (OwnerKey = ?) AND (AllProperties = ? OR ? IS NULL AND AllProperties IS NULL) AND (Name = ?) AND (Visible = ?); SELECT OwnerKey, AllProperties, Name, Visible FROM {0} WHERE (OwnerKey = ?)";
                    //updateCommand.CommandText = string.Format( commandTextTemplate, WinScheduleMSSQLServerSupport.OWNERS_TABLE_NAME );
                    //updateCommand.Connection = this.Connection;
                    //updateCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("OwnerKey", System.Data.OleDb.OleDbType.VarChar, 50, "OwnerKey"));
                    //updateCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("AllProperties", System.Data.OleDb.OleDbType.VarBinary, 256, "AllProperties"));
                    //updateCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("Name", System.Data.OleDb.OleDbType.VarChar, 50, "Name"));
                    //updateCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("Visible", System.Data.OleDb.OleDbType.Boolean, 1, "Visible"));
                    //updateCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_OwnerKey", System.Data.OleDb.OleDbType.VarChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "OwnerKey", System.Data.DataRowVersion.Original, null));
                    //updateCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_AllProperties", System.Data.OleDb.OleDbType.VarBinary, 1024, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "AllProperties", System.Data.DataRowVersion.Original, null));
                    //updateCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_AllProperties1", System.Data.OleDb.OleDbType.VarBinary, 1024, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "AllProperties", System.Data.DataRowVersion.Original, null));
                    //updateCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_Name", System.Data.OleDb.OleDbType.VarChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Name", System.Data.DataRowVersion.Original, null));
                    //updateCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_Visible", System.Data.OleDb.OleDbType.Boolean, 1, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Visible", System.Data.DataRowVersion.Original, null));
                    //updateCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("Select_OwnerKey", System.Data.OleDb.OleDbType.VarChar, 50, "OwnerKey"));
                    //this._oleDbDataAdapterForOwners.UpdateCommand = updateCommand;

                    //	Configure the DELETE command
                    //OleDbCommand deleteCommand = new OleDbCommand();
                    //commandTextTemplate = "DELETE FROM {0} WHERE (OwnerKey = ?) AND (AllProperties = ? OR ? IS NULL AND AllProperties IS NULL) AND (Name = ?) AND (Visible = ?)";
                    //deleteCommand.CommandText = string.Format( commandTextTemplate, WinScheduleMSSQLServerSupport.OWNERS_TABLE_NAME );
                    //deleteCommand.Connection = this.Connection;
                    //deleteCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_OwnerKey", System.Data.OleDb.OleDbType.VarChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "OwnerKey", System.Data.DataRowVersion.Original, null));
                    //deleteCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_AllProperties", System.Data.OleDb.OleDbType.VarBinary, 256, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "AllProperties", System.Data.DataRowVersion.Original, null));
                    //deleteCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_AllProperties1", System.Data.OleDb.OleDbType.VarBinary, 256, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "AllProperties", System.Data.DataRowVersion.Original, null));
                    //deleteCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_Name", System.Data.OleDb.OleDbType.VarChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Name", System.Data.DataRowVersion.Original, null));
                    //deleteCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_Visible", System.Data.OleDb.OleDbType.Boolean, 1, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Visible", System.Data.DataRowVersion.Original, null));
                    //this._oleDbDataAdapterForOwners.DeleteCommand = deleteCommand;

                }

                return this._oleDbDataAdapterForOwners;
            }
        }
        #endregion DataAdapterForOwners

        #region DataAdapterForAppointments
        /// <summary>
        /// Returns the OleDbDataAdapter to be used for Appointment data.
        /// </summary>
        /// <remarks>
        /// The OleDbDataAdapter instance referenced by this property is "lazily" created,
        /// i.e., object creation is deferred until the property is requested. When the
        /// object is created, the InsertCommand, UpdateCommand and DeleteCommand properties
        /// are all set to new instances of OleDbCommand objects, and those instances are
        /// configured appropriately.
        /// </remarks>
        protected override OleDbDataAdapter DataAdapterForAppointments
        {
            get
            {
                if (this._oleDbDataAdapterForAppointments == null)
                {
                    this._oleDbDataAdapterForAppointments = new OleDbDataAdapter();

                    //	Configure the SELECT command
                    string selectCommandText = string.Format(WinScheduleMSSQLServerSupport.SELECT_APPOINTMENTS_TEMPLATE, WinScheduleMSSQLServerSupport.APPOINTMENTS_TABLE_NAME);
                    this._oleDbDataAdapterForAppointments.SelectCommand = new OleDbCommand(selectCommandText, this.Connection);

                    //	Configure the INSERT command
                    OleDbCommand insertCommand = new OleDbCommand();
                    string commandTextTemplate = @"INSERT INTO {0}(ALLPROPERTIES, START_TIME, END_TIME, SUBJECT, SCHEDULE_FOR, LOCATION, CREATED_BY, ORG_ID, IMPORTANCE, SCHEDULE_STATUS, DETAILS, ALL_DAY_EVENT, CATEGORY_ID) VALUES (?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?); SELECT EMP_SCHEDULE_ID, ALLPROPERTIES, START_TIME, END_TIME, SUBJECT, SCHEDULE_FOR, LOCATION, CREATED_BY, ORG_ID, IMPORTANCE, SCHEDULE_STATUS, DETAILS, ALL_DAY_EVENT, CATEGORY_ID FROM {0} WHERE (EMP_SCHEDULE_ID = @@IDENTITY)";
                    insertCommand.CommandText = string.Format(commandTextTemplate, WinScheduleMSSQLServerSupport.APPOINTMENTS_TABLE_NAME);
                    insertCommand.Connection = this.Connection;
                    insertCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("AllProperties", System.Data.OleDb.OleDbType.VarBinary, ALLPROPERTIES_FIELD_SIZE, "ALLPROPERTIES"));
                    insertCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("StartDateTime", System.Data.OleDb.OleDbType.DBTimeStamp, 8, "START_TIME"));
                    insertCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("EndDateTime", System.Data.OleDb.OleDbType.DBTimeStamp, 8, "END_TIME"));
                    insertCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("Subject", System.Data.OleDb.OleDbType.VarChar, SUBJECT_FIELD_SIZE, "SUBJECT"));
                    //insertCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("AllDayEvent", System.Data.OleDb.OleDbType.Boolean, 1, "AllDayEvent"));
                    insertCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("EMP_ID", System.Data.OleDb.OleDbType.Integer, 4, "SCHEDULE_FOR"));
                    insertCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("ScRATE", System.Data.OleDb.OleDbType.VarChar, SUBJECT_FIELD_SIZE, "LOCATION"));
                    insertCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("ScCreatedBy", System.Data.OleDb.OleDbType.VarChar, SUBJECT_FIELD_SIZE, "CREATED_BY"));
                    insertCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("ScOrgID", System.Data.OleDb.OleDbType.VarChar, SUBJECT_FIELD_SIZE, "ORG_ID"));
                    insertCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("RefDoctor", System.Data.OleDb.OleDbType.VarChar, SUBJECT_FIELD_SIZE, "IMPORTANCE"));
                    insertCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("RefFrom", System.Data.OleDb.OleDbType.VarChar, SUBJECT_FIELD_SIZE, "SCHEDULE_STATUS"));
                    insertCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("ScheduleData", System.Data.OleDb.OleDbType.VarChar, SUBJECT_FIELD_SIZE, "DETAILS"));
                    insertCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("AllDayEvent", System.Data.OleDb.OleDbType.Boolean, 1, "ALL_DAY_EVENT"));
                    insertCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("Accession", System.Data.OleDb.OleDbType.Integer, 4, "CATEGORY_ID"));
                    this._oleDbDataAdapterForAppointments.InsertCommand = insertCommand;

                    //	Configure the UPDATE command
                    OleDbCommand updateCommand = new OleDbCommand();
                    commandTextTemplate = @"UPDATE {0} SET ALLPROPERTIES = ?, START_TIME = ?, END_TIME = ?, SUBJECT = ?, SCHEDULE_FOR = ?, LOCATION = ?, CREATED_BY = ?, ORG_ID =?, IMPORTANCE=?, SCHEDULE_STATUS=?, DETAILS=?, ALL_DAY_EVENT=?, CATEGORY_ID=? WHERE (EMP_SCHEDULE_ID = ?) AND (ALLPROPERTIES = ? OR ? IS NULL AND ALLPROPERTIES IS NULL) AND (END_TIME = ?) AND (START_TIME = ?); SELECT EMP_SCHEDULE_ID, ALLPROPERTIES, START_TIME, END_TIME, SUBJECT, SCHEDULE_FOR, LOCATION, CREATED_BY, ORG_ID, IMPORTANCE, SCHEDULE_STATUS, DETAILS, ALL_DAY_EVENT, CATEGORY_ID FROM {0} WHERE (EMP_SCHEDULE_ID = ?)";
                    updateCommand.CommandText = string.Format(commandTextTemplate, WinScheduleMSSQLServerSupport.APPOINTMENTS_TABLE_NAME);
                    updateCommand.Connection = this.Connection;
                    updateCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("AllProperties", System.Data.OleDb.OleDbType.VarBinary, ALLPROPERTIES_FIELD_SIZE, "ALLPROPERTIES"));
                    updateCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("StartDateTime", System.Data.OleDb.OleDbType.DBTimeStamp, 8, "START_TIME"));
                    updateCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("EndDateTime", System.Data.OleDb.OleDbType.DBTimeStamp, 8, "END_TIME"));
                    updateCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("Subject", System.Data.OleDb.OleDbType.VarChar, SUBJECT_FIELD_SIZE, "SUBJECT"));
                    //updateCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("AllDayEvent", System.Data.OleDb.OleDbType.Boolean, 1, "AllDayEvent"));
                    updateCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("EMP_ID", System.Data.OleDb.OleDbType.Integer, 4, "SCHEDULE_FOR"));
                    updateCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("ScRATE", System.Data.OleDb.OleDbType.VarChar, SUBJECT_FIELD_SIZE, "LOCATION"));
                    updateCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("ScCreatedBy", System.Data.OleDb.OleDbType.VarChar, SUBJECT_FIELD_SIZE, "CREATED_BY"));
                    updateCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("ScOrgID", System.Data.OleDb.OleDbType.VarChar, SUBJECT_FIELD_SIZE, "ORG_ID"));
                    updateCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("RefDoctor", System.Data.OleDb.OleDbType.VarChar, SUBJECT_FIELD_SIZE, "IMPORTANCE"));
                    updateCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("RefFrom", System.Data.OleDb.OleDbType.VarChar, SUBJECT_FIELD_SIZE, "SCHEDULE_STATUS"));
                    updateCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("ScheduleData", System.Data.OleDb.OleDbType.VarChar, SUBJECT_FIELD_SIZE, "DETAILS"));
                    updateCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("AllDayEvent", System.Data.OleDb.OleDbType.Boolean, 1, "ALL_DAY_EVENT"));
                    updateCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("Accession", System.Data.OleDb.OleDbType.Integer, 4, "CATEGORY_ID"));
                    updateCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_EMP_SCHEDULE_ID", System.Data.OleDb.OleDbType.Integer, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "EMP_SCHEDULE_ID", System.Data.DataRowVersion.Original, null));
                    //updateCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_AllDayEvent", System.Data.OleDb.OleDbType.Boolean, 1, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "AllDayEvent", System.Data.DataRowVersion.Original, null));
                    updateCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_AllProperties", System.Data.OleDb.OleDbType.VarBinary, ALLPROPERTIES_FIELD_SIZE, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ALLPROPERTIES", System.Data.DataRowVersion.Original, null));
                    updateCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_AllProperties1", System.Data.OleDb.OleDbType.VarBinary, ALLPROPERTIES_FIELD_SIZE, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ALLPROPERTIES", System.Data.DataRowVersion.Original, null));
                    updateCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_EndDateTime", System.Data.OleDb.OleDbType.DBTimeStamp, 8, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "END_TIME", System.Data.DataRowVersion.Original, null));
                    //updateCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_MODALITY_ID", System.Data.OleDb.OleDbType.Integer, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "MODALITY_ID", System.Data.DataRowVersion.Original, null));
                    //updateCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_MODALITY_ID1", System.Data.OleDb.OleDbType.Integer, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "OwMODALITY_IDnerKey", System.Data.DataRowVersion.Original, null));
                    updateCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_StartDateTime", System.Data.OleDb.OleDbType.DBTimeStamp, 8, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "START_TIME", System.Data.DataRowVersion.Original, null));
                    //updateCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_Subject", System.Data.OleDb.OleDbType.VarChar, SUBJECT_FIELD_SIZE, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Subject", System.Data.DataRowVersion.Original, null));
                    updateCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("Select_EMP_SCHEDULE_ID", System.Data.OleDb.OleDbType.Integer, 4, "EMP_SCHEDULE_ID"));
                    this._oleDbDataAdapterForAppointments.UpdateCommand = updateCommand;

                    //	Configure the DELETE command
                    OleDbCommand deleteCommand = new OleDbCommand();
                    commandTextTemplate = @"DELETE FROM {0} WHERE (EMP_SCHEDULE_ID = ?) AND (ALLPROPERTIES = ? OR ? IS NULL AND ALLPROPERTIES IS NULL) AND (END_TIME = ?) AND (SCHEDULE_FOR = ? OR ? IS NULL AND SCHEDULE_FOR IS NULL) AND (START_TIME = ?)";
                    deleteCommand.CommandText = string.Format(commandTextTemplate, WinScheduleMSSQLServerSupport.APPOINTMENTS_TABLE_NAME);
                    deleteCommand.Connection = this.Connection;
                    deleteCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_EMP_SCHEDULE_ID", System.Data.OleDb.OleDbType.Integer, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "EMP_SCHEDULE_ID", System.Data.DataRowVersion.Original, null));
                    //deleteCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_AllDayEvent", System.Data.OleDb.OleDbType.Boolean, 1, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "AllDayEvent", System.Data.DataRowVersion.Original, null));
                    deleteCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_AllProperties", System.Data.OleDb.OleDbType.VarBinary, ALLPROPERTIES_FIELD_SIZE, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ALLPROPERTIES", System.Data.DataRowVersion.Original, null));
                    deleteCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_AllProperties1", System.Data.OleDb.OleDbType.VarBinary, ALLPROPERTIES_FIELD_SIZE, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ALLPROPERTIES", System.Data.DataRowVersion.Original, null));
                    deleteCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_EndDateTime", System.Data.OleDb.OleDbType.DBTimeStamp, 8, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "END_TIME", System.Data.DataRowVersion.Original, null));
                    deleteCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_MODALITY_ID", System.Data.OleDb.OleDbType.VarChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "SCHEDULE_FOR", System.Data.DataRowVersion.Original, null));
                    deleteCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_MODALITY_ID1", System.Data.OleDb.OleDbType.VarChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "SCHEDULE_FOR", System.Data.DataRowVersion.Original, null));
                    deleteCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_StartDateTime", System.Data.OleDb.OleDbType.DBTimeStamp, 8, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "START_TIME", System.Data.DataRowVersion.Original, null));
                    //deleteCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_Subject", System.Data.OleDb.OleDbType.VarChar, SUBJECT_FIELD_SIZE, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Subject", System.Data.DataRowVersion.Original, null));
                    this._oleDbDataAdapterForAppointments.DeleteCommand = deleteCommand;

                }

                return this._oleDbDataAdapterForAppointments;
            }
        }
        #endregion DataAdapterForAppointments
    }
    #endregion WinScheduleMSSQLServerSupport class

    #region WinScheduleMSAccessSupport class
    /// <summary>
    /// Handles communication between the WinSchedule data binding layer and an MS Access database.
    /// </summary>
    /// <remarks>
    /// The WinScheduleMSSQLServerSupport class exposes properties that simplify the coding
    /// that is necessary to bind the UltraCalendarInfo component's Appointments and Owners
    /// collections to an MS Access database.
    /// </remarks>
    public class WinScheduleMSAccessSupport : WinScheduleDatabaseSupportBase
    {
        #region Constants

        /// <summary>
        /// Defines the connection string; takes the following parameters:
        /// 
        /// Parameter {0} = Path to the location (directory) of the database file
        /// Parameter {1} = Name of the database file, including file extension
        /// </summary>
        private const string DATABASE_CONNECTION_STRING_TEMPLATE = @"Provider=Microsoft.Jet.OLEDB.4.0;Password="""";User ID=Admin;Data Source={0}\{1};Mode=Share Deny None;Extended Properties="""";Jet OLEDB:System database="""";Jet OLEDB:Registry Path="""";Jet OLEDB:Database Password="""";Jet OLEDB:Engine Type=5;Jet OLEDB:Database Locking Mode=1;Jet OLEDB:Global Partial Bulk Ops=2;Jet OLEDB:Global Bulk Transactions=1;Jet OLEDB:New Database Password="""";Jet OLEDB:Create System Database=False;Jet OLEDB:Encrypt Database=False;Jet OLEDB:Don't Copy Locale on Compact=False;Jet OLEDB:Compact Without Replica Repair=False;Jet OLEDB:SFP=False";

        /// <summary>
        /// The filename of the MS Access database.
        /// </summary>
        private const string DATABASE_NAME = "WinScheduleData.mdb";

        #endregion Constants

        #region ConnectionString
        /// <summary>
        /// Returns a connection string specific to the MS Access database
        /// associated with this instance.
        /// </summary>
        protected override string ConnectionString
        {
            get
            {
                string connectionString = string.Empty;
                string databasePath = RIS.Forms.Schedule.Common.DataPath;

                if (databasePath != null)
                    connectionString = string.Format(DATABASE_CONNECTION_STRING_TEMPLATE, databasePath, DATABASE_NAME);

                return connectionString;
            }
        }
        #endregion ConnectionString

        #region DataAdapterForOwners
        /// <summary>
        /// Returns the OleDbDataAdapter to be used for Owner data.
        /// </summary>
        /// <remarks>
        /// The OleDbDataAdapter instance referenced by this property is "lazily" created,
        /// i.e., object creation is deferred until the property is requested. When the
        /// object is created, the InsertCommand, UpdateCommand and DeleteCommand properties
        /// are all set to new instances of OleDbCommand objects, and those instances are
        /// configured appropriately.
        /// </remarks>
        protected override OleDbDataAdapter DataAdapterForOwners
        {
            get
            {
                if (this._oleDbDataAdapterForOwners == null)
                {
                    this._oleDbDataAdapterForOwners = new OleDbDataAdapter();

                    //	Configure the SELECT command
                    string selectCommandText = string.Format(WinScheduleMSSQLServerSupport.SELECT_OWNERS_TEMPLATE, WinScheduleMSSQLServerSupport.OWNERS_TABLE_NAME);
                    this._oleDbDataAdapterForOwners.SelectCommand = new OleDbCommand(selectCommandText, this.Connection);

                    //	Configure the INSERT command
                    OleDbCommand insertCommand = new OleDbCommand();
                    string commandTextTemplate = "INSERT INTO {0}(AllProperties, Name, OwnerKey, Visible) VALUES (?, ?, ?, ?)";
                    insertCommand.CommandText = string.Format(commandTextTemplate, WinScheduleMSAccessSupport.OWNERS_TABLE_NAME);
                    insertCommand.Connection = this.Connection;
                    insertCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("AllProperties", System.Data.OleDb.OleDbType.VarBinary, 0, "AllProperties"));
                    insertCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("Name", System.Data.OleDb.OleDbType.VarWChar, 50, "Name"));
                    insertCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("OwnerKey", System.Data.OleDb.OleDbType.VarWChar, 50, "OwnerKey"));
                    insertCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("Visible", System.Data.OleDb.OleDbType.Boolean, 2, "Visible"));
                    this._oleDbDataAdapterForOwners.InsertCommand = insertCommand;

                    //	Configure the UPDATE command
                    OleDbCommand updateCommand = new OleDbCommand();
                    commandTextTemplate = "UPDATE {0} SET AllProperties = ?, Name = ?, OwnerKey = ?, Visible = ? WHERE (OwnerKey = ?) AND (AllProperties = ? OR ? IS NULL AND AllProperties IS NULL) AND (Name = ?) AND (Visible = ?)";
                    updateCommand.CommandText = string.Format(commandTextTemplate, WinScheduleMSAccessSupport.OWNERS_TABLE_NAME);
                    updateCommand.Connection = this.Connection;
                    updateCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("AllProperties", System.Data.OleDb.OleDbType.VarBinary, 0, "AllProperties"));
                    updateCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("Name", System.Data.OleDb.OleDbType.VarWChar, 50, "Name"));
                    updateCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("OwnerKey", System.Data.OleDb.OleDbType.VarWChar, 50, "OwnerKey"));
                    updateCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("Visible", System.Data.OleDb.OleDbType.Boolean, 2, "Visible"));
                    updateCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_OwnerKey", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "OwnerKey", System.Data.DataRowVersion.Original, null));
                    updateCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_AllProperties", System.Data.OleDb.OleDbType.VarBinary, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "AllProperties", System.Data.DataRowVersion.Original, null));
                    updateCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_AllProperties1", System.Data.OleDb.OleDbType.VarBinary, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "AllProperties", System.Data.DataRowVersion.Original, null));
                    updateCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_Name", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Name", System.Data.DataRowVersion.Original, null));
                    updateCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_Visible", System.Data.OleDb.OleDbType.Boolean, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Visible", System.Data.DataRowVersion.Original, null));
                    this._oleDbDataAdapterForOwners.UpdateCommand = updateCommand;

                    //	Configure the DELETE command
                    OleDbCommand deleteCommand = new OleDbCommand();
                    commandTextTemplate = "DELETE FROM {0} WHERE (OwnerKey = ?) AND (AllProperties = ? OR ? IS NULL AND AllProperties IS NULL) AND (Name = ?) AND (Visible = ?)";
                    deleteCommand.CommandText = string.Format(commandTextTemplate, WinScheduleMSAccessSupport.OWNERS_TABLE_NAME);
                    deleteCommand.Connection = this.Connection;
                    deleteCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_OwnerKey", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "OwnerKey", System.Data.DataRowVersion.Original, null));
                    deleteCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_AllProperties", System.Data.OleDb.OleDbType.VarBinary, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "AllProperties", System.Data.DataRowVersion.Original, null));
                    deleteCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_AllProperties1", System.Data.OleDb.OleDbType.VarBinary, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "AllProperties", System.Data.DataRowVersion.Original, null));
                    deleteCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_Name", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Name", System.Data.DataRowVersion.Original, null));
                    deleteCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_Visible", System.Data.OleDb.OleDbType.Boolean, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Visible", System.Data.DataRowVersion.Original, null));
                    this._oleDbDataAdapterForOwners.DeleteCommand = deleteCommand;
                }

                return this._oleDbDataAdapterForOwners;
            }
        }
        #endregion DataAdapterForOwners

        #region DataAdapterForAppointments
        /// <summary>
        /// Returns the OleDbDataAdapter to be used for Appointment data.
        /// </summary>
        /// <remarks>
        /// The OleDbDataAdapter instance referenced by this property is "lazily" created,
        /// i.e., object creation is deferred until the property is requested. When the
        /// object is created, the InsertCommand, UpdateCommand and DeleteCommand properties
        /// are all set to new instances of OleDbCommand objects, and those instances are
        /// configured appropriately.
        /// </remarks>
        protected override OleDbDataAdapter DataAdapterForAppointments
        {
            get
            {
                if (this._oleDbDataAdapterForAppointments == null)
                {
                    this._oleDbDataAdapterForAppointments = new OleDbDataAdapter();

                    //	Configure the SELECT command
                    string selectCommandText = string.Format(WinScheduleMSAccessSupport.SELECT_APPOINTMENTS_TEMPLATE, WinScheduleMSAccessSupport.APPOINTMENTS_TABLE_NAME);
                    this._oleDbDataAdapterForAppointments.SelectCommand = new OleDbCommand(selectCommandText, this.Connection);

                    //	Configure the INSERT command
                    OleDbCommand insertCommand = new OleDbCommand();
                    string commandTextTemplate = "INSERT INTO {0}(AllDayEvent, AllProperties, EndDateTime, OwnerKey, StartDateTime, Subject, BLOCK_REASON) VALUES (?, ?, ?, ?, ?, ?, ?)";
                    insertCommand.CommandText = string.Format(commandTextTemplate, WinScheduleMSAccessSupport.APPOINTMENTS_TABLE_NAME);
                    insertCommand.Connection = this.Connection;
                    insertCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("AllDayEvent", System.Data.OleDb.OleDbType.Boolean, 2, "AllDayEvent"));
                    insertCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("AllProperties", System.Data.OleDb.OleDbType.VarBinary, 0, "AllProperties"));
                    insertCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("EndDateTime", System.Data.OleDb.OleDbType.DBTimeStamp, 0, "EndDateTime"));
                    insertCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("OwnerKey", System.Data.OleDb.OleDbType.VarWChar, 50, "OwnerKey"));
                    insertCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("StartDateTime", System.Data.OleDb.OleDbType.DBTimeStamp, 0, "StartDateTime"));
                    insertCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("Subject", System.Data.OleDb.OleDbType.VarWChar, 50, "Subject"));
                    this._oleDbDataAdapterForAppointments.InsertCommand = insertCommand;

                    //	Configure the UPDATE command
                    OleDbCommand updateCommand = new OleDbCommand();
                    commandTextTemplate = @"UPDATE {0} SET AllDayEvent = ?, AllProperties = ?, EndDateTime = ?, OwnerKey = ?, StartDateTime = ?, Subject = ? WHERE (StartDateTime = ?) AND (AllDayEvent = ?) AND (AllProperties = ? OR ? IS NULL AND AllProperties IS NULL) AND (EndDateTime = ?) AND (OwnerKey = ? OR ? IS NULL AND OwnerKey IS NULL) AND (StartDateTime = ?) AND (Subject = ? OR ? IS NULL AND Subject IS NULL)";
                    updateCommand.CommandText = string.Format(commandTextTemplate, WinScheduleMSAccessSupport.APPOINTMENTS_TABLE_NAME);
                    updateCommand.Connection = this.Connection;
                    updateCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("AllDayEvent", System.Data.OleDb.OleDbType.Boolean, 2, "AllDayEvent"));
                    updateCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("AllProperties", System.Data.OleDb.OleDbType.VarBinary, 0, "AllProperties"));
                    updateCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("EndDateTime", System.Data.OleDb.OleDbType.DBTimeStamp, 0, "EndDateTime"));
                    updateCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("OwnerKey", System.Data.OleDb.OleDbType.VarWChar, 50, "OwnerKey"));
                    updateCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("StartDateTime", System.Data.OleDb.OleDbType.DBTimeStamp, 0, "StartDateTime"));
                    updateCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("Subject", System.Data.OleDb.OleDbType.VarWChar, 50, "Subject"));
                    updateCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_SCHEDULE_ID", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(10)), ((System.Byte)(0)), "SCHEDULE_ID", System.Data.DataRowVersion.Original, null));
                    updateCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_AllDayEvent", System.Data.OleDb.OleDbType.Boolean, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "AllDayEvent", System.Data.DataRowVersion.Original, null));
                    updateCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_AllProperties", System.Data.OleDb.OleDbType.VarBinary, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "AllProperties", System.Data.DataRowVersion.Original, null));
                    updateCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_AllProperties1", System.Data.OleDb.OleDbType.VarBinary, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "AllProperties", System.Data.DataRowVersion.Original, null));
                    updateCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_EndDateTime", System.Data.OleDb.OleDbType.DBTimeStamp, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "EndDateTime", System.Data.DataRowVersion.Original, null));
                    updateCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_OwnerKey", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "OwnerKey", System.Data.DataRowVersion.Original, null));
                    updateCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_OwnerKey1", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "OwnerKey", System.Data.DataRowVersion.Original, null));
                    updateCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_StartDateTime", System.Data.OleDb.OleDbType.DBTimeStamp, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "StartDateTime", System.Data.DataRowVersion.Original, null));
                    updateCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_Subject", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Subject", System.Data.DataRowVersion.Original, null));
                    updateCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_Subject1", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Subject", System.Data.DataRowVersion.Original, null));
                    this._oleDbDataAdapterForAppointments.UpdateCommand = updateCommand;

                    //	Configure the DELETE command
                    OleDbCommand deleteCommand = new OleDbCommand();
                    commandTextTemplate = @"DELETE FROM {0} WHERE (SCHEDULE_ID = ?) AND (AllDayEvent = ?) AND (AllProperties = ? OR ? IS NULL AND AllProperties IS NULL) AND (EndDateTime = ?) AND (OwnerKey = ? OR ? IS NULL AND OwnerKey IS NULL) AND (StartDateTime = ?) AND (Subject = ? OR ? IS NULL AND Subject IS NULL)";
                    deleteCommand.CommandText = string.Format(commandTextTemplate, WinScheduleMSAccessSupport.APPOINTMENTS_TABLE_NAME);
                    deleteCommand.Connection = this.Connection;
                    deleteCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_SCHEDULE_ID", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(10)), ((System.Byte)(0)), "SCHEDULE_ID", System.Data.DataRowVersion.Original, null));
                    deleteCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_AllDayEvent", System.Data.OleDb.OleDbType.Boolean, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "AllDayEvent", System.Data.DataRowVersion.Original, null));
                    deleteCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_AllProperties", System.Data.OleDb.OleDbType.VarBinary, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "AllProperties", System.Data.DataRowVersion.Original, null));
                    deleteCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_AllProperties1", System.Data.OleDb.OleDbType.VarBinary, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "AllProperties", System.Data.DataRowVersion.Original, null));
                    deleteCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_EndDateTime", System.Data.OleDb.OleDbType.DBTimeStamp, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "EndDateTime", System.Data.DataRowVersion.Original, null));
                    deleteCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_OwnerKey", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "OwnerKey", System.Data.DataRowVersion.Original, null));
                    deleteCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_OwnerKey1", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "OwnerKey", System.Data.DataRowVersion.Original, null));
                    deleteCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_StartDateTime", System.Data.OleDb.OleDbType.DBTimeStamp, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "StartDateTime", System.Data.DataRowVersion.Original, null));
                    deleteCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_Subject", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Subject", System.Data.DataRowVersion.Original, null));
                    deleteCommand.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_Subject1", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Subject", System.Data.DataRowVersion.Original, null));
                    this._oleDbDataAdapterForAppointments.DeleteCommand = deleteCommand;
                }

                return this._oleDbDataAdapterForAppointments;
            }
        }
        #endregion DataAdapterForAppointments
    }
    #endregion WinScheduleMSAccessSupport class

}