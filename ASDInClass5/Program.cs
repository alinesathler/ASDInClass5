using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Aline Sathler Delfino - InClass5
//Name of Project: Manipulating strings and number
//Purpose: C# console application to manipulate strings and number as asked
//Revision History:
//REV00 - 2023/11/22 - Initial version

namespace ASDInClass5 {
    internal class Program {
        //User's input
        //Method UserInputString to read a string
        static string UserInputString(string prompt) {
            string userInput;

            Console.Write(prompt); //Ask the user an input

            Console.ForegroundColor = ConsoleColor.Yellow;  //Change text color the yellow
            userInput = Console.ReadLine(); //Read the input
            Console.ResetColor();   //Reset color

            return userInput;
        }

        static void Main() {
            string name, nameReverse = "", creditCardString;
            int digit;

            //Call method the read a user input as string
            name = UserInputString("Please enter your name: ");
            char[] chars = name.ToCharArray();

            for (int i = chars.Length - 1; i >= 0; i--) {
                nameReverse += chars[i];
            }

            Console.WriteLine($"\nUser's name: {name}");
            Console.WriteLine($"User's reverse name: {nameReverse}");

            if (nameReverse == name) {
                Console.WriteLine($"\n{name} is a palindrome.");
            } else {
                Console.WriteLine($"\n{name} is not a palindrome.");
            }

            //creditCard = UserInputDouble("\nPlease enter your credit card: ");
            creditCardString = UserInputString("\nPlease enter your credit card: ");

            try {
                char[] charsNumbers = creditCardString.ToCharArray();
                int[] ints = new int[charsNumbers.Length];
                int sum = 0;

                if (charsNumbers.Length != 16) {
                    throw new ArgumentOutOfRangeException("Credit card number is invalid.");
                }

                for (int i = 0; i < charsNumbers.Length; i++) {
                    if (!char.IsDigit(charsNumbers[i])) {
                        throw new ArgumentOutOfRangeException("Credit card number is invalid.");
                    } else {
                        ints[i] = charsNumbers[i] - '0';
                    }
                }

                for (int i = 0; i < ints.Length - 1; i++) {
                    if (i % 2 == 0) {
                        string auxString="";
                        if (2 * ints[i] < 9) {
                            sum += 2 * ints[i];
                        } else {
                            //int aux = 2 * ints[i];
                            auxString = "" + 2 * ints[i];
                        }

                        char[] auxChar = auxString.ToCharArray();

                        foreach (var item in auxChar) {
                            sum = sum + (item - '0');
                        }   
                    } else {
                        sum += ints[i];
                    }
                }

                digit = 10 - (sum % 10);

                if (digit != ints[15]) {
                    throw new ArgumentOutOfRangeException("Credit card number is invalid.");
                } else {
                    Console.WriteLine("Credit card accepted!");
                }

            } catch (ArgumentOutOfRangeException ex) {
                Console.WriteLine(ex.ParamName);
            }
        }
    }
}
