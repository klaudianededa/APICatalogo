using APICatalogo.Context;
<<<<<<< HEAD
using APICatalogo.Filters;
using APICatalogo.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
=======
using APICatalogo.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
>>>>>>> 79843e2aff15604942b57c8b83ebb6416177ddb8

namespace APICatalogo.Controllers;

[Route("[controller]")]
[ApiController]
public class CategoriasController : ControllerBase
{
    private readonly AppDbContext _context;
<<<<<<< HEAD
    private readonly ILogger<CategoriasController> _logger;

    public CategoriasController(AppDbContext context, ILogger<CategoriasController> logger)
    {
        _context = context;
        _logger = logger;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Categoria>>> Get()
    {
        return await _context.Categorias.AsNoTracking().ToListAsync();
=======
    public CategoriasController(AppDbContext context)
    {
        _context = context; //injecao de dependencia
    }

    [HttpGet("produtos")]
    public ActionResult<IEnumerable<Categoria>> GetCategoriaProdutos()
    {
        return _context.Categorias.Include(p => p.Produtos).ToList();
    }

    [HttpGet]
    public ActionResult<IEnumerable<Categoria>> Get()
    {
        return _context.Categorias.ToList();
>>>>>>> 79843e2aff15604942b57c8b83ebb6416177ddb8
    }

    [HttpGet("{id:int}", Name = "ObterCategoria")]
    public ActionResult<Categoria> Get(int id)
    {
        var categoria = _context.Categorias.FirstOrDefault(p => p.CategoriaId == id);
<<<<<<< HEAD

        if (categoria == null)
        {
            _logger.LogWarning($"Categoria com id= {id} não encontrada...");
            return NotFound($"Categoria com id= {id} não encontrada...");
=======
        if (categoria is null)
        {
            return NotFound("Categoria não encontrada...");
>>>>>>> 79843e2aff15604942b57c8b83ebb6416177ddb8
        }
        return Ok(categoria);
    }

    [HttpPost]
    public ActionResult Post(Categoria categoria)
    {
        if (categoria is null)
<<<<<<< HEAD
        {
            _logger.LogWarning($"Dados inválidos...");
            return BadRequest("Dados inválidos");
        }
=======
            return BadRequest();
>>>>>>> 79843e2aff15604942b57c8b83ebb6416177ddb8

        _context.Categorias.Add(categoria);
        _context.SaveChanges();

<<<<<<< HEAD
        return new CreatedAtRouteResult("ObterCategoria", new { id = categoria.CategoriaId }, categoria);
=======
        return new CreatedAtRouteResult("ObterCategoria",
            new { id = categoria.CategoriaId }, categoria);
>>>>>>> 79843e2aff15604942b57c8b83ebb6416177ddb8
    }

    [HttpPut("{id:int}")]
    public ActionResult Put(int id, Categoria categoria)
    {
        if (id != categoria.CategoriaId)
        {
<<<<<<< HEAD
            _logger.LogWarning($"Dados inválidos...");
            return BadRequest("Dados inválidos");
=======
            return BadRequest();
>>>>>>> 79843e2aff15604942b57c8b83ebb6416177ddb8
        }

        _context.Entry(categoria).State = EntityState.Modified;
        _context.SaveChanges();
<<<<<<< HEAD
=======

>>>>>>> 79843e2aff15604942b57c8b83ebb6416177ddb8
        return Ok(categoria);
    }

    [HttpDelete("{id:int}")]
    public ActionResult Delete(int id)
    {
        var categoria = _context.Categorias.FirstOrDefault(p => p.CategoriaId == id);

<<<<<<< HEAD
        if (categoria == null)
        {
            _logger.LogWarning($"Categoria com id={id} não encontrada...");
            return NotFound($"Categoria com id={id} não encontrada...");
        }

        _context.Categorias.Remove(categoria);
        _context.SaveChanges();
        return Ok(categoria);
    }
}
=======
        if (categoria is null)
        {
            return NotFound("Categoria não localizada...");
        }
        _context.Categorias.Remove(categoria); //excluindo a categoria do banco de dados
        _context.SaveChanges(); //salvando as alterações no banco de dados

        return Ok(categoria); //retornando a categoria excluída
    }
}

>>>>>>> 79843e2aff15604942b57c8b83ebb6416177ddb8
