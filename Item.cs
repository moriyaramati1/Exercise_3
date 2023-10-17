using System;

namespace exc3
{
    internal class Item
    {
        private static int ID = 0;
        public int id { get; private set; }
        public string name { get; private set; }
        public int onShelfNumber { get; private set; }
        public string type { get; private set; }
        public string kashruth { get; private set; }
        public DateTime expirationDate{ get; private set; }
        public double space { get; private set; }

        public Item(string name, int shelfNumber, string type, string kashruth, DateTime expirationDate, double area)
        {
            this.id = ID;
            ID++;
            this.name = name;
            this.onShelfNumber = shelfNumber;
            this.type = type;
            this.kashruth = kashruth;
            this.expirationDate = expirationDate;
            this.space = area;
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
