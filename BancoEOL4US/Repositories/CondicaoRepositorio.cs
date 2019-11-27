using System.Collections.Generic;
using System.Threading.Tasks;
using BancoEOL4US.Interfaces;
using BancoEOL4US.Models;
using Microsoft.EntityFrameworkCore;

namespace BancoEOL4US.Repositories
{
    public class CondicaoRepositorio : ICondicaoInterface
    {
        Time2EOLContext context = new Time2EOLContext ();
        public async Task<Condicao> Delete(Condicao condicaoRetornada)
        {
            {
                context.Condicao.Remove(condicaoRetornada);
                await context.SaveChangesAsync();
                return condicaoRetornada;
            }
        }

        public async  Task<List<Condicao>> Get()
        {
            {
                return await context.Condicao.ToListAsync();
            }
        }

        public async Task<Condicao> Get(int id)
        {
            {
                return await context.Condicao.FindAsync(id);
            }
        }

        public async Task<Condicao> Post(Condicao condicao)
        {
            {
                await context.Condicao.AddAsync(condicao);
                await context.SaveChangesAsync();
                return condicao;
            }
        }

        public async Task<Condicao> Put(Condicao condicao)
        {
            {
                context.Entry(condicao).State = EntityState.Modified;
                await context.SaveChangesAsync();
                return condicao;
            }
        }
    }
}