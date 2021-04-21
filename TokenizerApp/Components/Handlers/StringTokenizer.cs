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

using System;

namespace TokenizerApp
{
    public class StringTokenizer : Tokenizable
    {
        public override bool tokenizable(Tokenizer t)
        {
            return t.input.hasMore() && t.input.peek() == '\"' && (t.input.indexOf('\"') != t.input.lastIndexOf('\"'));
        }

        public override Token tokenize(Tokenizer t)
        {
            //1. initialize token
            Token token = new Token(t.input.Position, t.input.LineNumber, "string", "");
            //2. do action

            token.Value += t.input.step().Character;

            while (t.input.hasMore() && t.input.peek() != '\"')
            {
                token.Value += t.input.step().Character;
            }

            //3. return token
            token.Value += t.input.step().Character;

            return token;
        }

        public bool isString(char c, Tokenizer t)
        {
            return c == '\"' || c == '\''
                && ((t.input.indexOf('\"') != t.input.lastIndexOf('\"')) || ((t.input.indexOf('\'') != t.input.lastIndexOf('\''))));
        }
    }
}
