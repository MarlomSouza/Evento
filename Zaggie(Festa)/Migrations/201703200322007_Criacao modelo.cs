namespace Zaggie_Festa_.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Criacaomodelo : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Eventoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                        Descricao = c.String(),
                        Data_Evento = c.DateTime(nullable: false),
                        DonoEventoId = c.Int(nullable: false),
                        Usuario_Id = c.Int(),
                        Usuario_Id1 = c.Int(),
                        Usuario_Id2 = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Usuarios", t => t.Usuario_Id)
                .ForeignKey("dbo.Usuarios", t => t.Usuario_Id1)
                .ForeignKey("dbo.Usuarios", t => t.Usuario_Id2)
                .Index(t => t.Usuario_Id)
                .Index(t => t.Usuario_Id1)
                .Index(t => t.Usuario_Id2);
            
            CreateTable(
                "dbo.Items",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                        Descricao = c.String(),
                        Quantidade = c.Int(nullable: false),
                        Selecionado = c.Boolean(nullable: false),
                        EventoId = c.Int(nullable: false),
                        UsuarioId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Eventoes", t => t.EventoId, cascadeDelete: true)
                .ForeignKey("dbo.Usuarios", t => t.UsuarioId, cascadeDelete: true)
                .Index(t => t.EventoId)
                .Index(t => t.UsuarioId);
            
            CreateTable(
                "dbo.Usuarios",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                        Telefone = c.String(),
                        Email = c.String(),
                        Senha = c.String(),
                        Evento_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Eventoes", t => t.Evento_Id)
                .Index(t => t.Evento_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Eventoes", "Usuario_Id2", "dbo.Usuarios");
            DropForeignKey("dbo.Usuarios", "Evento_Id", "dbo.Eventoes");
            DropForeignKey("dbo.Items", "UsuarioId", "dbo.Usuarios");
            DropForeignKey("dbo.Eventoes", "Usuario_Id1", "dbo.Usuarios");
            DropForeignKey("dbo.Eventoes", "Usuario_Id", "dbo.Usuarios");
            DropForeignKey("dbo.Items", "EventoId", "dbo.Eventoes");
            DropIndex("dbo.Usuarios", new[] { "Evento_Id" });
            DropIndex("dbo.Items", new[] { "UsuarioId" });
            DropIndex("dbo.Items", new[] { "EventoId" });
            DropIndex("dbo.Eventoes", new[] { "Usuario_Id2" });
            DropIndex("dbo.Eventoes", new[] { "Usuario_Id1" });
            DropIndex("dbo.Eventoes", new[] { "Usuario_Id" });
            DropTable("dbo.Usuarios");
            DropTable("dbo.Items");
            DropTable("dbo.Eventoes");
        }
    }
}
