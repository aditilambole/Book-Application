namespace BookMVCApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class bookm : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Books", "BookName", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Books", "BookName", c => c.String());
        }
    }
}
