using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BancoEOL4US.Models;
using BancoEOL4US.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BancoEOL4US.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class AnuncioController : ControllerBase
    {
        AnuncioRepositorio anunciorepositorio = new AnuncioRepositorio();
        
        [HttpGet]

        public async Task<ActionResult<List<Anuncio>>> Get()
        {
          try
          {
              List<Anuncio> listaAnuncio = await anunciorepositorio.Get();
              if (listaAnuncio == null)
              {
               return NotFound();   
              }

              foreach(var item in listaAnuncio){
                  item.FkIdCondicaoNavigation.Anuncio = null;
                  item.FkIdProdutoNavigation.Anuncio = null;
              }

              return listaAnuncio;
          }
          catch (Exception ex)
          {
              
              throw ex;
          }
        }
        
        [HttpGet ("buscapreco/{preco}")]

        public async Task<ActionResult<List<Anuncio>>> Get ( int preco)
        {
            try
            {
                List<Anuncio> anuncioRetornado = await anunciorepositorio.BuscaPorPreco(preco);
                return anuncioRetornado;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // [HttpGet ("buscaCondicao/{condicao}")]

        // public async Task<ActionResult<List<Anuncio>>> Get (string condicao)
        // {
        //     try
        //     {
        //         List<Anuncio> anuncioRetornado = await anunciorepositorio.BuscaPorCondicao(condicao);
        //         return anuncioRetornado;
        //     }
        //     catch (Exception ex)
        //     {
        //         throw ex;
        //     }
        // }

        [HttpGet ("buscaCondicao/{marca}%{estado}")]

        public async Task<ActionResult<List<Anuncio>>> BuscaPorMarcaEstado (string marca, string estado)
        {
            try
            {
                List<Anuncio> anuncioRetornado = await anunciorepositorio.BuscaPorMarcaCondicao(marca, estado);
                return anuncioRetornado;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }





        [HttpPost]

        public async Task<ActionResult<Anuncio>> Post (Anuncio anuncio)
        {
            try
            {
                return await anunciorepositorio.Post(anuncio);
            }
            catch (Exception ex)
            {   
                throw ex;
            }
        }
        
        [HttpPut ("{id}")]
    
        public async Task<ActionResult<Anuncio>> Put(int id, Anuncio anuncio)
        {
            if (id != anuncio.IdAnuncio)
            {
                return BadRequest();
            }
            try
            {
                return await anunciorepositorio.Put(anuncio); 
            }
            catch (DbUpdateConcurrencyException ex)
            { 
                var anuncioValido = anunciorepositorio.Get(id);
                if (anuncioValido == null)
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

        public async Task<ActionResult<Anuncio>> Delete (int id)
        {
            try
            {
                Anuncio anuncioRetornado = await anunciorepositorio.Get(id);
               
                if (anuncioRetornado == null)
                {
                    return NotFound();
                }
                await anunciorepositorio.Delete(anuncioRetornado);
                return anuncioRetornado;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}