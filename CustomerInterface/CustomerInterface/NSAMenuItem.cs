using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerInterface
{
    public class NSAMenuItem
    {
        int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        String name;

        public String Name
        {
            get { return name; }
            set { name = value; }
        }
        double price;

        public double Price
        {
            get { return price; }
            set { price = value; }
        }
        String menuType;

        public String MenuType
        {
            get { return menuType; }
            set { menuType = value; }
        }
        NSAComponent[] components;

        internal NSAComponent[] Components
        {
            get { return components; }
            set { components = value; }
        }
        NSAComponent[] removed_components;

        internal NSAComponent[] Removed_components
        {
            get { return removed_components; }
            set { removed_components = value; }
        }

        string image;

        public string Image
        {
            get { return image; }
            set { image = value; }
        }
        public bool Equals(NSAMenuItem p)
        {
            // If parameter is null return false:
            if ((object)p == null)
            {
                return false;
            }

            // Return true if the Ids match:
            return (Id == p.Id);
        }
        int categoryID;

        public int CategoryID
        {
            get { return categoryID; }
            set { categoryID = value; }
        }

        
    }
}
