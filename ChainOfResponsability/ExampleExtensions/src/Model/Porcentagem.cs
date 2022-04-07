using System;
using System.Collections.Generic;
using System.IO;

namespace ExampleExtensions.src.Model
{
    public class Porcentagem : Aprovador
    {
        public override void ProcessRequest(Conta conta, Formato formato)
        {
            if (Formato.PORCENTO.Equals(formato))
            {
                System.Console.WriteLine("retorne a requisição em formato arquivo.CSV separador %");
                CriarPasta("Entrada");
                CriarArquivo("arquivoCsvComPontoVirgula.csv");
                InserirConteudoNoArquivo(conta, "arquivoCsvComPontoVirgula.csv");
                ExibirOConteudoDoArquivo("arquivoCsvComPontoVirgula.csv");
                System.Console.WriteLine();
                Console.WriteLine("--------------------------------------------");
            }
            Successor.ProcessRequest(conta, formato);
        }

        private void ExibirOConteudoDoArquivo(string arquivo)
        {
            var path = Path.Combine(Environment.CurrentDirectory, "src", "Model", "Entrada", arquivo);
            var info = new FileInfo(path);
            if (!File.Exists(path))
                throw new FileNotFoundException($"O arquivo: {info.FullName} não existe");
            StreamReader sr = null;
            sr = new StreamReader(File.OpenRead(path));
            List<string> listA = new List<string>();
            while (!sr.EndOfStream)
            {
                var line = sr.ReadLine();

                System.Console.WriteLine(line);
            }
        }

        private void InserirConteudoNoArquivo(Conta conta, string arquivo)
        {
            var path = Path.Combine(Environment.CurrentDirectory, "src", "Model", "Entrada", arquivo);
            var info = new FileInfo(path);
            if (!File.Exists(path))
                throw new FileNotFoundException($"O arquivo: {info.FullName} não existe");
            using (var sw = new StreamWriter(path))
            {
                sw.Write("Nome%Saldo;\n");
                var linha = $"{conta.Nome}%{conta.Saldo}";
                sw.WriteLine(linha);
            }
        }

        private void CriarArquivo(string arquivo)
        {
            if (string.IsNullOrEmpty(arquivo))
                throw new ArgumentException("o valor da entrada não deve ser vazio ou nulo.");
            var path = Path.Combine(Environment.CurrentDirectory, "src", "Model", "Entrada", arquivo);
            if (!File.Exists(path))
            {
                File.Create(path);
            }
        }

        private void CriarPasta(string caminho)
        {
            if (string.IsNullOrEmpty(caminho))
                throw new ArgumentException("o valor da entrada não deve ser vazio ou nulo.");
            var path = Path.Combine(Environment.CurrentDirectory, "src", "Model", caminho);
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

        }
    }
}
