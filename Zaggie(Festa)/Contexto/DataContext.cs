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


    }
}