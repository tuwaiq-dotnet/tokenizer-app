using System;
namespace TokenizerApp
{
	public class WhiteSpaceTokenzier : Tokenizable
	{
		public override bool tokenizable(Tokenizer t)
		{
			return t.hasMore() && Char.IsWhiteSpace(t.peek());
		}

		public override Token tokeinze(Tokenizer t)
		{
			Token token = new Token();
			token.type = "white-space";
			token.value = "";
			token.position = t.currentPosition;
			token.lineNumber = t.lineNumber;
			while (t.hasMore() && Char.IsWhiteSpace(t.peek()))
			{
				token.value += t.next();
			}

			return token;
		}
	}
}
