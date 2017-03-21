namespace Zaggie_Festa_.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class criacaotabelafraca : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Eventoes", "Usuario_Id", "dbo.Usuarios");
            DropForeignKey("dbo.Usuarios", "Evento_Id", "dbo.Eventoes");
            DropIndex("dbo.Eventoes", new[] { "Usuario_Id" });
            DropIndex("dbo.Usuarios", new[] { "Evento_Id" });
            CreateTable(
                "dbo.EventoParticipando",
                c => new
                    {
                        UsuarioRefId = c.Int(nullable: false),
                        EventoRefId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.UsuarioRefId, t.EventoRefId })
                .ForeignKey("dbo.Usuarios", t => t.UsuarioRefId, cascadeDelete: true)
                .ForeignKey("dbo.Eventoes", t => t.EventoRefId, cascadeDelete: true)
                .Index(t => t.UsuarioRefId)
                .Index(t => t.EventoRefId);
            
            DropColumn("dbo.Eventoes", "Usuario_Id");
            DropColumn("dbo.Usuarios", "Evento_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Usuarios", "Evento_Id", c => c.Int());
            AddColumn("dbo.Eventoes", "Usuario_Id", c => c.Int());
            DropForeignKey("dbo.EventoParticipando", "EventoRefId", "dbo.Eventoes");
            DropForeignKey("dbo.EventoParticipando", "UsuarioRefId", "dbo.Usuarios");
            DropIndex("dbo.EventoParticipando", new[] { "EventoRefId" });
            DropIndex("dbo.EventoParticipando", new[] { "UsuarioRefId" });
            DropTable("dbo.EventoParticipando");
            CreateIndex("dbo.Usuarios", "Evento_Id");
            CreateIndex("dbo.Eventoes", "Usuario_Id");
            AddForeignKey("dbo.Usuarios", "Evento_Id", "dbo.Eventoes", "Id");
            AddForeignKey("dbo.Eventoes", "Usuario_Id", "dbo.Usuarios", "Id");
        }
    }
}
