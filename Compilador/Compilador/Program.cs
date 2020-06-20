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
            const string inputFileExtension = ".201";

            Console.WriteLine("Digite o caminho completo do arquivo de entrada ou o seu nome: ");
            inputFilePath = Console.ReadLine();

            // Verifica se apenas o nome do arquivo foi digitado já que todo caminho de arquivo tem o símbolo '/'
            if (!inputFilePath.Contains('/'))
                inputFilePath = "./" + inputFilePath;

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
