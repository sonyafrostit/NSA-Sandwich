using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using MySql.Data;

namespace CustomerInterface
{
    public class NSAFavoriteItem : NSAMenuItem
    {
        public new void getComponents(NSADatabase d, NSAComponent[] allComponents) {
            if (components.Count > 0) {
                return;
            }
            MySqlDataReader reader = d.CustomQuery("SELECT compontentid FROM favoriteitemcomponents WHERE favoriteitemid = " + id + ";");
            List<int> favcompIDs = new List<int>();
            if (reader != null)
            {
                while (reader.Read())
                {
                    favcompIDs.Add((int)reader["component"]); 
                }
            }

            reader.Close();
            
            foreach (NSAComponent comp in allComponents) {
                if (favcompIDs.Contains(comp.ComponentID)) {
                    components.Add(comp);
                    if (comp.Category == "Bread") {
                        breadIndex = components.Count - 1;
                    }
                }
            }
            
            
        }
       
    }
}
