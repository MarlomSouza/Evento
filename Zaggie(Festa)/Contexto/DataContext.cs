namespace Zaggie_Festa_.Contexto
{
    using Models;
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class DataContext : DbContext
    {

        public DataContext()
            : base("name=ZaggieEvento")
        {
        }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Item> Itens { get; set; }
        public DbSet<Evento> Eventos { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Usuario>()
                        .HasMany<Evento>(s => s.Eventos)
                        .WithMany(c => c.Participantes)
                        .Map(cs =>
                        {
                            cs.MapLeftKey("UsuarioRefId");
                            cs.MapRightKey("EventoRefId");
                            cs.ToTable("EventoParticipando");
                        });

        }
    }
}