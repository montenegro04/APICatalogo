using APICatalogo.Context;
using APICatalogo.Interfaces;
using APICatalogo.Models;
using APICatalogo.Pagination;

namespace APICatalogo.Repositories;

public class ProdutoRepository : Repository<Produto>, IProdutoRepository
{
    public ProdutoRepository(AppDbContext context) : base(context)
    {
    }

    // public IEnumerable<Produto> GetProdutos(ProdutosParameters produtosParams)
    // {
    //     return GetAll()
    //         .OrderBy(p => p.Nome)
    //         .Skip((produtosParams.PageNumber -1)* produtosParams.PageSize)
    //         .Take(produtosParams.PageSize).ToList();
    // }

    public PagedList<Produto> GetProdutos(ProdutosParameters produtosParams)
    {
        var produtos = GetAll().OrderBy(p => p.ProdutoId).AsQueryable();
        var produtosOrdenados = PagedList<Produto>.ToPagedList(produtos, produtosParams.PageNumber, produtosParams.PageSize);
        return produtosOrdenados;
    }

    public PagedList<Produto> GetProdutosFiltroPreco(ProdutosFiltroPreco produtoFiltroParams)
    {
        var produtos = GetAll().AsQueryable();
        if(produtoFiltroParams.Preco.HasValue && !string.IsNullOrEmpty(produtoFiltroParams.PrecoCriterio))
        {
            if(produtoFiltroParams.PrecoCriterio.Equals("maior", StringComparison.OrdinalIgnoreCase))
            {
                produtos = produtos.Where(p => p.Preco > produtoFiltroParams.Preco.Value).OrderBy(p => p.Preco);
            }
            else if(produtoFiltroParams.PrecoCriterio.Equals("menor", StringComparison.OrdinalIgnoreCase))
            {
                produtos = produtos.Where(p => p.Preco < produtoFiltroParams.Preco.Value).OrderBy(p => p.Preco);
            }
            else if(produtoFiltroParams.PrecoCriterio.Equals("igual", StringComparison.OrdinalIgnoreCase))
            {
                produtos = produtos.Where(p => p.Preco == produtoFiltroParams.Preco.Value).OrderBy(p => p.Preco);
            }
        }
        var produtosFiltrados = PagedList<Produto>.ToPagedList(produtos, produtoFiltroParams.PageNumber, produtoFiltroParams.PageSize);
        return produtosFiltrados;
    }

    public IEnumerable<Produto> GetProdutosPorCategoria(int id)
    {
        return GetAll().Where(p => p.CategoriaId == id);
    }
}