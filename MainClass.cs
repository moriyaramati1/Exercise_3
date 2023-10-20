


using System;

namespace exc3
{
    class MainClass
    {
        static List<Item> GetSortedByDate(Refrigerator refrigerator)
        {
            List<Item> allItems = new List<Item>();
            foreach (Shelf shelf in refrigerator.shelves)
            {
                allItems.AddRange(shelf.items);
            }

            return allItems.OrderBy(item => item.expirationDate).ToList();
        }

        static List<Shelf> SortShelfBySpace(List<Shelf> shelves)
        {
            List<Shelf> sortedShelves = shelves.OrderByDescending(shelf => shelf.availableSpace).ToList();
            return sortedShelves;

        }
        static List<Refrigerator> SortFridgeBySpace(List<Refrigerator> fridges)
        {
            List<Refrigerator> sortedFridges = fridges.OrderByDescending(fridge => fridge.GetAvailableSpace()).ToList();
            return sortedFridges;

        }



        public static int Main()
        {

            Program program = new Program();
            List<Refrigerator> refrigerators = program.createInfrastructure();
            Console.Clear();
            Refrigerator chosenFridge;

            try
            {

                chosenFridge = program.ShowManual(refrigerators);
                int option = program.UserInputOptions();

                while (option != 100)
                {

                    switch (option)
                    {

                        case 1:
                            Console.WriteLine(chosenFridge);
                            break;
                        case 2:
                            Console.WriteLine("Available Space: ");
                            Console.WriteLine(chosenFridge.GetAvailableSpace());

                            break;
                        case 3:
                            try
                            {
                                Console.WriteLine();
                                Item userItem = program.GetItemFromUser();
                                chosenFridge.AddToRefrigerator(userItem);
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine(ex.Message);

                            }
                            break;
                        case 4:
                            try
                            {
                                Console.WriteLine("Enter Item ID");
                                int Itemid = program.UserInputId();
                                Item item = chosenFridge.RemoveFromRefrigerator(Itemid);
                                Console.WriteLine(item);
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine(ex.Message);

                            }
                            break;
                        case 5:
                            chosenFridge.CleanRefrigerator();
                            break;
                        case 6:
                            Console.WriteLine("What should I eat?");
                            string kashruth = program.ValidInputKshruth();
                            string type = program.ValidInputType();
                            bool found = chosenFridge.WhatShouldIEat(kashruth, type);
                            if (found)
                            {
                                Console.WriteLine("\n What item would you like to get? \n");
                                goto case 4;
                            }

                            break;
                        case 7:
                            Console.WriteLine("\n Items sorted by expiration date \n");
                            List<Item> items = GetSortedByDate(chosenFridge);
                            program.PrintElements(items);
                            break;
                        case 8:
                            Console.WriteLine("\n Shelves sorted by available space  \n");
                            List<Shelf> shelves = SortShelfBySpace(chosenFridge.shelves);
                            program.PrintElements(shelves);

                            break;
                        case 9:
                            Console.WriteLine("\n Refrigerators sorted by available space  \n");
                            List<Refrigerator> fridges = SortFridgeBySpace(refrigerators);
                            program.PrintElements(fridges);
                            break;
                        case 10:
                            Console.WriteLine("\nLet's Prepere For Shopping  \n");
                            Console.WriteLine(chosenFridge.prepareForShopping());
                            break;

                        default:
                            Console.WriteLine("Please choose one of the options");
                            break;
                    }
                    Console.WriteLine("\n");
                    option = program.UserInputOptions();

                }
                option = Convert.ToInt32(Console.ReadLine());

            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
                Console.WriteLine("TRY ONE LAST TIME");
                program.ShowManual(refrigerators);
            }

            return 0;
        }
    }
}
