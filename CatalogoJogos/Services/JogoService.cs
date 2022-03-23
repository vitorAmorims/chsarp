using CatalogoJogos.Repositories;

namespace CatalogoJogos.Services
{
    public class JogoService
    {
        private readonly IGameRepository _jogoRepository;
        public JogoService(IGameRepository jogoRepository)
        {
            _jogoRepository = jogoRepository;
        }
        
    }
}
