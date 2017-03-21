namespace Zaggie_Festa_.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ajuste : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Items", "UsuarioId", "dbo.Usuarios");
            DropIndex("dbo.Items", new[] { "UsuarioId" });
            AlterColumn("dbo.Items", "UsuarioId", c => c.Int(nullable: true));
            CreateIndex("dbo.Items", "UsuarioId");
            AddForeignKey("dbo.Items", "UsuarioId", "dbo.Usuarios", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Items", "UsuarioId", "dbo.Usuarios");
            DropIndex("dbo.Items", new[] { "UsuarioId" });
            AlterColumn("dbo.Items", "UsuarioId", c => c.Int(nullable: true));
            CreateIndex("dbo.Items", "UsuarioId");
            AddForeignKey("dbo.Items", "UsuarioId", "dbo.Usuarios", "Id", cascadeDelete: true);
        }
    }
}
