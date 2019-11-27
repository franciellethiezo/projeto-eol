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

    public class TipoUsuarioController : ControllerBase
    {
        TipoUsuarioRepositorio tipoUsuarioRepositorio = new TipoUsuarioRepositorio();

        [HttpGet]
        public async Task<ActionResult<List<TipoUsuario>>> Get()
        {
            try
            {
                List<TipoUsuario> listaTipoUsuario = await tipoUsuarioRepositorio.Get();
                if (listaTipoUsuario == null)
                {
                    return NotFound();
                }
                return listaTipoUsuario;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TipoUsuario>> Get(int id)
        {
            try
            {
                TipoUsuario tipoUsuarioRetornado = await tipoUsuarioRepositorio.Get(id);
                if (tipoUsuarioRetornado == null)
                {
                    return NotFound();
                }
                return tipoUsuarioRetornado;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        [HttpPost]
        public async Task<ActionResult<TipoUsuario>> Post(TipoUsuario tipoUsuario)
        {
            try
            {
                return await tipoUsuarioRepositorio.Post(tipoUsuario);

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<TipoUsuario>> Put(int id, TipoUsuario tipoUsuario)
        {
            if (id != tipoUsuario.IdTipoUsuario)
            {
                return BadRequest();
            }
            try
            {
                return await tipoUsuarioRepositorio.Put(tipoUsuario);
            }
            catch (DbUpdateConcurrencyException)
            {
                var tipoUsuarioValido = tipoUsuarioRepositorio.Get(id);
                if (tipoUsuarioValido == null)
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
        public async Task<ActionResult<TipoUsuario>> Delete(int id)
        {
            try
            {
                TipoUsuario tipoUsuarioRetornado = await tipoUsuarioRepositorio.Get(id);
                if (tipoUsuarioRetornado == null)
                {
                    return NotFound();
                }
                await tipoUsuarioRepositorio.Delete(tipoUsuarioRetornado);
                return tipoUsuarioRetornado;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}