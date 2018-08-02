using ProjetoModeloDDD.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoModeloDDD.Domain.Interfaces.Services
{
    public interface IProdutoService : IServiceBase<Produto>
    {
        IEnumerable<Produto> BuscarPorNome(String nome);
    }
}
