using System;
using System.Collections.Generic;
using System.Text;

namespace Compilador.LexicAnalysor
{
    public class SymbolEntry
    {
        public int EntryNumber { get; set; }
        public Token SymbolToken { get; set; }

        public int CharAmoutBeforeAjustment { get; set; }
        public int CharAmoutAfterAjustment { get; set; }

        public List<int> Lines { get; set; }

        public SymbolEntry(int entryNumber, int firstLine, int charAmoutBeforeAjustment, int charAmoutAfterAjustment, Token token)
        {
            Lines = new List<int>();

            Lines.Add(firstLine);

            EntryNumber = entryNumber;
            CharAmoutAfterAjustment = charAmoutAfterAjustment;
            CharAmoutBeforeAjustment = charAmoutBeforeAjustment;
            SymbolToken = token;
        }
    }
}
