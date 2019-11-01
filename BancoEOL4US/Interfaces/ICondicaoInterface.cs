using System.Collections.Generic;
using System.Threading.Tasks;
using BancoEOL4US.Models;

namespace BancoEOL4US.Interfaces
{
    public interface ICondicaoInterface
    {
         Task<List<Condicao>> Get();

         Task<Condicao> Get(int id);

         Task<Condicao> Post(Condicao condicao);
         Task<Condicao> Put(Condicao condicao);

         Task<Condicao> Delete(Condicao condicaoRetornada);
    }
}