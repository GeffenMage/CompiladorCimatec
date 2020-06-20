using System;
using System.Collections.Generic;
using System.Text;

namespace Compilador.LexicAnalysor
{
    public class Lexer
    {
        private readonly string Text;

        private int Position;

        // Tabela de símbolos
        List<SymbolEntry> SymbolTable = new List<SymbolEntry>();

        private char CurrentChar {
            get {
                if (Position >= Text.Length)
                    return '\0'; // Caractere que indica o final do arquivo
                else
                    return Text[Position];
            }
        }

        public Lexer(string inputText)
        {
            Text = inputText;
        }

        public void NextChar()
        {
            Position++;
        }

        public Token NextToken()
        {
            if (char.IsDigit(CurrentChar))
            {
                var start = Position;

                while (char.IsDigit(CurrentChar))
                    NextChar();

                var length = Position - start;
                var text = Text.Substring(start, length);
                int.TryParse(text, out var value);
                return new Token(TokenKind.Number, start, text, value);
            }

        }

        public Token ReadInputText()
        {
            throw new NotImplementedException();
        }
    }
}
