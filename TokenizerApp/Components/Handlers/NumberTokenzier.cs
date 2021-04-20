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
	public class NumberTokenzier : Tokenizable
	{
		public override bool tokenizable(Tokenizer t)
		{
			return t.hasMore() && Char.IsDigit(t.peek());
		}

		public override Token tokeinze(Tokenizer t)
		{
			Token token = new Token();
			token.type = "number";
			token.value = "";
			token.position = t.currentPosition;
			token.lineNumber = t.lineNumber;
			while (t.hasMore() && Char.IsDigit(t.peek()))
			{
				token.value += t.next();
			}

			return token;
		}
	}
}
