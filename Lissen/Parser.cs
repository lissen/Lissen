using System;
using System.Collections.Generic;

namespace Lissen
{
    public class Parser
    {
        private Queue<string> tokens;

        public List<Sexpr> Parse(string rawString)
        {
            string preparedString = rawString.Replace("(", " ( ").Replace(")", " ) ").Trim();
            string[] splittedString = preparedString.Split(new[] { ' ', '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);

            this.tokens = new Queue<string>(splittedString);

            List<Sexpr> parsed = new List<Sexpr>();

            while (tokens.Count > 0)
            {
                parsed.Add(ParseTokens());
            }

            return parsed;
        }

        private Sexpr ParseTokens()
        {
            if (tokens.Count==0) throw new Exception("unexpected EOF");

            string token = tokens.Dequeue();

            if(token == "(") {
                List list = new List();
                while((tokens.Count >0) && (tokens.Peek() != ")")) {
                    list.Add(ParseTokens());
                }
                if (tokens.Count == 0) throw new Exception("expected )");
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
