using System;
using System.Windows.Forms;

namespace FemmeTranslate.Utilities
{
    public static class UiExtensions
    {
        public static void SafeInvoke(this Control control, Action action)
        {
            if (control.InvokeRequired)
                control.Invoke(action);
            else
                action();
        }
    }
}
