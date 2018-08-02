using ProjetoModeloDDD.Domain.Entities;
using System.Collections.Generic;
using System.Linq;

namespace ProjetoModeloDDD.Application.Interface
{
    public interface IProdutoAppService : IAppServiceBase<Produto>
    {
        IEnumerable<Produto> BuscarPorNome(string nome);
    }
}
