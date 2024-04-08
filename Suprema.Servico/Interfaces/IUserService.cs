
using Suprema.Entidade.Entidades;
using Suprema.Comum.Interfaces;

namespace Suprema.Servico.Interfaces
{
    public interface IUserService : IComumInterfacesService<UserEntidade>
    {
        Task<UserEntidade> Authenticate(string username, string password);
    }
}
