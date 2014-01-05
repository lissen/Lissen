using System;
using System.Collections.Generic;

namespace Lissen
{
    public class Parser
    {
        private Queue<string> tokens;

        public Symbol Parse(string rawString)
        {
            string preparedString = rawString.Replace("(", " ( ").Replace(")", " ) ").Trim();
            string[] splittedString = preparedString.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            this.tokens = new Queue<string>(splittedString);

            return ParseTokens();
        }

        private Symbol ParseTokens()
        {
            if (tokens.Count==0) throw new Exception("unexpected EOF");

            string token = tokens.Dequeue();

            if(token == "(") {
                List list = new List();
                while(tokens.Peek() != ")") {
                    list.Add(ParseTokens());
                }
                tokens.Dequeue();
                return list;
            }
            else if(token == ")")
	        {
                 throw new Exception("unexpected )");   
	        }
            else return Atom.s(token);
        }
    }
}
