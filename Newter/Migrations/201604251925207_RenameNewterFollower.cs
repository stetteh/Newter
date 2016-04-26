namespace Newter.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RenameNewterFollower : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.NewterUserNewterUsers", newName: "NewtFollowers");
            RenameColumn(table: "dbo.NewtFollowers", name: "NewterUser_Id", newName: "FollowerId");
            RenameColumn(table: "dbo.NewtFollowers", name: "NewterUser_Id1", newName: "FollowingId");
            RenameIndex(table: "dbo.NewtFollowers", name: "IX_NewterUser_Id", newName: "IX_FollowerId");
            RenameIndex(table: "dbo.NewtFollowers", name: "IX_NewterUser_Id1", newName: "IX_FollowingId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.NewtFollowers", name: "IX_FollowingId", newName: "IX_NewterUser_Id1");
            RenameIndex(table: "dbo.NewtFollowers", name: "IX_FollowerId", newName: "IX_NewterUser_Id");
            RenameColumn(table: "dbo.NewtFollowers", name: "FollowingId", newName: "NewterUser_Id1");
            RenameColumn(table: "dbo.NewtFollowers", name: "FollowerId", newName: "NewterUser_Id");
            RenameTable(name: "dbo.NewtFollowers", newName: "NewterUserNewterUsers");
        }
    }
}
