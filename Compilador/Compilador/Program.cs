using Compilador.LexicAnalysor;
using Compilador.ReportGenerator;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;

namespace Compilador
{
    class Program
    {
        static void Main(string[] args)
        {

            while (true)
            {
                string[] inputFileLines;
                string inputFilePath;
                const string inputFileExtension = ".201";
                
                // Tabela de Símbolos
                List<SymbolEntry> symbolTable = new List<SymbolEntry>();

                TokenRegistry registry = new TokenRegistry();
                
                Console.WriteLine("Digite o caminho completo do arquivo de entrada ou o seu nome: ");
                inputFilePath = Console.ReadLine();

                // Verifica se apenas o nome do arquivo foi digitado já que todo caminho de arquivo tem o símbolo '\\'
                if (!inputFilePath.Contains('\\'))
                    inputFilePath = "./" + inputFilePath;

                try
                {
                    inputFileLines = File.ReadAllLines(inputFilePath + inputFileExtension);
                    Lexer lexer = new Lexer(symbolTable, registry);
                    
                    // Análise Léxica
                    for (int index = 0; index < inputFileLines.Length; index++)
                    {
                        Console.WriteLine($"Realizando Análise Léxica, Linha: {index+1}/{inputFileLines.Length}");                        
                        lexer.ReadFileLine(inputFileLines[index], index + 1);
                    }

                    // Geração de Relatórios

                    ReportsGenerator report = new ReportsGenerator(lexer.FileTokens, symbolTable, inputFilePath + inputFileExtension, inputFileExtension, registry);

                    Console.WriteLine($"Escrevendo arquivos de relatório em: {inputFilePath}");

                    report.CreateLexicAnalysisReport();

                    Console.WriteLine("Relatórios Escritos!\n");
                }
                catch (Exception e)
                {
                    Console.WriteLine("Ocorreu um erro ao ler o arquivo, por favor verifique o caminho fornecido");
                    var writer = File.CreateText("./ErrorLog.txt");
                    writer.WriteLine(e.Message);

                    writer.Flush();
                    writer.Close();
                }             
            }
        }
    }
}
