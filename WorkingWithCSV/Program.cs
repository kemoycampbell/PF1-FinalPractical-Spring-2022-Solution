using System;
using System.Collections.Generic;
using System.IO;
namespace WorkingWithCSV
{
    class Program
    {
        static List<GameSale> records = new List<GameSale>();
        static void Main(string[] args)
        {
            //REMOVE THIS BEFORE SUBMIT
            //records.Add(new GameSale("Test", "Testing Platform1", "10/10/2020", 100, 2500));
            //records.Add(new GameSale("Test1", "Testing Platform2", "10/10/2020", 100, 2500));
            //records.Add(new GameSale("Test2", "Testing Platform3", "10/10/2020", 100, 2500));
            //records.Add(new GameSale("Test3", "Testing Platform4", "10/10/2020", 100, 2500));
            //records.Add(new GameSale("Test3", "Testing Platform5", "10/10/2020", 100, 2500));

            while (true)
            {
                Console.WriteLine("1. Create new Sales\n2. Remove a record\n3. Show all sale records\n" +
                    "4. Write records to file\n5. Read in sales from file\n" +
                    "6. Exit");

                Console.Write("Selection:");
                switch(Console.ReadLine())
                {
                    case "1":
                        Console.Write("Name:");
                        string name = Console.ReadLine();
                        Console.Write("Platform:");
                        string platform = Console.ReadLine();
                        Console.Write("Date:");
                        string date = Console.ReadLine();
                        Console.Write("Total Copies Sold:");
                        int copies = int.Parse(Console.ReadLine());
                        Console.Write("Total Revenues:");
                        double revenues = double.Parse(Console.ReadLine());

                        GameSale sale = new GameSale(name, platform, date, copies, revenues);
                        records.Add(sale);
                        break;
                    case "2":
                        Console.Write("Name:");
                        name = Console.ReadLine().ToLower();
                        Console.Write("Platform:");
                        platform = Console.ReadLine().ToLower();

                        bool deleted = false;
                        foreach(GameSale _sale in records)
                        {
                            if(_sale.Name.ToLower() == name && _sale.Platform.ToLower() == platform)
                            {
                                records.Remove(_sale);
                                deleted = true;
                                break;
                            }
                        }

                        if (!deleted)
                        {
                            Console.WriteLine($"No record found for {name} - {platform}");
                        }

                        break;

                    case "3":
                        foreach(GameSale _sale in records)
                            Console.WriteLine(_sale);
                        break;
                    case "4":
                        Console.Write("Filename:");
                        string filename = Console.ReadLine();

                        if (filename.IndexOf(".csv") == -1)
                        {
                            Console.WriteLine("the file must be a csv!!");
                        }else
                        {

                            //using(StreamWriter writer = new StreamWriter(filename))
                            //{
                            //    foreach (GameSale _sale in records)
                            //    {
                            //        writer.WriteLine($"{_sale.Name},{_sale.Platform},{_sale.Date},{_sale.TotalCopies},{_sale.TotalRevenues}");
                            //    }
                            //}


                            StreamWriter writer = new StreamWriter(filename);
                            foreach (GameSale _sale in records)
                            {
                                writer.WriteLine($"{_sale.Name},{_sale.Platform},{_sale.Date},{_sale.TotalCopies},{_sale.TotalRevenues}");
                            }

                            writer.Close();
                            Console.WriteLine("File created!");
                            
                        }
                        break;
                    case "5":

                        Console.Write("Filename:");
                        filename = Console.ReadLine();

                        if (File.Exists(filename))
                        {
                            StreamReader reader = new StreamReader(filename);
                            while(!reader.EndOfStream)
                            {
                                string[] info = reader.ReadLine().Split(",");
                                sale = new GameSale(info[0], info[1], info[2], int.Parse(info[3]), double.Parse(info[4]));
                                records.Add(sale);
                            }

                            reader.Close();
                            Console.WriteLine("All records has been loaded");

                        }
                        else
                        {
                            Console.WriteLine($"{filename} not found");
                        }
                        break;
                    case "6":
                        Console.WriteLine("Thank you for using this system. Goodbye... :-(");
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Invalid selection!");
                        break;

                }
            }
        }
    }
}
