using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exc3
{
    internal class Refrigerator
    {
        private static int ID = 0;
        public int refrigeratorId { get; private set; }
        public string model { get; private set; }
        public string color { get; private set; }
        public int shelvesNumber { get; private set; }
        public List<Shelf> shelves { get; set; }

        public Refrigerator(string model,string color,int shelvesNumber, List<Shelf> shelves)
        {   this.refrigeratorId = ID;
            this.model = model;
            this.color = color;
            this.shelvesNumber = shelvesNumber;
            this.shelves = shelves;
        }

        public double GetRefrigeratorSpace()
        {
            double TotalSpace = 0;
            foreach(Shelf shelf in shelves)
            {
                TotalSpace += shelf.GetShelfSpace();
            }

            return TotalSpace;
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
            Console.WriteLine(ShelvesDescriptionn);
            string PropertiesString = String.Format(PropertiesDesctiption, refrigeratorId, model, color, shelvesNumber,ShelvesDescriptionn);

            return PropertiesString;
        }


    }
}
