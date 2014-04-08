using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1
{
    class Mod
    {
            //mod_type refers to how the condiment should be applied
            //0 = no "condiment"
            //1 = add "condiment"
            private int mod_type;
            //Type of "condiment" to be removed or added
            private string condiment;
            private Mod()
            {
                mod_type = -1;
                condiment = "CONDIMENT";
            }
            public Mod(int mod_type, string condiment)
            {
                this.mod_type = mod_type;
                this.condiment = condiment;

            }
            public int getType()
            {
                return this.mod_type;

            }
            public string getCondiment()
            {
                return this.condiment;
            }
    }
}
