namespace AT_AspNet.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _001 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Livro", "AutorId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Livro", "AutorId", c => c.Int(nullable: false));
        }
    }
}
