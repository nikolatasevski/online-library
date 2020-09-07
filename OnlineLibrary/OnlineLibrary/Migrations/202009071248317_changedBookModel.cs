namespace OnlineLibrary.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changedBookModel : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Books", "Author_AuthorId", "dbo.Authors");
            DropIndex("dbo.Books", new[] { "Author_AuthorId" });
            AddColumn("dbo.Books", "Author", c => c.String(nullable: false));
            DropColumn("dbo.Books", "Author_AuthorId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Books", "Author_AuthorId", c => c.Int(nullable: false));
            DropColumn("dbo.Books", "Author");
            CreateIndex("dbo.Books", "Author_AuthorId");
            AddForeignKey("dbo.Books", "Author_AuthorId", "dbo.Authors", "AuthorId", cascadeDelete: true);
        }
    }
}
