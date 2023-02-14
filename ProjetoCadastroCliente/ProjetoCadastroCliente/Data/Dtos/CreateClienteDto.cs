using System.ComponentModel.DataAnnotations;

namespace ProjetoCadastroCliente.Data.Dtos
{
    public class CreateClienteDto
    {
        //public int id { get; set; }
        [Required(ErrorMessage ="O nome é obrigatório")]
        public string nome { get; set; }

        [Required(ErrorMessage = "Cpf ou Cnpj são obrigatórios")]
        public string cpfcnpj { get; set; }

        [Required(ErrorMessage ="Email de contato obrigatório")] 
        public string email { get; set;}

        public string telefone { get; set; }

        [Required(ErrorMessage ="Endereço obrigatório")]
        public string endereco { get; set;}

        public string cep { get; set; }
    }
}
