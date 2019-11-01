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
    public class CategoriaController : ControllerBase
    {
        CategoriaRepositorio categoriarespositorio = new CategoriaRepositorio();

        [HttpGet]
        public async Task<ActionResult<List<Categoria>>> Get()
        {
            try
            {
                List<Categoria> listaCategoria = await categoriarespositorio.Get();
                if (listaCategoria == null)
                {
                    return NotFound();
                }

                return listaCategoria;
            }

            catch (Exception ex)
            {

                throw ex;
            }

        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Categoria>> Get(int id)
        {

            try
            {
                Categoria categoriaRetornada = await categoriarespositorio.Get(id);

                if (categoriaRetornada == null)
                {
                    return NotFound();
                }

                return categoriaRetornada;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        [HttpPost]
        public async Task<ActionResult<Categoria>> Post(Categoria categoria)
        {
            try
            {
                return await categoriarespositorio.Post(categoria);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Categoria>> Put(int id, Categoria categoria)
        {
            if (id != categoria.IdCategoria)
            {
                return BadRequest();
            }

            try
            {
                return await categoriarespositorio.Put(categoria);

            }
            catch (DbUpdateConcurrencyException)
            {
                var categoriaValida = categoriarespositorio.Get(id);
                if (categoriaValida == null)
                {
                    return NotFound();
                }

                else
                {
                    throw;
                }
            }
            
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Categoria>> Delete(int id)
        {
            try
            {
                Categoria categoriaRetornada = await categoriarespositorio.Get(id);

                if (categoriaRetornada == null)
                {
                    return NotFound();
                }
                await categoriarespositorio.Delete(categoriaRetornada);
                return categoriaRetornada;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

    }

}