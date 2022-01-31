using System;
using System.Collections.Generic;
using Xunit;

namespace Ex2WithXml.Tests
{
    public class UnitTest1
    {
        [Fact]
        public void DeveRetornarOsNomesDosAutomoveis()
        {
            var objEx2Xml = new Exemplo2();
            var listaDeFabricantes = objEx2Xml.ListarOsNomesDosFabricantes();
            List<string> Fabricantes = new List<string>{"Volkswagen", "Hyundai", "Toyota"};

            System.Console.WriteLine("Lista dos fabricantes de automoveis do arquivo XML");
            foreach (var nome in listaDeFabricantes)
            {
                System.Console.WriteLine(nome);
            }

            for (var i = 0; i < Fabricantes.Count; i++)
            {
                Assert.Equal(Fabricantes[i], listaDeFabricantes[i]);
            }

        }     

        [Fact]
        public void DeveRetornarOsNomesDosAutomoveisESeusFabricantes()
        {
            var objEx2 = new Exemplo2();
            var resultado = objEx2.RetornarFabricanteENomeDoVeiculo();

            IDictionary<string,string> tabela = new Dictionary<string,string>();
            tabela.Add("Volkswagen", "Passat");
            tabela.Add("Hyundai", "Azera");
            tabela.Add("Toyota", "Corolla");

            Assert.Equal(tabela,resultado);
        }
    }
}
