using AutoMapper;
using ProjetoCadastroCliente.Data.Dtos;
using ProjetoCadastroCliente.Models;
namespace ProjetoCadastroCliente.Profiles
{
    public class ClienteProfile: Profile
    {
        public ClienteProfile() {
            CreateMap<CreateClienteDto, Cliente>();
            CreateMap<UpdateClienteDto, Cliente>();
            CreateMap<Cliente, UpdateClienteDto>();
            CreateMap<Cliente, ReadClienteDto>();
        }
    }
}
