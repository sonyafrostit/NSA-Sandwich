using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerInterface
{
    class NSASpecial : NSAMenuItem
    {
        DateTime beginDate;
        DateTime endDate;
        short daymask;
        public Boolean isActive() {
            return (DateTime.Compare(DateTime.Now, beginDate) > 0 && DateTime.Compare(DateTime.Now, endDate) < 0)
                && daymask == (2 ^ ((int)DateTime.Now.DayOfWeek));
        
        }
    }
}
