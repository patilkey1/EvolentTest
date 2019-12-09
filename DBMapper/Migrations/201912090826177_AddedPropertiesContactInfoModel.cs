namespace DBMapper.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedPropertiesContactInfoModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.tb_trnContactInfo", "lastName", c => c.String(nullable: false, maxLength: 255));
            AddColumn("dbo.tb_trnContactInfo", "Email", c => c.String(nullable: false, maxLength: 255));
            AddColumn("dbo.tb_trnContactInfo", "PhoneNumber", c => c.String(nullable: false, maxLength: 255));
            AddColumn("dbo.tb_trnContactInfo", "isActive", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.tb_trnContactInfo", "isActive");
            DropColumn("dbo.tb_trnContactInfo", "PhoneNumber");
            DropColumn("dbo.tb_trnContactInfo", "Email");
            DropColumn("dbo.tb_trnContactInfo", "lastName");
        }
    }
}
