using System;
using System.Collections.Generic;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;

namespace CustomerInterface

{
    public class NSAComponent
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

        string category;

        public string Category
        {
            get { return category; }
            set { category = value; }
        }
        public override bool Equals(System.Object obj)
        {
            // If parameter is null return false.
            if (obj == null)
            {
                return false;
            }

            NSAComponent compare = obj as NSAComponent;
            if ((System.Object)compare == null)
            {
                return false;
            }

            // Return true if the ids match:
            return (componentID == compare.componentID) && (componentID == compare.componentID);
        }
        public override string ToString() {
            if (rm == null)
            {
                return Name;
            }
            else {
                return rm.GetString(Name);
            }
        }
        ResourceManager rm;

        public ResourceManager Rm
        {
            get { return rm; }
            set { rm = value; }
        }

    }
}
