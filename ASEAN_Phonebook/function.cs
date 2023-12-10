using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
class Functions
{
    public static void to_ASEAN_phonebook()
    {
        while (true)
        {
            Console.Write("Enter Student Number: ");
            string studentNumber = Console.ReadLine();
            Console.Write("Enter Surname: ");
            string surname = Console.ReadLine();
            Console.Write("Enter First Name: ");
            string firstName = Console.ReadLine();
            Console.Write("Enter Occupation: ");
            string occupation = Console.ReadLine();
            Console.Write("Enter Gender (M/F): ");
            char gender = Console.ReadKey().KeyChar;
            Console.WriteLine();
            Console.Write("Enter Country Code: ");
            int countryCode = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter Area Code: ");
            int areaCode = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter Number: ");
            int number = Convert.ToInt32(Console.ReadLine());

            OtherInformation.add_to_Phonebook(new PersonalInformation(studentNumber, surname, firstName, occupation, gender, countryCode, areaCode, number));

            Console.Write("Do you want to enter another entry(Y/N)?");
            char choice = Console.ReadKey().KeyChar;
            Console.WriteLine();

            if (char.ToUpper(choice) == 'N')
                break;
        }
    }
    public static void edit_ASEAN_phonebook()
    {
        Console.Write("Enter Student Number: ");
        string studentNumber = Console.ReadLine();

        PersonalInformation person = OtherInformation.get_Phonebook().Find(s => s.StudentNumber == studentNumber);

        if (person == null)
        {
            Console.WriteLine("Student Number not found.");
            return;
        }

        while (true)
        {
            Console.WriteLine("\nPerson Found:");
            Console.WriteLine($"Student Number: {person.StudentNumber}");
            Console.WriteLine($"Name: {person.Surname}, {person.FirstName}");
            Console.WriteLine($"Occupation: {person.Occupation}");
            Console.WriteLine($"Gender: {person.Gender}");
            Console.WriteLine($"Country Code: {person.CountryCode}");
            Console.WriteLine($"Area Code: {person.AreaCode}");
            Console.WriteLine($"Phone Number: {person.Number}");
            Console.WriteLine("\nEdit Menu:");
            Console.WriteLine("[1] Student Number");
            Console.WriteLine("[2] Surname");
            Console.WriteLine("[3] Gender");
            Console.WriteLine("[4] Occupation");
            Console.WriteLine("[5] Country Code");
            Console.WriteLine("[6] Area Code");
            Console.WriteLine("[7] Phone Number");
            Console.WriteLine("[8] None/Go Back");
            Console.Write("Enter choice: ");
            if (int.TryParse(Console.ReadLine(), out int choice))
            {
                switch (choice)
                {
                    case 1:
                        Console.Write("Enter new person number: ");
                        person.StudentNumber = Console.ReadLine();
                        break;
                    case 2:
                        Console.Write("Enter new surname: ");
                        person.Surname = Console.ReadLine();
                        break;
                    case 3:
                        Console.Write("Enter new gender (M/F): ");
                        person.Gender = Console.ReadKey().KeyChar;
                        Console.WriteLine();
                        break;
                    case 4:
                        Console.Write("Enter new occupation: ");
                        person.Occupation = Console.ReadLine();
                        break;
                    case 5:
                        Console.Write("Enter new country code: ");
                        person.CountryCode = Convert.ToInt32(Console.ReadLine());
                        break;
                    case 6:
                        Console.Write("Enter new area code: ");
                        person.AreaCode = Convert.ToInt32(Console.ReadLine());
                        break;
                    case 7:
                        Console.Write("Enter new phone number: ");
                        person.Number = Convert.ToInt32(Console.ReadLine());
                        break;
                    case 8:
                        return;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a number.");
            }
        }
    }
    public static void get_ASEAN_phonebook()
    {
        List<PersonalInformation> filter_person = new List<PersonalInformation>();
        List<int> choices = new List<int>();
        List<string> country_names = new List<string>();

        while (true)
        {
            Console.WriteLine("From which country:");
            Console.WriteLine("[1] Malaysia");
            Console.WriteLine("[2] Indonesia");
            Console.WriteLine("[3] Philippines");
            Console.WriteLine("[4] Singapore");
            Console.WriteLine("[5] Thailand");
            Console.WriteLine("[6] ALL");
            Console.WriteLine("[0] None More Country");
            Console.Write("Enter choice: ");

            if (int.TryParse(Console.ReadLine(), out int choice))
            {
                if (choice == 0)
                {
                    break;
                }
                else if (choice == 6)
                {
                    choices = new List<int> { 1, 2, 3, 4, 5 };
                    break;
                }
                else if (choice > 0 && choice < 6)
                {
                    choices.Add(choice);
                }
                else
                {
                    Console.WriteLine("Invalid Number.");
                }
            }
            else
            {
                Console.WriteLine("Invalid Input.");
            }
        }

        foreach (var choice in choices)
        {
            var keyValuePair = OtherInformation.ASEANcountries.ElementAt(choice - 1);

            int countryCode = keyValuePair.Key;
            string countryName = keyValuePair.Value;
            country_names.Add(countryName);

            filter_person.AddRange(OtherInformation.get_Phonebook().Where(person => person.CountryCode == countryCode));
        }

        if (filter_person.Count > 0)
        {
            Console.WriteLine($"List of People in {string.Join(", ", country_names)}");

            foreach (PersonalInformation person in filter_person)
            {
                Console.WriteLine($"Student Number: {person.StudentNumber}");
                Console.WriteLine($"Name: {person.Surname}, {person.FirstName}");
                Console.WriteLine($"Occupation: {person.Occupation}");
                Console.WriteLine($"Gender: {person.Gender}");
                Console.WriteLine($"Country Code: {person.CountryCode}");
                Console.WriteLine($"Area Code: {person.AreaCode}");
                Console.WriteLine($"Phone Number: {person.Number}");
                Console.WriteLine();
            }
        }
        else
        {
            Console.WriteLine($"There is No Person in {string.Join(", ", country_names)}:");
        }
    }
}