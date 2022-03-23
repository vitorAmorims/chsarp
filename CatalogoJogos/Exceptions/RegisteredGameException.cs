using System;

namespace CatalogoJogos.Exceptions
{
    public class RegisteredGameException: Exception
    {
        public RegisteredGameException():base("Este jogo já existe.")
        {
            
        }
    }
}
