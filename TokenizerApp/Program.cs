/*
 * Tuwaiq .NET Bootcamp
 * Authors
 * Younes Alturkey
 * Abdulrahman Bin Maneea
 * Abdullah Albagshi
 * Ibrahim Alobaysi
 */
using System;

namespace TokenizerApp
{
    public class Program
    {
        // Driver code
        public static void Main(string[] args)
        {
            string case1 = "_id ali 123 - a3l 924";

            Tokenizer t = new Tokenizer(case1);
            Tokenizable[] handlers = new Tokenizable[] { new IdTokenzier(), new NumberTokenzier(), new WhiteSpaceTokenzier() };
            Console.WriteLine($"Source: {case1}");
            Console.WriteLine("Token\tType");

            Token token = null;
            do
            {
                try
                {
                    token = t.tokinze(handlers);
                    Console.WriteLine($"{token.value}\t{token.type}");

                }
                catch (System.Exception e)
                {
                    System.Console.WriteLine($"Exception: {e.Message}");
                }
            }
            while (token != null);
        }
    }
}