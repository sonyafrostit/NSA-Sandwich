using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerInterface
{
    class NSALoyaltyAccount
    {
        private string accountNumber;
        private string name;
        private string email;
        private int rewardscount;

        public NSALoyaltyAccount(string acc, string n, string e)
        {
            accountNumber = acc;
            name = n;
            email = e;
        }

        public NSALoyaltyAccount(string acc)
        {
            accountNumber = acc;
            queryForNameAndEmail();
        }

        public void queryForNameAndEmail()
        {
            NSADatabase db = new NSADatabase();
            db.OpenConnection();
            //query db with acc number
            //set name to db name
            //set email to db email
        }

        public string getAccountNumber()
        {
            return accountNumber;
        }

        public string getName()
        {
            return name;
        }

        public string getEmail()
        {
            return email;
        }
    }
}
