namespace FemmeTranslate.Forms
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.txtSource = new System.Windows.Forms.TextBox();
            this.txtResult = new System.Windows.Forms.TextBox();
            this.cmbSource = new System.Windows.Forms.ComboBox();
            this.cmbTarget = new System.Windows.Forms.ComboBox();
            this.btnTranslate = new System.Windows.Forms.Button();
            this.btnSwap = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnCopy = new System.Windows.Forms.Button();
            this.btnSpeak = new System.Windows.Forms.Button();
            this.lstHistory = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // txtSource
            this.txtSource.Multiline = true;
            this.txtSource.Location = new System.Drawing.Point(12, 12);
            this.txtSource.Size = new System.Drawing.Size(360, 100);
            // txtResult
            this.txtResult.Multiline = true;
            this.txtResult.Location = new System.Drawing.Point(12, 180);
            this.txtResult.Size = new System.Drawing.Size(360, 100);
            this.txtResult.ReadOnly = true;
            // cmbSource
            this.cmbSource.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSource.Location = new System.Drawing.Point(12, 120);
            this.cmbSource.Size = new System.Drawing.Size(120, 23);
            // cmbTarget
            this.cmbTarget.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTarget.Location = new System.Drawing.Point(252, 120);
            this.cmbTarget.Size = new System.Drawing.Size(120, 23);
            // btnSwap
            this.btnSwap.Location = new System.Drawing.Point(180, 120);
            this.btnSwap.Size = new System.Drawing.Size(60, 23);
            this.btnSwap.Text = "↔";
            this.btnSwap.Click += new System.EventHandler(this.btnSwap_Click);
            // btnTranslate
            this.btnTranslate.Location = new System.Drawing.Point(12, 150);
            this.btnTranslate.Size = new System.Drawing.Size(360, 23);
            this.btnTranslate.Text = "Traducir";
            this.btnTranslate.Click += new System.EventHandler(this.btnTranslate_Click);
            // btnClear
            this.btnClear.Location = new System.Drawing.Point(12, 290);
            this.btnClear.Size = new System.Drawing.Size(80, 23);
            this.btnClear.Text = "Limpiar";
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // btnCopy
            this.btnCopy.Location = new System.Drawing.Point(110, 290);
            this.btnCopy.Size = new System.Drawing.Size(80, 23);
            this.btnCopy.Text = "Copiar";
            this.btnCopy.Click += new System.EventHandler(this.btnCopy_Click);
            // btnSpeak
            this.btnSpeak.Location = new System.Drawing.Point(206, 290);
            this.btnSpeak.Size = new System.Drawing.Size(80, 23);
            this.btnSpeak.Text = "Escuchar";
            this.btnSpeak.Click += new System.EventHandler(this.btnSpeak_Click);
            // lstHistory
            this.lstHistory.Location = new System.Drawing.Point(380, 12);
            this.lstHistory.Size = new System.Drawing.Size(200, 301);
            this.lstHistory.DoubleClick += new System.EventHandler(this.lstHistory_DoubleClick);
            // MainForm
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(592, 323);
            this.Controls.Add(this.lstHistory);
            this.Controls.Add(this.btnSpeak);
            this.Controls.Add(this.btnCopy);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnTranslate);
            this.Controls.Add(this.btnSwap);
            this.Controls.Add(this.cmbTarget);
            this.Controls.Add(this.cmbSource);
            this.Controls.Add(this.txtResult);
            this.Controls.Add(this.txtSource);
            this.Name = "MainForm";
            this.Text = "FemmeTranslate";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.TextBox txtSource;
        private System.Windows.Forms.TextBox txtResult;
        private System.Windows.Forms.ComboBox cmbSource;
        private System.Windows.Forms.ComboBox cmbTarget;
        private System.Windows.Forms.Button btnTranslate;
        private System.Windows.Forms.Button btnSwap;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnCopy;
        private System.Windows.Forms.Button btnSpeak;
        private System.Windows.Forms.ListBox lstHistory;
    }
}
