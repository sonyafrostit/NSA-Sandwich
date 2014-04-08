using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerInterface
{
    public class NSAMenuCategory
    {
        NSAMenuItem[] items;

        public NSAMenuItem[] Items
        {
            get { return items; }
            set { items = value; }
        }
        string name;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

    }
}
