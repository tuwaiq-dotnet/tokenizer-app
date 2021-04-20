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
    public class LogicalOpsTokenizer : Tokenizable
    {

        private bool operatorAssertion(char op, Tokenizer t)
        {
            int i = t.currentPosition;
            t.next();
            if (!t.hasMore())
            {
                t.currentPosition = i;
                return false;
            }
            else
            {
                bool res = t.peek() == op;
                t.currentPosition = i;
                return res;
            }
        }
        public override bool tokenizable(Tokenizer t)
        {

            if (!t.hasMore()) return false;
            switch (t.peek())
            {
                case '!':
                    return true;
                case '&':
                    return operatorAssertion('&', t);
                case '|':
                    return operatorAssertion('|', t);
                default:
                    return false;
            }
        }

        public override Token tokeinze(Tokenizer t)
        {
            Token token = new Token();
            token.type = "logical operator";
            token.value = "" + t.next();
            token.position = t.currentPosition;
            token.lineNumber = t.lineNumber;
            switch (t.peek())
            {
                case '&':
                    token.value += t.next();
                    break;
                case '|':
                    token.value += t.next();
                    break;
            }
            return token;
        }
    }
}
