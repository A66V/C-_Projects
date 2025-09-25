using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projects
{
    internal class Randomization
    {
        public const string Capital_Letters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        public const string Small_Letters = "abcdefghijklmnopqrstuvwxyz";
        public const string Numbers = "0123456789";
        public const string Special_Characters = "~@!#$$%^&*()-_?<>";
        
        public void Run()
        {
            while (true)
            {
                try
                {
                    Console.WriteLine("----------------------------------------------------------------------------------------------------------------------");
                    Console.WriteLine("\t\t\t\t\t\t ----- Random Generator ------\t\t\t\t\t\t");
                    Console.WriteLine("----------------------------------------------------------------------------------------------------------------------");

                    Console.WriteLine("Enter Number of the choice you want : ");
                    Console.WriteLine("[1] Generate a Random Number \t\t\t [2] Generate a Random String  ");
                    int selected_choice = int.Parse(Console.ReadLine());

                    if (selected_choice == 1)
                    {
                        Console.Write("Enter the Minimum Boundry :");
                        int min = int.Parse(Console.ReadLine());
                        Console.Write("Enter the Maximum Boundry : ");
                        int max = int.Parse(Console.ReadLine());
                        GenerateRandomNumber(min, max);
                    }
                    else if (selected_choice == 2)
                    {
                        Console.Write("Enter The Length of string you want to generate it :");
                        int len = int.Parse(Console.ReadLine());
                        if (len <= 0)
                            throw new Exception(" Length Of The String Must Be Positive Number !");
                        else
                        {
                            GenerateRandomString(len);
                        }
                    }
                    else
                    {
                        throw new Exception("Invalid Option ! , Enter 1 OR 2 only .");
                    }

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    //Console.WriteLine(ex.ToString());

                }
            }
        }

        public void GenerateRandomNumber(int min, int max)
        {
            Random rnd = new Random();
            int value = rnd.Next(min, max);
            Console.WriteLine($"Random Number  = {value}");
        }

        public void GenerateRandomString(int len)
        {
            StringBuilder builder = new StringBuilder();
            StringBuilder Builder_ = new StringBuilder();
            builder.Capacity = (2 * (Capital_Letters.Length)) + Numbers.Length + Special_Characters.Length;
            Builder_.Capacity = len;
            Console.WriteLine("-----------------------------------------------------------------");
            Console.WriteLine("The Total Capacity of the StringBuilder is = " + builder.Capacity);
            Console.WriteLine("-----------------------------------------------------------------");
            //  [1]  Marking the Flags Based On the Choices of The User 

            Console.Write("Are you Want Numbers (yes/no) :");
            string choice_num = Console.ReadLine();
            bool Contain_Numbers = choice_num == "yes" ? true : false;
            Console.Write("Are you Want Small Characters (yes/no) :");
            string choice_small_chars = Console.ReadLine();
            bool Contain_small_chars = choice_small_chars == "yes" ? true : false;
            Console.Write("Are you Want Capital Letters (yes/no) :");
            string choice_capital_chars = Console.ReadLine();
            bool Contain_capital_chars = choice_capital_chars == "yes" ? true : false;
            Console.Write("Are you Want Special Characters (yes/no) :");
            string choice_special_chars = Console.ReadLine();
            bool Contain_Special_Chars = choice_special_chars == "yes" ? true : false;
            //Console.WriteLine($"Containg Numbers = {Contain_Numbers}");
            //Console.WriteLine($"Containg Small Characters = {Contain_small_chars}");
            //Console.WriteLine($"Containg Capital Characters = {Contain_capital_chars}");
            //Console.WriteLine($"Containg Special Characters = {Contain_Special_Chars}");

            //Console.WriteLine("-----------------------------------------");
            //Console.WriteLine("The Length of The String is = " + len);


            //   [2] Combination : 
            // in case the user only want Capital Letters in Generated String.
            string[] total_text = { Capital_Letters, Small_Letters, Numbers, Special_Characters };
            try
            {
                if (Contain_capital_chars && (!Contain_small_chars) && (!Contain_Special_Chars) && (!Contain_Numbers))
                {
                    builder.Append(string.Join("", total_text, 0, 1));
                }
                else if ((Contain_small_chars) && (!Contain_capital_chars) && (!Contain_Special_Chars) && (!Contain_Numbers))
                {
                    builder.Append(string.Join("", total_text, 1, 1));
                }
                else if ((Contain_capital_chars) && (Contain_small_chars) && (!Contain_Numbers) && (!Contain_Special_Chars))
                {
                    builder.Append(string.Join("", total_text, 0, 2));
                }
                else if ((Contain_Numbers) && (Contain_capital_chars) && (!Contain_small_chars) && (!Contain_Special_Chars))
                {
                    builder.Append(string.Join("", total_text[0], total_text[2]));
                }
                else if ((Contain_Numbers) && (Contain_small_chars) && (!Contain_capital_chars) && (Contain_Special_Chars))
                {
                    builder.Append(string.Join("", total_text[1], total_text[2]));
                }
                else if ((Contain_capital_chars) && (Contain_Special_Chars) && (!Contain_small_chars) && (!Contain_Numbers))
                {
                    builder.Append(string.Join("", total_text[0], total_text[3]));
                }
                else if ((Contain_small_chars) && (Contain_Special_Chars) && (!Contain_Numbers) && (!Contain_capital_chars))
                {
                    builder.Append(string.Join("", total_text[1], total_text[3]));
                }
                else if ((Contain_Numbers) && (Contain_Special_Chars) && (!Contain_capital_chars) && (!Contain_small_chars))
                {
                    builder.Append(string.Join("", total_text[2], total_text[3]));
                }
                else if ((Contain_capital_chars) && (Contain_small_chars) && (Contain_Special_Chars) && (!Contain_Numbers))
                {
                    builder.Append(string.Join("", total_text[0], total_text[1], total_text[3]));
                }
                else if ((Contain_capital_chars) && (Contain_small_chars) && (Contain_Numbers) && (!Contain_Special_Chars))
                {
                    builder.Append(string.Join("", total_text[0], total_text[1], total_text[2]));
                }
                else if ((Contain_capital_chars) && (Contain_small_chars) && (Contain_Numbers) && (Contain_Special_Chars))
                {
                    builder.Append(string.Join("", total_text));
                }
                else
                {
                    throw new Exception("Must Select At Least Two Options !");
                }
                // Debugging 
                Console.WriteLine($"Content of the String Builder is {builder.ToString()}");
                Random rnd = new Random();
                for (int i = 0; i < len; i++)
                {
                    int RandomIndX = rnd.Next(0, builder.Length - 1);
                    Builder_.Append(builder[RandomIndX]);
                }
                Console.WriteLine("Random String = " + " " + Builder_.ToString());
                Console.WriteLine($"The Length of The Random String = {Builder_.Length}");
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine(ex.Message);
                //Console.WriteLine(ex.ToString());
                Console.ForegroundColor = ConsoleColor.White;

            }
        }
    }
}
