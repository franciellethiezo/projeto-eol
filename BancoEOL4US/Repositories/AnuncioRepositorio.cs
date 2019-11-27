using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BancoEOL4US.Interfaces;
using BancoEOL4US.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;

namespace BancoEOL4US.Repositories
{

    public class AnuncioRepositorio : IAnuncioInterface
    {
         Time2EOLContext context = new Time2EOLContext ();         
        public async Task<Anuncio> Delete(Anuncio anuncioRetornado)
        {
           {
               context.Anuncio.Remove(anuncioRetornado);
               await context.SaveChangesAsync();
               return anuncioRetornado;
           }
        }

        public async Task<List<Anuncio>> Get()
        {
            {
                List<Anuncio> anuncios = await context.Anuncio.Include(con => con.FkIdCondicaoNavigation).Include(pr => pr.FkIdProdutoNavigation).ToListAsync();
                
                foreach(var anuncio in anuncios)
                {
                    anuncio.FkIdCondicaoNavigation.Anuncio = null;
                    anuncio.FkIdProdutoNavigation.Anuncio = null;
                }

                return anuncios;
            }
        }

        public async Task<Anuncio> Get(int id)
        {
            {
                return await context.Anuncio.Include(c => c.FkIdCondicaoNavigation).Include(p => p.FkIdProduto).FirstOrDefaultAsync(a => a.IdAnuncio == id);
            }
        }
        
        public async Task<List<Anuncio>> BuscaPorPreco(int preco)
        {
            List<Anuncio> anuncios = await context.Anuncio.Where(anu => anu.PrecoAnuncio >= preco).ToListAsync();
            return anuncios;
        }

        public async Task<List<Anuncio>> BuscaPorMarcaCondicao(string categoria, string condicaoRecebida)
        {
            // Condicao condicao = await context.Condicao.Where(c => c.AvaliacaoCondicao == condicaoRecebida).FirstOrDefaultAsync();

            List<Anuncio> listaAnuncio = await context.Anuncio.Where(c => c.FkIdCondicaoNavigation.AvaliacaoCondicao == condicaoRecebida &&
             c.FkIdProdutoNavigation.FkIdCategoriaNavigation.MarcaCategoria == categoria).ToListAsync();

            return listaAnuncio;
        }

        public async Task<Anuncio> Post(Anuncio anuncio)
        {
           {
               await context.Anuncio.AddAsync(anuncio);
               await context.SaveChangesAsync();
               return anuncio;
           }
        }

        public async Task<Anuncio> Put(Anuncio anuncio)
        {
          {
              context.Entry(anuncio).State = EntityState.Modified;
              await context.SaveChangesAsync();
              return anuncio;
          }
        }
    }
}