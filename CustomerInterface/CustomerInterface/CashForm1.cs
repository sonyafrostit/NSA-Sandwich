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
    
    public partial class CashForm1 : Form
    {
        private string total_to_pay;
        private string total_received;
        private string change_to_be_given;
        StringBuilder receipt;
        string email;

        public string passValueOntoForms1
        {
            get { return total_to_pay; }
            set { total_to_pay = value; }
        }

        public string passValueOntoForms2
        {
            get { return total_to_pay; }
            set { total_received = value; }
        }

        public string passValueOntoForms3
        {
            get { return total_to_pay; }
            set { change_to_be_given = value; }
        }

        public CashForm1(StringBuilder receipt, string email)
        {
            InitializeComponent();
            this.receipt = receipt;
            this.email = email;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (emailReceiptCheck.Checked && String.IsNullOrEmpty(emailAddressText.Text))
                checkLabel.Text = "Enter email address!";

            else
            {
                email = emailAddressText.Text;

                if (emailReceiptCheck.Checked)
                    sendReceipt();

                Close();
                StartForm form = new StartForm();
                form.Show();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            due_amount.Text = total_to_pay;
            received_amount.Text = total_received;
            change_amount.Text = change_to_be_given;
        }

        private void due_amount_Click(object sender, EventArgs e)
        {
            
        }

        private void Due_Click(object sender, EventArgs e)
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
                checkLabel.Visible = !checkLabel.Visible;
            }
        }

    }

}