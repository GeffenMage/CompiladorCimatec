using System;
using System.Collections.Generic;
using System.Text;

namespace Compilador.LexicAnalysor
{
    public class Token
    {
        public TokenKind Kind { get; }
        public int Position { get; }
        public string Text { get; }
        public object Value { get; }
        
        public Token(TokenKind kind, int position, string text, object value)
        {
            Kind = kind;
            Position = position;
            Text = text;
            Value = value;
        }
    }
}
