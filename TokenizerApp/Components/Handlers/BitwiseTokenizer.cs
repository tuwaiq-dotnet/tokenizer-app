using System;
namespace TokenizerApp
{
    public class BitwiseTokenizer : Tokenizable
    {

        private bool shiftAssertion(bool shiftRight, Tokenizer t)
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
                t.currentPosition = i;
                return t.peek() == (shiftRight?'>':'<');
            }
        }
        public override bool tokenizable(Tokenizer t)
        {

            if (!t.hasMore()) return false;
            switch (t.peek())
            {
                case '|':
                    return true;
                case '&':
                    return true;
                case '~':
                    return true;
                case '^':
                    return true;
                case '<':
                    return shiftAssertion(false, t);
                case '>':
                    return shiftAssertion(true, t);
                default:
                    return false;
            }
        }

        public override Token tokeinze(Tokenizer t)
        {
            Token token = new Token();
            token.type = "bitwise operator";
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
