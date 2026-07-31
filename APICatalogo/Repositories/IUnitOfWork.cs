namespace APICatalogo.Repositories;

public interface IUnitOfWork
{
    //poderia ser tambem com o repositorio generico:
    //IRepository<Produto> ProdutoRepository { get; }
    //IRepository<Categoria> CategoriaRepository { get; }
    IProdutoRepository ProdutoRepository { get; }
    ICategoriaRepository CategoriaRepository { get; }
    void Commit();
}
