using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Unkdevt
{
    /// <summary>
    /// copyright © Unknown Developers 
    /// http://www.github.com/unkdevt 
    /// Author @ Manoj Lakmal
    /// http://www.github.com/l4km47 
    /// Email @ manojlakmal999@gmail.com
    /// </summary>
    public static class AutoClosingMsgBox
    {
        [DllImport("user32.dll", EntryPoint = "FindWindow", SetLastError = true)]
        static extern IntPtr FindWindowByCaption(IntPtr ZeroOnly, string lpWindowName);

        [DllImport("user32.Dll")]
        static extern int PostMessage(IntPtr hWnd, UInt32 msg, int wParam, int lParam);

        private const UInt32 WM_CLOSE = 0x0010;

        /// <summary>
        /// Show Message box 
        /// </summary>
        /// <param name="message">message body</param>
        /// <param name="caption">Messagebox caption</param>
        /// <param name="MessageBoxButtons">Set messagebox buttons</param>
        /// <param name="MessageBoxIcon">Set messagebx icon</param>
        /// <param name="DefultButton">Set messagebox defult button</param>
        /// <param name="duration">time out in milisecond</param>
        /// <returns>DialogResult</returns>
        public static DialogResult Show(string message, string caption,
            MessageBoxButtons MessageBoxButtons, MessageBoxIcon MessageBoxIcon, MessageBoxDefaultButton DefultButton,int duration=500)
        {
            var timer = new System.Timers.Timer(duration) { AutoReset = false };
            timer.Elapsed += delegate
            {
                IntPtr hWnd = FindWindowByCaption(IntPtr.Zero, caption);
                if (hWnd.ToInt32() != 0) PostMessage(hWnd, WM_CLOSE, 0, 0);
            };
            timer.Enabled = true;
            return MessageBox.Show(message, caption, MessageBoxButtons, MessageBoxIcon, DefultButton);
        }
    }
}
