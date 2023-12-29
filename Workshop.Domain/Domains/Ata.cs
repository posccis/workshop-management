using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkshopMng.Domain.Domains
{
    public class Ata
    {
        public int Id { get; set; }
        public Workshop Workshop { get; set; }

        public ICollection<Colaborador> colaboradores { get; set;}
    }
}
