using System;
using System.Collections.Generic;

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
	public class Tokenizer
	{
		public List<Token> tokens;
		public bool enableHistory;
		public Input input;

		public Tokenizer(string source, Tokenizable[] handlers) { this.input = new Input(source); }
		public Tokenizer(Input source, Tokenizable[] handlers) { this.input = source; }

		public Token tokenize() { return null; }

		public List<Token> all() { return null; }
	}
}
