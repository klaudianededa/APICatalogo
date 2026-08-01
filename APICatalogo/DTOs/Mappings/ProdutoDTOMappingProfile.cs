using APICatalogo.Models;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APICatalogo.DTOs.Mappings;

internal class ProdutoDTOMappingProfile : Profile
{
    public ProdutoDTOMappingProfile()
    {
            CreateMap<Produto, ProdutoDTO>().ReverseMap();
            CreateMap<Categoria, CategoriaDTO>().ReverseMap();
    }
}
