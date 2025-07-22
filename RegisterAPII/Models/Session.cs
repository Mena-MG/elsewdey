namespace RegisterAPII.Models
{
    public class Session
    {
        public int Id { get; set; }
        public int sessionNo { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public int ClassId { get; set; }
        public ClassRoom Class { get; set; }
    }
}