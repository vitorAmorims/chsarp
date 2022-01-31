using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using System.Xml;

namespace Ex2WithXml
{
    public class Exemplo2
    {
        public List<string> ListarOsNomesDosFabricantes()
        {
            XElement root = XElement.Load(@"../../../../Ex2WithXml/Data/Automoveis.xml");

            System.Console.WriteLine(root);

            var queryXml = from f in root.Element("Fabricantes")
                            .Elements("Fabricante")
                           select f;

            List<string> nomesFabricantes = new List<string>();
            foreach (var fabricante in queryXml)
            {
                System.Console.WriteLine("{0}", fabricante.Element("Nome").Value);
                nomesFabricantes.Add((fabricante.Element("Nome").Value).ToString());
            }
            return nomesFabricantes;
        }

        public IDictionary<string, string> RetornarFabricanteENomeDoVeiculo()
        {
            IDictionary<string, string> dicionario = new Dictionary<string, string>();

            XElement root = XElement.Load(@"../../../../Ex2WithXml/Data/Automoveis.xml");

            var queryXml = from f in root.Element("Fabricantes").Elements("Fabricante")
                           join m in root.Element("Modelos").Elements("Modelo")
                           on f.Element("FabricanteId").Value equals m.Element("FabricanteId").Value
                           select new
                           {
                               Fabricante = f.Element("Nome").Value,
                               Veiculo = m.Element("Nome").Value

                           };
            System.Console.WriteLine("Fabricantes e Veiculos");
            foreach (var fabricanteEVeiculo in queryXml)
            {
                System.Console.WriteLine("{0}\t{1}",fabricanteEVeiculo.Fabricante, fabricanteEVeiculo.Veiculo);
                dicionario.Add(fabricanteEVeiculo.Fabricante, fabricanteEVeiculo.Veiculo);
            }
            Console.ReadKey();
            return dicionario;
        }
    }
}
