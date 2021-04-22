/*
 * Tuwaiq .NET Bootcamp
 * 
 * Authors
 * 
 *  Younes Alturkey
 *  Abdulrahman Bin Maneea
 *  Abdullah Albagshi
 *  Ibrahim Alobaysi
 */

using System;

namespace TokenizerApp
{
    public class Program
    {
        // Driver code
        public static void Main(string[] args)
        {
            try
            {
                string[] testCases = new string[]
                {
                    "123",
                    "-125.516",
                    "0x01010",
                    "10e+5",
                    "-0xe50",
                    "-0x10FcbA5e-2",
                    "-0B101010",
                    "0O01110101",
                    "10101010",
                    "3.25E+5",
                    "0xAbcE-20",
                    "-303051.21561e5",
                    "3.25E+5",
                    "0xAbcE-20",
                    "0b010",
                    "0xAdce+5",
                    "1235Ul",
                    "0b10101Ul",

                };

                NumberTokenizer numberTokenizer;
                Tokenizer t;
                Token token;

                Console.WriteLine($"{"Tokenized",-30}Type");

                foreach (string str in testCases)
                {
                    numberTokenizer = new NumberTokenizer();
                    t = new Tokenizer(new Input(str), new Tokenizable[] { });
                     token = numberTokenizer.tokenize(t);

                     Console.WriteLine($"{token.Value,-30}{numberTokenizer.Type}");
                }


            } catch (Exception error)
            {
                Console.WriteLine(error.Message);
            }
        }
    }
}