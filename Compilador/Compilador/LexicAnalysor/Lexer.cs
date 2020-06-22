using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Compilador.LexicAnalysor
{
    public class Lexer
    {
        private string Text;

        // Variáveis de controle de leitura
        private int Position;
        private int CurrentLineNumber;
        private const int MaxTokenLenght = 30;
               
        // Tabela de símbolos
        public List<SymbolEntry> SymbolTable;
        private int currentEntry = 1;

        public TokenRegistry TokenRegistry;

        // Lista de Tokens criados
        public List<Token> FileTokens = new List<Token>();

        public Lexer(List<SymbolEntry> symbolTable, TokenRegistry tokenRegistry)
        {
            SymbolTable = symbolTable;
            TokenRegistry = tokenRegistry;
        }

        public void ReadFileLine(string line, int lineNumber)
        {
            // Resetando variáveis de controle
            Text = string.Empty;
            Position = 0;
            
            // Setando linha a ser lida
            Text = line;
            CurrentLineNumber = lineNumber;

            // Leitura dos caracteres da linha
            while(Position <= line.Length)
            {
                Token token = NextToken();

                if (token.Kind == TokenKind.EndOfFile)
                    break;

                FileTokens.Add(token);
            }
        }

        private char CurrentChar {
            get {
                if (Position >= Text.Length)
                    return '\0'; // Caractere que indica o final do arquivo
                else
                    return Text[Position];
            }
        }

        public void NextChar()
        {
            Position++;
        }

        public Token NextToken()
        {
            // Verifica se chegou ao final do arquivo
            if (Position >= Text.Length)
                return new Token(TokenKind.EndOfFile, Position, "\0", null);
                        
            if (char.IsDigit(CurrentChar))
            {
                var start = Position;

                while (char.IsDigit(CurrentChar))
                    NextChar();

                var length = Position - start;
                var text = "";
                var token = new Object();

                // Verificação para truncagem 
                if (length > MaxTokenLenght)
                {
                    text = Text.Substring(start, MaxTokenLenght);
                    int.TryParse(text, out var value);
                    token = new Token(TokenKind.Number, CurrentLineNumber, text, value);
                }
                else
                {
                    text = Text.Substring(start, length);
                    int.TryParse(text, out var value);
                    token = new Token(TokenKind.Number, CurrentLineNumber, text, value);                    
                }

                TokenRegistry.AddRegister(TokenKind.Number);

                return (Token)token;
            }
            
            if (char.IsWhiteSpace(CurrentChar))
            {
                var start = Position;

                while (char.IsWhiteSpace(CurrentChar))
                    NextChar();

                var length = Position - start;
                var text = "";
                var token = new Object();

                text = Text.Substring(start, length);
                token = new Token(TokenKind.Whitespace, CurrentLineNumber, text, null);

                TokenRegistry.AddRegister(TokenKind.Whitespace);

                return (Token)token;
            }


            switch (CurrentChar)
            {
                case '+':
                    var token = new Object();
                    token = new Token(TokenKind.PlusOperator, Position++, "+", null);

                    TokenRegistry.AddRegister(TokenKind.PlusOperator);

                    return (Token)token;                   
                
                case '-':
                    token = new Token(TokenKind.MinusOperator, Position++, "-", null);

                    TokenRegistry.AddRegister(TokenKind.MinusOperator);

                    return (Token)token;
                
                case '/':
                    token = new Token(TokenKind.DivideOperator, Position++, "/", null);

                    TokenRegistry.AddRegister(TokenKind.DivideOperator);

                    return (Token)token;
                
                case '*':
                    token = new Token(TokenKind.TimesOperator, Position++, "*", null);

                    TokenRegistry.AddRegister(TokenKind.TimesOperator);

                    return (Token)token;
                
                case '(':
                    token = new Token(TokenKind.ParenthesisStart, Position++, "(", null);

                    TokenRegistry.AddRegister(TokenKind.ParenthesisStart);

                    return (Token)token;

                case ')':
                    token = new Token(TokenKind.ParenthesisEnd, Position++, ")", null);

                    TokenRegistry.AddRegister(TokenKind.ParenthesisEnd);

                    return (Token)token;

                case '[':
                    token = new Token(TokenKind.BracketStart, Position++, "[", null);

                    TokenRegistry.AddRegister(TokenKind.BracketStart);

                    return (Token)token;

                case ']':
                    token = new Token(TokenKind.BracketEnd, Position++, "]", null);

                    TokenRegistry.AddRegister(TokenKind.BracketEnd);

                    return (Token)token;

                case '{':
                    token = new Token(TokenKind.CurlyBraceStart, Position++, "{", null);

                    TokenRegistry.AddRegister(TokenKind.CurlyBraceStart);

                    return (Token)token;

                case '}':
                    token = new Token(TokenKind.CurlyBraceEnd, Position++, "}", null);

                    TokenRegistry.AddRegister(TokenKind.CurlyBraceEnd);

                    return (Token)token;

                case '=':
                    token = new Token(TokenKind.AssignOperator, Position++, "=", null);

                    TokenRegistry.AddRegister(TokenKind.AssignOperator);

                    return (Token)token;

                default:
                    break;
            }

            TokenRegistry.AddRegister(TokenKind.BadToken);

            return new Token(TokenKind.BadToken, Position++, Text.Substring(Position - 1, 1), null);
        }

        private void AddSymbolToTable(Token token, int lenghtBefore, int lenghtAfter)
        {
            var previousSymbol = SymbolTable.Where(s => s.SymbolToken.Kind == token.Kind && s.SymbolToken.Value == token.Value).FirstOrDefault();

            if (previousSymbol != null)
            {
                previousSymbol.Lines.Add(token.Line);
            }
            else
            {
                SymbolTable.Add(new SymbolEntry(currentEntry, CurrentLineNumber, lenghtBefore, lenghtAfter, token));
                currentEntry++;
            }            
        }

    }
}
