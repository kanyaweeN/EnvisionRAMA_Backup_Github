namespace Envision.Plugin.DirectPrint
{
    partial class dialogPrintersList
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
            this.layoutButton = new System.Windows.Forms.TableLayoutPanel();
            this.cmbPrintersList = new DevExpress.XtraEditors.ComboBoxEdit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbPrintersList.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutButton
            // 
            this.layoutButton.AutoSize = true;
            this.layoutButton.ColumnCount = 1;
            this.layoutButton.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.layoutButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutButton.Location = new System.Drawing.Point(0, 20);
            this.layoutButton.Name = "layoutButton";
            this.layoutButton.RowCount = 1;
            this.layoutButton.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.layoutButton.Size = new System.Drawing.Size(244, 6);
            this.layoutButton.TabIndex = 2;
            // 
            // cmbPrintersList
            // 
            this.cmbPrintersList.Dock = System.Windows.Forms.DockStyle.Top;
            this.cmbPrintersList.Location = new System.Drawing.Point(0, 0);
            this.cmbPrintersList.Name = "cmbPrintersList";
            this.cmbPrintersList.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbPrintersList.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cmbPrintersList.Size = new System.Drawing.Size(244, 20);
            this.cmbPrintersList.TabIndex = 3;
            // 
            // dialogPrintersList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(244, 26);
            this.Controls.Add(this.layoutButton);
            this.Controls.Add(this.cmbPrintersList);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "dialogPrintersList";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Printers List";
            this.Load += new System.EventHandler(this.dialogPrintersList_Load);
            ((System.ComponentModel.ISupportInitialize)(this.cmbPrintersList.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel layoutButton;
        private DevExpress.XtraEditors.ComboBoxEdit cmbPrintersList;
    }
}