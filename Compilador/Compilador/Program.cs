using Compilador.LexicAnalysor;
using System;
using System.Collections.Generic;
using System.IO;

namespace Compilador
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputFileText = "";
            string inputFilePath = "";            
            const string inputFileExtension = ".304";

            Console.WriteLine("Digite o caminho completo do arquivo de entrada e o seu nome: ");
            inputFilePath = Console.ReadLine();

            try
            {
                inputFileText = File.ReadAllText(inputFilePath + inputFileExtension);
                Lexer lexer = new Lexer(inputFileText);                
            }
            catch(Exception e)
            {
                Console.WriteLine("Ocorreu um erro ao ler o arquivo, por favor verifique o caminho fornecido");
                File.CreateText("./ErrorLog.txt").Write(e.ToString());
            }            
        }
    }
}
