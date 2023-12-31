

using WorkshopMng.Domain.Domains;

namespace WorkshopMng.Application.Interfaces
{
    public interface IColaboradorService<T> where T : Colaborador
    {
        Task InserirColaborador(T colaborador);
        IEnumerable<T> ObterTodosColaboradores();
        Task<T> ObterColaboradorPorId(int id);
        Task AlterarColaborador(T colaborador);
        Task RemoverColaborador(int id);
        void ValidaColaboradorInserido(T colaborador);
        void ValidaColaboradorRetornado(T colaborador);


    }
}
