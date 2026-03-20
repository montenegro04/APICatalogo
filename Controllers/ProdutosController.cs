using APICatalogo.Models;
using APICatalogo.Interfaces;
using Microsoft.AspNetCore.Mvc;
using APICatalogo.DTOs;
using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using APICatalogo.Pagination;
using Newtonsoft.Json;

namespace APICatalogo.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProdutosController : ControllerBase
{
    private readonly IUnitOfWork _uof;
    private readonly IMapper _mapper;
    private readonly ILogger _logger;
    public ProdutosController( IUnitOfWork uof, ILogger<ProdutosController> logger, IMapper mapper)
    {
        _uof = uof;
        _logger = logger;
        _mapper = mapper;
    }

    [HttpGet("produtos/{id}")]
    public ActionResult <IEnumerable<ProdutoDTO>> GetProdutosPorCategoria(int id)
    {
        var produtos = _uof.ProdutoRepository.GetProdutosPorCategoria(id);
        if (produtos is null)
        {
            return NotFound("Produtos não encontrados...");
        }
        var produtosDTO = _mapper.Map<List<ProdutoDTO>>(produtos);
        return Ok(produtosDTO);
    }

    [HttpGet("pagination")]
    public ActionResult<IEnumerable<ProdutoDTO>> Get([FromQuery] ProdutosParameters produtosParameters)
    {
        var produtos = _uof.ProdutoRepository.GetProdutos(produtosParameters);
        return ObterProdutos(produtos);
    }

     private ActionResult<IEnumerable<ProdutoDTO>> ObterProdutos(PagedList<Produto> produtos)
    {
        var metadata = new
        {
            produtos.TotalCount,
            produtos.PageSize,
            produtos.CurrentPage,
            produtos.TotalPages,
            produtos.HasNext,
            produtos.HasPrevious
        };

        Response.Headers.Append("X-Paginations", JsonConvert.SerializeObject(metadata));

        var produtosDTO = _mapper.Map<IEnumerable<ProdutoDTO>>(produtos);

        return Ok(produtosDTO);
    }

    [HttpGet("filter/preco/pagination")]
    public ActionResult<IEnumerable<ProdutoDTO>> GetProdutoFiltroPreco([FromQuery] ProdutosFiltroPreco produtosFiltroPreco)
    {
        var produtos = _uof.ProdutoRepository.GetProdutosFiltroPreco(produtosFiltroPreco);
        return ObterProdutos(produtos);
    }

    [HttpGet]
    public ActionResult<IEnumerable<ProdutoDTO>> Get()
    {
        var produtos =  _uof.ProdutoRepository.GetAll().ToList();
        if (produtos is null)
        {
            return NotFound("Produtos não encontrados...");
        }
       var produtosDTO = _mapper.Map<List<ProdutoDTO>>(produtos);
        return Ok(produtosDTO);
    }

    [HttpGet("{id}", Name = "ObterProduto")]
    public ActionResult<ProdutoDTO> Get(int id)
    {
        var produto = _uof.ProdutoRepository.Get(c => c.ProdutoId == id);
        if (produto is null)
        {
            return NotFound("Produto não encontrado...");
        }
        var produtoDTO = _mapper.Map<ProdutoDTO>(produto);
        return Ok(produtoDTO);
    }

    [HttpPost]
    public ActionResult<ProdutoDTO> Post(ProdutoDTO produtoDTO)
    {
        if (produtoDTO is null){
            return BadRequest();
        }
        var produto = _mapper.Map<Produto>(produtoDTO);

        var produtoCriado = _uof.ProdutoRepository.Create(produto);
        _uof.Commit();

        var produtoCriadoDTO = _mapper.Map<ProdutoDTO>(produtoCriado);

        return new CreatedAtRouteResult("ObterProduto", new { id = produtoCriado.ProdutoId }, produtoCriadoDTO);
    }

    [HttpPatch("{id}/UpdatePartial")]
    public ActionResult<ProdutoDTOUpdateResponse> Patch(int id,  JsonPatchDocument<ProdutoDTOUpdateRequest> patchProdutoDTO)
    {
        if(patchProdutoDTO is null || id <=0)
        {
            return BadRequest();
        }

        var produto = _uof.ProdutoRepository.Get(c => c.ProdutoId == id);

        if(produto is null)
        {
            return NotFound();
        }

        var produtoUpdateRequest = _mapper.Map<ProdutoDTOUpdateRequest> (produto);

        patchProdutoDTO.ApplyTo(produtoUpdateRequest, ModelState);

        if(!ModelState.IsValid || !TryValidateModel(produtoUpdateRequest))
        {
            return BadRequest(ModelState);
        }

        _mapper.Map(produtoUpdateRequest, produto);
        _uof.ProdutoRepository.Update(produto);
        _uof.Commit();

        return Ok(_mapper.Map<ProdutoDTOUpdateResponse>(produto));
    }

    [HttpPut("{id:int}")]
    public ActionResult<ProdutoDTO> Put(int id, ProdutoDTO produtoDTO)
    {
        if (id != produtoDTO.ProdutoId)
        {
            return BadRequest();
        }
        var produto = _mapper.Map<Produto>(produtoDTO);

        var produtoAtualizado = _uof.ProdutoRepository.Update(produto);
        _uof.Commit();

        var produtoAtualizadoDTO = _mapper.Map<ProdutoDTO>(produtoAtualizado);

        return Ok(produtoAtualizadoDTO);
    }

    [HttpDelete("{id:int}")]
    public ActionResult<ProdutoDTO> Delete(int id)
    {
        var produto = _uof.ProdutoRepository.Get(c => c.ProdutoId == id);
        if(produto is null)
        {
            return NotFound("Produto não encontrado...");
        }
        var produtoDeletado = _uof.ProdutoRepository.Delete(produto);
        _uof.Commit();

        var produtoDeletadoDTO = _mapper.Map<ProdutoDTO>(produtoDeletado);
        
        return Ok(produtoDeletadoDTO);
    }
}