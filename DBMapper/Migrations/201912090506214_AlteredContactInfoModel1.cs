namespace DBMapper.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AlteredContactInfoModel1 : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.tb_trnContractInfo", newName: "tb_trnContactInfo");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.tb_trnContactInfo", newName: "tb_trnContractInfo");
        }
    }
}
