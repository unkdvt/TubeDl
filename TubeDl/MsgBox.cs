using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TubeDl
{
    public partial class MsgBox : Form
    {
        DialogResult d;
        DialogResult dd;
        public MsgBox(string text, string caption, string b1, string b2,DialogResult d1,DialogResult d2)
        {
            InitializeComponent();
            label1.Text = text;
            Text = caption;
            button1.Text = b1;
            button2.Text = b2;
            d = d1;
            dd = d2;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult = d;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult = dd;
        }

        private void MsgBox_Load(object sender, EventArgs e)
        {
            button2.Left = button1.Left + button1.Width + 5;
        }
    }
}
