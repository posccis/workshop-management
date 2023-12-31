
using Azure.Core;
using Microsoft.EntityFrameworkCore;
using Workshop.Domain.Exceptions;
using WorkshopMng.Application.Interfaces;
using WorkshopMng.Domain.Domains;
using WorkshopMng.Persistence.Context;

namespace WorkshopMng.Application.Services
{
    public class AtaService : IAtaService<Ata>
    {
        private readonly WorkshopContext _dbContext;

        public AtaService(WorkshopContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AlterarAta(Ata ata)
        {
            throw new NotImplementedException();
        }

        public async Task InserirAta(Ata ata)
        {
            try
            {
                ValidaAtaInserida(ata);
                await _dbContext.Atas.AddAsync(ata);
                await _dbContext.SaveChangesAsync();
            }
            catch(ServiceException serviceExp)
            {
                throw;
            }
            catch (Exception exp)
            {

                throw new ServiceException("Um erro ocorreu durante a inserção da ata:\n" + exp.Message);
            }
        }
        public async Task<Ata> ObterAtaPorId(int id)
        {
            try
            {
                var ata = await _dbContext.Atas.FindAsync(id);
                ValidaAtaRetornada(ata);
                return ata;
            }
            catch (ServiceException serviceExp)
            {
                throw;
            }
            catch (Exception exp)
            {

                throw new ServiceException("Um erro ao tentar obter a ata:\n" + exp.Message);
            }
        }

        public async Task RemoverAta(int id)
        {
            throw new NotImplementedException();
        }
        public async Task InserirColaboradorNaAta(Colaborador colaborador, int ataId)
        {
            try
            {
                if(!_dbContext.Colaboradores.Any(c => c.Id == colaborador.Id)) throw new ServiceException("O colaborador que você está tentando inserir não existe.");
                if (!_dbContext.Atas.Any(a => a.Id == ataId)) throw new ServiceException("A ata que você está tentando inserir o colaborador não existe.");
                var ata = await _dbContext.Atas.Include(a => a.colaboradores).FirstOrDefaultAsync(a => a.Id == ataId);
                ata.colaboradores.Add(colaborador);
                _dbContext.Update(ata);
                await _dbContext.SaveChangesAsync();
            }
            catch (ServiceException serviceExp)
            {
                throw;
            }
            catch (Exception exp)
            {

                throw new ServiceException("Um erro ocorreu durante a inserção do colaborador na ata:\n" + exp.Message);
            }
        }

        public IEnumerable<Ata> ObterTodasAtas()
        {
            foreach (Ata ata in _dbContext.Atas.Include(a => a.colaboradores))
            {
                yield return ata;
            }
        }

        public IEnumerable<Colaborador> RetornaColaboradoresPorWorkshop(string workshopNome)
        {
            var ata = _dbContext.Atas.Include(a => a.colaboradores).FirstOrDefault(a => a.Workshop.Nome == workshopNome);
            if (ata == null) throw new ServiceException("O workshop que você está buscando não existe ou não possui nenhuma ata.");
            foreach (Colaborador colaborador in ata.colaboradores)
            {
                yield return colaborador;
            }
        }

        public Dictionary<string, int> ObterQuantidadeDeWorkshopPorColaborador()
        {
            Dictionary<string, int> dicionario = new Dictionary<string, int>();
            foreach(Colaborador colaborador in _dbContext.Colaboradores)
            {
                var quantidade = _dbContext.Atas.Include(a => a.Workshop)
                    .Count(a => a.colaboradores
                    .Any(a => a.Id == colaborador.Id));

                dicionario.Add(colaborador.Nome, quantidade);
            }

            return dicionario;
        }
        public Dictionary<string, int> ObterQuantidadeDeColaboradorPorWorkshop()
        {

            Dictionary<string, int> dicionario = new Dictionary<string, int>();

            dicionario = _dbContext.Atas.ToDictionary(x => x.Workshop.Nome, x => x.colaboradores.Count());

            return dicionario;
        }

        public async Task RemoverColaboradorDaAta(Colaborador colaborador, int ataId)
        {
            try
            {
                var ata = await _dbContext.Atas.Include(a => a.colaboradores).FirstOrDefaultAsync(a => a.Id == ataId);
                if (ata == null) throw new ServiceException("A ata da qual você está tentando remover o colaborador não existe.");
                if (colaborador == null) throw new ServiceException("O colaborador enviado para ser removido está vazio.");
                ata.colaboradores.Remove(colaborador);
                _dbContext.Update(ata);
                await _dbContext.SaveChangesAsync();
            }
            catch (ServiceException serviceExp)
            {
                throw;
            }
            catch (Exception exp)
            {

                throw new ServiceException("Um erro ocorreu durante a remoção do colaborador:\n"+exp.Message);
            }
        }

        public void ValidaAtaInserida(Ata ata)
        {
            if (ata == null) throw new ServiceException("O objeto Ata que você está tentando inserir/alterar está vazio ou nulo.");
            if (ata.Workshop == null) throw new ServiceException("É necessário que a Ata possua um workshop atrelado a ela");
            if (_dbContext.Atas.Any(c => c.Workshop == ata.Workshop)) throw new ServiceException("Já existe um Ata registrada para este workshop.");
        }

        public void ValidaAtaRetornada(Ata ata)
        {
            if (ata == null) throw new ServiceException("Ata não encontrada. Não foi possivel encontrar nenhum Ata com o Id informado.");
        }
    }
}
