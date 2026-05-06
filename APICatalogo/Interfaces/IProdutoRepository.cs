using APICatalogo.Models;
using APICatalogo.Pagination;

namespace APICatalogo.Interfaces;

public interface IProdutoRepository : IRepository<Produto>
{
    //IEnumerable<Produto> GetProdutos(ProdutosParameters produtosParams);
    Task<PagedList<Produto>> GetProdutosAsync(ProdutosParameters produtosParams);
    Task<PagedList<Produto>> GetProdutosFiltroPrecoAsync(ProdutosFiltroPreco produtoFiltroParams);
    Task<IEnumerable<Produto>> GetProdutosPorCategoriaAsync(int id);
}