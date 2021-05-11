using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using Infragistics.Win;
using Infragistics.Win.EmployeeSchedule;

namespace RIS.Forms.EmployeeSchedule
{
	#region frmOwner class
	/// <summary>
	/// Dialog which enables the end user to add a new WinSchedule Owner
	/// or modify the properties of an existing one.
	/// </summary>
	public class frmOwner : System.Windows.Forms.Form
	{
		#region Member variables

		private Infragistics.Win.Misc.UltraButton cmdOk;
        private Infragistics.Win.Misc.UltraButton cmdCancel;
        private IContainer components=null;
		private Owner _owner = null;
		private Infragistics.Win.UltraWinEditors.UltraCheckEditor chkLocked;
		private Infragistics.Win.UltraWinEditors.UltraCheckEditor chkVisible;
		private Infragistics.Win.Misc.UltraLabel lblEmail;
		private Infragistics.Win.UltraWinEditors.UltraTextEditor txtEmail;
		private Infragistics.Win.Misc.UltraLabel lblName;
		private Infragistics.Win.UltraWinEditors.UltraTextEditor txtName;
		private Infragistics.Win.Misc.UltraLabel lblKey;
        private Infragistics.Win.UltraWinEditors.UltraTextEditor txtKey;
		UltraCalendarInfo calendarInfo = null;

		#endregion Member variables

