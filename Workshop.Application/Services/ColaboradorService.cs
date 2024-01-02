
using Azure.Core;
using Microsoft.EntityFrameworkCore;
using System.Collections;
using Workshop.Domain.DTOs;
using Workshop.Domain.Exceptions;
using WorkshopMng.Application.Interfaces;
using WorkshopMng.Domain.Domains;
using WorkshopMng.Persistence.Context;

namespace WorkshopMng.Application.Services
{
    public class ColaboradorService : IColaboradorService<Colaborador>
    {
        private readonly WorkshopContext _dbContext;

        public ColaboradorService(WorkshopContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AlterarColaborador(Colaborador colaborador)
        {
            throw new NotImplementedException();
        }

        public async Task InserirColaborador(Colaborador colaborador)
        {
            try
            {
                ValidaColaboradorInserido(colaborador);
                await _dbContext.Colaboradores.AddAsync(colaborador);
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

        public IEnumerable<Colaborador> ObterTodosColaboradores()
        {
            throw new NotImplementedException();
        }

        public async Task<Colaborador> ObterColaboradorPorId(int id)
        {
            try
            {
                var colaborador = await _dbContext.Colaboradores.FindAsync(id);
                ValidaColaboradorRetornado(colaborador);
                return colaborador;
            }
            catch (ServiceException serviceExp)
            {
                throw serviceExp;
            }
            catch (Exception exp)
            {

                throw exp;
            }
        }

        public IEnumerable<ColaboradorDTO> ObterColaboradorComWorkshop()
        {

            var colaboradores = _dbContext.Colaboradores.OrderBy(c => c.Nome).ToList();
            if (!colaboradores.Any()) throw new ServiceException("Não há colaboradores cadastrados para serem retornados.");
            foreach (Colaborador colaborador in colaboradores)
            {
                ColaboradorDTO colaboradorDTO = new ColaboradorDTO();
                try
                {
                    List<Domain.Domains.Workshop> lista = _dbContext.Atas
                    .Where(a => a.colaboradores.Any(c => c.Nome == colaborador.Nome))
                    .Select(ata => new Domain.Domains.Workshop
                    {
                        Id = ata.Workshop.Id,
                        Nome = ata.Workshop.Nome,
                        DataRealizacao = ata.Workshop.DataRealizacao,
                        Descricao = ata.Workshop.Descricao,
                    })
                    .ToList();
                    colaboradorDTO = new ColaboradorDTO()
                    {
                        Nome = colaborador.Nome,
                        Workshops = lista
                    };
                }
                catch (ServiceException serviceExp)
                {
                    throw serviceExp;
                }
                catch (Exception exp)
                {

                    throw exp;
                }

                yield return colaboradorDTO;
            }
        }

        public Task RemoverColaborador(int id)
        {
            throw new NotImplementedException();
        }

        public void ValidaColaboradorInserido(Colaborador colaborador)
        {
            if (_dbContext.Colaboradores.Any(c => c.Nome == colaborador.Nome)) throw new ServiceException("Já existe um colaborador registrado com este nome.");
            if (colaborador == null) throw new ServiceException("O objeto Colaborador que você está tentando inserir/alterar está vazio ou nulo.");
            if (String.IsNullOrEmpty(colaborador.Nome)) throw new ServiceException("É necessário informar o atributo Nome do objeto Colaborador que está sendo inserido.");
        }
        public void ValidaColaboradorRetornado(Colaborador colaborador)
        {
            if (colaborador == null) throw new ServiceException("Colaborador não encontrado. Não foi possivel encontrar nenhum colaborador com o Id informado.");
            if (String.IsNullOrEmpty(colaborador.Nome)) throw new ServiceException("Não foi possivel localizar o nome do colaborador informado.");
        }
    }
}
