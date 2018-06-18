using System.ComponentModel;
using System.Drawing;
using System.Drawing.Text;
using System.Windows.Forms;

namespace YoutubeTheme.Skin
{
    public class YouTubeGroupBox : ContainerControl
    {

        #region  Declarations 

        private static readonly HelperMethods H = new HelperMethods();
        private Rectangle _r;
        private IStyle _style;

        #endregion

        #region  Properties 

        [Category("Custom"), Description("Gets or sets the image of the control.")]
        public Image Image { get; set; }

        [Category("Custom"), Description("Gets or sets the style for the control.")]
        public IStyle Style
        {
            get { return _style; }
            set
            {
                _style = value;
                Invalidate();
            }
        }


        #endregion

        #region  Constructors 

        public YouTubeGroupBox()
        {
            SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.SupportsTransparentBackColor, true);
            DoubleBuffered = true;
            Font = new Font("Segoe UI", 10);
            BackColor = Color.Transparent;
            UpdateStyles();
            Image = null;
            _style = IStyle.Blue;
        }

        #endregion

        #region  Draw Control 

        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
            Rectangle rect = new Rectangle(0, 0, Width - 1, Height - 1);
            _r = new Rectangle(Width - 30, 15, 20, 20);
            g.FillRectangle(Brushes.White, rect);
            g.FillRectangle(Style == IStyle.Blue ? Brushes.Blue : Brushes.Red, new Rectangle(0, 0, Width - 1, 50));
            g.DrawString(Text, Font, Brushes.White, new Rectangle(Image == null ? 10 : 35, 0, Width - 1, 50), H.SetPosition(StringAlignment.Near));
            if (Image != null)
            { H.DrawImageWithColor(g, new Rectangle(12, 15, 18, 18), Image, Colors.White); }
            using (Font f = new Font(Font, FontStyle.Bold))
            {
                g.DrawString("x", f, Brushes.White, _r, H.SetPosition());
            }

            g.DrawRectangle(Style == IStyle.Blue ? Pens.Blue : Pens.Red, rect);
        }

        #endregion

        #region  Events 

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            if (_r.Contains(e.Location))
            {
                Cursor = Cursors.Hand;
            }
            else
            {
                Cursor = Cursors.Default;
            }
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            if (e.Button == MouseButtons.Left && _r.Contains(e.Location))
            {
                Parent.Controls.Remove(this);
            }
        }

        #endregion

        #region  Enumerators 

        public enum IStyle
        {
            Blue,
            Red
        }

        #endregion

    }
}