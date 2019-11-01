using System.Collections.Generic;
using System.Threading.Tasks;
using BancoEOL4US.Models;

namespace BancoEOL4US.Interfaces
{
    public interface ICategoriaInterface
    {
         Task<List<Categoria>> Get();

         Task<Categoria> Get(int id);

         Task<Categoria> Post(Categoria categoria);

         Task<Categoria> Put(Categoria categoria);

         Task<Categoria> Delete(Categoria categoriaRetornada);         
    }
}