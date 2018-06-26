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
    public partial class frmAddlink : Form
    {
        public frmAddlink()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var new_ = new frmSelect(exTextBox1.Text.Trim());
            if (new_.ShowDialog() == DialogResult.OK)
                DialogResult = DialogResult.OK;
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
