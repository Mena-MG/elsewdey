using System.ComponentModel.DataAnnotations;

namespace RegisterAPII.Models
{
    public class TicketType
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public int OrderNo { get; set; }
        public string BusinessEntity { get; set; }
    }
}