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
        

    }
}
