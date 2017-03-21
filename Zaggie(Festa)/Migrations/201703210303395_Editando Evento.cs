namespace Zaggie_Festa_.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EditandoEvento : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Eventoes", "Usuario_Id2", "dbo.Usuarios");
            DropIndex("dbo.Eventoes", new[] { "Usuario_Id2" });
            DropColumn("dbo.Eventoes", "DonoEventoId");
            RenameColumn(table: "dbo.Eventoes", name: "Usuario_Id2", newName: "DonoEventoId");
            AlterColumn("dbo.Eventoes", "DonoEventoId", c => c.Int(nullable: false));
            CreateIndex("dbo.Eventoes", "DonoEventoId");
            AddForeignKey("dbo.Eventoes", "DonoEventoId", "dbo.Usuarios", "Id", cascadeDelete: false);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Eventoes", "DonoEventoId", "dbo.Usuarios");
            DropIndex("dbo.Eventoes", new[] { "DonoEventoId" });
            AlterColumn("dbo.Eventoes", "DonoEventoId", c => c.Int());
            RenameColumn(table: "dbo.Eventoes", name: "DonoEventoId", newName: "Usuario_Id2");
            AddColumn("dbo.Eventoes", "DonoEventoId", c => c.Int(nullable: false));
            CreateIndex("dbo.Eventoes", "Usuario_Id2");
            AddForeignKey("dbo.Eventoes", "Usuario_Id2", "dbo.Usuarios", "Id");
        }
    }
}
