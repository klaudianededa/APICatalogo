using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APICatalogo.Pagination;

public class CategoriasFiltroNome : QueryStringParameters
{
    public string? Nome { get; set; }
}
