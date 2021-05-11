namespace Miracle.UserControls
{
    partial class HISPatientPhotoForm
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
            this.hisPatientPhoto1 = new Miracle.UserControls.HISPatientPhoto();
            this.SuspendLayout();
            // 
            // hisPatientPhoto1
            // 
            this.hisPatientPhoto1.HN = null;
            this.hisPatientPhoto1.Location = new System.Drawing.Point(1, 2);
            this.hisPatientPhoto1.Name = "hisPatientPhoto1";
            this.hisPatientPhoto1.Size = new System.Drawing.Size(150, 200);
            this.hisPatientPhoto1.TabIndex = 0;
            // 
            // HISPatientPhotoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(151, 202);
            this.Controls.Add(this.hisPatientPhoto1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "HISPatientPhotoForm";
            this.Text = "HN : 4009812";
            this.TopMost = true;
            this.ResumeLayout(false);

        }

        #endregion

        private Miracle.UserControls.HISPatientPhoto hisPatientPhoto1;
    }
}