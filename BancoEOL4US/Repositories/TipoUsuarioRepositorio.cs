using System.Collections.Generic;
using System.Threading.Tasks;
using BancoEOL4US.Interfaces;
using BancoEOL4US.Models;
using Microsoft.EntityFrameworkCore;

namespace BancoEOL4US.Repositories
{
    public class TipoUsuarioRepositorio : ITipoUsuarioInterface
    {
        Time2EOLContext context = new Time2EOLContext();

        public async Task<TipoUsuario> Delete(TipoUsuario tipoUsuarioRetornado)
        {
            {
                context.TipoUsuario.Remove(tipoUsuarioRetornado);
                await context.SaveChangesAsync();
                return tipoUsuarioRetornado;
            }
        }

        public async Task<List<TipoUsuario>> Get()
        {
            {
                return await context.TipoUsuario.ToListAsync();
            }
        }

        public async Task<TipoUsuario> Get(int id)
        {
            {
                return await context.TipoUsuario.FindAsync(id);
            }
        }

        public async Task<TipoUsuario> Post(TipoUsuario tipoUsuario)
        {
            {
                await context.TipoUsuario.AddAsync(tipoUsuario);
                await context.SaveChangesAsync();
                return tipoUsuario;
            }
        }

        public async Task<TipoUsuario> Put(TipoUsuario tipoUsuario)
        {
            {
                context.Entry(tipoUsuario).State = EntityState.Modified;
                await context.SaveChangesAsync();
                return tipoUsuario;
            }
        }
    }
}