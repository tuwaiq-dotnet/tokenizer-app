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
    public class CommentTokenzier : Tokenizable
    {
        public override bool tokenizable(Tokenizer t)
        {
            if (t.hasMore() && t.peek() == '/')
            {
                t.next();
                if (t.hasMore() && (t.peek() == '/' || t.peek() == '*'))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            return t.hasMore() && t.peek() == '/';
        }
        public override Token tokeinze(Tokenizer t)
        {
            Token token = new Token();
            token.type = "comment";
            token.value = "/";
            token.position = t.currentPosition;
            token.lineNumber = t.lineNumber;
            while (t.hasMore())
            {
                if (t.peek() == '\n')
                    break;
                if (t.peek() == '/' && token.value.EndsWith('*'))
                {
                    token.value += t.next();
                    break;
                }
                token.value += t.next();
            }
            return token;
        }
    }
}
