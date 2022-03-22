using System.Globalization;
using CsvHelper.Configuration;
using projectCSVHelper.src.Entities;

namespace projectCSVHelper.src.Mapping
{
    public class PadariaMap : ClassMap<Producao>
    {
        public PadariaMap()
        {
            Map(x => x.Nome).Name("nome");
            Map(x => x.Titulo).Name("titulo");
            Map(x => x.Preco).Name("preço")
                .TypeConverterOption
                .CultureInfo(CultureInfo
                .GetCultureInfo("pt-BR"));
            Map(x => x.DataFabricacao).Name("dataFabricacao");
            Map(x => x.DataVencimento).Name("dataVencimento");
        }
    }
}
