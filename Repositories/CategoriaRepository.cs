using APICatalogo.Context;
using APICatalogo.Interfaces;
using APICatalogo.Models;
using APICatalogo.Pagination;

namespace APICatalogo.Repositories;

public class CategoriaRepository : Repository<Categoria>, ICategoriaRepository
{
   public CategoriaRepository(AppDbContext context) : base(context)
   {
   }

    public async Task<PagedList<Categoria>> GetCategoriasAsync(CategoriasParameters categoriasParams)
    {
        var categorias = GetQueryable();
        var categoriasOrdenadas = categorias.OrderBy(p => p.CategoriaId);
        var resultado = await PagedList<Categoria>.ToPagedListAsync(categoriasOrdenadas, categoriasParams.PageNumber, categoriasParams.PageSize);

        return resultado;
    }
}