using System;
using System.Collections.Generic;
using System.Text;

namespace Compilador.LexicAnalysor
{
    public class TokenRegister
    {
        public TokenKind Kind { get; set; }
        public int NumOfTimesRegistered { get; set; }

        public TokenRegister(TokenKind kind, int numOfTimesRegistered)
        {
            Kind = kind;
            NumOfTimesRegistered = numOfTimesRegistered;
        }
    }
}
