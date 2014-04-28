using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerInterface
{
    class NSALoyaltyAccount
    {
        private long accountNumber;
        private string name;
        private string email;
        private string rewardsCount;
        private NSAFavoriteItem[] favoriteItems;

        public NSAFavoriteItem[] FavoriteItems
        {
            get { return favoriteItems; }
            set { favoriteItems = value; }
        }
        private NSAOrder[] favoriteOrders;

        internal NSAOrder[] FavoriteOrders
        {
            get { return favoriteOrders; }
            set { favoriteOrders = value; }
        }


        public NSALoyaltyAccount(string n, string e, string rewards, string acc)
        {
            name = n;
            email = e;
            rewardsCount = rewards;
            accountNumber = Convert.ToInt64(acc);
        }

        public long getAccountNumber()
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
                    return "No";
                case 1:
                    return "1";
                case 2:
                    return "2";
                case 3:
                    return "3";
                case 4:
                    return "4";
                case 5:
                    return "5";
                default:
                    return "No";
            }
        }
    }
}
