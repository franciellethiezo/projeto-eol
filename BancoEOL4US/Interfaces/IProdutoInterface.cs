using System.Collections.Generic;
using System.Threading.Tasks;
using BancoEOL4US.Models;

namespace BancoEOL4US.Interfaces
{
    public interface IProdutoInterface
    {
         Task<List<Produto>> Get();
         Task<Produto> Get(int id);
         Task<Produto> Post(Produto produto);
         Task<Produto> Put(Produto produto);

         Task<Produto> Delete(Produto produto); 
    }
}