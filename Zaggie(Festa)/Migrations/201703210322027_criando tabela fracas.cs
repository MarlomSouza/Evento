namespace Zaggie_Festa_.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class criandotabelafracas : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Eventoes", "Usuario_Id1", "dbo.Usuarios");
            DropIndex("dbo.Eventoes", new[] { "Usuario_Id1" });
            DropColumn("dbo.Eventoes", "Usuario_Id1");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Eventoes", "Usuario_Id1", c => c.Int());
            CreateIndex("dbo.Eventoes", "Usuario_Id1");
            AddForeignKey("dbo.Eventoes", "Usuario_Id1", "dbo.Usuarios", "Id");
        }
    }
}
