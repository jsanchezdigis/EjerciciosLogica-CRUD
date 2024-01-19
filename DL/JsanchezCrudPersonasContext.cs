using Microsoft.EntityFrameworkCore;

namespace DL;

public partial class JsanchezCrudPersonasContext : DbContext
{
    public JsanchezCrudPersonasContext()
    {
    }

    public JsanchezCrudPersonasContext(DbContextOptions<JsanchezCrudPersonasContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Persona> Personas { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Server=.; Database= JSanchezCrudPersonas; User ID=sa; TrustServerCertificate=True; Password=pass@word1;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Persona>(entity =>
        {
            entity.HasKey(e => e.Idpersona).HasName("PK__PERSONA__76CA73C8D8B5E418");

            entity.ToTable("PERSONA");

            entity.Property(e => e.Idpersona).HasColumnName("IDPERSONA");
            entity.Property(e => e.Apellidomaterno)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("APELLIDOMATERNO");
            entity.Property(e => e.Apellidopaterno)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("APELLIDOPATERNO");
            entity.Property(e => e.Nomrre)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("NOMRRE");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
