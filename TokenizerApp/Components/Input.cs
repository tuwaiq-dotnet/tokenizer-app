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
    public class Input
    {
        public string input;
        public int length;
        public int position;
        public int nextPosition;
        public int lineNumber;
        public char currentValue;

        public Input(string input)
        {
            this.input = input;
            this.length = input.Length;
            this.position = -1;
            this.nextPosition = 0;
            this.lineNumber = 1;
            this.currentValue = '\0';
        }

        public Input step(int numOfSteps = 1)
        {
            return this;
        }

        public Input reset()
        {
            return this;
        }

        public char peek(int numOfSteps = 1)
        {
            return '\0';
        }

        public bool hasMore(int numOfSteps = 1)
        {
            return true;
        }
    }
}
