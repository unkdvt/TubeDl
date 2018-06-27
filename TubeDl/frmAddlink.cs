using System;
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
            var new_ = new frmDownloadDialog(exTextBox1.Text.Trim());
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
