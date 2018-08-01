using System;
using System.Collections.Generic;
using static ContactLibrary.Person;


namespace ContactLibrary
{
    public class CommandHandler
        {
        //declare list
        private List<PersonLister> directory;

        //Make a command handler
        public CommandHandler() { directory = new List<PersonLister>(); }

        //Print the directory
        public void PRINT() {
            foreach (PersonLister plister in directory)
            {
                Console.WriteLine(plister.Print + "\n");
            }
        }

        //Read the directroy 
        public void READ() {
            StartDeserialization(SQLConnection.ReadFromSQL_DB());
            Console.WriteLine("\n");
            Console.WriteLine("Directory has been loaded.");
            Console.WriteLine("\n");
        }

        //Make a new person 
        public Person CREATE() {
            return new Person();
        }

        //Make a new PersonList
        public void ADD(Person p)
        {
            DirectoryEntry(p);

            string jsonString = StartSerialization();
            SQLConnection.WriteToSQL_DB(jsonString);
            Console.WriteLine("\n");
            Console.WriteLine($"Person + {p} + has been added");
            Console.WriteLine("\n");
        }

        //Delete a person 
        public void DELETE()
        {
            do
            {
                try
                {
                    Console.WriteLine("\n");
                    Console.WriteLine($"Please enter the ID of the Person to delete.");
                    Console.WriteLine($"*Hint* Use the search/print function to find the ID");
                    Console.WriteLine("\n");
                    string feedback = Console.ReadLine();
                    short searchoption = Convert.ToInt16(feedback);

                    //Loop through directory, then change SQL Database
                    for (int x = 0; x < directory.Count; x++)
                    {
                        if (directory[x].ID == searchoption)
                        {
                            Console.WriteLine($"Person has been deleted.");
                            directory.Remove(directory[x]);
                            string jsonString = StartSerialization();
                            SQLConnection.WriteToSQL_DB(jsonString);
                            return;
                        }
                    }
                    break;
                }
                catch(Exception)
                {
                    Console.WriteLine("\n");
                    Console.WriteLine("Contact not found. Please try again.");
                    Console.WriteLine("\n");
                }
            }
            while (true);

        }

        ///UPDATES a ContactEntry in the PhoneDirectory by using its ID Number.
        public void UPDATE()
        {
            //user input for person and field to update
            bool acceptable = false;
            Console.WriteLine("\n");
            Console.WriteLine($"Please enter a person to search for the update.");
            Console.WriteLine("You will use the Search function");
            Console.WriteLine("\n");
            PersonLister entry = SEARCH();

            Console.WriteLine($"Please enter the field that you will update.");
            Console.WriteLine($"Press 1 to update name.");
            Console.WriteLine($"Press 2 to update address.");
            Console.WriteLine($"Press 3 to update Phone #");
            string searchoption = Console.ReadLine();

            //options for update
            do
            {
                if (searchoption.Contains("1")) { UpdateEntryName(entry); acceptable = true; }
                if (searchoption.Contains("2")) { UpdateEntryAddress(entry); acceptable = true; }
                if (searchoption.Contains("3")) { UpdateEntryPhone(entry); acceptable = true; }
                else
                {
                    Console.WriteLine($"Contact Updated. Please press enter to continue.");
                    searchoption = Console.ReadLine();
                }
            } while (acceptable == false);

        }
        //Phone, Address, Name Update methods
            private void UpdateEntryPhone(PersonLister entry)
            {
                PersonLister newEntry = new PersonLister();
                newEntry.Name = entry.Name;
                newEntry.Address = entry.Address;
                Phone pn = new Phone();
                newEntry.Number = pn.Print();
                directory.Remove(entry);
                directory.Add(newEntry);
            }

            private void UpdateEntryAddress(PersonLister entry)
            {
                PersonLister newEntry = new PersonLister();
                newEntry.Name = entry.Name;
                newEntry.Number = entry.Number;
                Address add = new Address();
                newEntry.Address = add.Print();
                directory.Remove(entry);
                directory.Add(newEntry);
            }

