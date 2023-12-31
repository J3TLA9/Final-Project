﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASEANphonebook
{
    class main
    {
        static void Main(string[] args)
        {
            Menu();
        }

        static void Menu()
        { 
            while (true)
            {
                Console.WriteLine("\nMain Menu:");
                Console.WriteLine("[1] Store to ASEAN phonebook");
                Console.WriteLine("[2] Edit entry in ASEAN phonebook");
                Console.WriteLine("[3] Search ASEAN phonebook by country");
                Console.WriteLine("[4] Exit");
                Console.Write("\nEnter number of choice: ");
                if (int.TryParse(Console.ReadLine(), out int choice))
                {
                    switch (choice)
                    {
                        case 1:
                            Functions.to_ASEAN_phonebook();
                            break;
                        case 2:
                            Functions.edit_ASEAN_phonebook();
                            break;
                        case 3:
                            Functions.get_ASEAN_phonebook();
                            break;
                        case 4:
                            return;
                        default:
                            Console.WriteLine("Invalid choice. Please try again.\n");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a number.\n");
                }
            }
        }
    }
}
