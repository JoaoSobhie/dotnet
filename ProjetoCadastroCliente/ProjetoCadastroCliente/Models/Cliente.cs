using System.ComponentModel.DataAnnotations;

namespace ProjetoCadastroCliente.Models
{
    public class Cliente
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required]
        public string nome { get; set; }

        [Required]
        public string cpfcnpj{ get; set;}

        public string email { get; set;}

        public string telefone { get; set;}
        
        public string endereco { get;set;}
        public string cep { get; set;}

    }
}
