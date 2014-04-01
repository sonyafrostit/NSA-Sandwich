using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerInterface
{
    class NSAComponent
    {
        int componentID;

        public int ComponentID
        {
            get { return componentID; }
            set { componentID = value; }
        }
        string name;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        float price;

        public float Price
        {
            get { return price; }
            set { price = value; }
        }
        string category;

        public string Category
        {
            get { return category; }
            set { category = value; }
        }

    }
}
