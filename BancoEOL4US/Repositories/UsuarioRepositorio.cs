using System.Collections.Generic;
using System.Threading.Tasks;
using BancoEOL4US.Interfaces;
using BancoEOL4US.Models;
using Microsoft.EntityFrameworkCore;

namespace BancoEOL4US.Repositories
{
    public class UsuarioRepositorio : IUsuarioInterface
    {
        Time2EOLContext context = new Time2EOLContext();
        public async Task<Usuario> Delete(Usuario userRetornado)
        {
            {
                context.Usuario.Remove(userRetornado);
                await context.SaveChangesAsync();
                return userRetornado;
            }
        }

        public async Task<Usuario> Get(int id)
        {
            {
                return await context.Usuario.Include(x => x.FkIdTipoUsuarioNavigation).FirstOrDefaultAsync(x => x.IdUsuario == id);
            }
        }

        public async Task<List<Usuario>> Get()
        {
            {
                return await context.Usuario.Include(x => x.FkIdTipoUsuarioNavigation).ToListAsync();
            }
        }

        public async Task<Usuario> Post(Usuario user)
        {
            {
                await context.Usuario.AddAsync(user);
                await context.SaveChangesAsync();

                return user;
            }
        }

        public async Task<Usuario> Put(Usuario user)
        {
            {
                context.Entry(user).State = EntityState.Modified;
                await context.SaveChangesAsync();

                return user;
            }
        }
    }
}