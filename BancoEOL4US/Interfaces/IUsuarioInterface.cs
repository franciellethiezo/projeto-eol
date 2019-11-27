using System.Collections.Generic;
using System.Threading.Tasks;
using BancoEOL4US.Models;

namespace BancoEOL4US.Interfaces
{
    public interface IUsuarioInterface
    {
         Task<List<Usuario>> Get();
         Task<Usuario> Get(int id);
         Task<Usuario> Post(Usuario user);
         Task<Usuario> Put(Usuario user);
         Task<Usuario> Delete(Usuario userRetornado);
    }
}