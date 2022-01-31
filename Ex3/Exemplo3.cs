using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using System.Xml;


namespace Ex3
{
    public class Exemplo3
    {
        public IDictionary<int, string> RetornarDicionarioComIdENomeDaMusica()
        {
            XElement root = XElement.Load(@"../../../../Ex3/Data/AluraTunes.xml");
            // System.Console.WriteLine(root);

            IDictionary<int, string> dicionario = new Dictionary<int, string>();

            var queryXml = from m in root.Element("Musicas")
                         .Elements("Musica")
                           select m;

            foreach (var item in queryXml)
            {
                dicionario.Add(Convert.ToInt32(item.Element("MusicaId").Value), item.Element("Nome").Value);

            }

            return dicionario;
        }

        public List<string> RetornarIdNomeMusicaENomeGenero()
        {
            XElement root = XElement.Load(@"../../../../Ex3/Data/AluraTunes.xml");

            var queryXml = from m in root.Element("Musicas").Elements("Musica")
                           join g in root.Element("Generos").Elements("Genero")
                           on m.Element("GeneroId").Value equals g.Element("GeneroId").Value
                           select new
                           {
                               IdMusica = m.Element("MusicaId").Value,
                               NomeMusica = m.Element("Nome").Value,
                               NomeGenero = g.Element("Nome").Value
                           };
            
            List<string> dadosDeRetorno = new List<string>();

            foreach (var item in queryXml)
            {
                var stringCominformacoes = $"{item.IdMusica} - {item.NomeGenero} - {item.NomeGenero}";
                dadosDeRetorno.Add(stringCominformacoes);
            }

            return dadosDeRetorno;

        }
    }
}
