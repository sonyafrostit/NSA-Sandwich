using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerInterface
{
    public class NSAOrder
    {
        List<NSAMenuItem> items = new List<NSAMenuItem>();
        long id;

        public long Id
        {
            get { return id; }
            set { id = value; }
        }

        public List<NSAMenuItem> Items
        {
            get { return items; }
            set { items = value; }
        }
        public void AddItem(NSAMenuItem item) {
            items.Add(item);
        }
        public void GetFormattedString() { 
        
        }
        public Decimal Total {
            get
            {
                Decimal tot = 0;
                foreach (NSAMenuItem it in items) { tot += (Decimal)it.Price; }
                return tot;
            }
        }
        public Decimal Tax {
            get {
                return Total * (Decimal)0.84;
            }
        }
    }
}
