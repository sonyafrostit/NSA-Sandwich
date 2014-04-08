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

        public string getOrdersNeeded()
        {
            int ordersNeeded = (5 - Convert.ToInt32(rewardsCount));

            switch (ordersNeeded)
            {
                case 0:
                    return "You have earned a free sandwich!";
                case 1:
                    return "1 orders needed";
                case 2:
                    return "2 orders needed";
                case 3:
                    return "3 orders needed";
                case 4:
                    return "4 orders needed";
                case 5:
                    return "5 orders needed";
                default:
                    return "You have earned a free sandwich!";
            }
        }
    }
}
