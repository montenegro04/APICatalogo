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

    public async Task<PagedList<Produto>> GetProdutosAsync(ProdutosParameters produtosParams)
    {
        var produtos = GetQueryable();
        var produtosOrdenados = produtos.OrderBy(p => p.ProdutoId);
        var resultado = await PagedList<Produto>.ToPagedListAsync(produtosOrdenados, produtosParams.PageNumber, produtosParams.PageSize);
        return resultado;
    }

    public async Task<PagedList<Produto>> GetProdutosFiltroPrecoAsync(ProdutosFiltroPreco produtoFiltroParams)
    {
        var produtos = GetQueryable();
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
        var produtosFiltrados = await PagedList<Produto>.ToPagedListAsync(produtos, produtoFiltroParams.PageNumber, produtoFiltroParams.PageSize);
        return produtosFiltrados;
    }

    public async Task<IEnumerable<Produto>> GetProdutosPorCategoriaAsync(int id)
    {
        var produtos = await GetAllAsync();
        var produtosCategoria = produtos.Where(p => p.CategoriaId == id);
        return produtosCategoria;
    }
}