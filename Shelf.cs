using System;
using System.Collections.Generic;

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
            shelfSpace -= item.itemSpace;
        }
        public Item? FindItem(int itemId)
        {
            var foundItem = items.Find(item => item.itemId == itemId);
            
            return foundItem;
        }
        public bool RemoveFromShelf(int itemId)
        {
            var itemToRemove = this.FindItem(itemId);
            if (itemToRemove != null)
            {
                shelfSpace += itemToRemove.itemSpace;
                items.Remove(itemToRemove);
                
                return true;
            }

            return false;

        }
        public double GetShelfSpace()
        {
            return this.shelfSpace;
        }
        public void CleanShelf()
        {
            this.items.RemoveAll(item => item.itemExpirationDate < DateTime.Today);

        }
        public List<Item> GetItemsToEat(string kashruth,string type)
        {
            this.CleanShelf();
            var matchItems = items.FindAll(item => item.itemKashruth == kashruth && item.itemType == type);
            
            return matchItems;
        }

        public List<Item> SortItemsByDate()
        {
            List < Item > sortedItems = this.items.OrderBy(item => item.itemExpirationDate).ToList();
            
            return sortedItems;
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
