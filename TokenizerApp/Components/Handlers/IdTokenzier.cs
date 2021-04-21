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
    public class IdTokenizer : Tokenizable
    {
        private List<string> keywords = new List<string> {
            "let","var","if","else","for","while","fun","return"
        };
        private bool isKeyword(string value)
        {
            return this.keywords.Contains(value);
        }
        public override bool tokenizable(Tokenizer t)
        {
            char currentCharacter = t.input.peek();
            //Console.WriteLine(currentCharacter);
            return Char.IsLetter(currentCharacter) || currentCharacter == '_';
        }
        public override Token tokenize(Tokenizer t)
        {
            //1. initialize token
            Token token = new Token(t.input.Position, t.input.LineNumber, "identifier", "");
            //2. do action
            //loop
            char currentCharacter = t.input.peek();
            while (t.input.hasMore() && (Char.IsLetterOrDigit(currentCharacter) || currentCharacter == '_'))
            {
                token.Value += t.input.step().Character;
                currentCharacter = t.input.peek();
            }
            //3. return token
            if (this.isKeyword(token.Value))
                token.Type = "keyword";
            return token;
        }
    }
}
