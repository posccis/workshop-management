
using Microsoft.EntityFrameworkCore;
using Workshop.Domain.Exceptions;
using WorkshopMng.Application.Interfaces;
using WorkshopMng.Persistence.Context;

namespace WorkshopMng.Application.Services
{
    public class WorkshopService : IWorkshopService<Domain.Domains.Workshop>
    {
        private readonly WorkshopContext _dbContext;

        public WorkshopService(WorkshopContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Task AlterarWorkshop(Domain.Domains.Workshop workshop)
        {
            throw new NotImplementedException();
        }

        public async Task InserirWorkshop(Domain.Domains.Workshop workshop)
        {
            try
            {
                ValidaWorkshopInserido(workshop);
                await _dbContext.Workshops.AddAsync(workshop);
                await _dbContext.SaveChangesAsync();
            }
            catch(ServiceException serviceExp)
            {
                throw serviceExp;
            }
            catch (Exception exp)
            {

                throw exp;
            }
        }

        public IEnumerable<Domain.Domains.Workshop> ObterTodosWorkshops()
        {
            throw new NotImplementedException();
        }

        public async Task<Domain.Domains.Workshop> ObterWorkshopPorId(int id)
        {
            try
            {
                var workshop = await _dbContext.Workshops.FindAsync(id);
                ValidaWorkshopRetornado(workshop);
                return workshop;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Task RemoverWorkshop(int id)
        {
            throw new NotImplementedException();
        }

        public void ValidaWorkshopInserido(Domain.Domains.Workshop workshop)
        {
            if (_dbContext.Workshops.Any(w => w.Nome == workshop.Nome)) throw new ServiceException("Já existe um workshop registrado com esse nome.");
            if (workshop == null) throw new ServiceException("O objeto Workshop que você está tentando inserir/alterar está vazio ou nulo.");
            if (String.IsNullOrEmpty(workshop.Nome)) throw new ServiceException("É necessário informar o atributo Nome do objeto Workshop que está sendo inserido.");
            if(String.IsNullOrEmpty(workshop.Descricao)) throw new ServiceException("É necessário informar o atributo Descrição do objeto Workshop que está sendo inserido.");
        }
        public void ValidaWorkshopRetornado(Domain.Domains.Workshop workshop)
        {
            if (workshop == null) throw new ServiceException("O objeto Workshop que você está tentando inserir/alterar está vazio ou nulo.");
            if (String.IsNullOrEmpty(workshop.Nome)) throw new ServiceException("É necessário informar o atributo Nome do objeto Workshop que está sendo inserido.");
            if(String.IsNullOrEmpty(workshop.Descricao)) throw new ServiceException("É necessário informar o atributo Descrição do objeto Workshop que está sendo inserido.");
        }
    }
}
