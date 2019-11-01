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
    public class InteresseController : ControllerBase
    {
        InteresseRepositorio repositorio = new InteresseRepositorio();

        [HttpGet]

        public async Task<ActionResult<List<Interesse>>> Get()
        {
          try
          {
              List<Interesse> listaInteresse = await repositorio.Get();
              if (listaInteresse == null)
              {
               return NotFound();   
              }
              return listaInteresse;
          }
          catch (Exception ex)
          {
              
              throw ex;
          }
        }

        [HttpGet ("{id}")]

        public async Task<ActionResult<Interesse>> Get ( int id)
        {
            try
            {
                Interesse interesseRetornado = await repositorio.Get(id);
                if (interesseRetornado == null)
                {
                 return NotFound();   
                }

                return interesseRetornado;
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
        }
        
         [HttpPost]

        public async Task<ActionResult<Interesse>> Post (Interesse interesse)
        {
            try
            {
                return await repositorio.Post(interesse);
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
        }
        
        [HttpPut ("{id}")]
    
        public async Task<ActionResult<Interesse>> Put(int id, Interesse interesse)
        {
            if (id != interesse.IdInteresse)
            {
                return BadRequest();
            }

            try
            {
                return await repositorio.Put(interesse); 
            }
            catch (DbUpdateConcurrencyException ex)
            { 
                var interesseValido = repositorio.Get(id);
                if (interesseValido == null)
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

        public async Task<ActionResult<Interesse>> Delete (int id)
        {
            try
            {
                Interesse interesseRetornado = await repositorio.Get(id);
               
                if (interesseRetornado == null)
                {
                    return NotFound();
                }
                await repositorio.Delete(interesseRetornado);
                return interesseRetornado;
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
        }
    }
}