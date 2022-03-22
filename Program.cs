using System;
using System.Collections.Generic;
using System.IO;
using CsvHelper.Configuration;
using CsvHelper;
using projectCSVHelper.src.Entities;
using System.Globalization;
using System.Linq;
using projectCSVHelper.src.Mapping;

namespace projectCSVHelper
{
    class Program
    {
        static void Main()
        {
            CriarPasta("Entrada");
            CriarPasta("Entities");
            CriarArquivoInserirExibirProdutos();
            CriarArquivoInserirExibirUsuarios();
            CriarArquivoInserirExibirLivros();
            CriarArquivoInserirExibirProgramas();
            CriarArquivoInserirExibirProgramas2();
            CriarArquivoInserirExibirProdutosPadaria();
        }

        private static void CriarArquivoInserirExibirProdutosPadaria()
        {
            var listaProducaoPadaria = new List<Producao>(){
                new Producao(){
                    Nome="Vitor",
                    Titulo="pão francês",
                    Preco=7.89,
                    DataFabricacao=new DateTime(2022,03,21),
                    DataVencimento= new DateTime(2022,03,22)},
                new Producao(){
                    Nome="Vitor",
                    Titulo="pão de milho",
                    Preco=10.20,
                    DataFabricacao=new DateTime(2022,03,21),
                    DataVencimento= new DateTime(2022,03,21)},
            };
            CriarArquivo("Producao-padaria.csv", "Entrada");
            try
            {
                InserirConteudoProducaoPadaria("Producao-padaria.csv", "Entrada", listaProducaoPadaria);
                LerArquivoProducaoPadaria("Producao-padaria.csv", "Entrada", listaProducaoPadaria);
            }
            catch (System.Exception e)
            {

                System.Console.WriteLine(e.Message);
            }
        }

        private static void CriarArquivoInserirExibirProgramas2()
        {
            var listaProgramas = new List<Programa>(){
                new Programa(){Nome="Os video mais engraçados", Apresentador="Franklin", Salario=10500.50, Datalancamento= new DateTime(2022, 03, 21, 08, 59, 59)},
                new Programa(){Nome="Caçadores", Apresentador="Elmo", Salario=1500d, Datalancamento= new DateTime(2020, 07, 02, 22, 59, 59)},
            };

            CriarArquivo("Programa-com-ponto-virgula-sem-header.csv", "Entrada");
            try
            {
                InserirConteudoProgramaSemHeader("Programa-com-ponto-virgula-sem-header.csv", "Entrada", listaProgramas);
                LerArquivoProgramaSemHeaderConfiguration("Programa-com-ponto-virgula-sem-header.csv", "Entrada");
            }
            catch (System.Exception e)
            {

                System.Console.WriteLine(e.Message);
            }

        }

        private static void CriarArquivoInserirExibirProgramas()
        {
            var listaProgramas = new List<Programa>(){
                new Programa(){Nome="Primeiro lugar Deus", Apresentador="Pastor Amigo", Salario=10500.50, Datalancamento= new DateTime(2022, 03, 21, 08, 59, 59)},
                new Programa(){Nome="Segundo lugar espirito santo", Apresentador="Pastor Amigo2", Salario=1500d, Datalancamento= new DateTime(2020, 07, 02, 22, 59, 59)},
            };
            CriarArquivo("Programa-com-ponto-virgula.csv", "Entrada");
            try
            {
                InserirConteudoProgramaHeaderConfiguration("Programa-com-ponto-virgula.csv", "Entrada", listaProgramas);
                LerArquivoProgramaHeaderConfiguration("Programa-com-ponto-virgula.csv", "Entrada");

            }
            catch (System.Exception e)
            {
                System.Console.WriteLine(e.Message);
            }
        }

        private static void CriarArquivoInserirExibirLivros()
        {
            var listaDeLivros = new List<Livro>(){
                new Livro(){Titulo="Harry Potter e a Pedra Filosofal", Autor="Jk Rolling", Preco=89.90M, Lancamento = "26/06/1997"},
                new Livro(){Titulo="Harry Potter e a Camera Secreta", Autor="Jk Rolling", Preco=78.85M, Lancamento = "02/07/1998"},
                new Livro(){Titulo="Harry Potter e o Prisioneiro Azkaban", Autor="Jk Rolling", Preco=102.00M, Lancamento = "08/07/1999"},
            };

            CriarArquivo("Livro-preco-com-virgula.csv", "Entrada");
            try
            {
                InserirConteudoLivro("Livro-preco-com-virgula.csv", "Entrada", listaDeLivros);
                LerArquivoLivroPrecoCsvComDelimitadorClasseCsvHelper("Livro-preco-com-virgula.csv", "Entrada");
            }
            catch (System.Exception e)
            {

                System.Console.WriteLine(e.Message);
            }
        }

