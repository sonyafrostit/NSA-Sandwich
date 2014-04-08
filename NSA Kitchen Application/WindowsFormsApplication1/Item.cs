using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1
{
    class Item
    {
        //each item has a list of possible modifers to it
        //Add ketchup would be one modifer
        //Remove mustard would be another... etc.
        private List<Mod> list_of_mods = new List<Mod>();
        private int itemid;
        private string itemName;
        private Item()
        {
            itemName = "ENTREE";
        }
        public Item(string itemName)
        {
            this.itemName = itemName;
        }
        public Item(int itemid)
        {
            this.itemid = itemid;
        }
        public Item(int itemid, string itemName)
        {
            this.itemid = itemid;
            this.itemName = itemName;
        }
        public Item(string itemName, Mod newmod)
        {
            this.itemName = itemName;
            this.list_of_mods.Add(newmod);
        }
        public Item(string itemName, List<Mod> list_of_mods)
        {
            this.itemName = itemName;
            this.list_of_mods = list_of_mods;
        }
        public void add(List<Mod> list_of_mods)
        {
            this.list_of_mods = list_of_mods;
        }
        public void add(Mod newmod)
        {
            this.list_of_mods.Add(newmod);

        }
        public int numMods()
        {
            return list_of_mods.Count();

        }
        public string getName()
        {
            return this.itemName;
        }
        public int getId()
        {
            return this.itemid;
        }
        public void setName(string itemName)
        {
            this.itemName = itemName;
        }
        public Mod itemAt(int i)
        {
            return list_of_mods[i];

        }
        public List<Mod> getMods()
        {
            return this.list_of_mods;
        }


    }
}
