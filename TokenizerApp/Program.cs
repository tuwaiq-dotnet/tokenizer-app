using System;

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

namespace TokenizerApp
{
    public class Program
    {
        // Driver code
        public static void Main(string[] args)
        {
            Tokenizer t = new Tokenizer(new Input("\"qkljqiejoqijeoqi2jeoqi2j\""), new Tokenizable[]
            {
                // Inject handlers here
                //new IdTokenizer()
                new StringTokenizer()
            }); ;

            Console.WriteLine(t.tokenize().Value);
        }
    }
}