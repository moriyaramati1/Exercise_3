using System;
using System.Collections.Generic;

namespace exc3
{
    internal class Shelf
    {
        private static int ID = 1;
        public int shelfId { get; private set; }
        public int shelfNumber { get; private set; }
        public double availableSpace { get; private set; }
        public List<Item> items { get; set; }


        public Shelf(int shelfNumber, double availableSpace, List<Item> items)
        {
            this.shelfId = ID;
            ID++;
            this.shelfNumber = shelfNumber;
            this.availableSpace = availableSpace;
            this.items = items;

        }
        public Shelf(int shelfNumber, double availableSpace = 900.0)
            : this(shelfNumber, availableSpace, new List<Item>())
        {

        }


        public void AddToShelf(Item item)
        {
            item.onShelfNumber = shelfNumber;
            items.Add(item);
            availableSpace -= item.space;
        }
        public Item? FindItem(int itemId)
        {
            var foundItem = items.Find(item => item.id == itemId);

            return foundItem;
        }
        public Item? RemoveFromShelf(int itemId)
        {
            var itemToRemove = this.FindItem(itemId);
            if (itemToRemove != null)
            {
                availableSpace += itemToRemove.space;
                items.Remove(itemToRemove);
            }

            return itemToRemove;

        }

        public double GetShelfSpace()
        {
            return this.availableSpace;
        }
        public List<Item>? CleanShelf()
        {
            var expiredItems = this.items.FindAll(item => item.expirationDate < DateTime.Today);
            ; return expiredItems;

        }
        public List<Item>? GetItemsToEat(string kashruth, string type)
        {
            var matchItems = items.FindAll(item => item.kashruth == kashruth && item.type == type);

            return matchItems;
        }

        public List<Item> SortItemsByDate()
        {
            List<Item> sortedItems = this.items.OrderBy(item => item.expirationDate).ToList();

            return sortedItems;
        }

        public override string ToString()
        {
            string PropertiesDesctiption = "Shelf properties:   " +
                " Id: {0} \t  " +
                "Shelf Number: {1} \t " +
                "Shelf Space: {2} \n " +
                "Items:\n \n{3} ";
            string ItemDescriptionn = "";
            foreach (Item item in items)
            {
                ItemDescriptionn += item.ToString() + "\n \n";
            }
            string PropertiesString = string.Format(PropertiesDesctiption, shelfId, shelfNumber, availableSpace, ItemDescriptionn);

            return PropertiesString;
        }
    }


}
