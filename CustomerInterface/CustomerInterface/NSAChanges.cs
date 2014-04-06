using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerInterface
{
    public class NSAChanges
    {
        NSAMenuItem finishedItem;

        public NSAMenuItem FinishedItem
        {
            get { return finishedItem; }
            set { finishedItem = value; }
        }
        List<string> changes;

        public List<string> Changes
        {
            get { return changes; }
            set { changes = value; }
        }

        int originalItem;

        public int OriginalItem
        {
            get { return originalItem; }
            set { originalItem = value; }
        }
    }
}
