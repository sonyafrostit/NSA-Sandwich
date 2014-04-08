using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerInterface
{
    class NSARandomItem : NSAMenuItem
    {
        Random rand = new Random(DateTime.Now.Millisecond);
        public override void GenerateItem (NSAComponent[] allcomponents) {
            components = new List<NSAComponent>();
            components.Add(allcomponents[0]);
            foreach (NSAComponent component in allcomponents) {
                
                int thenum = rand.Next(4);
                Console.WriteLine(thenum);
                
                if (thenum > 1 && component.Category != "Bread")
                {
                    components.Add(component);


                }
            }
            
        }
    }
}
