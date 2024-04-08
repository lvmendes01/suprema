
using Suprema.Entidade.Entidades;
using Suprema.Comum.Interfaces;
using Suprema.Comum.Entidades;

namespace Suprema.Servico.Interfaces
{
    public interface IPokerTableService : IComumInterfacesService<PokerTableEntidade>
    {
        RetornoApi AdicionarJogador(Int64 UserId, Int64 TableId);

        RetornoApi Simular(Int64 TableId);

    }
}
