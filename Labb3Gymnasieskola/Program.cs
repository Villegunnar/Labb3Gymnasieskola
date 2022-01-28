using Labb3Gymnasieskola.Data;
using System;
using System.Linq;
namespace Labb3Gymnasieskola
{
    class Program
    {
        static void Main(string[] args)
        {

            using GymnasieskolaDbContext Context = new GymnasieskolaDbContext();


            bool loop = true;
            ConsoleKey selector;

            while (loop)
            {
                do
                {
                    Console.Clear();
                    Console.WriteLine("1. Hämta ut alla elever\n2. Hämta ut alla elever i en viss klass\n3. Lägga till ny personal");
                    var keyInfo = Console.ReadKey(intercept: true);
                    selector = keyInfo.Key;
                } while (selector != ConsoleKey.NumPad1 && selector != ConsoleKey.NumPad2 && selector != ConsoleKey.NumPad3 && selector != ConsoleKey.D1 && selector != ConsoleKey.D2 && selector != ConsoleKey.D3);
                if (selector == ConsoleKey.NumPad1 || selector == ConsoleKey.D1)
                {
                    do
                    {
                        Console.Clear();
                        Console.WriteLine("Hämta ut alla elever och sortera efter:\n\n1.Förnamn\n2.Efternamn");
                        var keyInfo = Console.ReadKey(intercept: true);
                        selector = keyInfo.Key;
                    } while (selector != ConsoleKey.NumPad1 && selector != ConsoleKey.NumPad2 && selector != ConsoleKey.D1 && selector != ConsoleKey.D2);

                    if (selector == ConsoleKey.NumPad1 || selector == ConsoleKey.D1)
                    {
                        do
                        {
                            Console.Clear();
                            Console.WriteLine("Sortera FÖRNAMN via \n\n1. Fallande\n2. Stigande");
                            var keyInfo = Console.ReadKey(intercept: true);
                            selector = keyInfo.Key;
                        } while (selector != ConsoleKey.NumPad1 && selector != ConsoleKey.NumPad2 && selector != ConsoleKey.D1 && selector != ConsoleKey.D2);
                        if (selector == ConsoleKey.NumPad1 || selector == ConsoleKey.D1)
                        {
                            Console.Clear();
                            Console.WriteLine("FÖRNAMN via FALLANDE sortering:\n");
                            var sortByFnameAsc = from TblElev in Context.TblElev
                                                 orderby TblElev.Förnamn
                                                 select TblElev;


                            foreach (var item in sortByFnameAsc)
                            {
                                Console.WriteLine($"{item.Förnamn} {item.Efternamn}");
                            }
                            Console.WriteLine("\nDone!");
                            Console.ReadLine();
                        }
                        Console.Clear();
                        Console.WriteLine("FÖRNAMN via STIGANDE sortering:\n");
                        if (selector == ConsoleKey.NumPad2 || selector == ConsoleKey.D2)
                        {

                            var sortByFnameDesc = from TblElev in Context.TblElev
                                                  orderby TblElev.Förnamn descending
                                                  select TblElev;


                            foreach (var item in sortByFnameDesc)
                            {
                                Console.WriteLine($"{item.Förnamn} {item.Efternamn}");
                            }
                            Console.WriteLine("\nDone!");
                            Console.ReadLine();

                        }
                    }
                    if (selector == ConsoleKey.NumPad2 || selector == ConsoleKey.D2)
                    {
                        do
                        {
                            Console.Clear();
                            Console.WriteLine("Sortera EFTERNAMN via \n\n1. Fallande\n2. Stigande");
                            var keyInfo = Console.ReadKey(intercept: true);
                            selector = keyInfo.Key;
                        } while (selector != ConsoleKey.NumPad1 && selector != ConsoleKey.NumPad2 && selector != ConsoleKey.D1 && selector != ConsoleKey.D2);
                        if (selector == ConsoleKey.NumPad1 || selector == ConsoleKey.D1)
                        {
                            Console.Clear();
                            Console.WriteLine("EFTERNAMN via FALLANDE sortering:\n");
                            var sortByFnameAsc = from TblElev in Context.TblElev
                                                 orderby TblElev.Efternamn
                                                 select TblElev;


                            foreach (var item in sortByFnameAsc)
                            {
                                Console.WriteLine($"{item.Förnamn} {item.Efternamn}");
                            }
                            Console.WriteLine("\nDone!");
                            Console.ReadLine();
                        }
                        Console.Clear();
                        Console.WriteLine("EFTERNAMN via STIGANDE sortering:\n");
                        if (selector == ConsoleKey.NumPad2 || selector == ConsoleKey.D2)
                        {

                            var sortByFnameDesc = from TblElev in Context.TblElev
                                                  orderby TblElev.Efternamn descending
                                                  select TblElev;


                            foreach (var item in sortByFnameDesc)
                            {
                                Console.WriteLine($"{item.Förnamn} {item.Efternamn}");
                            }
                            Console.WriteLine("\nDone!");
                            Console.ReadLine();

                        }
                    }
                }
                if (selector == ConsoleKey.NumPad2 || selector == ConsoleKey.D2)
                {
                    Console.Clear();
                    Console.WriteLine("Hämta ut alla elever i en viss klass");
                    Console.WriteLine("Alla klasser som finns i databasen:\n\n");


                    var allClasses = (from TblElev in Context.TblElev
                                      select TblElev.Klass).Distinct();

                    foreach (var item in allClasses)
                    {
                        
                        Console.WriteLine($"{item}");
                    }


                    Console.WriteLine("Choice whitch Class:");
                    string className1 = Console.ReadLine();
                    if (className1 ==  "SUT21")
                    {
                        var SUT21 = from TblElev in Context.TblElev
                                    where TblElev.Klass == "SUT21"
                                    select TblElev;

                        foreach (var item in SUT21)
                        {

                            Console.WriteLine($"{item.Förnamn} {item.Efternamn}");
                        }
                    }


                    Console.ReadLine();
                }
                if (selector == ConsoleKey.NumPad3 || selector == ConsoleKey.D3)
                {
                    Console.Clear();
                    Console.WriteLine("Lägga till ny personal");
                    Console.ReadLine();
                }
                else
                {
                    Console.WriteLine("avslutar....");

                    loop = false;
                }
            }























            //while (runMenu)
            //{
            //    string menyChoice = Console.ReadLine();

            //    switch (menyChoice)
            //    {

            //        case "1":
            //            Console.Clear();
            //            Console.WriteLine("Hämta ut alla elever\n\n\nSortera efter:\n1.Förnamn\n2.Efternamn");

            //            string sortByNameChoice = Console.ReadLine();
            //            Console.WriteLine("Sortera via\n1. Fallande\n2. Stigande");
            //            string sortyByAscDesc = Console.ReadLine();

            //            switch (sortByNameChoice)
            //            {
            //                case "1":
            //                    switch (sortyByAscDesc)


            //                    {
            //                        case "1":
            //                            var sortByFnameAsc = from TblElev in Context.TblElev
            //                                                 orderby TblElev.Förnamn
            //                                                 select TblElev;


            //                            foreach (var item in sortByFnameAsc)
            //                            {
            //                                Console.WriteLine($"{item.Förnamn} {item.Efternamn}");
            //                            }

            //                            break;
            //                        case "2":
            //                            var sortByFnameDesc = from TblElev in Context.TblElev
            //                                                  orderby TblElev.Förnamn descending
            //                                                  select TblElev;


            //                            foreach (var item in sortByFnameDesc)
            //                            {
            //                                Console.WriteLine($"{item.Förnamn} {item.Efternamn}");
            //                            }
            //                            break;
            //                        default:
            //                            Console.WriteLine("Fel input");
            //                            break;
            //                    }
            //                    break;
            //                case "2":
            //                    switch (sortyByAscDesc)


            //                    {
            //                        case "1":
            //                            var sortByFnameAsc = from TblElev in Context.TblElev
            //                                                 orderby TblElev.Efternamn
            //                                                 select TblElev;


            //                            foreach (var item in sortByFnameAsc)
            //                            {
            //                                Console.WriteLine($"{item.Förnamn} {item.Efternamn}");
            //                            }

            //                            break;
            //                        case "2":
            //                            var sortByFnameDesc = from TblElev in Context.TblElev
            //                                                  orderby TblElev.Efternamn descending
            //                                                  select TblElev;


            //                            foreach (var item in sortByFnameDesc)
            //                            {
            //                                Console.WriteLine($"{item.Förnamn} {item.Efternamn}");
            //                            }
            //                            break;
            //                        default:
            //                            break;
            //                    }
            //                    break;
            //                default:
            //                    break;
            //            }



            //            break;
            //        case "2":
            //            Console.Clear();
            //            Console.WriteLine("Hämta ut alla elever i en viss klass");
            //            break;
            //        case "3":
            //            Console.Clear();
            //            Console.WriteLine("Lägga till ny personal");
            //            break;

            //        default:
            //            Console.WriteLine("fel input");
            //            break;
            //    }
            //}













            //var pro = from TblElev in Context.TblElev
            //          where TblElev.Klass == "SUT21"
            //          select TblElev;
            //foreach (var item in pro)
            //{
            //    Console.WriteLine(item.Förnamn);
            //}





            //Console.ReadLine();
        }
    }
}
