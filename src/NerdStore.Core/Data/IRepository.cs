// Interface genérica para um repositório
// Não representa um repositório genérico porque não assina/declara métodos genéricos
using NerdStore.Core.DomainObjects;

namespace NerdStore.Core.Data
{
    /* Interface genérica para repositório que implementa IDisposable e espera uma entidade
        que implementa IAggregateRoot (neste caso, a entidade "Produto") */
    /* IDisposable - define um único método chamado Dispose().
        Este método permite liberar quaisquer recursos não gerenciados mantidos por seu objeto
        antes que ele seja coletado pelo lixo */
    // IAggregateRoot - para obedecer à regra de "um repositório por agregação"
    public interface IRepository<T> : IDisposable where T : IAggregateRoot // T tem que implementar "IAggregateRoot"
    {
        IUnitOfWork UnitOfWork { get; }
    }
}
