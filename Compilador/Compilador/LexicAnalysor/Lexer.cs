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
        List<Token> TokenTable = new List<Token>();

        private char CaractereAtual {
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

        public Token ReadInputText()
        {
            throw new NotImplementedException();
        }
    }
}
