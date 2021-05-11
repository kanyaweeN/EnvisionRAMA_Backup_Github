namespace RIS.Forms.Admin
{
    partial class menuEntry
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cmbParentSubMenuNo = new System.Windows.Forms.ComboBox();
            this.cmbParentSubMenu = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtSubMenuSerial = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.btnSubDelete = new System.Windows.Forms.Button();
            this.btnSubEdit = new System.Windows.Forms.Button();
            this.btnSubAddNew = new System.Windows.Forms.Button();
            this.txtFormName = new System.Windows.Forms.TextBox();
            this.txtSubDesc = new System.Windows.Forms.TextBox();
            this.cmbSubStatus = new System.Windows.Forms.ComboBox();
            this.cmbSubmenuType = new System.Windows.Forms.ComboBox();
            this.txtSubName = new System.Windows.Forms.TextBox();
            this.label20 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.listView1 = new System.Windows.Forms.ListView();
            this.colName = new System.Windows.Forms.ColumnHeader();
            this.colType = new System.Windows.Forms.ColumnHeader();
            this.colStatus = new System.Windows.Forms.ColumnHeader();
            this.colDescription = new System.Windows.Forms.ColumnHeader();
            this.colFormName = new System.Windows.Forms.ColumnHeader();
            this.colSerialNo = new System.Windows.Forms.ColumnHeader();
            this.colParentNo = new System.Windows.Forms.ColumnHeader();
            this.colLevel = new System.Windows.Forms.ColumnHeader();
            this.colSubMenuNo = new System.Windows.Forms.ColumnHeader();
            this.colParentName = new System.Windows.Forms.ColumnHeader();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnAddNew = new System.Windows.Forms.Button();
            this.cmbMenuStat = new System.Windows.Forms.ComboBox();
            this.txtMenuSerial = new System.Windows.Forms.TextBox();
            this.txtMenuDesc = new System.Windows.Forms.TextBox();
            this.txtMenuName = new System.Windows.Forms.TextBox();
            this.txtMenuId = new System.Windows.Forms.TextBox();
            this.txtMenuNo = new System.Windows.Forms.TextBox();
            this.treeMenu = new System.Windows.Forms.TreeView();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btnClose);
            this.groupBox3.Location = new System.Drawing.Point(36, 534);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(691, 47);
            this.groupBox3.TabIndex = 5;
            this.groupBox3.TabStop = false;
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Location = new System.Drawing.Point(310, 14);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(59, 23);
            this.btnClose.TabIndex = 0;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cmbParentSubMenuNo);
            this.groupBox2.Controls.Add(this.cmbParentSubMenu);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.txtSubMenuSerial);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.btnSubDelete);
            this.groupBox2.Controls.Add(this.btnSubEdit);
            this.groupBox2.Controls.Add(this.btnSubAddNew);
            this.groupBox2.Controls.Add(this.txtFormName);
            this.groupBox2.Controls.Add(this.txtSubDesc);
            this.groupBox2.Controls.Add(this.cmbSubStatus);
            this.groupBox2.Controls.Add(this.cmbSubmenuType);
            this.groupBox2.Controls.Add(this.txtSubName);
            this.groupBox2.Controls.Add(this.label20);
            this.groupBox2.Controls.Add(this.label19);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.listView1);
            this.groupBox2.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.groupBox2.Location = new System.Drawing.Point(36, 226);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(691, 302);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Submenu Information";
            // 
            // cmbParentSubMenuNo
            // 
            this.cmbParentSubMenuNo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbParentSubMenuNo.Enabled = false;
            this.cmbParentSubMenuNo.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbParentSubMenuNo.FormattingEnabled = true;
            this.cmbParentSubMenuNo.Location = new System.Drawing.Point(121, 69);
            this.cmbParentSubMenuNo.Name = "cmbParentSubMenuNo";
            this.cmbParentSubMenuNo.Size = new System.Drawing.Size(257, 22);
            this.cmbParentSubMenuNo.TabIndex = 35;
            this.cmbParentSubMenuNo.Visible = false;
            // 
            // cmbParentSubMenu
            // 
            this.cmbParentSubMenu.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbParentSubMenu.Enabled = false;
            this.cmbParentSubMenu.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbParentSubMenu.FormattingEnabled = true;
            this.cmbParentSubMenu.Location = new System.Drawing.Point(96, 104);
            this.cmbParentSubMenu.Name = "cmbParentSubMenu";
            this.cmbParentSubMenu.Size = new System.Drawing.Size(257, 22);
            this.cmbParentSubMenu.TabIndex = 34;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label9.Location = new System.Drawing.Point(10, 107);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(86, 14);
            this.label9.TabIndex = 33;
            this.label9.Text = "Parent SubMenu";
            // 
            // txtSubMenuSerial
            // 
            this.txtSubMenuSerial.Enabled = false;
            this.txtSubMenuSerial.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSubMenuSerial.Location = new System.Drawing.Point(473, 104);
            this.txtSubMenuSerial.Name = "txtSubMenuSerial";
            this.txtSubMenuSerial.Size = new System.Drawing.Size(114, 20);
            this.txtSubMenuSerial.TabIndex = 32;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label8.Location = new System.Drawing.Point(419, 107);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(53, 14);
            this.label8.TabIndex = 31;
            this.label8.Text = "Serial No.";
            // 
            // btnSubDelete
            // 
            this.btnSubDelete.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnSubDelete.Enabled = false;
            this.btnSubDelete.Location = new System.Drawing.Point(603, 87);
            this.btnSubDelete.Name = "btnSubDelete";
            this.btnSubDelete.Size = new System.Drawing.Size(65, 21);
            this.btnSubDelete.TabIndex = 30;
            this.btnSubDelete.Text = "Delete";
            this.btnSubDelete.UseVisualStyleBackColor = false;
            this.btnSubDelete.Click += new System.EventHandler(this.btnSubDelete_Click);
            // 
            // btnSubEdit
            // 
            this.btnSubEdit.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnSubEdit.Enabled = false;
            this.btnSubEdit.Location = new System.Drawing.Point(603, 62);
            this.btnSubEdit.Name = "btnSubEdit";
            this.btnSubEdit.Size = new System.Drawing.Size(65, 21);
            this.btnSubEdit.TabIndex = 29;
            this.btnSubEdit.Text = "Edit";
            this.btnSubEdit.UseVisualStyleBackColor = false;
            this.btnSubEdit.Click += new System.EventHandler(this.btnSubEdit_Click);
            // 
            // btnSubAddNew
            // 
            this.btnSubAddNew.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnSubAddNew.Enabled = false;
            this.btnSubAddNew.Location = new System.Drawing.Point(603, 37);
            this.btnSubAddNew.Name = "btnSubAddNew";
            this.btnSubAddNew.Size = new System.Drawing.Size(65, 21);
            this.btnSubAddNew.TabIndex = 27;
            this.btnSubAddNew.Text = "Add New";
            this.btnSubAddNew.UseVisualStyleBackColor = false;
            this.btnSubAddNew.Click += new System.EventHandler(this.btnSubAddNew_Click);
            // 
            // txtFormName
            // 
            this.txtFormName.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFormName.Location = new System.Drawing.Point(473, 82);
            this.txtFormName.Name = "txtFormName";
            this.txtFormName.Size = new System.Drawing.Size(114, 20);
            this.txtFormName.TabIndex = 26;
            // 
            // txtSubDesc
            // 
            this.txtSubDesc.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSubDesc.Location = new System.Drawing.Point(96, 57);
            this.txtSubDesc.Multiline = true;
            this.txtSubDesc.Name = "txtSubDesc";
            this.txtSubDesc.Size = new System.Drawing.Size(257, 44);
            this.txtSubDesc.TabIndex = 25;
            // 
            // cmbSubStatus
            // 
            this.cmbSubStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSubStatus.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbSubStatus.FormattingEnabled = true;
            this.cmbSubStatus.Items.AddRange(new object[] {
            "A",
            "I"});
            this.cmbSubStatus.Location = new System.Drawing.Point(473, 58);
            this.cmbSubStatus.Name = "cmbSubStatus";
            this.cmbSubStatus.Size = new System.Drawing.Size(114, 22);
            this.cmbSubStatus.TabIndex = 24;
            // 
            // cmbSubmenuType
            // 
            this.cmbSubmenuType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSubmenuType.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbSubmenuType.FormattingEnabled = true;
            this.cmbSubmenuType.Items.AddRange(new object[] {
            "F",
            "R",
            "T"});
            this.cmbSubmenuType.Location = new System.Drawing.Point(473, 34);
            this.cmbSubmenuType.Name = "cmbSubmenuType";
            this.cmbSubmenuType.Size = new System.Drawing.Size(114, 22);
            this.cmbSubmenuType.TabIndex = 16;
            // 
            // txtSubName
            // 
            this.txtSubName.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSubName.Location = new System.Drawing.Point(96, 35);
            this.txtSubName.Name = "txtSubName";
            this.txtSubName.Size = new System.Drawing.Size(257, 20);
            this.txtSubName.TabIndex = 15;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label20.Location = new System.Drawing.Point(35, 69);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(61, 14);
            this.label20.TabIndex = 14;
            this.label20.Text = "Description";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label19.Location = new System.Drawing.Point(433, 61);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(38, 14);
            this.label19.TabIndex = 13;
            this.label19.Text = "Status";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label11.Location = new System.Drawing.Point(390, 37);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(82, 14);
            this.label11.TabIndex = 5;
            this.label11.Text = "Sub Menu Type";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label10.Location = new System.Drawing.Point(62, 38);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(34, 14);
            this.label10.TabIndex = 4;
            this.label10.Text = "Name";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label7.Location = new System.Drawing.Point(411, 85);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(61, 14);
            this.label7.TabIndex = 1;
            this.label7.Text = "Form Name";
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colName,
            this.colType,
            this.colStatus,
            this.colDescription,
            this.colFormName,
            this.colSerialNo,
            this.colParentNo,
            this.colLevel,
            this.colSubMenuNo,
            this.colParentName});
            this.listView1.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listView1.FullRowSelect = true;
            this.listView1.GridLines = true;
            this.listView1.Location = new System.Drawing.Point(6, 138);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(671, 158);
            this.listView1.TabIndex = 0;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            this.listView1.SelectedIndexChanged += new System.EventHandler(this.listView1_SelectedIndexChanged);
            // 
            // colName
            // 
            this.colName.Text = "Name";
            this.colName.Width = 213;
            // 
            // colType
            // 
            this.colType.Text = "Type";
            this.colType.Width = 50;
            // 
            // colStatus
            // 
            this.colStatus.Text = "Status";
            this.colStatus.Width = 50;
            // 
            // colDescription
            // 
            this.colDescription.Text = "Description";
            this.colDescription.Width = 189;
            // 
            // colFormName
            // 
            this.colFormName.Text = "Form Name";
            this.colFormName.Width = 136;
            // 
            // colSerialNo
            // 
            this.colSerialNo.DisplayIndex = 6;
            this.colSerialNo.Text = "Serial No.";
            // 
            // colParentNo
            // 
            this.colParentNo.DisplayIndex = 5;
            this.colParentNo.Text = "Parent No";
            this.colParentNo.Width = 100;
            // 
            // colLevel
            // 
            this.colLevel.Text = "Level";
            this.colLevel.Width = 100;
            // 
            // colSubMenuNo
            // 
            this.colSubMenuNo.Text = "SubMenu No.";
            this.colSubMenuNo.Width = 100;
            // 
            // colParentName
            // 
            this.colParentName.Text = "Parent Name";
            this.colParentName.Width = 100;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.checkBox1);
            this.groupBox1.Controls.Add(this.btnDelete);
            this.groupBox1.Controls.Add(this.btnEdit);
            this.groupBox1.Controls.Add(this.btnAddNew);
            this.groupBox1.Controls.Add(this.cmbMenuStat);
            this.groupBox1.Controls.Add(this.txtMenuSerial);
            this.groupBox1.Controls.Add(this.txtMenuDesc);
            this.groupBox1.Controls.Add(this.txtMenuName);
            this.groupBox1.Controls.Add(this.txtMenuId);
            this.groupBox1.Controls.Add(this.txtMenuNo);
            this.groupBox1.Controls.Add(this.treeMenu);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.SystemColors.Desktop;
            this.groupBox1.Location = new System.Drawing.Point(36, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(691, 203);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Menu Information";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter_1);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Enabled = false;
            this.checkBox1.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBox1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.checkBox1.Location = new System.Drawing.Point(603, 179);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(178, 18);
            this.checkBox1.TabIndex = 16;
            this.checkBox1.Text = "Check Here To Change Menu ID";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.Visible = false;
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnDelete.Enabled = false;
            this.btnDelete.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.Location = new System.Drawing.Point(603, 120);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(65, 21);
            this.btnDelete.TabIndex = 15;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnEdit.Enabled = false;
            this.btnEdit.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEdit.Location = new System.Drawing.Point(603, 99);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(65, 21);
            this.btnEdit.TabIndex = 14;
            this.btnEdit.Text = "Edit";
            this.btnEdit.UseVisualStyleBackColor = false;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnAddNew
            // 
            this.btnAddNew.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnAddNew.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddNew.Location = new System.Drawing.Point(603, 78);
            this.btnAddNew.Name = "btnAddNew";
            this.btnAddNew.Size = new System.Drawing.Size(65, 21);
            this.btnAddNew.TabIndex = 13;
            this.btnAddNew.Text = "Add New";
            this.btnAddNew.UseVisualStyleBackColor = false;
            this.btnAddNew.Click += new System.EventHandler(this.btnAddNew_Click);
            // 
            // cmbMenuStat
            // 
            this.cmbMenuStat.Enabled = false;
            this.cmbMenuStat.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbMenuStat.FormattingEnabled = true;
            this.cmbMenuStat.Items.AddRange(new object[] {
            "A",
            "I"});
            this.cmbMenuStat.Location = new System.Drawing.Point(347, 175);
            this.cmbMenuStat.Name = "cmbMenuStat";
            this.cmbMenuStat.Size = new System.Drawing.Size(240, 22);
            this.cmbMenuStat.TabIndex = 12;
            // 
            // txtMenuSerial
            // 
            this.txtMenuSerial.Enabled = false;
            this.txtMenuSerial.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMenuSerial.Location = new System.Drawing.Point(347, 152);
            this.txtMenuSerial.Name = "txtMenuSerial";
            this.txtMenuSerial.Size = new System.Drawing.Size(240, 20);
            this.txtMenuSerial.TabIndex = 11;
            // 
            // txtMenuDesc
            // 
            this.txtMenuDesc.Enabled = false;
            this.txtMenuDesc.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMenuDesc.Location = new System.Drawing.Point(347, 87);
            this.txtMenuDesc.Multiline = true;
            this.txtMenuDesc.Name = "txtMenuDesc";
            this.txtMenuDesc.Size = new System.Drawing.Size(240, 61);
            this.txtMenuDesc.TabIndex = 10;
            // 
            // txtMenuName
            // 
            this.txtMenuName.Enabled = false;
            this.txtMenuName.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMenuName.Location = new System.Drawing.Point(347, 64);
            this.txtMenuName.Name = "txtMenuName";
            this.txtMenuName.Size = new System.Drawing.Size(240, 20);
            this.txtMenuName.TabIndex = 9;
            // 
            // txtMenuId
            // 
            this.txtMenuId.Enabled = false;
            this.txtMenuId.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMenuId.Location = new System.Drawing.Point(347, 42);
            this.txtMenuId.Name = "txtMenuId";
            this.txtMenuId.Size = new System.Drawing.Size(240, 20);
            this.txtMenuId.TabIndex = 8;
            // 
            // txtMenuNo
            // 
            this.txtMenuNo.Enabled = false;
            this.txtMenuNo.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMenuNo.Location = new System.Drawing.Point(347, 20);
            this.txtMenuNo.Name = "txtMenuNo";
            this.txtMenuNo.Size = new System.Drawing.Size(240, 20);
            this.txtMenuNo.TabIndex = 7;
            // 
            // treeMenu
            // 
            this.treeMenu.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.treeMenu.Location = new System.Drawing.Point(6, 20);
            this.treeMenu.Name = "treeMenu";
            this.treeMenu.Size = new System.Drawing.Size(231, 177);
            this.treeMenu.TabIndex = 6;
            this.treeMenu.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeMenu_AfterSelect);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label6.Location = new System.Drawing.Point(310, 178);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(38, 14);
            this.label6.TabIndex = 5;
            this.label6.Text = "Status";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label5.Location = new System.Drawing.Point(295, 154);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 14);
            this.label5.TabIndex = 4;
            this.label5.Text = "Serial No.";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label4.Location = new System.Drawing.Point(285, 67);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 14);
            this.label4.TabIndex = 3;
            this.label4.Text = "Menu Name";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label3.Location = new System.Drawing.Point(287, 113);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 14);
            this.label3.TabIndex = 2;
            this.label3.Text = "Description";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label2.Location = new System.Drawing.Point(303, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 14);
            this.label2.TabIndex = 1;
            this.label2.Text = "Menu ID";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label1.Location = new System.Drawing.Point(296, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 14);
            this.label1.TabIndex = 0;
            this.label1.Text = "Menu No.";
            // 
            // menuEntry
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(762, 587);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "menuEntry";
            this.Text = "menuEntry";
            this.Load += new System.EventHandler(this.menuEntry_Load);
            this.groupBox3.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnSubDelete;
        private System.Windows.Forms.Button btnSubEdit;
        private System.Windows.Forms.Button btnSubAddNew;
        private System.Windows.Forms.TextBox txtFormName;
        private System.Windows.Forms.TextBox txtSubDesc;
        private System.Windows.Forms.ComboBox cmbSubStatus;
        private System.Windows.Forms.ComboBox cmbSubmenuType;
        private System.Windows.Forms.TextBox txtSubName;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader colName;
        private System.Windows.Forms.ColumnHeader colType;
        private System.Windows.Forms.ColumnHeader colStatus;
        private System.Windows.Forms.ColumnHeader colDescription;
        private System.Windows.Forms.ColumnHeader colFormName;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnAddNew;
        private System.Windows.Forms.ComboBox cmbMenuStat;
        private System.Windows.Forms.TextBox txtMenuSerial;
        private System.Windows.Forms.TextBox txtMenuDesc;
        private System.Windows.Forms.TextBox txtMenuName;
        private System.Windows.Forms.TextBox txtMenuId;
        private System.Windows.Forms.TextBox txtMenuNo;
        private System.Windows.Forms.TreeView treeMenu;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtSubMenuSerial;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cmbParentSubMenu;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ColumnHeader colParentNo;
        private System.Windows.Forms.ColumnHeader colSerialNo;
        private System.Windows.Forms.ColumnHeader colLevel;
        private System.Windows.Forms.ColumnHeader colSubMenuNo;
        private System.Windows.Forms.ColumnHeader colParentName;
        private System.Windows.Forms.ComboBox cmbParentSubMenuNo;
    }
}