using Microsoft.EntityFrameworkCore;

namespace Lab4_Part2.Models;

public class UniversityDbContext : DbContext
{

    public UniversityDbContext(DbContextOptions<UniversityDbContext> options) : base(options)
    {
        
    }
    
    public DbSet<Student> Students { get; set; }
    public DbSet<Teacher> Teachers { get; set; }
    public DbSet<Course> Courses { get; set; }
    public DbSet<Class> Classes { get; set; }
    public DbSet<Enrollement> Enrollements { get; set; }
    public DbSet<Teaching> Teachings { get; set; }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Host=localhost:5434;Database=postgres;Username=root;Password=mysecretpassword");
}