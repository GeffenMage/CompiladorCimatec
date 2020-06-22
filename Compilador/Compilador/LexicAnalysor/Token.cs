using System;
using System.Collections.Generic;
using System.Text;

namespace Compilador.LexicAnalysor
{
    public class Token
    {
        public TokenKind Kind { get; }
        public int Line { get; }
        public string Text { get; }
        public object Value { get; }
        
        public Token(TokenKind kind, int line, string text, object value)
        {
            Kind = kind;
            Line = line;
            Text = text;
            Value = value;
        }
    }
}
