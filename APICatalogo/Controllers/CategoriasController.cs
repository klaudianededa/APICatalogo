using APICatalogo.DTOs;
using APICatalogo.DTOs.Mappings;
using APICatalogo.Models;
using APICatalogo.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APICatalogo.Controllers;

[Route("[controller]")]
[ApiController]
public class CategoriasController : ControllerBase
{
    private readonly IUnitOfWork _uof;
    private readonly ILogger<CategoriasController> _logger;

    public CategoriasController(ILogger<CategoriasController> logger, IUnitOfWork uof)
    {
        _logger = logger;
        _uof = uof;
    }

    [HttpGet]
    public ActionResult<IEnumerable<CategoriaDTO>> Get()
    {
        var categorias = _uof.CategoriaRepository.GetAll();

        if (categorias is null)
            return NotFound("Nenhuma categoria encontrada...");

        //var categoriasDto = new List<CategoriaDTO>();
        //foreach (var categoria in categorias)
        //{
        //     var categoriaDto = new CategoriaDTO
        //    {
        //        CategoriaId = categoria.CategoriaId,
        //        Nome = categoria.Nome,
        //        ImagemUrl = categoria.ImagemUrl
        //    };
        //    categoriasDto.Add(categoriaDto);
        //}

        var categoriasDto = categorias.ToCategoriaDTOList();

        return Ok(categoriasDto);
    }

    [HttpGet("{id:int}", Name = "ObterCategoria")]
    public ActionResult<CategoriaDTO> Get(int id)
    {
        var categoria = _uof.CategoriaRepository.Get(c => c.CategoriaId == id);

        if (categoria is null)
        {
            _logger.LogWarning($"Categoria com id= {id} não encontrada...");
            return NotFound($"Categoria com id= {id} não encontrada...");
        }

        //var categoriaDto = new CategoriaDTO
        //{
        //    CategoriaId = categoria.CategoriaId,
        //    Nome = categoria.Nome,
        //    ImagemUrl = categoria.ImagemUrl
        //};

        var categoriaDto = categoria.ToCategoriaDTO();

        return Ok(categoriaDto);
    }

    [HttpPost]
    public ActionResult<CategoriaDTO> Post(CategoriaDTO categoriaDto)
    {
        if (categoriaDto is null)
        {
            _logger.LogWarning($"Dados inválidos...");
            return BadRequest("Dados inválidos");
        }

        //var categoria = new Categoria() //convertendo DTO para entidade
        //{
        //    CategoriaId = categoriaDto.CategoriaId,
        //    Nome = categoriaDto.Nome,
        //    ImagemUrl = categoriaDto.ImagemUrl
        //};

        var categoria = categoriaDto.ToCategoria();

        var categoriaCriada = _uof.CategoriaRepository.Create(categoria); //o create espera uma entidade, por isso a conversão acima
        _uof.Commit();

        //var novaCategoriaDto = new CategoriaDTO //convertendo entidade para DTO, pois o retorno da API é um DTO
        //{
        //    CategoriaId = categoriaCriada.CategoriaId,
        //    Nome = categoriaCriada.Nome,
        //    ImagemUrl = categoriaCriada.ImagemUrl
        //};

        var novaCategoriaDto = categoriaCriada.ToCategoriaDTO();

        return new CreatedAtRouteResult("ObterCategoria",  
            new { id = novaCategoriaDto.CategoriaId }, 
            novaCategoriaDto);
    }

    [HttpPut("{id:int}")]
    public ActionResult<CategoriaDTO> Put(int id, CategoriaDTO categoriaDto)
    {
        if (id != categoriaDto.CategoriaId)
        {
            _logger.LogWarning($"Dados inválidos...");
            return BadRequest("Dados inválidos");
        }

        //var categoria = new Categoria() //convertendo DTO para entidade
        //{
        //    CategoriaId = categoriaDto.CategoriaId,
        //    Nome = categoriaDto.Nome,
        //    ImagemUrl = categoriaDto.ImagemUrl
        //};

        var categoria = categoriaDto.ToCategoria();

        var categoriaAtualizada = _uof.CategoriaRepository.Update(categoria);
        _uof.Commit();

        //var categoriaAtualizadaDto = new CategoriaDTO //convertendo entidade para DTO, pois o retorno da API é um DTO
        //{
        //    CategoriaId = categoriaAtualizada.CategoriaId,
        //    Nome = categoriaAtualizada.Nome,
        //    ImagemUrl = categoriaAtualizada.ImagemUrl
        //};

        var categoriaAtualizadaDto = categoriaAtualizada.ToCategoriaDTO();

        return Ok(categoriaAtualizadaDto);
    }

    [HttpDelete("{id:int}")]
    public ActionResult<CategoriaDTO> Delete(int id)
    {
        var categoria = _uof.CategoriaRepository.Get(c => c.CategoriaId == id); 

        if (categoria is null)
        {
            _logger.LogWarning($"Categoria com id={id} não encontrada...");
            return NotFound($"Categoria com id={id} não encontrada...");
        }

        var categoriaExcluida = _uof.CategoriaRepository.Delete(categoria);
        _uof.Commit();
        
        //var categoriaExcluidaDto = new CategoriaDTO //convertendo entidade para DTO, pois o retorno da API é um DTO
        //{
        //    CategoriaId = categoriaExcluida.CategoriaId,
        //    Nome = categoriaExcluida.Nome,
        //    ImagemUrl = categoriaExcluida.ImagemUrl
        //};

        var categoriaExcluidaDto = categoriaExcluida.ToCategoriaDTO();

        return Ok(categoriaExcluidaDto);
     
    }
}