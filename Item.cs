using System;

namespace exc3
{
    internal class Item
    {
        private static int ID = 0;
        public int itemId { get; private set; }
        public string itemName { get; private set; }
        public int onShelfNumber { get; private set; }
        public string itemType { get; private set; }
        public string itemKashruth { get; private set; }
        public DateTime itemExpirationDate{ get; private set; }
        public double itemSpace { get; private set; }

        public Item(string name, int shelfNumber, string type, string kashruth, DateTime expirationDate, double area)
        {
            this.itemId = ID;
            ID++;
            this.itemName = name;
            this.onShelfNumber = shelfNumber;
            this.itemType = type;
            this.itemKashruth = kashruth;
            this.itemExpirationDate = expirationDate;
            this.itemSpace = area;
        }
        
        public override string ToString()
        {
            string PropertiesDesctiption = "Item properties: \n" +
                " Id: {0} \n " +
                "Item Name: {1} \n " +
                "On Shelf Number: {2} \n " +
                "Item Type: {3} \n "+
                "Kshruth: {4} \n " +
                "Expiration Date: {5} \n " +
                "Area: {6}";
            string PropertiesString = string.Format(PropertiesDesctiption, itemId, itemName, onShelfNumber, itemType, itemKashruth, itemExpirationDate, itemSpace);
      
            return PropertiesString;
        }

      

    }
    
}
