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
        public NSAMenuItem() { }
        //Clone constructor
        public NSAMenuItem(NSAMenuItem a) {
            id = a.id;
            name = a.name;
            price = a.price;
            menuType = a.menuType;
            components = a.components;
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

            reader.Close();
            foreach (NSAComponent comp in allComponents) {
                if (compIDs.Contains(comp.ComponentID)) {
                    components.Add(comp);
                    if (comp.Category == "Bread") {
                        breadIndex = components.Count - 1;
                    }
                }
            }
            
            
        }
        int breadIndex; //Index of Bread in the sandwich. If -1, then salad

        public int BreadIndex
        {
            get { return breadIndex; }
            set { breadIndex = value; }
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
            
        }
    }
}
