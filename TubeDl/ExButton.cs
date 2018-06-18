using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TubeDl
{
    public partial class ExButton : PictureBox
    {
        public ExButton()
        {
            InitializeComponent();
        }
        protected override void OnCreateControl()
        {
            Cursor = System.Windows.Forms.Cursors.Hand;
            // Image = global::TubeDl.Properties.Resources.add_color;
            // Location = new System.Drawing.Point(15, 13);
            Size = new System.Drawing.Size(32, 32);
            SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            if (Enabled)
                Image = ImageEnable;
            else
            {
                Bitmap pic = new Bitmap(ImageDisable);
                for (int w = 0; w < pic.Width; w++)
                {
                    for (int h = 0; h < pic.Height; h++)
                    {
                        Color c = pic.GetPixel(w, h);
                        Color newC = Color.FromArgb(30, c);
                        pic.SetPixel(w, h, newC);
                    }
                }
                Image = pic;
            }
            base.OnCreateControl();
        }
        protected override void OnEnabledChanged(EventArgs e)
        {
            try
            {
                base.OnEnabledChanged(e);
                if (Enabled)
                    Image = ImageEnable;
                else
                {
                    Bitmap pic = new Bitmap(ImageDisable);
                    for (int w = 0; w < pic.Width; w++)
                    {
                        for (int h = 0; h < pic.Height; h++)
                        {
                            Color c = pic.GetPixel(w, h);
                            Color newC = Color.FromArgb(30, c);
                            pic.SetPixel(w, h, newC);
                        }
                    }
                    Image = pic;
                }
            }
            catch { }
        }

        private Image enabledImage;
        public Image ImageEnable
        {
            get
            {
                return enabledImage;
            }
            set
            {
                enabledImage = value;
            }
        }

        private Image disableImage;
        public Image ImageDisable
        {
            get
            {
                return disableImage;
            }
            set
            {
                disableImage = value;
            }
        }

    }
}
