namespace DBMapper.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AlteredContactInfoModel : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.ContactInfoes", newName: "tb_trnContractInfo");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.tb_trnContractInfo", newName: "ContactInfoes");
        }
    }
}
