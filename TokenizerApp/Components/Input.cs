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
    public class Input
    {
        private readonly string input;
        private readonly int length;
        private int position;
        private int lineNumber;
        //Properties
        public int Length
        {
            get
            {
                return this.length;
            }
        }
        public int Position
        {
            get
            {
                return this.position;
            }
        }
        public int NextPosition
        {
            get
            {
                return this.position + 1;
            }
        }
        public int LineNumber
        {
            get
            {
                return this.lineNumber;
            }
        }
        public char Character
        {
            get
            {
                if (this.position > -1) return this.input[this.position];
                else return '\0';
            }
        }
        public Input(string input)
        {
            this.input = input;
            this.length = input.Length;
            this.position = -1;
            this.lineNumber = 1;
        }
        public bool hasMore(int numOfSteps = 1)
        {
            if (numOfSteps <= 0) throw new Exception("Invalid number of steps");
            return (this.position + numOfSteps) < this.length;
        }
        public bool hasLess(int numOfSteps = 1)
        {
            if (numOfSteps <= 0) throw new Exception("Invalid number of steps");
            return (this.position - numOfSteps) > -1;
        }
        //callback -> delegate
        public Input step(int numOfSteps = 1)
        {
            if (this.hasMore(numOfSteps))
                this.position += numOfSteps;
            else
            {
                throw new Exception("There is no more step");
            }
            return this;
        }
        public Input back(int numOfSteps = 1)
        {
            if (this.hasLess(numOfSteps))
                this.position -= numOfSteps;
            else
            {
                throw new Exception("There is no more step");
            }
            return this;
        }
        public Input reset()
        {
            this.position = -1;
            this.lineNumber = 1;
            return this;
        }
        public char peek(int numOfSteps = 1)
        {
            if (this.hasMore(numOfSteps))
                return this.Character;
            else
            {
                throw new Exception("There is no more step");
            }
        }
        public char next()
        {
            return this.step(1).Character;
        }
        public int indexOf(char ch)
        {
            int firstIndex = -1;
            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == ch)
                    return i;
            }
            return firstIndex;
        }
        public int lastIndexOf(char ch)
        {
            int lastIndex = -1;
            for(int i = 0; i < input.Length; i++)
            {
                if (input[i] == ch)
                    lastIndex = i;
            }
            return lastIndex;
        }
        public int frequencyOf(char ch)
        {
            int numberOfFrequency = 0;
            foreach (char character in input)
            {
                if (character == ch)
                    numberOfFrequency++;
            }
            return numberOfFrequency;
        }
        public bool contains(char ch)
        {
            foreach(char character in input)
            {
                if (character == ch)
                    return true;
            }

            return false;
        }
    }
}
