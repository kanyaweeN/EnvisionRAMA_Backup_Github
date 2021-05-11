namespace Envision.NET.Forms.Dialog
{
    partial class LookupAlertComment
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
            this.components = new System.ComponentModel.Container();
            this.grdAccession = new DevExpress.XtraGrid.GridControl();
            this.viewAccession = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.tmComment = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.grdAccession)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.viewAccession)).BeginInit();
            this.SuspendLayout();
            // 
            // grdAccession
            // 
            this.grdAccession.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdAccession.Location = new System.Drawing.Point(0, 0);
            this.grdAccession.MainView = this.viewAccession;
            this.grdAccession.Name = "grdAccession";
            this.grdAccession.Size = new System.Drawing.Size(375, 502);
            this.grdAccession.TabIndex = 9;
            this.grdAccession.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.viewAccession});
            this.grdAccession.DoubleClick += new System.EventHandler(this.grdAccession_DoubleClick);
            // 
            // viewAccession
            // 
            this.viewAccession.Appearance.GroupRow.Options.UseTextOptions = true;
            this.viewAccession.Appearance.GroupRow.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.viewAccession.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.viewAccession.GridControl = this.grdAccession;
            this.viewAccession.GroupFormat = "{1} {2}";
            this.viewAccession.Name = "viewAccession";
            this.viewAccession.OptionsCustomization.AllowFilter = false;
            this.viewAccession.OptionsLayout.Columns.AddNewColumns = false;
            this.viewAccession.OptionsLayout.Columns.RemoveOldColumns = false;
            this.viewAccession.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.viewAccession.OptionsView.RowAutoHeight = true;
            this.viewAccession.OptionsView.ShowAutoFilterRow = true;
            this.viewAccession.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.viewAccession.OptionsView.ShowGroupExpandCollapseButtons = false;
            this.viewAccession.OptionsView.ShowGroupPanel = false;
            this.viewAccession.OptionsView.ShowHorzLines = false;
            this.viewAccession.OptionsView.ShowIndicator = false;
            this.viewAccession.OptionsView.ShowPreviewLines = false;
            this.viewAccession.OptionsView.ShowVertLines = false;
            this.viewAccession.PaintStyleName = "Skin";
            this.viewAccession.CustomDrawGroupRow += new DevExpress.XtraGrid.Views.Base.RowObjectCustomDrawEventHandler(this.viewAccession_CustomDrawGroupRow);
            this.viewAccession.GroupLevelStyle += new DevExpress.XtraGrid.Views.Grid.GroupLevelStyleEventHandler(this.viewAccession_GroupLevelStyle);
            this.viewAccession.GroupRowCollapsing += new DevExpress.XtraGrid.Views.Base.RowAllowEventHandler(this.viewAccession_GroupRowCollapsing);
            this.viewAccession.EndGrouping += new System.EventHandler(this.viewAccession_EndGrouping);
            // 
            // tmComment
            // 
            this.tmComment.Interval = 5000;
            this.tmComment.Tick += new System.EventHandler(this.tmComment_Tick);
            // 
            // LookupAlertComment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(375, 502);
            this.Controls.Add(this.grdAccession);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "LookupAlertComment";
            this.Text = "New Comments";
            this.Load += new System.EventHandler(this.LookupAlertComment_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdAccession)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.viewAccession)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl grdAccession;
        private DevExpress.XtraGrid.Views.Grid.GridView viewAccession;
        private System.Windows.Forms.Timer tmComment;


    }
}