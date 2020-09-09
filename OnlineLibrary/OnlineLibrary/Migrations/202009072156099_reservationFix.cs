namespace OnlineLibrary.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class reservationFix : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.ReserveBooks", newName: "BookReservations");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.BookReservations", newName: "ReserveBooks");
        }
    }
}
