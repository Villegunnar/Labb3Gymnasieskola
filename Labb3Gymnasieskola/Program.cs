using Labb3Gymnasieskola.Data;
using Labb3Gymnasieskola.Models;
using System;
using System.Linq;
using System.Threading;

namespace Labb3Gymnasieskola
{
    class Program
    {
        public static void ClearAndPrint(string text = "", string text2 = "", string text3 = "", string text4 = "", string text5 = "")
        {
            Console.Clear();
            Console.Write(text);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write(text2);
            Console.ResetColor();
            Console.Write(text3);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write(text4);
            Console.ResetColor();
            Console.Write(text5);
        }
        public static void RetrunToHeadMenu()
        {
            Console.WriteLine("\nKlart! Tryck Enter för att komma till huvudmenyn");
            Console.ReadLine();
        }
        public static void SortFirstNameAscending(GymnasieskolaDbContext tempContext)
        {
            var sortByFnameAsc = from TblElev in tempContext.TblElev
                                 orderby TblElev.Förnamn
                                 select TblElev;

            foreach (var item in sortByFnameAsc)
            {
                Console.WriteLine($"{item.Förnamn} {item.Efternamn}");
            }
        }
        public static void SortFirstNameDescending(GymnasieskolaDbContext tempContext)
        {
            var sortByFnameDesc = from TblElev in tempContext.TblElev
                                  orderby TblElev.Förnamn descending
                                  select TblElev;

            foreach (var item in sortByFnameDesc)
            {
                Console.WriteLine($"{item.Förnamn} {item.Efternamn}");
            }
        }
        public static void SortLastNameAscending(GymnasieskolaDbContext tempContext)
        {
            var sortByFnameAsc = from TblElev in tempContext.TblElev
                                 orderby TblElev.Efternamn
                                 select TblElev;

            foreach (var item in sortByFnameAsc)
            {
                Console.WriteLine($"{item.Förnamn} {item.Efternamn}");
            }
        }
        public static void SortLastNameDescending(GymnasieskolaDbContext tempContext)
        {
            var sortByFnameDesc = from TblElev in tempContext.TblElev
                                  orderby TblElev.Efternamn descending
                                  select TblElev;

            foreach (var item in sortByFnameDesc)
            {
                Console.WriteLine($"{item.Förnamn} {item.Efternamn}");
            }
        }
        public static void GetAllClasses(GymnasieskolaDbContext tempContext)
        {
            var allClasses = (from TblElev in tempContext.TblElev
                              select TblElev.Klass).Distinct();

            foreach (var item in allClasses)
            {

                Console.WriteLine($"{item}");
            }
        }
        public static void GetAllStudentsFromClass(GymnasieskolaDbContext tempContext)
        {
            bool loopClassChoice = true;
            while (loopClassChoice)
            {
                Console.Write("\nSkriv vilken klass: ");

                string tempClass = Console.ReadLine();
                if (tempClass.ToUpper() == "SUT20")
                {
                    Console.WriteLine();
                    var SUT21 = from TblElev in tempContext.TblElev
                                where TblElev.Klass == "SUT20"
                                select TblElev;

                    foreach (var item in SUT21)
                    {

                        Console.WriteLine($"{item.Förnamn} {item.Efternamn}");
                    }
                    break;
                }
                if (tempClass.ToUpper() == "SUT21")
                {
                    Console.WriteLine();
                    var SUT21 = from TblElev in tempContext.TblElev
                                where TblElev.Klass == "SUT21"
                                select TblElev;

                    foreach (var item in SUT21)
                    {

                        Console.WriteLine($"{item.Förnamn} {item.Efternamn}");
                    }
                    break;
                }
                if (tempClass.ToUpper() == "SUT22")
                {
                    Console.WriteLine();
                    var SUT21 = from TblElev in tempContext.TblElev
                                where TblElev.Klass == "SUT22"
                                select TblElev;

                    foreach (var item in SUT21)
                    {

                        Console.WriteLine($"{item.Förnamn} {item.Efternamn}");
                    }
                    break;
                }
                else
                {
                    Console.WriteLine("Fel input, testa igen.");
                }
            }
        }
        public static void AddNewStaff(GymnasieskolaDbContext tempContext)
        {
            Console.SetCursorPosition(9, 2);
            string firstName = Console.ReadLine();
            Console.SetCursorPosition(11, 3);
            string lastName = Console.ReadLine();
            Console.SetCursorPosition(12, 4);
            string position = Console.ReadLine();
            TblPersonal P1 = new TblPersonal()
            {
                Förnamn = firstName,
                Efternamn = lastName,
                Befattning = position
            };
            tempContext.TblPersonal.Add(P1);
            tempContext.SaveChanges();
        }
        static void Main(string[] args)
        {
            using GymnasieskolaDbContext Context = new GymnasieskolaDbContext();

            bool loop = true;
            ConsoleKey selector;
            while (loop)
            {
                do
                {
                    ClearAndPrint("1. Hämta ut alla elever\n2. Hämta ut alla elever i en viss klass\n3. Lägga till ny personal\n\nESC för att avsluta programmet\n");

                    var keyInfo = Console.ReadKey(intercept: true);
                    selector = keyInfo.Key;
                } while (selector != ConsoleKey.NumPad1 && selector != ConsoleKey.NumPad2 && selector != ConsoleKey.NumPad3 && selector != ConsoleKey.D1 && selector != ConsoleKey.D2 && selector != ConsoleKey.D3 && selector != ConsoleKey.Escape);
                if (selector == ConsoleKey.NumPad1 || selector == ConsoleKey.D1)
                {
                    do
                    {
                        ClearAndPrint("Hämta ut alla ","ELEVER"," och sortera efter:\n\n1. Förnamn\n2. Efternamn\n");        
                        var keyInfo = Console.ReadKey(intercept: true);
                        selector = keyInfo.Key;
                    } while (selector != ConsoleKey.NumPad1 && selector != ConsoleKey.NumPad2 && selector != ConsoleKey.D1 && selector != ConsoleKey.D2);
                    if (selector == ConsoleKey.NumPad1 || selector == ConsoleKey.D1)
                    {
                        do
                        {
                            ClearAndPrint("Sortera", " ELEVERS FÖRNAMN", " via \n\n1. Fallande\n2. Stigande\n");                       
                            var keyInfo = Console.ReadKey(intercept: true);
                            selector = keyInfo.Key;
                        } while (selector != ConsoleKey.NumPad1 && selector != ConsoleKey.NumPad2 && selector != ConsoleKey.D1 && selector != ConsoleKey.D2);
                        if (selector == ConsoleKey.NumPad1 || selector == ConsoleKey.D1)
                        {
                            ClearAndPrint("","ELEVERS FÖRNAMN ", "via ", "FALLANDE ", "sortering:\n\n");
                            SortFirstNameAscending(Context);
                            RetrunToHeadMenu();
                            selector = ConsoleKey.A;

                        }
                        ClearAndPrint("", "ELEVERS FÖRNAMN", " via ","STIGANDE", " sortering:\n\n");
                        if (selector == ConsoleKey.NumPad2 || selector == ConsoleKey.D2)
                        {
                            SortFirstNameDescending(Context);
                            RetrunToHeadMenu();
                            selector = ConsoleKey.A;
                        }
                    }
                    if (selector == ConsoleKey.NumPad2 || selector == ConsoleKey.D2)
                    {
                        do
                        {
                            ClearAndPrint("Sortera", " ELEVERS EFTERNAMN", " via \n\n1. Fallande\n2. Stigande\n");
                            var keyInfo = Console.ReadKey(intercept: true);
                            selector = keyInfo.Key;
                        } while (selector != ConsoleKey.NumPad1 && selector != ConsoleKey.NumPad2 && selector != ConsoleKey.D1 && selector != ConsoleKey.D2);
                        if (selector == ConsoleKey.NumPad1 || selector == ConsoleKey.D1)
                        {
                            ClearAndPrint("","ELEVERS EFTERNAMN"," via ","FALLANDE", " sortering:\n\n");
                            SortLastNameAscending(Context);
                            RetrunToHeadMenu();
                            selector = ConsoleKey.A;
                        }

                        ClearAndPrint("", "ELEVERS EFTERNAMN", " via ","STIGANDE", " sortering:\n\n");
                        if (selector == ConsoleKey.NumPad2 || selector == ConsoleKey.D2)
                        {
                            SortLastNameDescending(Context);
                            RetrunToHeadMenu();
                            selector = ConsoleKey.A;
                        }
                    }
                }
                if (selector == ConsoleKey.NumPad2 || selector == ConsoleKey.D2)
                {
                    ClearAndPrint("Hämta ut alla ","ELEVER", " i en viss ","KLASS","\n\nAlla klasser som finns i databasen:\n");
                    GetAllClasses(Context);
                    GetAllStudentsFromClass(Context);
                    RetrunToHeadMenu();
                }
                if (selector == ConsoleKey.NumPad3 || selector == ConsoleKey.D3)
                {
                    ClearAndPrint("Lägg till ny ","PERSONAL","\n\nFörnamn: \nEfternamn: \nBefattning:\n");
                    AddNewStaff(Context);
                    RetrunToHeadMenu();
                }
                if (selector == ConsoleKey.Escape)
                {
                    Console.WriteLine("avslutar....");
                    Thread.Sleep(2000);
                    loop = false;
                }
            }
        }
    }
}




