namespace Envision.NET.Forms.Dialog
{
    partial class frmAllergy2
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAllergy2));
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.gridAllergyControl = new DevExpress.XtraGrid.GridControl();
            this.gridAllergyView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn43 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcSideEffect = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn44 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridAllergyControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridAllergyView)).BeginInit();
            this.SuspendLayout();
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.gridAllergyControl);
            this.panelControl1.Controls.Add(this.labelControl1);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(482, 170);
            this.panelControl1.TabIndex = 0;
            // 
            // gridAllergyControl
            // 
            this.gridAllergyControl.Location = new System.Drawing.Point(9, 39);
            this.gridAllergyControl.MainView = this.gridAllergyView;
            this.gridAllergyControl.Margin = new System.Windows.Forms.Padding(0);
            this.gridAllergyControl.Name = "gridAllergyControl";
            this.gridAllergyControl.Size = new System.Drawing.Size(464, 122);
            this.gridAllergyControl.TabIndex = 17;
            this.gridAllergyControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridAllergyView});
            // 
            // gridAllergyView
            // 
            this.gridAllergyView.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.gridAllergyView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn43,
            this.gcSideEffect,
            this.gridColumn44});
            this.gridAllergyView.GridControl = this.gridAllergyControl;
            this.gridAllergyView.Name = "gridAllergyView";
            this.gridAllergyView.OptionsBehavior.AllowPartialRedrawOnScrolling = false;
            this.gridAllergyView.OptionsBehavior.Editable = false;
            this.gridAllergyView.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridAllergyView.OptionsView.ShowGroupPanel = false;
            this.gridAllergyView.OptionsView.ShowIndicator = false;
            // 
            // gridColumn43
            // 
            this.gridColumn43.Caption = "Drug Name";
            this.gridColumn43.FieldName = "drugname";
            this.gridColumn43.MinWidth = 30;
            this.gridColumn43.Name = "gridColumn43";
            this.gridColumn43.Visible = true;
            this.gridColumn43.VisibleIndex = 0;
            this.gridColumn43.Width = 78;
            // 
            // gcSideEffect
            // 
            this.gcSideEffect.Caption = "Side Effect";
            this.gcSideEffect.FieldName = "side_effect";
            this.gcSideEffect.Name = "gcSideEffect";
            this.gcSideEffect.Visible = true;
            this.gcSideEffect.VisibleIndex = 1;
            this.gcSideEffect.Width = 102;
            // 
            // gridColumn44
            // 
            this.gridColumn44.Caption = "Naranjo";
            this.gridColumn44.FieldName = "naranjo";
            this.gridColumn44.MinWidth = 10;
            this.gridColumn44.Name = "gridColumn44";
            this.gridColumn44.Width = 56;
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl1.Appearance.ForeColor = System.Drawing.Color.Red;
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Appearance.Options.UseForeColor = true;
            this.labelControl1.Location = new System.Drawing.Point(163, 12);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(125, 14);
            this.labelControl1.TabIndex = 2;
            this.labelControl1.Text = "ผู้ป่วยมีประวัติการแพ้ยา";
            // 
            // frmAllergy2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(482, 170);
            this.Controls.Add(this.panelControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmAllergy2";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "ประวัติการแพ้ยา";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.frmAllergy2_Load);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridAllergyControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridAllergyView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraGrid.GridControl gridAllergyControl;
        private DevExpress.XtraGrid.Views.Grid.GridView gridAllergyView;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn43;
        private DevExpress.XtraGrid.Columns.GridColumn gcSideEffect;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn44;
    }
}