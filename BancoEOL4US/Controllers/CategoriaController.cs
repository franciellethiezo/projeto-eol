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

        /// <summary>
        /// Listagem de todas as categorias
        /// </summary>
        /// <returns>Retorna ao usuário uma lista com todas as categorias </returns>
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
        /// <summary>
        /// Lista de categoria específica
        /// </summary>
        /// <param name="id">Recebe o id da categoria informada</param>
        /// <returns>Retorna ao usuário as inormações da característica informada</returns>
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
        /// <summary>
        /// Incusão de nova categoria
        /// </summary>
        /// <param name="categoria"> Parâmetro recebe uma nova categoria</param>
        /// <returns> Retorna ao usuário os campos para criar uma nova categoria </returns>
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

        /// <summary>
        /// Alteração de anúncio específico
        /// </summary>
        /// <param name="id"> Recebe o id específico de uma categoria </param>
        /// <param name="categoria"> Recebe as informações que serão alteradas</param>
        /// <returns>Retorna ao usuário os campos para alteração de uma categoria</returns>
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
        /// <summary>
        /// Deleta uma categoria
        /// </summary>
        /// <param name="id"> Recebe o id da categoria que será deletada </param>
        /// <returns>Retorna ao usuário a informação de exclusão</returns>
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