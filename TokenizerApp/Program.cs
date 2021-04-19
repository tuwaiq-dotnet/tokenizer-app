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
            string case1 = "\"this is args string\" 55 _ioig var base /*drgdrgdrgdr8*/ ";

            Tokenizer t = new Tokenizer(case1);
            Tokenizable[] handlers = new Tokenizable[]
            {
                new CommentTokenzier(),
                new BitwiseTokenizer(),
                new KeywordsTokenizer(),
                new IdTokenzier(),
                new NumberTokenzier(),
                new WhiteSpaceTokenzier(),
                new StringTokenizer()
            };

            Console.WriteLine($"Source: {case1}\n");
            Console.WriteLine("Token\t\t\t\tType");

            Token token = null;

            do
            {
                try
                {
                    token = t.tokinze(handlers);

<<<<<<< HEAD
                    if(token != null)
                        Console.WriteLine($"{token.value}\t\t\t\t{token.type}");
=======
                    if (token != null)
                        Console.WriteLine($"{token.value,-10}{token.type,30}");

>>>>>>> 49c397a2af25a49e4b885403817f173c3bc0578d
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