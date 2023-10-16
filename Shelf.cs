using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exc3
{
    internal class Shelf
    {
        private static int ID = 0;
        public int shelfId { get; private set; }
        public int shelfNumber { get; private set; }
        public double shelfSpace { get; private set; }
        public List<Item> items { get; set; }

          
        public Shelf(int shelfNumber, double shelfSpace, List<Item> items)
        {
            this.shelfId = ID;
            ID++;
            this.shelfSpace = shelfSpace;
            this.items = items;

        }
    }
    
}
