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
