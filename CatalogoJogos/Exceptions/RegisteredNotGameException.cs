using System;

namespace CatalogoJogos.Exceptions
{
    public class RegisteredNotGameException: Exception
    {
        public RegisteredNotGameException():base("Este jogo não existe.")
        {
            
        }
        
    }
}
