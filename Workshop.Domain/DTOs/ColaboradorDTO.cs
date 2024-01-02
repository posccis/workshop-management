
namespace Workshop.Domain.DTOs
{
    public class ColaboradorDTO
    {
        public string Nome { get; set; }

        public List<WorkshopMng.Domain.Domains.Workshop> Workshops { get; set; }
    }
}
