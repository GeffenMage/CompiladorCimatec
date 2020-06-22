using Compilador.LexicAnalysor;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Compilador.ReportGenerator
{
    public class ReportsGenerator
    {
        private List<Token> FileTokens;

        private List<SymbolEntry> SymbolTable;

        private TokenRegistry Registry;

        private string InputFilePath;

        private string InputFileExtension;

        public ReportsGenerator(List<Token> fileTokens, List<SymbolEntry> symbolTable, string inputFilePath, string inputFileExtension, TokenRegistry tokenRegistry)
        {
            FileTokens = fileTokens;
            SymbolTable = symbolTable;
            InputFilePath = inputFilePath;
            InputFileExtension = inputFileExtension;
            Registry = tokenRegistry;
        }

        public void CreateLexicAnalysisReport()
        {
            string lexicReportFileExtension = ".LEX";

            string lexicReportHeader = "" +
                "====================================================\n " +
                "   Equipe: E01 \n" +
                "       Integrantes: \n" +
                "           Paulo Sá\n" +
                "               Email: paulo.miranda107@gmail.com\n" +
                "               Tel: (71) 98812-2008\n" +
                "           Daniel Duplat\n" +
                "               Email: ddaniel1912@gmail.com\n" +
                "               Tel: (71) 98180-5184\n" +
                "           João Victor Sledz\n" +
                "               Email: victor.bulhoes@gmail.com\n" +
                "               Tel: (71) 99334-8845\n" +
                "           Lucas Ortega\n" +
                "               Email: lucaslemosortega@gmail.com\n" +
                "               Tel: (71) 99670-3063\n" +
                "====================================================\n\n";

            var lexicReportFilePath = InputFilePath.Replace(InputFileExtension, lexicReportFileExtension);

            var writer = File.CreateText(lexicReportFilePath);

            writer.Write(lexicReportHeader);

            foreach (var token in FileTokens)
            {
                int numOfOcurrences = Registry.GetRegistersOfKind(token.Kind);
                SymbolEntry tokenEntry = SymbolTable.Where(s => s.SymbolToken == token).FirstOrDefault();

                string reportLineText = $"" +
                    $" ({token.Kind})\n" +
                    $"      Código : {(int)token.Kind},\n" +
                    $"      Texto: '{token.Text}',\n" +
                    $"      Ocorrencias: {numOfOcurrences},\n";

                writer.Write(reportLineText);

                if (tokenEntry != null)
                    writer.WriteLine($"      Índicie na tabela de símbolos: {tokenEntry.EntryNumber}");                
            }

            writer.Flush();
            writer.Close();
        }

        public void CreateSymbolTableReport()
        {
            string symbolTableReportFileExtension = ".TAB";

            string symbolTableReportFilePath = InputFilePath + symbolTableReportFileExtension;

            var writer = File.CreateText(symbolTableReportFilePath);

            foreach (var symbol in SymbolTable)
            {
                string reportLineText = $"" +
                    $"({symbol.SymbolToken.Kind})\n" +
                    $"      Número de Entrada: {symbol.EntryNumber}\n" +
                    $"      Texto: {symbol.SymbolToken.Text}\n" +
                    $"      Caracteres antes da truncagem: {symbol.CharAmoutBeforeAjustment}\n" +
                    $"      Caracteres depois da truncagem: {symbol.CharAmoutAfterAjustment}\n" +
                    $"      Cinco primeiras linhas: {symbol.Lines.Take(symbol.Lines.Count)}\n";

                writer.Write(reportLineText);
            }

            writer.Flush();
            writer.Close();
        }
    }
}
