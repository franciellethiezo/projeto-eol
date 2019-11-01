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
    public class UsuarioController : ControllerBase
    {
        UsuarioRepositorio userRepositorio = new UsuarioRepositorio();

        [HttpGet("listar")]
        public async Task<ActionResult<List<Usuario>>> Get()
        {
            try
            {
                List<Usuario> lstUsuario = await userRepositorio.Get();

                if (lstUsuario == null)
                {
                    return NotFound();
                }

                foreach (Usuario item in lstUsuario)
                {
                    item.FkIdTipoUsuarioNavigation = null;
                }

                return lstUsuario;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpGet("buscar/{id}")]
        public async Task<ActionResult<Usuario>> Get(int id)
        {
            try
            {
                Usuario lstUsuario = await userRepositorio.Get(id);

                if (lstUsuario == null)
                {
                    return NotFound();
                }

                return lstUsuario;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost("inserir")]
        public async Task<ActionResult<Usuario>> Post(Usuario user)
        {
            try
            {
                return await userRepositorio.Post(user);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPut("alterar")]
        public async Task<ActionResult<Usuario>> Put(int id, Usuario user)
        {
            if (id != user.IdUsuario)
            {
                return BadRequest();
            }

            try
            {
                return await userRepositorio.Put(user);
            }
            catch (DbUpdateConcurrencyException)
            {
                var usuarioValido = userRepositorio.Get(id);

                if (usuarioValido == null)
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
        }

        [HttpDelete("deletar/{id}")]
        public async Task<ActionResult<Usuario>> Delete(int id)
        {
            try
            {
                Usuario usuarioRetornado = await userRepositorio.Get(id);

                if (usuarioRetornado == null)
                {
                    return NotFound();
                }

                await userRepositorio.Delete(usuarioRetornado);

                return usuarioRetornado;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}