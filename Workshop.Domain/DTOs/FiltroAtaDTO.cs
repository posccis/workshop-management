using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Workshop.Domain.DTOs
{
    public class FiltroAtaDTO
    {
        public DateTime? DataRealizacao { get; set; }
        public string NomeColaborador { get; set; }
        public string NomeWorkshop { get; set; }
    }
}
