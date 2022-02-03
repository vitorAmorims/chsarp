using System.Collections;
using System.Text;

namespace FactoryMethod
{
    public abstract class Pizza
    {
        protected string Nome { get; set; }
        protected string Massa { get; set; }
        protected string Molho { get; set; }
        protected ArrayList ingredientes = new ArrayList();

        public string Preparar()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Preparando " + Nome + "\n");
            sb.Append(Massa + "\n");
            sb.Append(Molho + "\n");
            sb.Append("Ingredientes : " + "\n");

            foreach (string ingrediente in ingredientes)
            {
                sb.Append("\t" + ingrediente + "\n");
            }

            sb.Append(Assar());
            sb.Append(Fatiar());
            sb.Append(Embalar());
            sb.Append(Entregar());
            return sb.ToString();
        }

        public virtual string Assar()
        {
            return "\nAssar por 25 minutos com forno 350 graus.";
        }

        public virtual string Fatiar()
        {
            return "\nFatiar a pizza em pedaços.";
        }

        public virtual string Embalar()
        {
            return "\nRealizar a embalagem na pizza.";
        }

        public virtual string Entregar()
        {
            return "\nRealizar a entrega.";
        }
    }
}
