using System.Threading.Tasks;

// IUnitOfWork - serve para agrupar várias operações de banco de dados em uma única transação
namespace NerdStore.Core.Data
{
    public interface IUnitOfWork
    {
        // Método para confirmar a transação
        Task<bool> Commit();
    }
}