		#region Constructor
		/// <summary>
		/// Creates a new instance of the <see cref="frmOwner"/> class.
		/// </summary>
		/// <param name="calendarInfo">The UltraCalendarInfo instance to which this dialog is associated.</param>
		public frmOwner( UltraCalendarInfo calendarInfo )
		{
			this.calendarInfo = calendarInfo;
			InitializeComponent();
		}
		#endregion Constructor

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
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            this.chkLocked = new Infragistics.Win.UltraWinEditors.UltraCheckEditor();
            this.chkVisible = new Infragistics.Win.UltraWinEditors.UltraCheckEditor();
            this.lblEmail = new Infragistics.Win.Misc.UltraLabel();
            this.txtEmail = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.lblName = new Infragistics.Win.Misc.UltraLabel();
            this.txtName = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.lblKey = new Infragistics.Win.Misc.UltraLabel();
            this.txtKey = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.cmdOk = new Infragistics.Win.Misc.UltraButton();
            this.cmdCancel = new Infragistics.Win.Misc.UltraButton();
            ((System.ComponentModel.ISupportInitialize)(this.txtEmail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtKey)).BeginInit();
            this.SuspendLayout();
            // 
            // chkLocked
            // 
            appearance1.BackColor = System.Drawing.Color.Transparent;
            this.chkLocked.Appearance = appearance1;
            this.chkLocked.BackColor = System.Drawing.Color.Transparent;
            this.chkLocked.BackColorInternal = System.Drawing.Color.Transparent;
            this.chkLocked.Location = new System.Drawing.Point(8, 152);
            this.chkLocked.Name = "chkLocked";
            this.chkLocked.Size = new System.Drawing.Size(248, 24);
            this.chkLocked.TabIndex = 17;
            this.chkLocked.Text = "This owner\'s data is accessible through the user interface";
            // 
            // chkVisible
            // 
            appearance2.BackColor = System.Drawing.Color.Transparent;
            this.chkVisible.Appearance = appearance2;
            this.chkVisible.BackColor = System.Drawing.Color.Transparent;
            this.chkVisible.BackColorInternal = System.Drawing.Color.Transparent;
            this.chkVisible.Location = new System.Drawing.Point(8, 120);
            this.chkVisible.Name = "chkVisible";
            this.chkVisible.Size = new System.Drawing.Size(248, 20);
            this.chkVisible.TabIndex = 16;
            this.chkVisible.Text = "This owner is visible in the user interface";
            // 
            // lblEmail
            // 
            appearance3.BackColor = System.Drawing.Color.Transparent;
            appearance3.TextHAlignAsString = "Right";
            appearance3.TextVAlignAsString = "Middle";
            this.lblEmail.Appearance = appearance3;
            this.lblEmail.Location = new System.Drawing.Point(16, 80);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(48, 20);
            this.lblEmail.TabIndex = 14;
            this.lblEmail.Text = "Email:";
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(72, 80);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(208, 22);
            this.txtEmail.TabIndex = 15;
            this.txtEmail.Text = "[Email]";
            // 
            // lblName
            // 
            appearance4.BackColor = System.Drawing.Color.Transparent;
            appearance4.TextHAlignAsString = "Right";
            appearance4.TextVAlignAsString = "Middle";
            this.lblName.Appearance = appearance4;
            this.lblName.Location = new System.Drawing.Point(16, 48);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(48, 20);
            this.lblName.TabIndex = 12;
            this.lblName.Text = "Name:";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(72, 48);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(208, 22);
            this.txtName.TabIndex = 13;
            this.txtName.Text = "[Name]";
            // 
            // lblKey
            // 
            appearance5.BackColor = System.Drawing.Color.Transparent;
            appearance5.TextHAlignAsString = "Right";
            appearance5.TextVAlignAsString = "Middle";
            this.lblKey.Appearance = appearance5;
            this.lblKey.Location = new System.Drawing.Point(16, 16);
            this.lblKey.Name = "lblKey";
            this.lblKey.Size = new System.Drawing.Size(48, 20);
            this.lblKey.TabIndex = 10;
            this.lblKey.Text = "Key:";
            // 
            // txtKey
            // 
            this.txtKey.Location = new System.Drawing.Point(72, 16);
            this.txtKey.Name = "txtKey";
            this.txtKey.Size = new System.Drawing.Size(208, 22);
            this.txtKey.TabIndex = 11;
            this.txtKey.Text = "[Key]";
            // 
            // cmdOk
            // 
            this.cmdOk.Location = new System.Drawing.Point(66, 192);
            this.cmdOk.Name = "cmdOk";
            this.cmdOk.Size = new System.Drawing.Size(75, 23);
            this.cmdOk.TabIndex = 8;
            this.cmdOk.Text = "Ok";
            this.cmdOk.Click += new System.EventHandler(this.cmdOk_Click);
            // 
            // cmdCancel
            // 
            this.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cmdCancel.Location = new System.Drawing.Point(154, 192);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(75, 23);
            this.cmdCancel.TabIndex = 9;
            this.cmdCancel.Text = "Cancel";
            this.cmdCancel.Click += new System.EventHandler(this.cmdCancel_Click);
            // 
            // frmOwner
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 14);
            this.ClientSize = new System.Drawing.Size(290, 224);
            this.Controls.Add(this.chkLocked);
            this.Controls.Add(this.chkVisible);
            this.Controls.Add(this.lblEmail);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.lblKey);
            this.Controls.Add(this.txtKey);
            this.Controls.Add(this.cmdOk);
            this.Controls.Add(this.cmdCancel);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmOwner";
            this.Text = "Add/Modify Owner";
            ((System.ComponentModel.ISupportInitialize)(this.txtEmail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtKey)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		#region Event handlers
		
		/// <summary>
		/// Handles the Ok button's Click event
		/// </summary>
		private void cmdOk_Click(object sender, System.EventArgs e)
		{
			if ( this.ValidateKey() == false )
				return;

			this.DialogResult = DialogResult.OK;
			this.Close();
		}

		/// <summary>
		/// Handles the Cancel button's Click event
		/// </summary>
		private void cmdCancel_Click(object sender, System.EventArgs e)
		{
			this.DialogResult = DialogResult.Cancel;		
			this.Close();
		}

		/// <summary>
		/// Handles the appropriate "value changed" event for all controls
		/// on the dialog which represent Owner properties.
		/// </summary>
		private void OnFieldValueChanged( object sender, EventArgs e )
		{
			this.cmdOk.Enabled = true;
		}

		#endregion Event handlers

		#region ShowMe
		/// <summary>
		/// Shows the dialog
		/// </summary>
		/// <param name="owner">The Owner being edited, or null if adding a new Owner.</param>
		public void ShowMe( Owner owner )
		{
			this._owner = owner;
			this.txtKey.Text = string.Empty;
			this.txtName.Text = string.Empty;
			this.txtEmail.Text = string.Empty;
			this.chkVisible.Checked = true;
			this.chkLocked.Checked = false;
			this.cmdOk.Enabled = false;
			this.Text = "Add new Owner";

			this.txtKey.MaxLength = 50;
			this.txtName.MaxLength = 50;
			this.txtEmail.MaxLength = 50;

			if ( this._owner != null )
			{
				this.txtKey.Text = owner.Key;
				this.txtName.Text = owner.Name;
				this.txtEmail.Text = owner.EmailAddress;
				this.chkVisible.Checked = owner.Visible;
				this.chkLocked.Checked = owner.Locked;
				this.Text = string.Format( "Modify '{0}' properties", owner.Name );
			}

			this.StartPosition = FormStartPosition.CenterParent;

			this.txtKey.TextChanged += new EventHandler( this.OnFieldValueChanged );
			this.txtName.TextChanged += new EventHandler( this.OnFieldValueChanged );
			this.txtEmail.TextChanged += new EventHandler( this.OnFieldValueChanged );
			this.chkLocked.CheckedChanged += new EventHandler( this.OnFieldValueChanged );
			this.chkVisible.CheckedChanged += new EventHandler( this.OnFieldValueChanged );

			this.ShowDialog();
		}

		#endregion ShowMe

		#region ValidateKey
		/// <summary>
		/// Validates the 'Key' field by ensuring the key is non-empty and unique.
		/// </summary>
		private bool ValidateKey()
		{
			bool keyOk = true;
			if ( this.txtKey.Text.Length == 0 )
			{
				MessageBox.Show( "Must specify key.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error );
				keyOk = false;
			}
			else
			{
				if ( this.calendarInfo.Owners.Exists(this.txtKey.Text) )
				{
					//	If the specified key exists, and we are adding a new owner,
					//	fail the validation.
					if ( this._owner == null )
						keyOk = false;
					else
					//	If the specified key exists, we are modifying an existing owner,
					//	and the specified key is different than this owner's fail the validation.
					if ( this.txtKey.Text.Equals(this._owner.Key) == false )
						keyOk = false;
				}
			}

			if ( keyOk == false )
			{
				this.txtKey.Select();
				MessageBox.Show( "Specified key already exists.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error );
			}

			return keyOk;
		}
		#endregion ValidateKey

		#region Key
		/// <summary>
		/// Returns the value of the 'Key' field.
		/// </summary>
		public string Key
		{
			get{ return this.txtKey.Text; }
		}
		#endregion Key

		#region OwnerName
		/// <summary>
		/// Returns the value of the 'Name' field.
		/// </summary>
		public string OwnerName
		{
			get{ return this.txtName.Text; }
		}
		#endregion OwnerName

		#region EMailAddress
		/// <summary>
		/// Returns the value of the 'Email' field.
		/// </summary>
		public string EMailAddress
		{
			get{ return this.txtEmail.Text; }
		}
		#endregion EMailAddress

		#region OwnerVisible
		/// <summary>
		/// Returns the value of the 'Visible' field.
		/// </summary>
		public bool OwnerVisible
		{
			get{ return this.chkVisible.Checked; }
		}
		#endregion OwnerVisible

		#region Locked
		/// <summary>
		/// Returns the value of the 'Locked' field.
		/// </summary>
		public bool Locked
		{
			get{ return this.chkLocked.Checked; }
		}
		#endregion Locked
	}
	#endregion frmOwner class
}
