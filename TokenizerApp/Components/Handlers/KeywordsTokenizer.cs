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
    public class KeywordsTokenizer : Tokenizable
    {
        string[] keywords = { "abstract", "base", "break", "switch", "checked", "class", "const", "continue",
            "default", "do", "event", "extern", "for", "goto", "in", "interface", "internal", "is", "namespace",
            "null", "out", "override", "params", "private", "protected", "public", "readonly", "ref", "return",
            "sealed", "static", "switch", "this", "throw", "unchecked", "unsafe", "using", "virtual", "volatile",
            "while", "add", "ascending", "async", "by", "descending", "equals", "get", "init", "into", "on", "remove",
            "set", "value", "var", "when", "yield" };
        string key = "";
        public override bool tokenizable(Tokenizer t)
        {
            //Console.WriteLine("Entered");
            int currentPostion = t.getCurrentPostion();
            while (t.hasMore() && t.peek() != ' ')
            {
                key += t.next();
            }
            if (key.Length > 1)
            {
                //Console.WriteLine(key);
                foreach (var k in keywords)
                {
                    if (key == k)
                        return true;
                }
            }
            t.setCurrentPostion(currentPostion);
            key = "";
            return false;
        }
        public override Token tokeinze(Tokenizer t)
        {
            Token token = new Token();
            token.type = "keyword";
            token.value = key;
            token.position = t.currentPosition;
            token.lineNumber = t.lineNumber;
            key = "";
            return token;
        }
    }
}
