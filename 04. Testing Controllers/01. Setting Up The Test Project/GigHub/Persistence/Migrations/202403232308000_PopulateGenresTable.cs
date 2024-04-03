namespace GigHub.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateGenresTable : DbMigration
    {
        public override void Up()
        {
            Sql(@"INSERT INTO Genres(Id, Name) 
                VALUES 
                (1, 'Jazz'),
                (2, 'Blues'),
                (3, 'Rock'),
                (4, 'Country')");
        }
        
        public override void Down()
        {
            Sql("DELETE FROM Genres WHERE Id IN (1, 2, 3, 4)");
        }
    }
}
