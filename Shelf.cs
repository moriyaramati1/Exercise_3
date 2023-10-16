using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
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
        public void AddToShelf(Item item)
        {
            items.Add(item);
        }
        public void RemoveFromShelf(int itemId)
        {
            var itemToRemove = items.Single(item => item.itemId == itemId);
            items.Remove(itemToRemove);
        }
        public List<Item> GetItems(string kashruth,string type)
        {
            var matchItems = items.FindAll(item => item.itemKashruth == kashruth && item.itemType == type);
            Console.WriteLine(matchItems);
            return matchItems;
        }
        public override string ToString()
        {
            string PropertiesDesctiption = "Shelf properties: \n" +
                " Id: {0} \n " +
                "Shelf Number: {1} \n " +
                "Shelf Space: {2} \n " +
                "Items:\n \n{3} ";
            string ItemDescriptionn = "";
            foreach (Item item in items) {
                ItemDescriptionn += item.ToString() + "\n \n";
            }
            string PropertiesString = string.Format(PropertiesDesctiption, shelfId, shelfNumber, shelfSpace, ItemDescriptionn) ;

            return PropertiesString;
        }
    }

    
}
