namespace OnlineLibrary.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class reservationSetAdded : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.LibraryBooks", newName: "BookLibraries");
            DropPrimaryKey("dbo.BookLibraries");
            AddPrimaryKey("dbo.BookLibraries", new[] { "Book_BookId", "Library_LibraryId" });
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.BookLibraries");
            AddPrimaryKey("dbo.BookLibraries", new[] { "Library_LibraryId", "Book_BookId" });
            RenameTable(name: "dbo.BookLibraries", newName: "LibraryBooks");
        }
    }
}
