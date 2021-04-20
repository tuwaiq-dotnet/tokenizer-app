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
	public class StringTokenizer : Tokenizable
	{
		public override bool tokenizable(Tokenizer t)
		{
			return t.hasMore() && t.peek() == '\"' && (t.indexOfChar('\"') != t.lastIndexOfChar('\"'));
		}

		public override Token tokeinze(Tokenizer t)
		{
			Token token = new Token();
			token.type = "string";
			token.value += t.next();
			token.position = t.currentPosition;
			token.lineNumber = t.lineNumber;
			while (t.hasMore() && t.peek() != '\"')
			{
				token.value += t.next();
			}

			token.value += t.next();

			return token;
		}
	}
}
