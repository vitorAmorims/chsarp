using System;
using System.Collections.Generic;
using System.IO;

namespace ExampleExtensions.src.Model
{
    public class CSV : Aprovador
    {
        public override void ProcessRequest(Conta conta, Formato formato)
        {
            if (Formato.CSV.Equals(formato))
            {
                System.Console.WriteLine("retorne a requisição em formato arquivo.CSV");
                CriarPasta("Entrada");
                CriarArquivo("arquivo.csv");
                InserirConteudoNoArquivo(conta, "arquivoCsvComPontoVirgula.csv");
                ExibirOConteudoDoArquivo("arquivoCsvComPontoVirgula.csv");
                System.Console.WriteLine();
                Console.WriteLine("--------------------------------------------");
            }
            Successor.ProcessRequest(conta, formato);
        }

        private void ExibirOConteudoDoArquivo(string arquivo)
        {
            if (string.IsNullOrEmpty(arquivo))
                throw new ArgumentNullException("O arquivo não deve ser nulo ou vazio");
            var path = Path.Combine(Environment.CurrentDirectory, "src", "Model", "Entrada", arquivo);
            if (File.Exists(path))
            {
                StreamReader sr = null;
                sr = new StreamReader(File.OpenRead(path));
                List<string> listA = new List<string>();
                while (!sr.EndOfStream)
                {
                    var line = sr.ReadLine();

                    System.Console.WriteLine(line);
                }
            }
        }

        private void InserirConteudoNoArquivo(Conta conta, string arquivo)
        {
            if (string.IsNullOrEmpty(arquivo))
                throw new ArgumentNullException("O arquivo não deve ser nulo ou vazio");
            var path = Path.Combine(Environment.CurrentDirectory, "src", "Model", "Entrada", arquivo);
            if (File.Exists(path))
            {
                using (var sw = new StreamWriter(path))
                {
                    sw.Write("Nome;Saldo;\n");
                    var linha = $"{conta.Nome};{conta.Saldo}";
                    sw.WriteLine(linha);
                }
            }

        }

        private void CriarArquivo(string arquivo)
        {
            if (string.IsNullOrEmpty(arquivo))
                throw new ArgumentNullException("O arquivo não deve ser nulo ou vazio");
            var path = Path.Combine(Environment.CurrentDirectory, "src", "Model", "Entrada", arquivo);
            if (!File.Exists(path))
            {
                File.Create(path);
            }
        }

        private void CriarPasta(string caminho)
        {
            if (string.IsNullOrEmpty(caminho))
                throw new ArgumentNullException("O caminho não deve ser nulo ou vazio");
            var path = Path.Combine(Environment.CurrentDirectory, "src", "Model", "Entrada");
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
        }
    }
}
