using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using PrimeiroApp.Data;
using PrimeiroApp.Data.Dtos;
using PrimeiroApp.Models;

namespace PrimeiroApp.Controllers
{

    [ApiController]
    [Route("[Controller]")]
    public class FilmeController : ControllerBase
    {
        private FilmeContext _context;
        private IMapper _mapper;

        public FilmeController(FilmeContext context, IMapper mapper)
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
        //public void AdicionaFilme([FromBody] Filme filme) {
        public IActionResult AdicionaFilme([FromBody] CriateFilmeDto filmeDto)
        {
            Filme filme = _mapper.Map<Filme>(filmeDto);

            //Validação na mão:
            //if(!string.IsNullOrEmpty(filme.Titulo) && !string.IsNullOrEmpty(filme.Genero) && (filme.Duracao > 400)){
            //    filmes.Add(filme);
            //    Console.WriteLine(filme.Titulo);
            //    Console.WriteLine(filme.Duracao);
            //}
            // RECOMENDADO USAR AS DATA ANNOTATIONS NO MODEL

            _context.Filmes.Add(filme);
            _context.SaveChanges();
            return CreatedAtAction(nameof(RecuperaFilmePorId),
            new { id = filme.id },
            filme);
            // filmes.Add(filme);
            //Console.WriteLine(filme.Titulo);
            //Console.WriteLine(filme.Duracao);
        }

        //BUSCA TODOS OS FILMES NA BASE
        [HttpGet("recuperaFilme")]
        public IEnumerable<Filme> RecuperaFilmes()
        {
            //return filmes;
            return _context.Filmes;
        }


        // BUSCA POR ID
        [HttpGet("recuperaFilmePorId/{id}")]
        public Filme? RecuperaFilmePorId(int id )
        {
            //return filmes.FirstOrDefault(filme => filme.id == id);
            return _context.Filmes.FirstOrDefault(filme => filme.id == id);
        }

        // BUSCA POR QUANTIA ENVIANDO NA URL O PARAMETRO
        [HttpGet("recuperaPorQuantia")]
        public IEnumerable<Filme> RecuperaPorQuantia([FromQuery] int skip = 0, [FromQuery] int take = 50)
        {
            //return filmes.Skip(skip).Take(take);
            return _context.Filmes.Skip(skip).Take(take);
        }

        [HttpGet("recuperaPorQuantiaDTO")]
        public IEnumerable<ReadFilmeDto> RecuperaPorQuantiaDTO([FromQuery] int skip = 0, [FromQuery] int take = 50)
        {
            //return filmes.Skip(skip).Take(take);
            return _mapper.Map<List<ReadFilmeDto>>(_context.Filmes.Skip(skip).Take(take));
        }

        //VALIDANDO EXISTENCIA COM RESPONSE 404 OU 200  E ASSIM POR DIANTE
        [HttpGet("validaURL/{id}")]
        public IActionResult ValidaUrlExiste(int id)
        {
            //var filme = filmes.FirstOrDefault(filme => filme.id == id);
            var filme = _context.Filmes.FirstOrDefault(filme => filme.id == id);
            if (filme == null) return NotFound();
            var filmeDto = _mapper.Map<ReadFilmeDto>(filme);
            return Ok(filmeDto);
        }

        //Validando Criação de Objeto
        //int id = 0;
        //[HttpPost]
        //public IActionResult AdicionaFilmeValidando([FromBody] Filme filme)
        //{
        //    filme.id = id++ ;
        //    //filmes.Add(filme);
        //    _context.Filmes.Add(filme);
        //    return CreatedAtAction(nameof(RecuperaFilmePorId), new { id = filme.id }, filme);
        //    //Console.WriteLine(filme.Titulo);
        //    //Console.WriteLine(filme.Duracao);
        //}
        
        [HttpPut("{id}")]
        public IActionResult AtualizaFilme(int id, [FromBody] UpdateFilmeDto filmeDto)
        {
            var filme = _context.Filmes.FirstOrDefault(filme=> filme.id == id);
            if (filme == null) return NotFound();
            _mapper.Map(filmeDto, filme);
            _context.SaveChanges();
            return NoContent();
        }

        [HttpPatch("{id}")]
        public IActionResult AtualizaFilmePatch(int id, JsonPatchDocument<UpdateFilmeDto> patch)
        {
            var filme = _context.Filmes.FirstOrDefault(filme => filme.id == id);
            if (filme == null) return NotFound();

            var filmeParaAtualizar = _mapper.Map<UpdateFilmeDto>(filme);

            patch.ApplyTo(filmeParaAtualizar, ModelState);
            if (!TryValidateModel(filmeParaAtualizar))
            {
                return ValidationProblem(ModelState);
            }

            _mapper.Map(filmeParaAtualizar, filme);
            _context.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeletaFilme(int id)
        {
            var filme  = _context.Filmes.FirstOrDefault(filme => filme.id == id);
            if (filme == null) return NotFound();
            _context.Remove(filme);
            _context.SaveChanges();
            return NoContent();

        }

        
    }
}
