using System;
namespace TokenizerApp
{
	public abstract class Tokenizable
	{
		public abstract bool tokenizable(Tokenizer tokenizer);
		public abstract Token tokeinze(Tokenizer tokenizer);
	}
}
