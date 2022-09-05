using HR_001.Entities;
using HR_001.Entities.Leave_Management;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace HR_001
{
    public partial class HrDbContext: DbContext
    {
        public HrDbContext()
        {
        }

        public HrDbContext(DbContextOptions<HrDbContext> options)
            : base(options)
        {
        }

        public  DbSet<Role> Roles { get; set; }
        public  DbSet<Status> Statuses { get; set; }
        public  DbSet<User> Users { get; set; }
        public  DbSet<RefreshToken> RefreshTokens { get; set; }
        public  DbSet<Employee> Employees { get; set; }
        public  DbSet<Branch> Branches { get; set; }
        public  DbSet<Permission> Permissions { get; set; }
        public  DbSet<EmployeePosition> EmployeePositions { get; set; }
        public DbSet<PositionType> PositionTypes { get; set; }
        public  DbSet<Contact> Contacts { get; set; }
        public  DbSet<Attachment> Attachments { get; set; }
        public  DbSet<Education> Educations { get; set; }
        public  DbSet<JobTitle> JobTitles { get; set; }
        public DbSet<JobType> JobTypes { get; set; }
        public  DbSet<Address> Addresses { get; set; }
        public  DbSet<Region> Regions { get; set; }
        public  DbSet<Province> Provinces { get; set; }
        public  DbSet<Skill> Skills { get; set; }
        public  DbSet<Salary> Salaries { get; set; }
        public  DbSet<Country> Countries { get; set; }
        public  DbSet<BranchType> BranchTypes { get; set; }
        public  DbSet<AttachmentType> AttachmentTypes { get; set; }
        public  DbSet<EducationType> EducationTypes { get; set; }
        public  DbSet<StatusType> StatusTypes { get; set; }
        public  DbSet<PermissionType> PermissionTypes { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<CompanyType> CompanyTypes { get; set; }
        public DbSet<VacationType> VacationTypes { get; set; }
        public DbSet<Vacation> Vacations { get; set; }
        public DbSet<Holidays> Holidays { get; set; }
        public DbSet<EmployeeBlance> EmployeeBlances { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string ConnectionString = System.IO.File.ReadAllText(@"ConnectionString.txt");

            optionsBuilder.UseSqlServer(ConnectionString);
        }
     }
    }
