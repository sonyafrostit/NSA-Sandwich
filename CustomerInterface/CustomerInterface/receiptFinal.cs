using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CustomerInterface
{
    public partial class receiptFinal : Form
    {
        private string receipt;

        public receiptFinal(string receipt)
        {
            InitializeComponent();
            this.receipt = receipt;
            receiptText.Text = receipt;
        }

        private void finishButton_Click(object sender, EventArgs e)
        {
            Close();
            StartForm form = new StartForm();
            form.Show();
        }
    }
}