        private static void CriarArquivoInserirExibirUsuarios()
        {
            var listaDeUsuarios = new List<Usuario>(){
                new Usuario(){Nome="Vitor", Idade = 40, Celular = "11998999999"},
                new Usuario(){Nome="Lucas", Idade = 18, Celular = "998989898"},
                new Usuario(){Nome="Neusa", Idade = 60, Celular = "997979797"},
            };

            CriarArquivo("Usuarios.csv", "Entrada");
            try
            {
                InserirConteudoUsuario("Usuarios.csv", "Entrada", listaDeUsuarios);
                LerArquivoUsuarioCsvComClasseCsvHelper("Usuarios.csv", "Entrada");
            }
            catch (Exception e)
            {

                System.Console.WriteLine(e.Message);
            }
        }

        private static void CriarArquivoInserirExibirProdutos()
        {
            var listaDeProdutos = new List<Produto>(){
                new Produto(){Nome="Ipad", Preco = 2000d, Quantidade = 2},
                new Produto(){Nome="Televisão", Preco = 3000d, Quantidade = 5},
                new Produto(){Nome="Liquidificador", Preco = 400d, Quantidade = 10},
            };
            CriarArquivo("produtos.csv", "Entrada");
            try
            {
                InserirConteudo("produtos.csv", "Entrada", listaDeProdutos);
                LerArquivoCsvComCsvHelper("produtos.csv", "Entrada", listaDeProdutos);
            }
            catch (Exception e)
            {
                System.Console.WriteLine(e.Message);
            }
        }

        public static void InserirConteudoProducaoPadaria(string arquivo, string pasta, List<Producao> lista)
        {
            var path = Path.Combine(Environment.CurrentDirectory, "src", pasta, arquivo);
            var info = new FileInfo(path);
            if(!File.Exists(path))
                throw new FileNotFoundException($"O arquivo: {info.FullName} não existe");
            using(var sw = new StreamWriter(path))
            {
                sw.Write("nome|titulo|preço|dataFabricacao|dataVencimento\n");
                foreach (var item in lista)
                {
                    var linha = $"{item.Nome}|{item.Titulo}|{item.Preco}|{item.DataFabricacao}|{item.DataVencimento}";
                    sw.WriteLine(linha);
                }
            }
            System.Console.WriteLine($"O arquivo {info.FullName} foi preenchido com as informações");
        }

        public static void LerArquivoProducaoPadaria(string arquivo, string pasta, List<Producao> lista)
        {
            var path = Path.Combine(Environment.CurrentDirectory, "src", pasta, arquivo);
            if (!File.Exists(path))
            {
                throw new FileNotFoundException($"O arquivo {path} não existe.!");
            }
            using (var sr = new StreamReader(path))
            {
                var info = new FileInfo(path);
                System.Console.WriteLine($"Relizando Leitura do arquivo {info.FullName}");
                var csvConfig = new CsvConfiguration(CultureInfo.InvariantCulture)
                {
                    Delimiter = "|"
                };
                using (var csvReader = new CsvReader(sr, csvConfig))
                {
                    csvReader.Context.RegisterClassMap<PadariaMap>();
                    //cuidado com ToList, para arquivos grandes.
                    var Registros = csvReader.GetRecords<Producao>().ToList();

                    foreach (var registro in Registros)
                    {
                        System.Console.WriteLine("-----------------------------------------");
                        System.Console.WriteLine($"Nome: {registro.Nome}");
                        System.Console.WriteLine($"Titulo: {registro.Titulo}");
                        System.Console.WriteLine($"Preço: {registro.Preco}");
                        System.Console.WriteLine($"Data de fabricação: {registro.DataFabricacao}");
                        System.Console.WriteLine($"Data de vencimento: {registro.DataVencimento}");
                    }
                }
            }

        }



        public static void InserirConteudoProgramaSemHeader(string arquivo, string pasta, List<Programa> lista)
        {
            var path = Path.Combine(Environment.CurrentDirectory, "src", pasta, arquivo);
            if (!File.Exists(path))
                throw new FileNotFoundException(path);
            using (var sw = new StreamWriter(path))
            {
                foreach (var programa in lista)
                {
                    var linha = $"{programa.Nome};{programa.Apresentador};{programa.Salario};{programa.Datalancamento}";
                    sw.WriteLine(linha);
                }
            }
            var info = new FileInfo(path);
            System.Console.WriteLine($"Inserido conteúdo no arquivo {info.FullName}");
        }

