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
        private string rewardsCount;

        public NSALoyaltyAccount(string n, string e, string rewards, string acc)
        {
            name = n;
            email = e;
            rewardsCount = rewards;
            accountNumber = acc;
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

        public string getRewardCount()
        {
            return rewardsCount;
        }
    }
}
