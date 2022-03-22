using System.ComponentModel.DataAnnotations;

namespace CatalogoJogos.InputModel
{
    public class GameInputModel
    {
        [Required]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "Por favor, o Nome do jogo deve estar entre 3 e 100 caracteres.")]
        public string Name { get; set; }
        
        [Required]
        [StringLength(100, MinimumLength = 1, ErrorMessage = "Por favor, o nome da Prdutora do jogo deve estar entre 1 e 100 caracteres.")]
        public string Producer { get; set; }

        [Required]
        [Range(1, 1000, ErrorMessage = "Por favor, o Preço deve estar entre os valores de 1 e 1000")]
        public double Price { get; set; }
    }
}
