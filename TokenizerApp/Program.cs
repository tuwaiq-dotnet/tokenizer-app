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
            Input input = new Input("This is Younes and I'm buTTTTTTTmbTed!");

            try
            {
                Console.WriteLine(input.frequencyOf('T'));
            } catch(Exception error)
            {
                Console.WriteLine(error.Message);
            }

            //string input = "\"this is args string\" |mewo || HELLo & jaw && 55 _ioig var base /*dzdwdwdw*/ || | && & ";
            //Tokenizer tokenizer = new Tokenizer(input);
            //// Inject handlers and print tokens
            //tokenizer.print(new Tokenizable[]
            //{
            //    new CommentTokenzier(),
            //    new LogicalOpsTokenizer(),
            //    new BitwiseTokenizer(),
            //    new KeywordsTokenizer(),
            //    new IdTokenzier(),
            //    new NumberTokenzier(),
            //    new WhiteSpaceTokenzier(),
            //    new StringTokenizer()
            //});

        }
    }
}