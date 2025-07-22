namespace RegisterAPII.Models
{
    public class ClassRoom
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int GradeId { get; set; }
        public Grade Grade { get; set; }

        public ICollection<StudentProfile> Students { get; set; }
        public ICollection<Session> Sessions { get; set; }
    }
}