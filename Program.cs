using System;

namespace exc3
{
    internal class Program
    {
        public void PrintElements<T>(List<T> list)
        {
            foreach (var element in list)
            {
                Console.WriteLine(element + "\n");
            }
        }
        public int UserInputOptions()
        {
            // A general function that responsible for user input a number format.

            Console.WriteLine("Please enter your action choise");
            int num;
            bool parseSuccess = int.TryParse(Console.ReadLine(), out num);
            while (!parseSuccess || ((0 >= num || num > 10) && num != 100))
            {
                Console.WriteLine("ERROR - PLEASE ENTER VALID NUMBER");
                parseSuccess = int.TryParse(Console.ReadLine(), out num);
            }
            return num;
        }
        public int UserInputId()
        {
            // A general function that responsible for user input a number format.

            int num;
            bool parseSuccess = int.TryParse(Console.ReadLine(), out num);
            while (!parseSuccess || num < 0)
            {
                Console.WriteLine("ERROR - PLEASE ENTER VALID ID");
                parseSuccess = int.TryParse(Console.ReadLine(), out num);
            }
            return num;
        }
        public Refrigerator GetRefrigerator(List<Refrigerator> refrigerators)
        {
            Console.WriteLine("Enter your refrigerator ID");

            int id = UserInputId();

            var fridge = refrigerators.Find(refrigerator => refrigerator.refrigeratorId == id);
            if (fridge == null)
            {
                throw new Exception("This refrigerator is not exist!");
            }
            return fridge;
        }
        public string ValidInputName()
        {
            var name = Console.ReadLine();

            while (string.IsNullOrEmpty(name))
            {
                Console.WriteLine("Name can't be empty! Input your name once more");
                name = Console.ReadLine();
            }
            return name;
        }

        public string ValidInputType()
        {
            IDictionary<int, string> options = new Dictionary<int, string>(){
                                  {1, "Solid"},
                                  {2, "Liquid"}};

            Console.Write(" For Solid Press 1 \n For Liquid Press 2 \n");
            int num;
            bool parseSuccess = int.TryParse(Console.ReadLine(), out num);
            while (!parseSuccess || (num != 1 && num != 2))
            {
                Console.WriteLine("ERROR - PLEASE ENTER VALID NUMBER");
                parseSuccess = int.TryParse(Console.ReadLine(), out num);
            }
            return options[num];

        }
        public string ValidInputKshruth()
        {
            IDictionary<int, string> options = new Dictionary<int, string>(){
                                  {1, "Meat"},
                                  {2, "Dairy"},
                                  {3, "Pareve"}};

            Console.Write(" For Meat Press 1 \n For Dairy Press 2 \n For Pareve Press 3 \n");
            int num;
            bool parseSuccess = int.TryParse(Console.ReadLine(), out num);
            while (!parseSuccess || (num != 1 && num != 2 && num != 3))
            {
                Console.WriteLine("ERROR - PLEASE ENTER VALID NUMBER");
                parseSuccess = int.TryParse(Console.ReadLine(), out num);
            }

            return options[num];

        }
        public DateTime ValidInputDate()
        {
            Console.WriteLine("Enter a date: ");
            DateTime date;
            bool parseSuccess = DateTime.TryParse(Console.ReadLine(), out date);

            while (!parseSuccess)
            {
                Console.WriteLine("ERROR - PLEASE ENTER VALID DATE");
                parseSuccess = DateTime.TryParse(Console.ReadLine(), out date);
            }
            return date;

        }
        public double ValidInputArea()
        {
            // A general function that responsible for user input a number format.

            double num;
            bool parseSuccess = double.TryParse(Console.ReadLine(), out num);
            while (!parseSuccess || num <= 0)
            {
                Console.WriteLine("ERROR - PLEASE ENTER VALID ID");
                parseSuccess = double.TryParse(Console.ReadLine(), out num);
            }
            return num;
        }

        public Item GetItemFromUser()
        {
            Console.Write("Enter item name \n");
            string name = ValidInputName();
            Console.Write("Enter the type: Liquid / Solid \n");
            string type = ValidInputType();
            Console.Write("Enter the Kashruth: Meat / Dairy / Pareve \n");
            string kashruth = ValidInputKshruth();
            Console.Write("Enter item's expiration date \n");
            DateTime date = ValidInputDate();
            Console.Write("Enter item's area \n");
            double area = ValidInputArea();
            Item userItem = new Item(name, type, kashruth, date, area);
            return userItem;
        }

        public Refrigerator ShowManual(List<Refrigerator> refrigerators)
        {
            Console.WriteLine("\n");
            Refrigerator chosenFridge = GetRefrigerator(refrigerators);
            Console.WriteLine("\n Manual");
            Console.WriteLine("Press 1: For checking the refrigerator contents");
            Console.WriteLine("Press 2: For knowing how much available space is in the refrigerator");
            Console.WriteLine("Press 3: For putting an item in the fridge");
            Console.WriteLine("Press 4: For removing an item from the fridge.");
            Console.WriteLine("Press 5: For clecning the refrigerator");
            Console.WriteLine("Press 6: For grabbig a bite");
            Console.WriteLine("Press 7: For sorting products by expiration date");
            Console.WriteLine("Press 8: For arranging shelves according to the free space left on them");
            Console.WriteLine("Press 9: For arranging refrigerators according to the free space left on them");
            Console.WriteLine("Press 10: For preparing the refrigerator for shopping ");
            Console.WriteLine("Press 100: EXIT \n");
            return chosenFridge;
        }
        public void createItems(Refrigerator r)
        {

            List<Item> items = new List<Item>();
            Item item1 = new Item("Meat", "Solid", "Meat", DateTime.Today.AddDays(+6), 900);
            Item item2 = new Item("Milk", "Liquid", "Dairy", DateTime.Today.AddDays(+2), 900);
            Item item3 = new Item("Cheese", "Solid", "Dairy", DateTime.Today.AddDays(+2), 900);
            Item item4 = new Item("Carrot juice", "Liquid", "Pareve", DateTime.Today, 450);
            Item item5 = new Item("Apple", "Solid", "Pareve", DateTime.Today.AddDays(+1), 450);

            r.AddToRefrigerator(item1);
            r.AddToRefrigerator(item2);
            r.AddToRefrigerator(item3);
            r.AddToRefrigerator(item4);
            r.AddToRefrigerator(item5);

        }

        public List<Refrigerator> createInfrastructure()
        {
            List<Refrigerator> refrigerators = new List<Refrigerator>();

            Refrigerator r1 = new Refrigerator(900.0, "LG", "Silver", 4);
            Refrigerator r2 = new Refrigerator(0.0, "Bosch", "Black", 4);
            Refrigerator r3 = new Refrigerator(900, "Electra", "Silver", 4);

            refrigerators.Add(r1);
            refrigerators.Add(r2);
            refrigerators.Add(r3);

            createItems(r1);
            createItems(r2);
            createItems(r3);

            return refrigerators;

        }
    }
}