        public static void LerArquivoProgramaSemHeaderConfiguration(string arquivo, string pasta)
        {
            var path = Path.Combine(Environment.CurrentDirectory, "src", pasta, arquivo);
            if (!File.Exists(path))
            {
                throw new FileNotFoundException($"O arquivo {path} não existe.!");
            }
            using (var sr = new StreamReader(path))
            {
                var info = new FileInfo(path);
                System.Console.WriteLine($"Relizando Leitura do arquivo {info.FullName}");
                var csvConfig = new CsvConfiguration(CultureInfo.InvariantCulture)
                {
                    Delimiter = ";"
                };
                using (var csvReader = new CsvReader(sr, csvConfig))
                {
                    //cuidado com ToList, para arquivos grandes.
                    var Registros = csvReader.GetRecords<Programa2>().ToList();

                    foreach (var registro in Registros)
                    {
                        System.Console.WriteLine("-----------------------------------------");
                        System.Console.WriteLine($"Nome: {registro.Nome}");
                        System.Console.WriteLine($"Apresentador: {registro.Apresentador}");
                        System.Console.WriteLine($"Salario: {registro.Salario}");
                        System.Console.WriteLine($"DataLancamento: {registro.Datalancamento}");
                    }
                }
            }
        }

        public static void InserirConteudoProgramaHeaderConfiguration(string arquivo, string pasta, List<Programa> lista)
        {
            var path = Path.Combine(Environment.CurrentDirectory, "src", pasta, arquivo);
            if (!File.Exists(path))
                throw new FileNotFoundException(path);
            using (var sw = new StreamWriter(path))
            {
                sw.Write("Nome;Apresentador;Salario;DataLançamento\n");
                foreach (var programa in lista)
                {
                    var linha = $"{programa.Nome};{programa.Apresentador};{programa.Salario};{programa.Datalancamento}";
                    sw.WriteLine(linha);
                }
            }
            var info = new FileInfo(path);
            System.Console.WriteLine($"Inserido conteúdo no arquivo {info.FullName}");
        }

        public static void LerArquivoProgramaHeaderConfiguration(string arquivo, string pasta)
        {
            var path = Path.Combine(Environment.CurrentDirectory, "src", pasta, arquivo);
            if (!File.Exists(path))
            {
                throw new FileNotFoundException($"O arquivo {path} não existe.!");
            }
            using (var sr = new StreamReader(path))
            {
                var info = new FileInfo(path);
                System.Console.WriteLine($"Relizando Leitura do arquivo {info.FullName}");
                var csvConfig = new CsvConfiguration(CultureInfo.InvariantCulture)
                {
                    Delimiter = ";"
                };
                using (var csvReader = new CsvReader(sr, csvConfig))
                {
                    //cuidado com ToList, para arquivos grandes.
                    var Registros = csvReader.GetRecords<Programa>().ToList();

                    foreach (var registro in Registros)
                    {
                        System.Console.WriteLine("-----------------------------------------");
                        System.Console.WriteLine($"Nome: {registro.Nome}");
                        System.Console.WriteLine($"Apresentador: {registro.Apresentador}");
                        System.Console.WriteLine($"Salario: {registro.Salario}");
                        System.Console.WriteLine($"DataLancamento: {registro.Datalancamento}");
                    }
                }
            }
        }






        public static void LerArquivoLivroPrecoCsvComDelimitadorClasseCsvHelper(string arquivo, string pasta)
        {
            var path = Path.Combine(Environment.CurrentDirectory, "src", pasta, arquivo);
            if (!File.Exists(path))
            {
                throw new FileNotFoundException($"O arquivo {path} não existe.!");
            }
            using (var sr = new StreamReader(path))
            {
                System.Console.WriteLine("Relizando Leitura do arquivo Livro-preco-com-virgula.csv");
                var csvConfig = new CsvConfiguration(CultureInfo.InvariantCulture)
                {
                    Delimiter = ";"
                };
                using (var csvReader = new CsvReader(sr, csvConfig))
                {
                    var Registros = csvReader.GetRecords<Livro>();

                    foreach (var registro in Registros)
                    {
                        System.Console.WriteLine("-----------------------------------------");
                        System.Console.WriteLine($"Titulo: {registro.Titulo}");
                        System.Console.WriteLine($"Autor: {registro.Autor}");
                        System.Console.WriteLine($"Preco: {registro.Preco}");
                        System.Console.WriteLine($"Lancamento: {registro.Lancamento}");
                    }
                }
            }
        }


        public static void InserirConteudoLivro(string arquivo, string pasta, List<Livro> lista)
        {
            var path = Path.Combine(Environment.CurrentDirectory, "src", pasta, arquivo);
            if (!File.Exists(path))
            {
                throw new FileNotFoundException($"O arquivo {path} não existe.!");
            }
            else
            {
                using (var sw = new StreamWriter(path))
                {
                    sw.Write("Titulo;Autor;Preco;Lancamento\n");
                    foreach (var livro in lista)
                    {
                        var linha = $"{livro.Titulo};{livro.Autor};{livro.Preco};{livro.Lancamento}";
                        sw.WriteLine(linha);
                    }
                }
                System.Console.WriteLine("Inserido conteúdo no arquivo.");
            }

        }

