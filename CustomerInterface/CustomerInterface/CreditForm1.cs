using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data;
using System.Net.Mail;
using System.Net;

namespace CustomerInterface
{
    public partial class CreditForm1 : Form
    {
        long orderID;
        Decimal cost; //for show
        NSADatabase db;
        StringBuilder receipt;
        string email;

        public CreditForm1(long orderID, Decimal cost, NSADatabase db, StringBuilder receipt, string email)
        {
            InitializeComponent();
            this.orderID = orderID;
            this.cost = cost;
            this.db = db;
            this.receipt = receipt;
            this.email = email;
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (emailReceiptCheck.Checked && String.IsNullOrEmpty(emailAddressText.Text))
                checkLabel.Text = "Enter email address!";

            else
            {
                email = emailAddressText.Text;
                if (CCBox.TextLength == 16)
                {
                    if (emailReceiptCheck.Checked)
                        sendReceipt();

                    db.CustomQuery("UPDATE orders SET status = 1 WHERE orderid = " + orderID + ";").Close();
                    CreditForm2 f2 = new CreditForm2();
                    f2.passValue = CCBox.Text;
                    f2.ShowDialog();
                    Close();
                }

                else
                { 
                    checkLabel.Text = "Invalid card length!";
                }
            }

           
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void sendReceipt()
        {
            if (!String.IsNullOrEmpty(email))
            {
                MailMessage mail = new MailMessage();
                mail.To.Add(email);
                mail.Subject = "NSA Receipt";
                mail.From = new MailAddress("cse4444project@gmail.com");
                mail.Body = receipt.ToString();

                SmtpClient smtp = new SmtpClient("smtp.gmail.com");
                smtp.Port = 587;
                smtp.Credentials = new System.Net.NetworkCredential("cse4444project@gmail.com", "NSAproject1");
                smtp.EnableSsl = true;

                smtp.Send(mail);
            }
        }

        private void emailReceiptCheck_CheckedChanged(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(email))
            {
                emailAddressLabel.Visible = !emailAddressLabel.Visible;
                emailAddressText.Visible = !emailAddressText.Visible;
            }
        }
    }
}
