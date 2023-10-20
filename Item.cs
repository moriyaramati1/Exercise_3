using System;

namespace exc3
{
    internal class Item
    {
        private static int ID = 1;
        public int id { get; private set; }
        public string name { get; private set; }
        public int onShelfNumber { get; set; }
        public string type { get; private set; }
        public string kashruth { get; private set; }
        public DateTime expirationDate { get; private set; }
        public double space { get; private set; }

        public Item(string name, string type, string kashruth, DateTime expirationDate, double area, int shelfNumber = -1)
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
                " Id: {0} \t " +
                "Item Name: {1} \t " +
                "On Shelf Number: {2} \t " +
                "Item Type: {3} \n " +
                "Kshruth: {4} \t " +
                "Expiration Date: {5} \t " +
                "Area: {6}";
            string PropertiesString = string.Format(PropertiesDesctiption, id, name, onShelfNumber, type, kashruth, expirationDate, space);

            return PropertiesString;
        }



    }

}