        public static void LerArquivoUsuarioCsvComClasseCsvHelper(string arquivo, string pasta)
        {
            var path = Path.Combine(Environment.CurrentDirectory, "src", pasta, arquivo);
            var fi = new FileInfo(path);
            if (!fi.Exists)
                throw new FileNotFoundException($"O arquivo {path} não existe.!");
            using (var sr = new StreamReader(fi.FullName))
            {
                System.Console.WriteLine("Relizando Leitura do arquivo .csv");
                var csvConfig = new CsvConfiguration(CultureInfo.InvariantCulture);
                using (var csvReader = new CsvReader(sr, csvConfig))
                {
                    var Registros = csvReader.GetRecords<Usuario>();

                    foreach (var registro in Registros)
                    {
                        System.Console.WriteLine("-----------------------------------------");
                        System.Console.WriteLine($"Nome: {registro.Nome}");
                        System.Console.WriteLine($"Idade: {registro.Idade}");
                        System.Console.WriteLine($"Celular: {registro.Celular}");
                    }
                }
            }

        }

        public static void InserirConteudoUsuario(string arquivo, string pasta, List<Usuario> lista)
        {
            var path = Path.Combine(Environment.CurrentDirectory, "src", pasta, arquivo);
            if (!File.Exists(path))
            {
                // System.Console.WriteLine($"O arquivo: {arquivo}, não existe na pasta: {pasta}");
                // return;
                throw new FileNotFoundException($"O arquivo {path} não existe.!");
            }
            else
            {
                using (var sw = new StreamWriter(path))
                {
                    sw.Write("Nome,Idade,Celular\n");
                    foreach (var usuario in lista)
                    {
                        var linha = $"{usuario.Nome},{usuario.Idade},{usuario.Celular}";
                        sw.WriteLine(linha);
                    }
                }
                System.Console.WriteLine("Inserido conteúdo no arquivo.");
            }
        }


        public static void LerArquivoCsvComCsvHelper(string arquivo, string pasta, List<Produto> listaDeProdutos)
        {
            var path = Path.Combine(Environment.CurrentDirectory, "src", pasta, arquivo);
            var fi = new FileInfo(path);
            if (!fi.Exists)
                throw new FileNotFoundException($"O arquivo {path} não existe.!");
            using (var sr = new StreamReader(fi.FullName))
            {
                System.Console.WriteLine("Relizando Leitura do arquivo .csv");
                var csvConfig = new CsvConfiguration(CultureInfo.InvariantCulture);
                using (var csvReader = new CsvReader(sr, csvConfig))
                {
                    var Registros = csvReader.GetRecords<dynamic>();

                    foreach (var registro in Registros)
                    {
                        System.Console.WriteLine("-----------------------------------------");
                        System.Console.WriteLine($"Nome: {registro.Nome}");
                        System.Console.WriteLine($"Preco: {registro.Preco}");
                        System.Console.WriteLine($"Quantidade: {registro.Quantidade}");
                    }
                }


            }

        }

        public static void InserirConteudo(string arquivo, string pasta, List<Produto> lista)
        {
            var path = Path.Combine(Environment.CurrentDirectory, "src", pasta, arquivo);
            if (!File.Exists(path))
            {
                // System.Console.WriteLine($"O arquivo: {arquivo}, não existe na pasta: {pasta}");
                // return;
                throw new FileNotFoundException($"O arquivo {path} não existe.!");
            }
            else
            {
                using (var sw = new StreamWriter(path))
                {
                    sw.Write("Nome,Preco,Quantidade\n");
                    foreach (var produto in lista)
                    {
                        var linha = $"{produto.Nome},{produto.Preco},{produto.Quantidade}";
                        sw.WriteLine(linha);
                    }
                }
                System.Console.WriteLine("Inserido conteúdo no arquivo.");
            }


        }

        public static void CriarArquivo(string arquivo, string destino)
        {
            if (string.IsNullOrEmpty(arquivo))
            {
                System.Console.WriteLine("o nome o arquivo deve ser informado.");
                return;
            }
            var path = Path.Combine(Environment.CurrentDirectory, "src", destino, arquivo);
            if (!File.Exists(path))
            {
                File.Create(path);
            }
            else
            {
                System.Console.WriteLine($"O arquivo já existe na pasta: {path}");
                return;
            }
        }
        public static void CriarPasta(string caminho)
        {
            if (string.IsNullOrEmpty(caminho))
            {
                System.Console.WriteLine("o nome da pasta deve ser informado");
            }
            var path = Path.Combine(Environment.CurrentDirectory, "src", caminho);
            if (Directory.Exists(path))
            {
                System.Console.WriteLine($"Diretorio: {caminho} já existe.");
                return;
            }
            Directory.CreateDirectory(path);
        }
    }
}
