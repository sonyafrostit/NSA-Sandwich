using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerInterface
{
    class NSARandomItem : NSAMenuItem
    {
        public void generateItem(NSAComponent[] allcomponents) {
            foreach (NSAComponent component in allcomponents) {
                Random r = new Random();
                if (r.Next(2) > 1) {
                    Components.Add(component);
                    ComponentChanges.Add("+" + component.Name);
                }
            }
            
        }
    }
}
