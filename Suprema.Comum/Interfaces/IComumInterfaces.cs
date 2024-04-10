
using Suprema.Comum.Entidades;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Suprema.Comum.Interfaces
{
    public interface IComumInterfaces<T> where T : class
    {
        List<T> ObterTodos(bool includes = false);
        List<T> ObterFiltros(Expression<Func<T, bool>> predicate);
        T Procurar(params object[] key);
        T Primeiro(Expression<Func<T, bool>> predicate);
        T Adicionar(T entity);
        T Atualizar(T entity);
        bool Deletar(Func<T, bool> predicate);
    }
    public interface IComumInterfacesService<T> where T : class
    {
        List<T> ObterTodos(bool includes = false);
        List<T> ObterFiltros(Expression<Func<T, bool>> predicate);
        T Procurar(params object[] key);
        T Primeiro(Expression<Func<T, bool>> predicate);
        RetornoApi Adicionar(T entity);
        RetornoApi Atualizar(T entity);
        RetornoApi Deletar(Int64 Id);
    }
}

