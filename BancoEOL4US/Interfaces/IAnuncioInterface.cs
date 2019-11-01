using System.Collections.Generic;
using System.Threading.Tasks;
using BancoEOL4US.Models;

namespace BancoEOL4US.Interfaces
{
    public interface IAnuncioInterface
    {
        Task<List<Anuncio>> Get();
        Task<List<Anuncio>> BuscaPorPreco(int preco);
        // Task<List<Anuncio>> BuscaPorCondicao(string Condicao);
        Task<Anuncio> Get(int id);
        Task<Anuncio> Post(Anuncio anuncio);
        Task<Anuncio> Put(Anuncio anuncio);
        Task<List<Anuncio>> BuscaPorMarcaCondicao(string marcaRecebida, string condicaoRecebida);
        Task<Anuncio> Delete(Anuncio anuncioRetornado);
    }
}