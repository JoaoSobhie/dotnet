using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ProjetoCadastroCliente.Data;
using ProjetoCadastroCliente.Data.Dtos;
using ProjetoCadastroCliente.Models;
namespace ProjetoCadastroCliente.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class ClienteController : ControllerBase
    {
        private ClienteContext _context;
        private IMapper _mapper;

        public ClienteController(ClienteContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        /// <summary>
        /// Adiciona um filme ao banco de dados
        /// </summary>
        /// <param name="filmeDto">Objeto com os campos necessários para criação de um filme</param>
        /// <returns>IActionResult</returns>
        /// <response code="201">Caso inserção seja feita com sucesso</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public IActionResult AdicionaCliente([FromBody] CreateClienteDto clienteDto) {
            Cliente cliente = _mapper.Map<Cliente>(clienteDto);
            _context.Cliente.Add(cliente);
            _context.SaveChanges();
            return CreatedAtAction(nameof(RecuperaClientePorId), new { id = cliente.Id }, cliente);
        }

        [HttpGet("buscaporid/{id}")]
        public IActionResult RecuperaClientePorId(int id)
        {
            var cliente = _context.Cliente.FirstOrDefault(clinte => clinte.Id == id);
            if (cliente == null) return NotFound();
            var clienteDto = _mapper.Map<ReadClienteDto>(cliente);
            return Ok(clienteDto);
        }
        [HttpGet("all")]
        public IEnumerable<Cliente> All() {
            return _context.Cliente;
        }

        [HttpGet("buscapornome/{nome}")]
        public IActionResult RecuperaClientePorNome(string nome)
        {
            var cliente = _context.Cliente.FirstOrDefault(clinte => clinte.nome == nome);
            if (cliente == null) return NotFound();
            var clienteDto = _mapper.Map<ReadClienteDto>(cliente);
            return Ok(clienteDto);
        }

        [HttpPut("{id}")]
        public IActionResult AtualizaCliente(int id, [FromBody] UpdateClienteDto clienteDto)
        {
            var cliente = _context.Cliente.FirstOrDefault(clinte => clinte.Id == id);
            if (cliente == null) return NotFound();
            _mapper.Map(clienteDto, cliente);
            _context.SaveChanges();
            return NoContent();

        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCliente(int id)
        {
            var cliente = _context.Cliente.FirstOrDefault(cliente => cliente.Id == id);
            if (cliente == null) return NotFound(id);
            _context.Remove(cliente);
            _context.SaveChanges();
            return NoContent();
        }



    }
}
