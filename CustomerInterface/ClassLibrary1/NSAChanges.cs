using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NSAData
{
    public class NSAChanges
    {
        NSAMenuItem finishedItem;

        public NSAMenuItem FinishedItem
        {
            get { return finishedItem; }
            set { finishedItem = value; }
        }
        

        int originalItem;

        public int OriginalItem
        {
            get { return originalItem; }
            set { originalItem = value; }
        }
    }
}
