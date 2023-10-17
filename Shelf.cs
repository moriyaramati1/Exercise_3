using System;
using System.Collections.Generic;

namespace exc3
{
    internal class Shelf
    {
        private static int ID = 0;
        public int shelfId { get; private set; }
        public int shelfNumber { get; private set; }
        public double availableSpace { get; private set; }
        public List<Item> items { get; set; }

          
        public Shelf(int shelfNumber, double availableSpace, List<Item> items)
        {
            this.shelfId = ID;
            ID++;
            this.availableSpace = availableSpace;
            this.items = items;

        }
        public void AddToShelf(Item item)
        {
            items.Add(item);
            availableSpace -= item.space;
        }
        public Item? FindItem(int itemId)
        {
            var foundItem = items.Find(item => item.id == itemId);
            
            return foundItem;
        }
        public bool RemoveFromShelf(int itemId)
        {
            var itemToRemove = this.FindItem(itemId);
            if (itemToRemove != null)
            {
                availableSpace += itemToRemove.space;
                items.Remove(itemToRemove);
                
                return true;
            }

            return false;

        }
        public double GetShelfSpace()
        {
            return this.availableSpace;
        }
        public void CleanShelf()
        {
            this.items.RemoveAll(item => item.expirationDate < DateTime.Today);

        }
        public List<Item> GetItemsToEat(string kashruth,string type)
        {
            this.CleanShelf();
            var matchItems = items.FindAll(item => item.kashruth == kashruth && item.type == type);
            
            return matchItems;
        }

        public List<Item> SortItemsByDate()
        {
            List < Item > sortedItems = this.items.OrderBy(item => item.expirationDate).ToList();
            
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
            string PropertiesString = string.Format(PropertiesDesctiption, shelfId, shelfNumber, availableSpace, ItemDescriptionn) ;

            return PropertiesString;
        }
    }

    
}
