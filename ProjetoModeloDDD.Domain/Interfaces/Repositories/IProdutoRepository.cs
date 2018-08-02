using ProjetoModeloDDD.Domain.Entities;
using ProjetoModeloDDD.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoModeloDDD.Domain.Interfaces.Repositories
{
    public interface IProdutoRepository : IRepositoryBase<Produto>
    {
        IEnumerable<Produto> BuscarPorNome(String nome);
    }
}
