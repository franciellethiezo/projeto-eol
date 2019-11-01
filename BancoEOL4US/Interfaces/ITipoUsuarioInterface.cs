using System.Collections.Generic;
using System.Threading.Tasks;
using BancoEOL4US.Models;

namespace BancoEOL4US.Interfaces
{
    public interface ITipoUsuarioInterface
    {
        Task<List<TipoUsuario>> Get();
        Task<TipoUsuario> Get(int id);
        Task<TipoUsuario> Post(TipoUsuario tipoUsuario);
        Task<TipoUsuario> Put(TipoUsuario tipoUsuario);
        Task<TipoUsuario> Delete(TipoUsuario tipoUsuarioRetornado);




    }
}