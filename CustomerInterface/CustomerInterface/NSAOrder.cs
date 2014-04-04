using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerInterface
{
    class NSAOrder
    {
        List<NSAMenuItem> items = new List<NSAMenuItem>();

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
    }
}