            private void UpdateEntryName(PersonLister entry)
            {
            if(entry == null) { Console.WriteLine($"Error, doesn't exist!"); return;  }
                PersonLister newEntry = new PersonLister();
                newEntry.Number = entry.Number;
                newEntry.Address = entry.Address;
                Console.WriteLine($"Enter in the new first name.");
                string tempFName = Console.ReadLine();
                Console.WriteLine($"Enter in the new last name.");
                string tempLName = Console.ReadLine();
                newEntry.Name = tempLName + ", " + tempFName;
                directory.Remove(entry);
                directory.Add(newEntry);
            }
        

        //Search for a person
         public PersonLister SEARCH()
         {
            //display search options
            Console.WriteLine($"Please select a field to search.");
            Console.WriteLine($"Press 1 for Name.");
            Console.WriteLine($"Press 2 for Address.");
            Console.WriteLine($"Press 3 for Phone #.");
            string searchoption = Console.ReadLine();

            //execute options for search
            do
            {
                if (searchoption.Contains("1"))
                {
                    return SearchByName();
                }
                if (searchoption.Contains("2"))
                {
                    return SearchByAddress();
                }
                if (searchoption.Contains("3"))
                {
                    return SearchByPhone();
                }
                else
                {
                    //error handling
                    Console.WriteLine("\n");
                    Console.WriteLine($"Invalid Entry.");
                    Console.WriteLine("\n");
                    searchoption = Console.ReadLine();
                }
            } while (true); 
         }


        private PersonLister SearchByName()
        {
            Console.WriteLine($"Please enter a name to search.");
            string input = Console.ReadLine();
            foreach (PersonLister entry in directory)
            {
                if (entry.Name.Contains(input))
                {
                    Console.WriteLine("\n");
                    Console.WriteLine($"Person found in directory.");
                    Console.WriteLine(entry.Print);
                    Console.WriteLine("\n");
                    return entry;
                }
            }
            return null;
        }

        private PersonLister SearchByAddress()
        {
            Console.WriteLine($"Please enter an address to search.");
            string input = Console.ReadLine();
            foreach (PersonLister entry in directory)
            {
                if (entry.Address.Contains(input))
                {
                    Console.WriteLine("\n");
                    Console.WriteLine($"Person found in directory.");
                    Console.WriteLine(entry.Print);
                    Console.WriteLine("\n");
                    return entry;
                }
            }
            return null;
        }

        private PersonLister SearchByPhone()
        {
            Console.WriteLine($"Please enter a phone # to search.");
            string input = Console.ReadLine();
            foreach (PersonLister entry in directory)
            {
                if (entry.Number.Contains(input))
                {
                    Console.WriteLine("\n");
                    Console.WriteLine($"Person found in directory.");
                    Console.WriteLine(entry.Print);
                    Console.WriteLine("\n");
                    return entry;
                }
            }
            return null;
        }

        private string StartSerialization()
        {
            System.Web.Script.Serialization.JavaScriptSerializer JsonWriter = new System.Web.Script.Serialization.JavaScriptSerializer();
            return JsonWriter.Serialize(directory);
            
        }

        private void StartDeserialization(string inputJSON)
        {
            System.Web.Script.Serialization.JavaScriptSerializer JsonWriter = new System.Web.Script.Serialization.JavaScriptSerializer();
            directory = JsonWriter.Deserialize<List<PersonLister>>(inputJSON); 
        }

        private void DirectoryEntry(Person p)
        {
            PersonLister per = new PersonLister();
            per.Name = p.GetLastName + ", " + p.GetFirstName + ".";
            per.Address = p.GetAddress.Print() + ".";
            per.Number = p.GetPhoneNumber.Print() + ".";
            directory.Add(per);

        }
    }
}
