using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Compilador.LexicAnalysor
{
    public class TokenRegistry
    {
        private List<TokenRegister> Registry;

        public Dictionary<TokenKind, string> RegexBank;

        public TokenRegistry()
        {
            Registry = new List<TokenRegister>();

            RegexBank = new Dictionary<TokenKind, string>();
            
            InitializeRegistry();

            InitializeRegexBank();
        }

        private void InitializeRegistry()
        {
            var tokenKinds = Enum.GetValues(typeof(TokenKind));

            foreach (var kind in tokenKinds)
            {
                Registry.Add(new TokenRegister((TokenKind)kind, 0));
            }
        }

        private void InitializeRegexBank()
        {
            RegexBank.Add(TokenKind.ProgramIdentifier, "PROGRAM");
            RegexBank.Add(TokenKind.BeginIdentifier, "BEGIN");
            RegexBank.Add(TokenKind.EndIdentifier, "END");
            RegexBank.Add(TokenKind.IfConditionalIdentifier, "IF");
            RegexBank.Add(TokenKind.ElseConditionalIdentifial, "ELSE");
            RegexBank.Add(TokenKind.IntIdentifier, "INT");
            RegexBank.Add(TokenKind.FloatIdentifier, "FLOAT");
            RegexBank.Add(TokenKind.CharIdentifier, "CHAR");
            RegexBank.Add(TokenKind.BoolIdentifier, "BOOL");
            RegexBank.Add(TokenKind.StringIdentifier, "STRING");
            RegexBank.Add(TokenKind.VoidIdentifier, "VOID");
            RegexBank.Add(TokenKind.ReturnKeyword, "RETURN");
            RegexBank.Add(TokenKind.BreakKeywork, "BREAK");
            RegexBank.Add(TokenKind.WhileConditionalIdentifier, "WHILE");            
            RegexBank.Add(TokenKind.TrueKeyword, "TRUE");
            RegexBank.Add(TokenKind.FalseKeyword, "FALSE");
            RegexBank.Add(TokenKind.VaribleName, "[A-Z0-9]+");            
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
