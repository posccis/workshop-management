using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkshopMng.Domain.Domains;

namespace WorkshopMng.Persistence.Context
{
    public class WorkshopMngContext : DbContext
    {
        public WorkshopMngContext(DbContextOptions op) : base(op)
        {
            
        }

        public DbSet<Colaborador> Colaboradores { get; set; }
        public DbSet<Workshop> Workshops { get; set; }
        public DbSet<Ata> Atas { get; set; }
    }
}
