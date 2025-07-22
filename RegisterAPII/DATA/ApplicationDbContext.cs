using Microsoft.EntityFrameworkCore;
using RegisterAPII.Models;

namespace RegisterAPII.DATA
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Accounts> Accounts { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<LoginAccount> LoginAccounts { get; set; }
        public DbSet<TicketType> TicketTypes { get; set; }
        public DbSet<Grade> Grades { get; set; }
        public DbSet<ClassRoom> ClassRooms { get; set; }
        public DbSet<Session> Sessions { get; set; }
        public DbSet<SubordinateTicket> subordinateTickets { get; set; }
        public DbSet<StudentProfile> StudentProfiles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // --- Seeding Roles ---
            modelBuilder.Entity<Role>().HasData(
                new Role { RoleId = 1, Name = "SuperAdmin" },
                new Role { RoleId = 2, Name = "Admin" },
                new Role { RoleId = 3, Name = "Student" },
                new Role { RoleId = 4, Name = "Specialist" },
                new Role { RoleId = 5, Name = "It" },
                new Role { RoleId = 6, Name = "Teacher" },
                new Role { RoleId = 7, Name = "Engineer" },
                new Role { RoleId = 8, Name = "Parent" }
            );

            modelBuilder.Entity<StudentProfile>()
     .Property(e => e.GoodNotesJson)
     .HasDefaultValue("[]");

            modelBuilder.Entity<StudentProfile>()
                .Property(e => e.BadNotesJson)
                .HasDefaultValue("[]");


            // --- Configure one-to-one relationship between Accounts and LoginAccount ---
            modelBuilder.Entity<Accounts>()
                .HasOne(a => a.LoginAccount)
                .WithOne(la => la.Accounts)
                .HasForeignKey<Accounts>(a => a.LoginId);


            modelBuilder.Entity<TicketType>().HasData(
                new TicketType { Id = 5, Name = "Late", OrderNo = 10, BusinessEntity = "Behaviour" },
                new TicketType { Id = 7, Name = "Eating", OrderNo = 30, BusinessEntity = "Behaviour" },
                new TicketType { Id = 10, Name = "SideTalks", OrderNo = 20, BusinessEntity = "Behaviour" },
                new TicketType { Id = 12, Name = "Absence", OrderNo = 10, BusinessEntity = "Absence" }
            );

            modelBuilder.Entity<Grade>().HasData(
         new Grade { Id = 1, Name = "Wheeler" },
         new Grade { Id = 2, Name = "Senior" },
         new Grade { Id = 3, Name = "Junior" }
     );

            // Seed Classes
            modelBuilder.Entity<ClassRoom>().HasData(
                new ClassRoom { Id = 1, Name = "Wheeler 1", GradeId = 1 },
                new ClassRoom { Id = 2, Name = "Wheeler 2", GradeId = 1 },
                new ClassRoom { Id = 3, Name = "Wheeler 3", GradeId = 1 },
                new ClassRoom { Id = 4, Name = "Wheeler 4", GradeId = 1 },
                new ClassRoom { Id = 5, Name = "Senior 1", GradeId = 2 },
                new ClassRoom { Id = 6, Name = "Senior 2", GradeId = 2 },
                new ClassRoom { Id = 7, Name = "Senior 3", GradeId = 2 },
                new ClassRoom { Id = 8, Name = "Senior 4", GradeId = 2 },
                new ClassRoom { Id = 9, Name = "Junior 1", GradeId = 3 },
                new ClassRoom { Id = 10, Name = "Junior 2", GradeId = 3 },
                new ClassRoom { Id = 11, Name = "Junior 3", GradeId = 3 },
                new ClassRoom { Id = 12, Name = "Junior 4", GradeId = 3 }

            );

            // Seed Sessions
            modelBuilder.Entity<Session>().HasData(
                new Session { Id = 1, sessionNo = 1, ClassId = 1 },
                new Session { Id = 2, sessionNo = 2, ClassId = 2 },
                new Session { Id = 3, sessionNo = 3, ClassId = 3 },
                new Session { Id = 4, sessionNo = 4, ClassId = 4 },
                new Session { Id = 5, sessionNo = 5, ClassId = 5 },
                new Session { Id = 6, sessionNo = 6, ClassId = 6 },
                new Session { Id = 7, sessionNo = 7, ClassId = 7 },
                new Session { Id = 8, sessionNo = 8, ClassId = 8 }
            );

            // Seed Students
            modelBuilder.Entity<StudentProfile>().HasData(
                new StudentProfile { Id = 1, Name = "Student 1", ClassId = 2 },
                new StudentProfile { Id = 2, Name = "Student 2", ClassId = 2 },
                new StudentProfile { Id = 3, Name = "Student 3", ClassId = 3 },
                new StudentProfile { Id = 4, Name = "Student 4", ClassId = 3 },
                new StudentProfile { Id = 5, Name = "Student 5", ClassId = 4 },
                new StudentProfile { Id = 6, Name = "Student 6", ClassId = 4 }
                );
           
            modelBuilder.Entity<LoginAccount>().HasData(
                // --- Role 1 ---
                new LoginAccount { Id = 1, Email = "batolmagdy092@gmail.com", Password = "StrongPassword123", NationalID = "30101010000001", AccountId = 1 },
                new LoginAccount { Id = 2, Email = "user2.role1@example.com", Password = "StrongPassword123", NationalID = "30101010000002", AccountId = 2 },
                new LoginAccount { Id = 3, Email = "user3.role1@example.com", Password = "StrongPassword123", NationalID = "30101010000003", AccountId = 3 },
                new LoginAccount { Id = 4, Email = "user4.role1@example.com", Password = "StrongPassword123", NationalID = "30101010000004", AccountId = 4 },
                new LoginAccount { Id = 5, Email = "user5.role1@example.com", Password = "StrongPassword123", NationalID = "30101010000005", AccountId = 5 },
                // --- Role 2 ---
                new LoginAccount { Id = 6, Email = "user6.role2@example.com", Password = "StrongPassword123", NationalID = "30101010000006", AccountId = 6 },
                new LoginAccount { Id = 7, Email = "user7.role2@example.com", Password = "StrongPassword123", NationalID = "30101010000007", AccountId = 7 },
                new LoginAccount { Id = 8, Email = "user8.role2@example.com", Password = "StrongPassword123", NationalID = "30101010000008", AccountId = 8 },
                new LoginAccount { Id = 9, Email = "user9.role2@example.com", Password = "StrongPassword123", NationalID = "30101010000009", AccountId = 9 },
                new LoginAccount { Id = 10, Email = "user10.role2@example.com", Password = "StrongPassword123", NationalID = "30101010000010", AccountId = 10 },
                // --- Role 3 ---
                new LoginAccount { Id = 11, Email = "user11.role3@example.com", Password = "StrongPassword123", NationalID = "30101010000011", AccountId = 11 },
                new LoginAccount { Id = 12, Email = "user12.role3@example.com", Password = "StrongPassword123", NationalID = "30101010000012", AccountId = 12 },
                new LoginAccount { Id = 13, Email = "user13.role3@example.com", Password = "StrongPassword123", NationalID = "30101010000013", AccountId = 13 },
                new LoginAccount { Id = 14, Email = "user14.role3@example.com", Password = "StrongPassword123", NationalID = "30101010000014", AccountId = 14 },
                new LoginAccount { Id = 15, Email = "user15.role3@example.com", Password = "StrongPassword123", NationalID = "30101010000015", AccountId = 15 },
                // --- Role 4 ---
                new LoginAccount { Id = 16, Email = "user16.role4@example.com", Password = "StrongPassword123", NationalID = "30101010000016", AccountId = 16 },
                new LoginAccount { Id = 17, Email = "user17.role4@example.com", Password = "StrongPassword123", NationalID = "30101010000017", AccountId = 17 },
                new LoginAccount { Id = 18, Email = "user18.role4@example.com", Password = "StrongPassword123", NationalID = "30101010000018", AccountId = 18 },
                new LoginAccount { Id = 19, Email = "user19.role4@example.com", Password = "StrongPassword123", NationalID = "30101010000019", AccountId = 19 },
                new LoginAccount { Id = 20, Email = "user20.role4@example.com", Password = "StrongPassword123", NationalID = "30101010000020", AccountId = 20 },
                // --- Role 5 ---
                new LoginAccount { Id = 21, Email = "user21.role5@example.com", Password = "StrongPassword123", NationalID = "30101010000021", AccountId = 21 },
                new LoginAccount { Id = 22, Email = "user22.role5@example.com", Password = "StrongPassword123", NationalID = "30101010000022", AccountId = 22 },
                new LoginAccount { Id = 23, Email = "user23.role5@example.com", Password = "StrongPassword123", NationalID = "30101010000023", AccountId = 23 },
                new LoginAccount { Id = 24, Email = "user24.role5@example.com", Password = "StrongPassword123", NationalID = "30101010000024", AccountId = 24 },
                new LoginAccount { Id = 25, Email = "user25.role5@example.com", Password = "StrongPassword123", NationalID = "30101010000025", AccountId = 25 },
                // --- Role 6 ---
                new LoginAccount { Id = 26, Email = "user26.role6@example.com", Password = "StrongPassword123", NationalID = "30101010000026", AccountId = 26 },
                new LoginAccount { Id = 27, Email = "user27.role6@example.com", Password = "StrongPassword123", NationalID = "30101010000027", AccountId = 27 },
                new LoginAccount { Id = 28, Email = "user28.role6@example.com", Password = "StrongPassword123", NationalID = "30101010000028", AccountId = 28 },
                new LoginAccount { Id = 29, Email = "user29.role6@example.com", Password = "StrongPassword123", NationalID = "30101010000029", AccountId = 29 },
                new LoginAccount { Id = 30, Email = "user30.role6@example.com", Password = "StrongPassword123", NationalID = "30101010000030", AccountId = 30 },
                // --- Role 7 ---
                new LoginAccount { Id = 31, Email = "user31.role7@example.com", Password = "StrongPassword123", NationalID = "30101010000031", AccountId = 31 },
                new LoginAccount { Id = 32, Email = "user32.role7@example.com", Password = "StrongPassword123", NationalID = "30101010000032", AccountId = 32 },
                new LoginAccount { Id = 33, Email = "user33.role7@example.com", Password = "StrongPassword123", NationalID = "30101010000033", AccountId = 33 },
                new LoginAccount { Id = 34, Email = "user34.role7@example.com", Password = "StrongPassword123", NationalID = "30101010000034", AccountId = 34 },
                new LoginAccount { Id = 35, Email = "user35.role7@example.com", Password = "StrongPassword123", NationalID = "30101010000035", AccountId = 35 }
            );

            // --- Seed all 35 Accounts in a SINGLE HasData call with empty passwords ---
            modelBuilder.Entity<Accounts>().HasData(
                // --- Role 1 ---
                new Accounts { Id = 1, FullName = "User 1 (Role 1)", Email = "batolmagdy092@gmail.com", NationalID = "30101010000001", PasswordHash = "", RoleId = 1, LoginId = 1, IsActive = true, CreatedAt = new DateTime(2025, 07, 16) },
                new Accounts { Id = 2, FullName = "User 2 (Role 1)", Email = "user2.role1@example.com", NationalID = "30101010000002", PasswordHash = "", RoleId = 1, LoginId = 2, IsActive = true, CreatedAt = new DateTime(2025, 07, 16) },
                new Accounts { Id = 3, FullName = "User 3 (Role 1)", Email = "user3.role1@example.com", NationalID = "30101010000003", PasswordHash = "", RoleId = 1, LoginId = 3, IsActive = true, CreatedAt = new DateTime(2025, 07, 16) },
                new Accounts { Id = 4, FullName = "User 4 (Role 1)", Email = "user4.role1@example.com", NationalID = "30101010000004", PasswordHash = "", RoleId = 1, LoginId = 4, IsActive = true, CreatedAt = new DateTime(2025, 07, 16) },
                new Accounts { Id = 5, FullName = "User 5 (Role 1)", Email = "user5.role1@example.com", NationalID = "30101010000005", PasswordHash = "", RoleId = 1, LoginId = 5, IsActive = true, CreatedAt = new DateTime(2025, 07, 16) },
                // --- Role 2 ---
                new Accounts { Id = 6, FullName = "User 6 (Role 2)", Email = "user6.role2@example.com", NationalID = "30101010000006", PasswordHash = "", RoleId = 2, LoginId = 6, IsActive = true, CreatedAt = new DateTime(2025, 07, 16) },
                new Accounts { Id = 7, FullName = "User 7 (Role 2)", Email = "user7.role2@example.com", NationalID = "30101010000007", PasswordHash = "", RoleId = 2, LoginId = 7, IsActive = true, CreatedAt = new DateTime(2025, 07, 16) },
                new Accounts { Id = 8, FullName = "User 8 (Role 2)", Email = "user8.role2@example.com", NationalID = "30101010000008", PasswordHash = "", RoleId = 2, LoginId = 8, IsActive = true, CreatedAt = new DateTime(2025, 07, 16) },
                new Accounts { Id = 9, FullName = "User 9 (Role 2)", Email = "user9.role2@example.com", NationalID = "30101010000009", PasswordHash = "", RoleId = 2, LoginId = 9, IsActive = true, CreatedAt = new DateTime(2025, 07, 16) },
                new Accounts { Id = 10, FullName = "User 10 (Role 2)", Email = "user10.role2@example.com", NationalID = "30101010000010", PasswordHash = "", RoleId = 2, LoginId = 10, IsActive = true, CreatedAt = new DateTime(2025, 07, 16) },
                // --- Role 3 ---
                new Accounts { Id = 11, FullName = "User 11 (Role 3)", Email = "user11.role3@example.com", NationalID = "30101010000011", PasswordHash = "", RoleId = 3, LoginId = 11, IsActive = true, CreatedAt = new DateTime(2025, 07, 16) },
                new Accounts { Id = 12, FullName = "User 12 (Role 3)", Email = "user12.role3@example.com", NationalID = "30101010000012", PasswordHash = "", RoleId = 3, LoginId = 12, IsActive = true, CreatedAt = new DateTime(2025, 07, 16) },
                new Accounts { Id = 13, FullName = "User 13 (Role 3)", Email = "user13.role3@example.com", NationalID = "30101010000013", PasswordHash = "", RoleId = 3, LoginId = 13, IsActive = true, CreatedAt = new DateTime(2025, 07, 16) },
                new Accounts { Id = 14, FullName = "User 14 (Role 3)", Email = "user14.role3@example.com", NationalID = "30101010000014", PasswordHash = "", RoleId = 3, LoginId = 14, IsActive = true, CreatedAt = new DateTime(2025, 07, 16) },
                new Accounts { Id = 15, FullName = "User 15 (Role 3)", Email = "user15.role3@example.com", NationalID = "30101010000015", PasswordHash = "", RoleId = 3, LoginId = 15, IsActive = true, CreatedAt = new DateTime(2025, 07, 16) },
                // --- Role 4 ---
                new Accounts { Id = 16, FullName = "User 16 (Role 4)", Email = "user16.role4@example.com", NationalID = "30101010000016", PasswordHash = "", RoleId = 4, LoginId = 16, IsActive = true, CreatedAt = new DateTime(2025, 07, 16) },
                new Accounts { Id = 17, FullName = "User 17 (Role 4)", Email = "user17.role4@example.com", NationalID = "30101010000017", PasswordHash = "", RoleId = 4, LoginId = 17, IsActive = true, CreatedAt = new DateTime(2025, 07, 16) },
                new Accounts { Id = 18, FullName = "User 18 (Role 4)", Email = "user18.role4@example.com", NationalID = "30101010000018", PasswordHash = "", RoleId = 4, LoginId = 18, IsActive = true, CreatedAt = new DateTime(2025, 07, 16) },
                new Accounts { Id = 19, FullName = "User 19 (Role 4)", Email = "user19.role4@example.com", NationalID = "30101010000019", PasswordHash = "", RoleId = 4, LoginId = 19, IsActive = true, CreatedAt = new DateTime(2025, 07, 16) },
                new Accounts { Id = 20, FullName = "User 20 (Role 4)", Email = "user20.role4@example.com", NationalID = "30101010000020", PasswordHash = "", RoleId = 4, LoginId = 20, IsActive = true, CreatedAt = new DateTime(2025, 07, 16) },
                // --- Role 5 ---
                new Accounts { Id = 21, FullName = "User 21 (Role 5)", Email = "user21.role5@example.com", NationalID = "30101010000021", PasswordHash = "", RoleId = 5, LoginId = 21, IsActive = true, CreatedAt = new DateTime(2025, 07, 16) },
                new Accounts { Id = 22, FullName = "User 22 (Role 5)", Email = "user22.role5@example.com", NationalID = "30101010000022", PasswordHash = "", RoleId = 5, LoginId = 22, IsActive = true, CreatedAt = new DateTime(2025, 07, 16) },
                new Accounts { Id = 23, FullName = "User 23 (Role 5)", Email = "user23.role5@example.com", NationalID = "30101010000023", PasswordHash = "", RoleId = 5, LoginId = 23, IsActive = true, CreatedAt = new DateTime(2025, 07, 16) },
                new Accounts { Id = 24, FullName = "User 24 (Role 5)", Email = "user24.role5@example.com", NationalID = "30101010000024", PasswordHash = "", RoleId = 5, LoginId = 24, IsActive = true, CreatedAt = new DateTime(2025, 07, 16) },
                new Accounts { Id = 25, FullName = "User 25 (Role 5)", Email = "user25.role5@example.com", NationalID = "30101010000025", PasswordHash = "", RoleId = 5, LoginId = 25, IsActive = true, CreatedAt = new DateTime(2025, 07, 16) },
                // --- Role 6 ---
                new Accounts { Id = 26, FullName = "User 26 (Role 6)", Email = "user26.role6@example.com", NationalID = "30101010000026", PasswordHash = "", RoleId = 6, LoginId = 26, IsActive = true, CreatedAt = new DateTime(2025, 07, 16) },
                new Accounts { Id = 27, FullName = "User 27 (Role 6)", Email = "user27.role6@example.com", NationalID = "30101010000027", PasswordHash = "", RoleId = 6, LoginId = 27, IsActive = true, CreatedAt = new DateTime(2025, 07, 16) },
                new Accounts { Id = 28, FullName = "User 28 (Role 6)", Email = "user28.role6@example.com", NationalID = "30101010000028", PasswordHash = "", RoleId = 6, LoginId = 28, IsActive = true, CreatedAt = new DateTime(2025, 07, 16) },
                new Accounts { Id = 29, FullName = "User 29 (Role 6)", Email = "user29.role6@example.com", NationalID = "30101010000029", PasswordHash = "", RoleId = 6, LoginId = 29, IsActive = true, CreatedAt = new DateTime(2025, 07, 16) },
                new Accounts { Id = 30, FullName = "User 30 (Role 6)", Email = "user30.role6@example.com", NationalID = "30101010000030", PasswordHash = "", RoleId = 6, LoginId = 30, IsActive = true, CreatedAt = new DateTime(2025, 07, 16) },
                // --- Role 7 ---
                new Accounts { Id = 31, FullName = "User 31 (Role 7)", Email = "user31.role7@example.com", NationalID = "30101010000031", PasswordHash = "", RoleId = 7, LoginId = 31, IsActive = true, CreatedAt = new DateTime(2025, 07, 16) },
                new Accounts { Id = 32, FullName = "User 32 (Role 7)", Email = "user32.role7@example.com", NationalID = "30101010000032", PasswordHash = "", RoleId = 7, LoginId = 32, IsActive = true, CreatedAt = new DateTime(2025, 07, 16) },
                new Accounts { Id = 33, FullName = "User 33 (Role 7)", Email = "user33.role7@example.com", NationalID = "30101010000033", PasswordHash = "", RoleId = 7, LoginId = 33, IsActive = true, CreatedAt = new DateTime(2025, 07, 16) },
                new Accounts { Id = 34, FullName = "User 34 (Role 7)", Email = "user34.role7@example.com", NationalID = "30101010000034", PasswordHash = "", RoleId = 7, LoginId = 34, IsActive = true, CreatedAt = new DateTime(2025, 07, 16) },
                new Accounts { Id = 35, FullName = "User 35 (Role 7)", Email = "user35.role7@example.com", NationalID = "30101010000035", PasswordHash = "", RoleId = 7, LoginId = 35, IsActive = true, CreatedAt = new DateTime(2025, 07, 16) }
            );

            // =================================================================
            // END OF SEED DATA
            // =================================================================
        }
    }
}