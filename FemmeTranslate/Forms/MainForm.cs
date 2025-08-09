using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using FemmeTranslate.Services.Abstractions;
using FemmeTranslate.ViewModels;
using FemmeTranslate.Utilities;

namespace FemmeTranslate.Forms
{
    public partial class MainForm : Form
    {
        private readonly MainViewModel _vm;
        private readonly ILanguageService _langs;
        private CancellationTokenSource? _cts;

        public MainForm(MainViewModel vm, ILanguageService langs)
        {
            _vm = vm;
            _langs = langs;
            InitializeComponent();
            Style();
            Bind();
        }

        private void Bind()
        {
            cmbSource.DataSource = _langs.GetSupported();
            cmbSource.DisplayMember = "Display";
            cmbSource.ValueMember = "Code";
            cmbTarget.DataSource = _langs.GetSupported();
            cmbTarget.DisplayMember = "Display";
            cmbTarget.ValueMember = "Code";
            cmbSource.DataBindings.Add("SelectedValue", _vm, nameof(_vm.SourceLang), false, DataSourceUpdateMode.OnPropertyChanged);
            cmbTarget.DataBindings.Add("SelectedValue", _vm, nameof(_vm.TargetLang), false, DataSourceUpdateMode.OnPropertyChanged);
            txtSource.DataBindings.Add("Text", _vm, nameof(_vm.SourceText), false, DataSourceUpdateMode.OnPropertyChanged);
            txtResult.DataBindings.Add("Text", _vm, nameof(_vm.TargetText));
            lstHistory.DataSource = _vm.History;
            lstHistory.DisplayMember = nameof(Models.TranslationResult.SourceText);
        }

        private void Style()
        {
            this.BackColor = System.Drawing.ColorTranslator.FromHtml("#FFFDD0");
            foreach (var btn in new[] { btnTranslate, btnSwap, btnClear, btnCopy, btnSpeak })
            {
                btn.BackColor = System.Drawing.ColorTranslator.FromHtml("#FADADD");
                btn.FlatStyle = FlatStyle.Flat;
                btn.FlatAppearance.BorderSize = 0;
            }
            this.Font = new System.Drawing.Font("Segoe UI", 10);
        }

        private async void btnTranslate_Click(object sender, EventArgs e)
        {
            _cts?.Cancel();
            _cts = new CancellationTokenSource();
            btnTranslate.Enabled = false;
            await _vm.TranslateAsync(_cts.Token);
            btnTranslate.Enabled = true;
        }

        private void btnSwap_Click(object sender, EventArgs e) => _vm.SwapLanguages();
        private void btnClear_Click(object sender, EventArgs e) => _vm.Clear();
        private void btnCopy_Click(object sender, EventArgs e) => _vm.CopyResult();
        private async void btnSpeak_Click(object sender, EventArgs e)
        {
            _cts?.Cancel();
            _cts = new CancellationTokenSource();
            await _vm.SpeakResultAsync(_cts.Token);
        }

        private void lstHistory_DoubleClick(object sender, EventArgs e)
        {
            if (lstHistory.SelectedItem is Models.TranslationResult res)
            {
                _vm.SourceText = res.SourceText;
                _vm.TargetText = res.TranslatedText;
                _vm.SourceLang = res.SourceLang;
                _vm.TargetLang = res.TargetLang;
            }
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            _cts?.Cancel();
            base.OnFormClosing(e);
        }
    }
}
