using System.ComponentModel.DataAnnotations;

namespace ProjetoCadastroCliente.Data.Dtos
{
    public class ReadClienteDto
    {
        
        public string nome { get; set; }
        public string cpfcnpj { get; set; }
        public string email { get; set; }
        public string telefone { get; set; }
        public string endereco { get; set; }
        public string cep { get; set; }
    }
}
