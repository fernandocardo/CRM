using CRM.API.Models;

namespace CRM.API.Models
{
    public class Cliente : EntidadeBase
    {
        public string Nome { get; set; }
        public string Email { get; set; }
        public int Id { get; set; }
    }
}
