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
            string case1 = "\"this is args string\" 55 _ioig var base /*dzdwdwdw*/ ";

            Tokenizer t = new Tokenizer(case1);
            Tokenizable[] handlers = new Tokenizable[] {
                new IdTokenzier(),
                new NumberTokenzier(),
                new WhiteSpaceTokenzier(),
                new StringTokenizer(),
                new KeywordsTokenizer(),
                new CommentTokenzier()
            };

            Console.WriteLine($"Source: {case1}\n");
            Console.WriteLine("Token\t\t\t\t\tType");

            Token token = null;

            do
            {
                try
                {
                    token = t.tokinze(handlers);

                    if(token != null)
                        Console.WriteLine($"{token.value}\t\t\t\t\t{token.type}");

                }
                catch (Exception e)
                {
                    Console.WriteLine($"Exception: {e.Message}");
                }
            }
            while (token != null);
        }
    }
}