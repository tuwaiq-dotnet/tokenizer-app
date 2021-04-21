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
            Tokenizer t = new Tokenizer(new Input("how are you"), new Tokenizable[] { new IdTokenizer() });
            Console.WriteLine(t.tokenize().Value);
        }
    }
}