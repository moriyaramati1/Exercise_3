using System;


namespace exc3
{
    internal class Refrigerator
    {
        private static int ID = 1;
        public int refrigeratorId { get; private set; }
        public string? model { get; private set; }
        public string? color { get; private set; }
        public int shelvesNumber { get; private set; }
        public List<Shelf> shelves { get; set; }


        public Refrigerator(double shelfSpace = 0.0, string model = "None", string color = "None", int shelvesNumber = 4)
        {
            this.refrigeratorId = ID;
            ID++;
            this.model = model;
            this.color = color;
            this.shelvesNumber = shelvesNumber;
            this.shelves = new List<Shelf>();
            this.createShelves(shelfSpace);

        }
        public void createShelves(double shelfSpace)
        {
            // Function that create shelves according to sheves number in the new refrigerator.
            Shelf shelf;
            for (int num = 1; num <= this.shelvesNumber; num++)
            {
                if (shelfSpace != 0.0)
                {
                    shelf = new Shelf(num, shelfSpace);
                }
                else
                {
                    shelf = new Shelf(num);

                }
                shelves.Add(shelf);

            }

        }
        public double GetAvailableSpace()
        {
            double AvailableSpace = 0;
            foreach (Shelf shelf in shelves)
            {
                AvailableSpace += shelf.availableSpace;
            }
            return AvailableSpace;
        }


        public bool FindAvailableShelf(Item item)
        {
            foreach (Shelf shelf in shelves)
            {
                if (shelf.availableSpace >= item.space)
                {
                    shelf.AddToShelf(item);
                    return true;
                }
            }
            return false;
        }


        public void AddToRefrigerator(Item item)
        {
            if (this.FindAvailableShelf(item))
            {
                Console.WriteLine("The item has been added successfully!");
            }
            else
            {
                throw new Exception("There is no available place in the fridge for this item.");

            }

        }
        public Item RemoveFromRefrigerator(int itemId)
        {
            foreach (Shelf shelf in shelves)
            {
                var result = shelf.RemoveFromShelf(itemId);
                if (result != null)
                {
                    return result;
                }
            }
            throw new Exception("Item is not exist!");

        }

        public List<Item> GetItemsToEat(string kashruth, string type)
        {
            this.CleanRefrigerator();
            List<Item> itemsToEat = new List<Item>();
            foreach (Shelf shelf in shelves)
            {
                var items = shelf.GetItemsToEat(kashruth, type);
                if (items != null)
                {
                    itemsToEat.AddRange(items);
                }
            }
            return itemsToEat;
        }
        public bool WhatShouldIEat(string kashruth, string type)
        {
            var matchFood = GetItemsToEat(kashruth, type);
            if (matchFood.Count != 0)
            {
                foreach (Item item in matchFood)
                {
                    Console.WriteLine(item);
                }
            }
            else
            {
                Console.WriteLine("There are no products matching your request.");
                return false;

            }
            return true;
        }
        public double GetTotalSpace(List<Item> items)
        {
            double sumSpace = items.Sum(item => item.space);

            return sumSpace;

        }

        public List<Item> DateAndTypeClean(DateTime date, string type)
        {
            List<Item> items = new List<Item>();
            foreach (Shelf shelf in shelves)
            {
                var subList = shelf.items.FindAll(item => item.expirationDate < date && item.kashruth == type);
                if (subList != null)
                {
                    items.AddRange(subList);
                }
            }
            return items;
        }
        public List<Item> CleanDairy()
        {
            var result = this.DateAndTypeClean(DateTime.Today.AddDays(+3), "Dairy");

            return result;
        }

        public List<Item> CleanMeat()
        {
            var result = this.DateAndTypeClean(DateTime.Today.AddDays(+7), "Meat");

            return result;
        }
        public List<Item> CleanPareve()
        {
            var result = this.DateAndTypeClean(DateTime.Today.AddDays(+1), "Pareve");

            return result;
        }
        public bool ItsEnough(List<Item> itemToRemove)
        {

            if (this.GetTotalSpace(itemToRemove) >= 20)
            {
                return true;
            }
            return false;
        }
        public void printAndRemove(List<Item> itemToRemove)
        {
            foreach (Item item in itemToRemove)
            {
                Console.WriteLine(item.ToString());
                RemoveFromRefrigerator(item.id);

            }
        }
        public void PrintCleanStatus(List<Item> items)
        {
            if (items.Count > 0)
            {
                Console.WriteLine("As part of cleaning, we throw those items that had not expired:");
                printAndRemove(items);
            }
            else
            {
                Console.WriteLine("Your refrigerator is already clean \n");

            }
        }
        public void CleanRefrigerator()
        {
            List<Item> itemForRemove = new List<Item>();
            foreach (Shelf shelf in shelves)
            {
                var items = shelf.CleanShelf();
                if (items != null)
                {
                    itemForRemove.AddRange(items);
                }
            }

            PrintCleanStatus(itemForRemove);
        }

        public bool CleanByType()
        {
            List<Item> itemForRemove = new List<Item>();
            itemForRemove.AddRange(this.CleanDairy());

            if (!this.ItsEnough(itemForRemove))
            {
                itemForRemove.AddRange(this.CleanMeat());

                if (!this.ItsEnough(itemForRemove))
                {
                    itemForRemove.AddRange(this.CleanPareve());


                    if (!this.ItsEnough(itemForRemove))
                    {
                        return false;
                    }
                }

            }
            Console.WriteLine("As part of cleaning, we throw those items that had not expired:");
            printAndRemove(itemForRemove);
            return true;
        }
        public string prepareForShopping()
        {
            if (this.GetAvailableSpace() < 29.0)
            {
                this.CleanRefrigerator();
                if (this.GetAvailableSpace() < 20.0)
                {
                    if (!CleanByType())
                    {
                        return "It's not the right time for doing shopping";
                    }
                }
            }
            return "\n You can go for shopping.";
        }

        public override string ToString()
        {
            string PropertiesDesctiption = "Refrigerator properties: \n" +
                " Id: {0} \n " +
                "Model: {1} \n " +
                "Color: {2} \n " +
                "Shelves Number :{3} \n" +
                "Shelves :\n \n {4} ";

            string ShelvesDescriptionn = "";
            foreach (Shelf shelf in shelves)
            {
                ShelvesDescriptionn += shelf.ToString() + "\n \n";
            }
            string PropertiesString = String.Format(PropertiesDesctiption, refrigeratorId, model, color, shelvesNumber, ShelvesDescriptionn);

            return PropertiesString;
        }


    }
}
