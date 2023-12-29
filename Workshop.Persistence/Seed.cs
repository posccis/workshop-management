
using WorkshopMng.Domain.Domains;
using WorkshopMng.Persistence.Context;

namespace WorkshopMng.Persistence
{
    public class Seed
    {
        public static async Task SeedData(WorkshopContext context)
        {
            if (context.Colaboradores.Any() || context.Workshops.Any() || context.Atas.Any())
            {
                // Já existe dados no banco de dados, então não precisamos popular.
                return;
            }

            // Adiciona Colaboradores
            var colaboradores = new List<Colaborador>
            {
                new Colaborador { Nome = "Helton" },
                new Colaborador { Nome = "Cleviton" },
                new Colaborador { Nome = "Carlos" }
            };
            context.Colaboradores.AddRange(colaboradores);
            await context.SaveChangesAsync();

            // Adiciona Workshops
            var workshops = new List<Workshop>
            {
                new Workshop { Nome = "Workshop 1", DataRealizacao = DateTime.Now.AddDays(7), Descricao = "Descrição do Workshop 1" },
                new Workshop { Nome = "Workshop 2", DataRealizacao = DateTime.Now.AddDays(14), Descricao = "Descrição do Workshop 2" },
            };
            context.Workshops.AddRange(workshops);
            await context.SaveChangesAsync();

            // Adiciona Atas com Colaboradores associados
            var atas = new List<Ata>
            {
                new Ata
                {
                    Workshop = workshops[0],
                    colaboradores = colaboradores.Take(2).ToList() // Associar os dois primeiros colaboradores à Ata
                },
                new Ata
                {
                    Workshop = workshops[1],
                    colaboradores = colaboradores.Skip(1).Take(2).ToList() // Associar os dois últimos colaboradores à Ata
                }
            };
            context.Atas.AddRange(atas);
            await context.SaveChangesAsync();
        }
    }
}
