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
    public class CondicaoController : ControllerBase
    {
        CondicaoRepositorio repositorio = new CondicaoRepositorio();

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<List<Condicao>>> Get()
        {
            try
            {
                List<Condicao> listaCondicao = await repositorio.Get();

                if (listaCondicao == null)
                {
                    return NotFound();
                }
                return listaCondicao;
            }
            catch (System.Exception)
            {

                throw;
            }
        }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<Condicao>> Get(int id)
        {
            try
            {
                Condicao condicaoRetornada = await repositorio.Get(id);
                if (condicaoRetornada == null)
                {
                    return NotFound();
                }
                return condicaoRetornada;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="condicao"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<Condicao>> Post(Condicao condicao)
        {
            try
            {
                return await repositorio.Post(condicao);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="condicao"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<ActionResult<Condicao>> Put(int id, Condicao condicao)
        {
            if (id != condicao.IdCondicao)
            {
                return BadRequest();
            }

            try
            {
                return await repositorio.Put(condicao);
            }
            catch (DbUpdateConcurrencyException)
            {
                var condicaoValida = repositorio.Get(id);
                if (condicaoValida == null)
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
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<ActionResult<Condicao>> Delete(int id)
        {
            try
            {
                Condicao condicaoRetornada = await repositorio.Get(id);
                if (condicaoRetornada == null)
                {
                    return NotFound();
                }
                await repositorio.Delete(condicaoRetornada);
                return condicaoRetornada;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}