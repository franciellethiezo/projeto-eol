using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BancoEOL4US.Models;
using BancoEOL4US.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BancoEOL4US.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class ProdutoController : ControllerBase
    {
        ProdutoRepositorio repositorio = new ProdutoRepositorio();

        [HttpGet]
        public async Task<ActionResult<List<Produto>>> Get()
        {
            try
            {
                List<Produto> listaProduto = await repositorio.Get();
                if (listaProduto == null)
                {
                    return NotFound();
                }
                return listaProduto;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Produto>> Get(int id)
        {
            try
            {
                Produto produtoRetornado = await repositorio.Get(id);
                if (produtoRetornado == null)
                {
                    return NotFound();
                }
                return produtoRetornado;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost]
        public async Task<ActionResult<Produto>> Post(Produto produto)
        {
            try
            {
                return await repositorio.Post(produto);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Produto>> Put(int id, Produto produto)
        {
            if (id != produto.IdProduto)
            {
                return BadRequest();
            }
            try
            {
                return await repositorio.Put(produto);
            }
            catch (DbUpdateConcurrencyException ex)
            {
                var produtoValido = repositorio.Get(id);
                if (produtoValido == null)
                {
                    return NotFound();
                }
                else
                {
                    throw ex;
                }
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Produto>> Delete(int id)
        {
            try
            {
                Produto produtoRetornado = await repositorio.Get(id);
                if (produtoRetornado == null)
                {
                    return NotFound();
                }
                await repositorio.Delete(produtoRetornado);
                return produtoRetornado;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}