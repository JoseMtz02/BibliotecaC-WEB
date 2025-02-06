using _2_Biblioteca.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace _2_Biblioteca.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options): base(options) { }

        //Modelos a mapear
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Rol> Roles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Usuario>().HasData(
                new Usuario
                {
                    PkUsuario = 1,
                    Nombre = "Jose Martinez",
                    UserName = "Usuario 1",
                    Password = "12345",
                    FkRol = 1
                });
            modelBuilder.Entity<Rol>().HasData(
                new Rol
                {
                    PkRol=1,
                    Nombre= "Admin"
                });
        }
    }
}
