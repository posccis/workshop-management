

using System.Collections.Generic;
using Workshop.Domain.DTOs;
using WorkshopMng.Domain.Domains;

namespace WorkshopMng.Application.Interfaces
{
    public interface IAtaService<T> where T : Ata
    {
        Task InserirAta(T ata);
        Task InserirColaboradorNaAta(Colaborador colaborador, int ataId);
        IEnumerable<T> ObterTodasAtas();
        Task<T> ObterAtaPorId(int id);
        IEnumerable<Colaborador> RetornaColaboradoresPorWorkshop(string workshopNome);
        IEnumerable<T> FiltrarAtas(FiltroAtaDTO filtro);
        Dictionary<string, int> ObterQuantidadeDeWorkshopPorColaborador();
        Dictionary<string, int> ObterQuantidadeDeColaboradorPorWorkshop();
        Task AlterarAta(T ata);
        Task RemoverAta(int id);
        Task RemoverColaboradorDaAta(Colaborador colaborador, int ataId);
        void ValidaAtaInserida(T ata);
        void ValidaAtaRetornada(T colaborador);


    }
}
