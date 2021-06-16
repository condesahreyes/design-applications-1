namespace AccesoDatos.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Migracion : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.EntidadDataBrechTarjetas", "Categoria", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.EntidadDataBrechTarjetas", "Categoria", c => c.Int(nullable: false));
        }
    }
}
