using System;
using System.Xml;

namespace ExampleExtensions.src.Model
{
    public class XML : Aprovador
{
    public override void ProcessRequest(Conta conta, Formato formato)
    {
        if (Formato.XML.Equals(formato))
        {
            System.Console.WriteLine("retorne a requisição co formato XML");
            System.Xml.Serialization.XmlSerializer x = new System.Xml.Serialization.XmlSerializer(conta.GetType());
            x.Serialize(Console.Out, conta);
            System.Console.WriteLine();
            Console.WriteLine("--------------------------------------------");
        }
        Successor.ProcessRequest(conta, formato);
    }
}
}
