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
using System.Collections.Generic;

namespace TokenizerApp
{
    /*
     * UNCLEAN CODE AHEAD - BE WARNED! RUN!
     */
    public class NumberTokenizer : Tokenizable
    {
        List<char> sign = new List<char> { '-', '+' };
        List<char> decimal_digit = new List<char> { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', 'b', 'B', 'O', 'o' };
        List<char> hex_digit = new List<char> { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', 'A', 'B', 'C', 'D', 'E', 'F', 'a', 'b', 'c', 'd', 'e', 'f' };
        List<string> integer_type_suffix = new List<string> { "U", "u", "L", "l", "UL", "Ul", "uL", "ul", "LU", "Lu", "lU", "lu" };
        List<char> real_type_suffix = new List<char> { 'F', 'f', 'D', 'd', 'M', 'm' };
        private string type = "";
        public bool readDot = false;
        public bool readExponent = false;
        public bool readSign = false;

        public string Type
        {
            get
            {
                return this.type;
            }
        }

        // return true if minimum token is found
        public override bool tokenizable(Tokenizer t)
        {
            return true;
        }

        public override Token tokenize(Tokenizer t)
        {
            char currentCharacter = t.input.peek();
            char nextCharacter = t.input.peek(1);
            bool isNegative = false;

            //1. initialize token
            Token token = new Token(t.input.Position, t.input.LineNumber, "NUMBER", "");

            //handle sign case
            if(isSign(currentCharacter) && isDecimalDigit(nextCharacter))
            {
                token.Value += t.input.step().Character;
                currentCharacter = t.input.peek();
                nextCharacter = t.input.peek(1);
                isNegative = true;
            }


            //2. consume string as long as it is valid
            if (isHexaStart(currentCharacter.ToString() + nextCharacter.ToString()))
            {
                //Dude what?? I know!!!
                token.Value += t.input.step().Character;
                token.Value += t.input.step().Character;
                while (t.input.hasMore() && isHexaDigit(currentCharacter) || isExponent(currentCharacter) || isSign(currentCharacter) || isDot(currentCharacter))
                {
                    if (isDot(currentCharacter)) throw new Exception("Unexpected token");

                    if (isExponent(currentCharacter) && readExponent) throw new Exception("Unexpected token");
                    else if (isExponent(currentCharacter)) readExponent = true;

                    if (isSign(currentCharacter) && readSign) throw new Exception("Unexpected token");
                    else if (isSign(currentCharacter)) readSign = true;

                    token.Value += t.input.step().Character;
                    currentCharacter = t.input.peek();
                }
            }
            else if (isDecimalDigit(currentCharacter) || isDot(currentCharacter))
            {
                while (t.input.hasMore() && (isDecimalDigit(currentCharacter) || isDot(currentCharacter) || isExponent(currentCharacter) || isSign(currentCharacter)))
                {

                    if (isDot(currentCharacter) && readDot) throw new Exception("Unexpected token");
                    else if (isDot(currentCharacter)) readDot = true;

                    if (isExponent(currentCharacter) && readExponent) throw new Exception("Unexpected token");
                    else if (isExponent(currentCharacter)) readExponent = true;

                    if (isSign(currentCharacter) && readSign) throw new Exception("Unexpected token");
                    else if (isSign(currentCharacter)) readSign = true;

                    token.Value += t.input.step().Character;
                    currentCharacter = t.input.peek();
                }

            } else
            {
                throw new Exception("Unexpected token");
            }

            // add integer type suffix
            if (isNegative)
            {
                if (isIntegerTypeSuffix(currentCharacter))
                    token.Value += t.input.step().Character;
            } else
            {
                for (int i = 0; i < 2; i++)
                {
                    currentCharacter = t.input.peek();
                    if (isIntegerTypeSuffix(currentCharacter))
                        token.Value += t.input.step().Character;
                }
            }
            // Determine number type
            if (token.Value.Contains('e') || token.Value.Contains('e'))
                type = "Scientific Notation Number";
            else if (token.Value.Contains('x') || token.Value.Contains('X'))
                type = "Hexadecimal Number";
            else if (token.Value.Contains('b') || token.Value.Contains('B'))
                type = "Binary Number";
            else if (token.Value.Contains('o') || token.Value.Contains('O'))
                type = "Octal Number";
            else if (token.Value.Contains('.'))
                type = "Real Number";
            else
                type = "Integer Number";

            //3. return token
            return token;
        }

        public bool isDecimalDigit(char c)
        {
            return decimal_digit.Contains(c);
        }

        public bool isIntegerTypeSuffix(char c)
        {
            return integer_type_suffix.Contains(c.ToString());
        }

        public bool isRealTypeSuffix(char c)
        {
            return real_type_suffix.Contains(c);
        }

        public bool isHexaStart(string str)
        {
            return str.Equals("0x") || str.Equals("0X");
        }
        public bool isHexaDigit(char c)
        {
            return hex_digit.Contains(c);
        }

        public bool isSign(char c)
        {
            return sign.Contains(c);
        }

        public bool isExponent(char c)
        {
            return c.Equals('e') || c.Equals('E');
        }
        
        public bool isDot(char c)
        {
            return c.Equals('.');
        }

    }
}
