using System;
using FluentValidation;
using FluentValidation.Results;

namespace Order.Model
{
    public class Agua : ItemComImposto
    {

        public Agua(string Marca, int Preco) : base("Agua", Marca, Preco)
        {

        }

        public override double getImposto(System.DateTime dateTime)
        {
            return 0.0;
        }
    }
}
