
using Suprema.Entidade.Entidades;
using Suprema.Comum.Interfaces;

namespace Suprema.Repositorio.Interfaces
{
    public interface IPokerTableRepositorio : IComumInterfaces<PokerTableEntidade>
    {
        string AdicionarJogador(Int64 UserId, Int64 TableId);

        PokerTableEntidade CarregarPoker(Int64 TableId);
    }
}
