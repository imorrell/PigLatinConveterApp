/*Prorammer: Ivoire Morrell
 *Program Name: Pig Latin App
 *Date: 10 - 18 - 19
 *Synopsis: The Pig Latin Application takes a sentence entered 
 *by a user and converts the sentence into Pig Latin
 */

using System;

namespace PigLatinCapStone
{
    class Program
    {
        static void Main(string[] args)
        {
            //intialize variables
            string sentence;
            bool ok = true;
            bool noWord = true;

            //display a wlecome message to the user
            Console.WriteLine("Welcome to the Pig Latin Translator \n");

            //wrap code in while loop to track if the user would like to enter another sentence
            while (ok)
            {
                //wrap code in another while loop to check if the user enter a sentence or not
                while (noWord == true)
                {

                    //promt the user to enter a sentence they would like to translate
                    Console.WriteLine("Enter a word or sentence you would like to translate. \n");

                    sentence = Console.ReadLine();

                    if (sentence == "")
                    {
                        //The user did not enter a sentence. Prompt them to reenter
                        Console.WriteLine("You did not enter a word! Please enter a word or sentence \n");

                        noWord = true;
                    }
                    else
                    {
                        Console.WriteLine();

                        //pass the sentence to the PigLatinConverter method
                        PigLatinConvert(sentence);

                        Console.WriteLine();
                        noWord = false;
                    }
                }

                //ask the user if they would like to enter another sentence
                Console.WriteLine();
                ok = getContinue();
                noWord = true;
                Console.WriteLine();
            }

            //Tell the user goodbye
            Console.WriteLine("Good Bye");
        }

        //the PigLatinConvert takes a sentence entered by user as 
        //a parameter and prints out a the sentence in pig latin
        public static void PigLatinConvert(string sentence)
        {
            //create an array varible that breaks each sentence passed from the user in chunks
            string[] sentenceArray = sentence.Split();
            
            //create a variable to hold the new string sentence for pig latin conversion
            string newWord = "";

            //create a firstLetter variable that removes first letter from a sentence
            string subString = "";

            //use for each loop to process through each sentence in the sentence array
            foreach (string word in sentenceArray)
            {
                //reset the substring back to empty in order to prevent it from printing twice
                subString = "";

                //use if statement to determine what the first letter of the sentence begins with
                if (word.StartsWith("a", StringComparison.OrdinalIgnoreCase) || word.StartsWith("e", StringComparison.OrdinalIgnoreCase)
                    || word.StartsWith("i", StringComparison.OrdinalIgnoreCase) || word.StartsWith("o", StringComparison.OrdinalIgnoreCase)
                    || word.StartsWith("u", StringComparison.OrdinalIgnoreCase))
                {
                    //append way to the end of the string
                    newWord = string.Concat(word, "way");

                    //display the new sentence
                    Console.Write(newWord + " ");
                    

                }

                else
                {
                    //use for each loop to loop through the sentence until you reach a vowel
                    for (int i = 0; i < word.Length; i++)
                    {
                        if (word[i] == 'a' || word[i] == 'e' || word[i] == 'i' || word[i] == 'o' || word[i] == 'u')
                        {
                            newWord = word.Substring(i);
                            break;
                        }
                        else
                        {
                            //append the letter to the subString variable and remove from the sentence
                            subString += word[i];
                        }
                    }

                    //add the substring to the end of the sentence
                    newWord = newWord + subString + "ay";

                    //display the new sentence
                    Console.Write(newWord + " ");
                    
                }

            }
        }

        //this method is used to determine if the user wants to continue within a loop
        public static bool getContinue()
        {
            //create variables
            String choice;
            bool ok = true;
            bool result = true;

            //create while loop to determine if user wants to continue
            while (ok)
            {
                Console.WriteLine("Translate another sentence? (y/n): \n");

                //retrieve user input
                choice = Console.ReadLine();

                //determine the users input and return corresponding message
                if (choice.Equals("y", StringComparison.OrdinalIgnoreCase))
                {
                    //user wants to continue. exit the while loop and return true
                    ok = false;
                    result = true;
                }
                else if (choice.Equals("n", StringComparison.OrdinalIgnoreCase))
                {
                    //user does not want to continue
                    ok = false;
                    result = false;
                }
                else
                {
                    //user did not enter y or n
                    Console.WriteLine("Error! Please enter Y or N. Please enter correct input \n");

                }

            }

            return result;
        }
    }
}
