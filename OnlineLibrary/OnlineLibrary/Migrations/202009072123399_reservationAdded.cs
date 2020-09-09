namespace OnlineLibrary.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class reservationAdded : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ReserveBooks",
                c => new
                    {
                        reservationID = c.Int(nullable: false, identity: true),
                        library_LibraryId = c.Int(),
                        selectedBook_BookId = c.Int(),
                        user_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.reservationID)
                .ForeignKey("dbo.Libraries", t => t.library_LibraryId)
                .ForeignKey("dbo.Books", t => t.selectedBook_BookId)
                .ForeignKey("dbo.AspNetUsers", t => t.user_Id)
                .Index(t => t.library_LibraryId)
                .Index(t => t.selectedBook_BookId)
                .Index(t => t.user_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ReserveBooks", "user_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.ReserveBooks", "selectedBook_BookId", "dbo.Books");
            DropForeignKey("dbo.ReserveBooks", "library_LibraryId", "dbo.Libraries");
            DropIndex("dbo.ReserveBooks", new[] { "user_Id" });
            DropIndex("dbo.ReserveBooks", new[] { "selectedBook_BookId" });
            DropIndex("dbo.ReserveBooks", new[] { "library_LibraryId" });
            DropTable("dbo.ReserveBooks");
        }
    }
}
