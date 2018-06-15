using System.Drawing;
using System.Windows.Forms;
using System.ComponentModel;
using System;

namespace TextBoxWatermark
{
    public class ExTextBox : TextBox
    {
        string hint;
        [DefaultValue("")]
        public string Hint
        {
            get { return hint; }
            set { hint = value; this.Invalidate(); }
        }

        Color hintColor = SystemColors.GrayText;
        public Color HintColor
        {
            get { return hintColor; }
            set { hintColor = value; Invalidate(); }
        }
        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);
            if (m.Msg == 0xf)
            {
                if (!this.Focused && string.IsNullOrEmpty(this.Text)
                    && !string.IsNullOrEmpty(this.Hint))
                {
                    using (var g = this.CreateGraphics())
                    {
                        TextRenderer.DrawText(g, this.Hint, this.Font,
                            this.ClientRectangle, this.HintColor, this.BackColor,
                             TextFormatFlags.Top | TextFormatFlags.Left);
                    }
                }
            }
        }
        private bool ShouldSerializeHintColor()
        {
            return HintColor != SystemColors.GrayText;
        }
        private void ResetHintColor()
        {
            HintColor = SystemColors.GrayText;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            string drawString = "Sample Text";
            Font drawFont = new Font("Arial", 8f);
            SolidBrush drawBrush = new SolidBrush(System.Drawing.Color.Red);

            StringFormat drawFormat = new StringFormat();
            e.Graphics.DrawString(drawString, drawFont, drawBrush, Location);
            drawFont.Dispose();
            drawBrush.Dispose();
         

            base.OnPaint(e);
        }
        protected override void OnCreateControl()
        {


           
            // Send EM_SETMARGINS to prevent text from disappearing underneath the button
           // SendMessage(Handle, 0xd3, (IntPtr)2, (IntPtr)(btn.Width << 16));
            base.OnCreateControl();
        }
      

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern IntPtr SendMessage(IntPtr hWnd, int msg, IntPtr wp, IntPtr lp);

        private void btn_Click(object sender, EventArgs e)
        {
            Text = "";
        }
    }

}
