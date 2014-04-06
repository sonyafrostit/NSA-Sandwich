using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using MySql.Data;
namespace CustomerInterface
{
    public class NSAMenuItem
    {
        public NSAMenuItem() { 
            componentChanges = new List<string>();
        }
        //Clone constructor
        public NSAMenuItem(NSAMenuItem a) {
            id = a.id;
            name = a.name;
            price = a.price;
            menuType = a.menuType;
            components = a.components;
            componentChanges = a.componentChanges;
            image = a.image;
            categoryID = a.categoryID;
        }

        public void getComponents(NSADatabase d, NSAComponent[] allComponents) {
            MySqlDataReader reader = d.CustomQuery("SELECT component FROM menuitemcomponents WHERE menuitemid = " + id + ";");
            List<int> compIDs = new List<int>();
            if (reader != null)
            {
                while (reader.Read())
                {
                    compIDs.Add((int)reader["component"]);
                }
            }
            foreach (int i in compIDs) {
                Console.WriteLine(i);
            }
            reader.Close();
            foreach (NSAComponent comp in allComponents) {
                Console.WriteLine(comp.ComponentID);
                if (compIDs.Contains(comp.ComponentID)) {
                    components.Add(comp);
                }
            }
            
            
        }
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
        protected List<NSAComponent> components = new List<NSAComponent>();

        internal List<NSAComponent> Components
        {
            get { return components; }
            set { components = value; }
        }

        protected List<string> componentChanges = new List<string>();

        public List<string> ComponentChanges
        {
            get { return componentChanges; }
            set { componentChanges = value; }
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
            return (Id == p.Id && components == p.components);
        }
        int categoryID;

        public int CategoryID
        {
            get { return categoryID; }
            set { categoryID = value; }
        }

        public virtual void GenerateItem(NSAComponent[] components) { 
            componentChanges = new List<string>();
            
        }
    }
}
