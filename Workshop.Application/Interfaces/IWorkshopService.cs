

namespace WorkshopMng.Application.Interfaces
{
    public interface IWorkshopService<T> where T : WorkshopMng.Domain.Domains.Workshop
    {
        Task InserirWorkshop(T workshop);
        IEnumerable<T> ObterTodosWorkshops();
        Task<T> ObterWorkshopPorId(int id);
        Task AlterarWorkshop(T workshop);
        Task RemoverWorkshop(int id);
        void ValidaWorkshopInserido(T workshop);
        void ValidaWorkshopRetornado(T workshop);


    }
}
