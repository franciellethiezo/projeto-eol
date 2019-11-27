using System.Collections.Generic;
using System.Threading.Tasks;
using BancoEOL4US.Interfaces;
using BancoEOL4US.Models;
using Microsoft.EntityFrameworkCore;

namespace BancoEOL4US.Repositories
{
    public class InteresseRepositorio : IInteresseInterface
    {
        Time2EOLContext context = new Time2EOLContext();
        public async Task<Interesse> Delete(Interesse interesseRetornado)
        {
            {
                context.Interesse.Remove(interesseRetornado);
                await context.SaveChangesAsync();

                return interesseRetornado;
            }

        }

        public async Task<List<Interesse>> Get()
        {
            {
                return await context.Interesse.Include(u => u.FkIdUsuarioNavigation).Include(a => a.FkIdAnuncioNavigation).ToListAsync();
            }
        }

        public async Task<Interesse> Get(int id)
        {
            {
                return await context.Interesse.Include(u => u.FkIdUsuarioNavigation).Include(a => a.FkIdAnuncioNavigation).FirstOrDefaultAsync(a => a.FkIdUsuario == id);
            }
        }

        public async Task<Interesse> Post(Interesse interesse)
        {
            {
                await context.Interesse.AddAsync(interesse);
                await context.SaveChangesAsync();
                return interesse;
            }
        }

        public async Task<Interesse> Put(Interesse interesse)
        {
            {
                context.Entry(interesse).State = EntityState.Modified;
                await context.SaveChangesAsync();

                return interesse;
            }
        }
    }
}