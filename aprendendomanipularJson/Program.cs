using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace aprendendoManipularJson
{
    class Program
    {
        static void Main(string[] args)
        {
            var end = new Endereco(Faker.Address.StreetName(),Faker.Address.UkPostCode());
            Pessoa pessoa = new Pessoa();
            pessoa.Nome = Faker.Name.First();
            pessoa.endereco = end;
            var jsonSerializado = JsonConvert.SerializeObject(pessoa);
            Console.WriteLine(jsonSerializado);
        }
    }

    public class Pessoa
    {
        public string Nome { get; set; }
        public Endereco endereco { get; set; }
        
        public Pessoa(){}

    }

    public class Endereco
    {
        public string Rua { get; set; }
        public string Numero { get; set; }

        public Endereco(string rua, string numero)
        {
            Rua = rua;
            Numero = numero;
        }
        public Endereco(){}
    }

}
