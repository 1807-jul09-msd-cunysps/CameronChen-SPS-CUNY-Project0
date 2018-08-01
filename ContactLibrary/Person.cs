using System;

namespace ContactLibrary
{
    public class Person
    {
        //Variables
        private string firstName;
        private string lastName;
        private Address address;
        private Phone phone;

        //Getters for name variables
        public string GetFirstName { get { return firstName; } }
        public string GetLastName { get { return lastName; } }

        //Getters for Address and Phone objects
        public Address GetAddress { get { return address; } }
        public Phone GetPhoneNumber { get { return phone; } }


        //Update methods
        public void NewFirstName(string nfName) { firstName = nfName; }
        public void NewLastName(string nlName) { lastName = nlName; }
        public void NewPhoneNumber() { phone = new Phone(); }
        public void NewAddress() { address = new Address(); }

        //User inputs Name (default constructor)
        public Person()
        {
            while (true)
            {
                try
                {
                    Console.WriteLine("Please enter the first name.");
                    firstName = Console.ReadLine();
                    Console.WriteLine("Please enter the last name.");
                    lastName = Console.ReadLine();
                    address = new Address();
                    phone = new Phone();
                    break;
                }
                catch (Exception)
                {
                    Console.WriteLine("Invalid Entry. Try again.");
                }
            }

        }

        //Print Person's info
        public string PrintPerson()
        {
            return firstName + " " + lastName + " " + address.Print() + " " + phone.Print();
        }

        //Getters for the info inside of the phone and address
        public string GetAddressInfo { get { return address.Print(); } }
        public string GetPhoneNumberInfo { get { return phone.Print(); } }

        public class Address
        {
            //Variables
            private int buildingNum;
            private string street;
            private string city;
            private string state;
            private int zipCode;

            //User input
            public Address()
            {
                while (true)
                {
                    try
                    {
                        Console.WriteLine("Please enter the building number");
                        buildingNum = Int32.Parse(Console.ReadLine());
                        Console.WriteLine("Please enter the street.");
                        street = Console.ReadLine();
                        Console.WriteLine("Please enter the city.");
                        city = Console.ReadLine();
                        Console.WriteLine("Please enter the state.");
                        state = Console.ReadLine();
                        Console.WriteLine("Please enter the zip code.");
                        zipCode = Int32.Parse(Console.ReadLine());
                        break;
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("Invalid Entry. Try again.");
                    }

                }
            }

            //Add values 
            public Address(int a, string b, string c, string d, int e)
            {
                buildingNum = a;
                street = b;
                city = c;
                state = d;
                zipCode = e;
            }

            //Getter Methods
            public int GetBuildNum { get { return buildingNum; } }
            public string GetStreetName { get { return street; } }
            public string GetCity { get { return city; } }
            public string GetState { get { return state; } }
            public int GetZipcode { get { return zipCode; } }

            //Print Method
            public string Print() { return $"Address: {buildingNum} {street}, {city}, {state} {zipCode}"; }
        }

        public class Phone
        {
            //Variables
            private int countryCode;
            private int areaCode;
            private int phoneNumber;
            private int extension;

            //User input for Phone
            public Phone()
            {
                while (true)
                {
                    try
                    {
                        Console.WriteLine("Please enter the country code.");
                        countryCode = Int32.Parse(Console.ReadLine());
                        Console.WriteLine($"What is the area code?");
                        areaCode = Int32.Parse(Console.ReadLine());
                        Console.WriteLine($"What is the phone number?");
                        phoneNumber = Int32.Parse(Console.ReadLine());
                        Console.WriteLine($"What is the extension? 0 if there is none. ");
                        extension = Int32.Parse(Console.ReadLine());
                        break;
                    }

                    catch (Exception)
                    {
                        Console.WriteLine("Invalid Entry.");
                    }

                }
            }

            //Add values
            public Phone(int f, int g, int h, int i)
            {
                countryCode = f;
                areaCode = g;
                phoneNumber = h;
                extension = i;
            }

            //Getter methods
            public int CCode {
                get { return countryCode; } }
            public int ACode {
                get { return areaCode; } }
            public int pNum {
                get { return phoneNumber; } }
            public int Ext {
                get { return extension; } }

            //Print Phone Number
            public string Print()
            {
                if (Ext != 0)
                {
                    return $"Phone: + {CCode} {ACode} {pNum} Ext: {Ext}";
                }
                else
                {
                    return $"Phone: + {CCode} {ACode} {pNum} Ext: No Extension";
                }

            }
        }
        public class PersonLister
        {
            //Variables 
            private long iD = SQLConnection.iD++;
            private string name;
            private string address;
            private string number;

            //Getters and Setters 
            public long ID {
                get => iD; }
            public string Name {
                set => name = value; get => name; }
            public string Address {
                set => address = value; get => address; }
            public string Number {
                set => number = value; get => number; }

            //Print method
            public string Print {
                get => $"ID: {iD}; {name} {address} {number}";
            }
        }
    }
}
