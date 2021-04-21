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
	public class Token
	{
		public int Position { set; get; }
		public int lineNumber { set; get;  }
		public string Type { set; get;  }
		public string Value { set; get; }

		public Token(int position, int lineNumber, string type, string value) { }
	}
}
