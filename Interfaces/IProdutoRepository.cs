using APICatalogo.Models;
using APICatalogo.Pagination;

namespace APICatalogo.Interfaces;

public interface IProdutoRepository : IRepository<Produto>
{
    //IEnumerable<Produto> GetProdutos(ProdutosParameters produtosParams);
    PagedList<Produto> GetProdutos(ProdutosParameters produtosParams);
    PagedList<Produto> GetProdutosFiltroPreco(ProdutosFiltroPreco produtoFiltroParams);
    IEnumerable<Produto> GetProdutosPorCategoria(int id);
}