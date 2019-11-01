using System.Collections.Generic;
using System.Threading.Tasks;
using BancoEOL4US.Models;

namespace BancoEOL4US.Interfaces
{
    public interface IInteresseInterface
    {
        Task<List<Interesse>> Get();

        Task<Interesse> Get(int id);

        Task<Interesse> Post(Interesse interesse);

        Task<Interesse> Put(Interesse interesse);

        Task<Interesse> Delete(Interesse interesseRetornado);
    }
}