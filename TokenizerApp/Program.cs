using System;

namespace TokenizerApp
{


	public class Program
	{
		// Driver code
		public static void Main(string[] args)
		{
			string case1 = "_id ali 123 a3l 924";

			Tokenizer t = new Tokenizer(case1);
			Tokenizable[] handlers = new Tokenizable[] { new IdTokenzier(), new NumberTokenzier(), new WhiteSpaceTokenzier() };
			Token token = t.tokinze(handlers);

			Console.WriteLine("Source: " + case1 + "\n");

			Console.Write("Tokens: {");
			while (token != null)
			{
				Console.Write(token.value + ":" + token.type);
				token = t.tokinze(handlers);
				if (token != null)
					Console.Write(", ");
			}

			Console.WriteLine("}");
		}
	}
}