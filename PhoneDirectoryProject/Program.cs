using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContactLibrary;

namespace ContactClient
{
    class Program
    {
        static void Main(string[] args)
        {
             
            bool flag = false;
            //string log = "Documents\\log.txt";
            CommandHandler handler = new CommandHandler();

            do
            {
                //User Commands
                Console.WriteLine("*****************************************");
                Console.WriteLine("Please enter a command.");
                Console.WriteLine("*****************************************");
                Console.WriteLine("Enter Q to quit.");
                Console.WriteLine("Enter 1 to Load Directory.");
                Console.WriteLine("Enter 2 to Search a contact.");
                Console.WriteLine("Enter 3 to Add a contact.");
                Console.WriteLine("Enter 4 to Delete for a contact.");
                Console.WriteLine("Enter 5 to Update a contact.");
                Console.WriteLine("Enter 6 to Print all contacts");
                Console.WriteLine("*****************************************");
                
                //Read user command
                string feedback = Console.ReadLine();

                //Command Handler Methods
                if (feedback == "1" || feedback == "2" || feedback == "3" || feedback == "4" || feedback == "5" || feedback == "6" || feedback == "Q" || feedback =="q")
                { 
                    if (feedback.Contains("1")) { handler.READ();}
                    if (feedback.Contains("2")) { handler.SEARCH(); }
                    if (feedback.Contains("3")) { handler.ADD(handler.CREATE()); }
                    if (feedback.Contains("4")) { handler.DELETE(); }
                    if (feedback.Contains("5")) { handler.UPDATE(); }
                    if (feedback.Contains("6")) { handler.PRINT(); }
                    if (feedback.Contains("q") || feedback.Contains("Q")) { flag = true; }
                }
                else
                {
                    Console.WriteLine("\n");
                    Console.WriteLine("Please enter a valid command.");
                    Console.WriteLine("\n");
                }

                //Logger
                //System.IO.File.WriteAllText(@"c:\log.txt", "mymsg\n");

            } while (flag == false); 
        }
    }
}

           
