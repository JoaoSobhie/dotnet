using System.ComponentModel.DataAnnotations;

namespace PrimeiroApp.Data.Dtos
{
    public class CriateFilmeDto
    {
        //[Key]
        //[Required]
        //public int id { get; set; }

        // Utilizando data anotation para fazer validação
        [Required(ErrorMessage = "O Título do filme é obrigatório")]
        public string Titulo { get; set; }
        [Required(ErrorMessage = "O gênero do filme é obrigatório")]
        public string Genero { get; set; }
        [Required]
        [Range(70, 600, ErrorMessage = "A duração deve ter entre 70 e 600 minutos")]
        public int Duracao { get; set; }
    }
}
