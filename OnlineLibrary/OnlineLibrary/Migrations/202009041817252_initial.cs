namespace OnlineLibrary.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Authors",
                c => new
                    {
                        AuthorId = c.Int(nullable: false, identity: true),
                        AuthorFullName = c.String(),
                        Age = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.AuthorId);
            
            CreateTable(
                "dbo.Books",
                c => new
                    {
                        BookId = c.Int(nullable: false, identity: true),
                        BookName = c.String(nullable: false),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Publisher = c.String(),
                        Language = c.Int(nullable: false),
                        Author_AuthorId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.BookId)
                .ForeignKey("dbo.Authors", t => t.Author_AuthorId, cascadeDelete: true)
                .Index(t => t.Author_AuthorId);
            
            CreateTable(
                "dbo.Libraries",
                c => new
                    {
                        LibraryId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Address = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.LibraryId);
            
            CreateTable(
                "dbo.LibraryBooks",
                c => new
                    {
                        Library_LibraryId = c.Int(nullable: false),
                        Book_BookId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Library_LibraryId, t.Book_BookId })
                .ForeignKey("dbo.Libraries", t => t.Library_LibraryId, cascadeDelete: true)
                .ForeignKey("dbo.Books", t => t.Book_BookId, cascadeDelete: true)
                .Index(t => t.Library_LibraryId)
                .Index(t => t.Book_BookId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.LibraryBooks", "Book_BookId", "dbo.Books");
            DropForeignKey("dbo.LibraryBooks", "Library_LibraryId", "dbo.Libraries");
            DropForeignKey("dbo.Books", "Author_AuthorId", "dbo.Authors");
            DropIndex("dbo.LibraryBooks", new[] { "Book_BookId" });
            DropIndex("dbo.LibraryBooks", new[] { "Library_LibraryId" });
            DropIndex("dbo.Books", new[] { "Author_AuthorId" });
            DropTable("dbo.LibraryBooks");
            DropTable("dbo.Libraries");
            DropTable("dbo.Books");
            DropTable("dbo.Authors");
        }
    }
}
