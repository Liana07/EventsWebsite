namespace EventsWebsite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class again : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Events", "Topic_TopicId", "dbo.Topics");
            DropIndex("dbo.Events", new[] { "Topic_TopicId" });
            RenameColumn(table: "dbo.Events", name: "Topic_TopicId", newName: "TopicId");
            AlterColumn("dbo.Events", "TopicId", c => c.Int(nullable: false));
            CreateIndex("dbo.Events", "TopicId");
            AddForeignKey("dbo.Events", "TopicId", "dbo.Topics", "TopicId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Events", "TopicId", "dbo.Topics");
            DropIndex("dbo.Events", new[] { "TopicId" });
            AlterColumn("dbo.Events", "TopicId", c => c.Int());
            RenameColumn(table: "dbo.Events", name: "TopicId", newName: "Topic_TopicId");
            CreateIndex("dbo.Events", "Topic_TopicId");
            AddForeignKey("dbo.Events", "Topic_TopicId", "dbo.Topics", "TopicId");
        }
    }
}
