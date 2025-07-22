namespace RegisterAPII.Models
{
    public class SubordinateTicket
    {
        public int Id { get; set; }
        public int SupervisorAccountId { get; set; }

        public int GradeId { get; set; }

        public int ClassRoomId { get; set; }

        public int SessionId { get; set; }

        public int SubordinateAccountId { get; set; }
        public int TicketTypeId { get; set; }
    }
}
