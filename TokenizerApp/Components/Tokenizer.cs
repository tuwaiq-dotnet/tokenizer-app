using System;
namespace TokenizerApp
{
	public class Tokenizer
	{
		public string input;
		public int currentPosition;
		public int lineNumber;
		public Tokenizer(string input)
		{
			this.input = input;
			this.currentPosition = -1;
			this.lineNumber = 1;
		}

		public char peek()
		{
			if (this.hasMore())
			{
				return this.input[this.currentPosition + 1];
			}
			else
			{
				return '\0';
			}
		}

		public char next()
		{
			char currentChar = this.input[++this.currentPosition];
			if (currentChar == '\n')
			{
				this.lineNumber++;
			}

			return currentChar;
		}

		public bool hasMore()
		{
			return (this.currentPosition + 1) < this.input.Length;
		}

		public Token tokinze(Tokenizable[] handlers)
		{
			foreach (var t in handlers)
			{
				if (t.tokenizable(this))
				{
					return t.tokeinze(this);
				}
			}
			char c;
			if(hasMore()) c=this.next();
			else return null;
			throw new Exception($"Unexpected token {c}");
		}

		public int indexOfChar(char ch)
        {
			return input.IndexOf(ch);
        }

		public int lastIndexOfChar(char ch)
		{
			return input.LastIndexOf(ch);
		}

		public int getCurrentPostion()
		{
			return currentPosition;
		}
		public void setCurrentPostion(int currentPosition)
		{
			this.currentPosition = currentPosition;
		}
	}
}
