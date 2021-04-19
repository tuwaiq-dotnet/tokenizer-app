using System;
namespace TokenizerApp
{
	public class IdTokenzier : Tokenizable
	{
		public override bool tokenizable(Tokenizer t)
		{
			return t.hasMore() && (Char.IsLetter(t.peek()) || t.peek() == '_');
		}

		public override Token tokeinze(Tokenizer t)
		{
			Token token = new Token();
			token.type = "id";
			token.value = "";
			token.position = t.currentPosition;
			token.lineNumber = t.lineNumber;
			while (t.hasMore() && (Char.IsLetterOrDigit(t.peek()) || t.peek() == '_'))
			{
				token.value += t.next();
			}

			return token;
		}
	}
}
