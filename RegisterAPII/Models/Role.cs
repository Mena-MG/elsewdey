namespace RegisterAPII.Models
{
    public class Role
    {
        public int RoleId { get; set; }
        public string Name { get; set; } 

        public ICollection<Accounts> Account { get; set; }
    }
}