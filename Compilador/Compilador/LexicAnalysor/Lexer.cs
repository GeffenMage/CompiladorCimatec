using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

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
                return new Token(TokenKind.EndOfFile, CurrentLineNumber, "\0", null);
                        
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
                    token = new Token(TokenKind.IntegerNumber, CurrentLineNumber, text, value);
                }
                else
                {
                    text = Text.Substring(start, length);
                    int.TryParse(text, out var value);
                    token = new Token(TokenKind.IntegerNumber, CurrentLineNumber, text, value);                    
                }

                TokenRegistry.AddRegister(TokenKind.IntegerNumber);

                return (Token)token;
            }

            if (char.IsLetter(CurrentChar))
            {
                var start = Position;

                while (char.IsLetter(CurrentChar) || char.IsDigit(CurrentChar))
                    NextChar();

                var length = Position - start;
                var text = string.Empty;

                if (length > MaxTokenLenght)
                {
                    text = Text.Substring(start, MaxTokenLenght);

                    return IdentifyCharToken(text, length);
                }
                else
                {
                    text = Text.Substring(start, length);

                    return IdentifyCharToken(text, length);
                }
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

            // identificação de caracteres únicos
            switch (CurrentChar)
            {
                case '+':
                    var token = new Object();
                    token = new Token(TokenKind.PlusOperator, CurrentLineNumber, "+", null);

                    Position++;

                    TokenRegistry.AddRegister(TokenKind.PlusOperator);

                    return (Token)token;                   
                
                case '-':
                    token = new Token(TokenKind.MinusOperator, CurrentLineNumber, "-", null);

                    Position++;

                    TokenRegistry.AddRegister(TokenKind.MinusOperator);

                    return (Token)token;
                
                case '/':
                    token = new Token(TokenKind.DivideOperator, CurrentLineNumber, "/", null);

                    Position++;

                    TokenRegistry.AddRegister(TokenKind.DivideOperator);

                    return (Token)token;
                
                case '*':
                    token = new Token(TokenKind.TimesOperator, CurrentLineNumber, "*", null);

                    Position++;

                    TokenRegistry.AddRegister(TokenKind.TimesOperator);

                    return (Token)token;
                
                case '(':
                    token = new Token(TokenKind.ParenthesisStart, CurrentLineNumber, "(", null);

                    Position++;

                    TokenRegistry.AddRegister(TokenKind.ParenthesisStart);

                    return (Token)token;

                case ')':
                    token = new Token(TokenKind.ParenthesisEnd, CurrentLineNumber, ")", null);

                    Position++;

                    TokenRegistry.AddRegister(TokenKind.ParenthesisEnd);

                    return (Token)token;

                case '[':
                    token = new Token(TokenKind.BracketStart, CurrentLineNumber, "[", null);

                    Position++;

                    TokenRegistry.AddRegister(TokenKind.BracketStart);

                    return (Token)token;

                case ']':
                    token = new Token(TokenKind.BracketEnd, CurrentLineNumber, "]", null);

                    Position++;

                    TokenRegistry.AddRegister(TokenKind.BracketEnd);

                    return (Token)token;

                case '{':
                    token = new Token(TokenKind.CurlyBraceStart, CurrentLineNumber, "{", null);

                    Position++;

                    TokenRegistry.AddRegister(TokenKind.CurlyBraceStart);

                    return (Token)token;

                case '}':
                    token = new Token(TokenKind.CurlyBraceEnd, CurrentLineNumber, "}", null);

                    Position++;

                    TokenRegistry.AddRegister(TokenKind.CurlyBraceEnd);

                    return (Token)token;

                case '=':
                    token = new Token(TokenKind.AssignOperator, CurrentLineNumber, "=", null);

                    Position++;

                    TokenRegistry.AddRegister(TokenKind.AssignOperator);

                    return (Token)token;

                case '&':
                    token = new Token(TokenKind.AndOperator, CurrentLineNumber, "&", null);

                    Position++;

                    TokenRegistry.AddRegister(TokenKind.AndOperator);

                    return (Token)token;

                case ';':
                    token = new Token(TokenKind.EndOfLineIdentifier, CurrentLineNumber, ";", null);

                    Position++;

                    TokenRegistry.AddRegister(TokenKind.EndOfLineIdentifier);

                    return (Token)token;

                case '!':
                    token = new Token(TokenKind.NotOperator, CurrentLineNumber, "!", null);

                    Position++;

                    TokenRegistry.AddRegister(TokenKind.NotOperator);

                    return (Token)token;

                case '%':
                    token = new Token(TokenKind.ModOperator, CurrentLineNumber, "%", null);

                    Position++;

                    TokenRegistry.AddRegister(TokenKind.ModOperator);

                    return (Token)token;

                case '>':
                    token = new Token(TokenKind.GreaterThenOperator, CurrentLineNumber, ">", null);

                    Position++;

                    TokenRegistry.AddRegister(TokenKind.GreaterThenOperator);

                    return (Token)token;

                case '<':
                    token = new Token(TokenKind.LesserThenOperator, CurrentLineNumber, "<", null);

                    Position++;

                    TokenRegistry.AddRegister(TokenKind.LesserThenOperator);

                    return (Token)token;

                case ',':
                    token = new Token(TokenKind.Comma, CurrentLineNumber, ",", null);

                    Position++;

                    TokenRegistry.AddRegister(TokenKind.Comma);

                    return (Token)token;

                case '.':
                    token = new Token(TokenKind.Dot, CurrentLineNumber, ",", null);

                    Position++;

                    TokenRegistry.AddRegister(TokenKind.Dot);

                    return (Token)token;

                case '\"':
                    token = new Token(TokenKind.Quotes, CurrentLineNumber, "\"", null);

                    Position++;

                    TokenRegistry.AddRegister(TokenKind.Comma);

                    return (Token)token;

                default:
                    break;
            }

            TokenRegistry.AddRegister(TokenKind.BadToken);

            var badToken = new Token(TokenKind.BadToken, CurrentLineNumber, Text.Substring(Position, 1), null);

            Position++;

            return badToken;
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

        private Token IdentifyCharToken(string text, int oldLength)
        {
            string upperText = text.ToUpper();

            foreach (var regx in TokenRegistry.RegexBank)
            {
                if (Regex.IsMatch(upperText, regx.Value))
                {
                    TokenRegistry.AddRegister(regx.Key);
                    return new Token(regx.Key, CurrentLineNumber, text, text);
                }
            }

            TokenRegistry.AddRegister(TokenKind.BadToken);

            return new Token(TokenKind.BadToken, CurrentLineNumber, text, null);
        }

    }
}
