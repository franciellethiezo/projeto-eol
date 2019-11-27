using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BancoEOL4US.Interfaces;
using BancoEOL4US.Models;
using Microsoft.EntityFrameworkCore;

namespace BancoEOL4US.Repositories
{
    public class ProdutoRepositorio : IProdutoInterface
    {
        Time2EOLContext context = new Time2EOLContext ();
        public async Task<Produto> Delete(Produto produtoRetornado)
        {
            {
                context.Produto.Remove(produtoRetornado);
                await context.SaveChangesAsync();
                return produtoRetornado;
            }
        }

        public async Task<List<Produto>> Get()
        {
            {
                return await context.Produto.Include(u => u.FkIdUsuarioNavigation).Include(c => c.FkIdCategoriaNavigation).ToListAsync();
            }
        }

        public async Task<Produto> Get(int id)
        {
            {
                return await context.Produto.Include(u => u.FkIdUsuarioNavigation).Include(c => c.FkIdCategoriaNavigation).FirstOrDefaultAsync(p => p.IdProduto == id);
            }
        }

        public async Task<Produto> Post(Produto produto)
        {
            {
                await context.Produto.AddAsync(produto);
                await context.SaveChangesAsync();
                return produto;
            }
        }

        public async Task<Produto> Put(Produto produto)
        {
            {
                context.Entry(produto).State = EntityState.Modified;
                await context.SaveChangesAsync();
                return produto;
            }
        }
    }
}