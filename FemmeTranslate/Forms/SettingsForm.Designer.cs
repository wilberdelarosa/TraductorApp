namespace FemmeTranslate.Forms
{
    partial class SettingsForm
    {
        private System.ComponentModel.IContainer components = null;
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.chkDark = new System.Windows.Forms.CheckBox();
            this.btnOk = new System.Windows.Forms.Button();
            this.cmbDefault = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // chkDark
            this.chkDark.AutoSize = true;
            this.chkDark.Location = new System.Drawing.Point(12, 12);
            this.chkDark.Text = "Tema oscuro";
            // cmbDefault
            this.cmbDefault.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDefault.Location = new System.Drawing.Point(12, 40);
            this.cmbDefault.Size = new System.Drawing.Size(160, 23);
            // btnOk
            this.btnOk.Location = new System.Drawing.Point(60, 80);
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.Text = "Guardar";
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // SettingsForm
            this.ClientSize = new System.Drawing.Size(184, 111);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.cmbDefault);
            this.Controls.Add(this.chkDark);
            this.Name = "SettingsForm";
            this.Text = "Preferencias";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.CheckBox chkDark;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.ComboBox cmbDefault;
    }
}
