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
//REV01 - 2023/11/22 - Refactoring code

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

            char[] chars = name.ToCharArray(); //Convert the string to an array of chars

            for (int i = chars.Length - 1; i >= 0; i--) {
                nameReverse += chars[i];    //Revert the array and save it in a new string
            }

            Console.WriteLine($"\nUser's name: {name}");
            Console.WriteLine($"User's reverse name: {nameReverse}");

            if (nameReverse.ToLower() == name.ToLower()) {  //Checkin if name is a palindrome
                Console.WriteLine($"\n{name} is a palindrome.");
            } else {
                Console.WriteLine($"\n{name} is not a palindrome.");
            }

            //Call method the read a user input as string
            creditCardString = UserInputString("\nPlease enter your credit card: ");

            try {
                char[] charsNumbers = creditCardString.ToCharArray();   //Convert the string to an array of chars
                int[] ints = new int[charsNumbers.Length];  //Create an array of ints of the same size of the array of chars
                int sum = 0;

                if (charsNumbers.Length != 16) {    //Checking if the credit card number has 16 digits
                    throw new ArgumentOutOfRangeException("Credit card number is invalid.");
                }

                for (int i = 0; i < charsNumbers.Length; i++) {
                    if (!char.IsDigit(charsNumbers[i])) { //Checking if all characteres are digits
                        throw new ArgumentOutOfRangeException("Credit card number is invalid.");
                    } else {
                        ints[i] = charsNumbers[i] - '0';    //Converting the array of chars into an array of ints
                    }
                }

                for (int i = 0; i < ints.Length - 1; i++) {
                    if (i % 2 == 0) {   //Check if index of the number is even
                        string auxString="" + 2 * ints[i]; //For even index numbers, multiply if for 2
                        char[] auxChar = auxString.ToCharArray();   //Convert auxChar to an array of chars

                        foreach (var item in auxChar) {
                            sum = sum + (item - '0');   //Add each digit to the sum
                        }   
                    } else {
                        sum += ints[i]; //Add odd index numbers to the sum
                    }
                }

                digit = 10 - (sum % 10); //Checking what must be the last digit of the credit card

                if (digit != ints[15]) { //Check if last digit of the credit card is equal the calculated digit
                    throw new ArgumentOutOfRangeException("Credit card number is invalid.");
                } else {
                    Console.WriteLine("Credit card accepted!"); //Credit card number is approved
                }
            } catch (ArgumentOutOfRangeException ex) {
                Console.WriteLine(ex.ParamName);
            } finally {
                Console.WriteLine("\nThanks for using this application!");
            }
        }
    }
}
