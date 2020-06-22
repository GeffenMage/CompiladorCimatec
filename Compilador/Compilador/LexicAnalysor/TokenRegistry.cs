using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Compilador.LexicAnalysor
{
    public class TokenRegistry
    {
        private List<TokenRegister> Registry;

        public TokenRegistry()
        {
            Registry = new List<TokenRegister>();
            
            InitializeRegistry();
        }

        private void InitializeRegistry()
        {
            var tokenKinds = Enum.GetValues(typeof(TokenKind));

            foreach (var kind in tokenKinds)
            {
                Registry.Add(new TokenRegister((TokenKind)kind, 0));
            }
        }

        public void AddRegister(TokenKind kind)
        {
            Registry.Where(r => r.Kind == kind).FirstOrDefault().NumOfTimesRegistered++;
        }

        public int GetRegistersOfKind(TokenKind kind)
        {
            return Registry.Where(r => r.Kind == kind).FirstOrDefault().NumOfTimesRegistered;
        }
    }
}
