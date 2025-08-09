using System;
using System.Windows.Forms;
using FemmeTranslate.Services.Abstractions;

namespace FemmeTranslate.Forms
{
    public partial class SettingsForm : Form
    {
        private readonly ILanguageService _langs;
        public string DefaultLanguage { get; private set; } = "es";
        public bool DarkTheme { get; private set; }

        public SettingsForm(ILanguageService langs)
        {
            _langs = langs;
            InitializeComponent();
            cmbDefault.DataSource = _langs.GetSupported();
            cmbDefault.DisplayMember = "Display";
            cmbDefault.ValueMember = "Code";
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            DarkTheme = chkDark.Checked;
            if (cmbDefault.SelectedValue is string code)
                DefaultLanguage = code;
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
