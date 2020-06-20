using System;
using System.Collections.Generic;
using System.Text;

namespace Compilador.LexicAnalysor
{
    public class SymbolEntry
    {
        public int EntryNumber { get; set; }
        public Token Token { get; set; }

        public int CharAmoutBeforeAjustment { get; set; }
        public int CharAmoutAfterAjustment { get; set; }

        public int[] FirstFiveLines { get; set; }

        public SymbolEntry()
        {
            FirstFiveLines = new int[5];
        }
    }
}
