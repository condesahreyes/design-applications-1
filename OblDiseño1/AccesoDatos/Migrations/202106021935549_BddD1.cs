namespace AccesoDatos.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class BddD1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categorias",
                c => new
                    {
                        CatId = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                    })
                .PrimaryKey(t => t.CatId);
            
            CreateTable(
                "dbo.Dupla_UsuarioContrasenia",
                c => new
                    {
                        duplaId = c.Int(nullable: false, identity: true),
                        NombreUsuario = c.String(),
                        Contrasenia = c.String(),
                        NombreSitioApp = c.String(),
                        TipoSitioOApp = c.String(),
                        Nota = c.String(),
                        FechaUltimaModificacion = c.DateTime(nullable: false),
                        DataBrench = c.Boolean(nullable: false),
                        Categoria_CatId = c.Int(),
                    })
                .PrimaryKey(t => t.duplaId)
                .ForeignKey("dbo.Categorias", t => t.Categoria_CatId)
                .Index(t => t.Categoria_CatId);
            
            CreateTable(
                "dbo.Probandoes",
                c => new
                    {
                        ProbandoId = c.Int(nullable: false, identity: true),
                        name = c.String(),
                        numero = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ProbandoId);
            
            CreateTable(
                "dbo.Tarjetas",
                c => new
                    {
                        Numero = c.String(nullable: false, maxLength: 128),
                        TarjetaId = c.Int(nullable: false),
                        NotaOpcional = c.String(),
                        Nombre = c.String(),
                        Tipo = c.String(),
                        CodigoSeguridad = c.Int(nullable: false),
                        FechaVencimiento = c.DateTime(nullable: false),
                        Categoria_CatId = c.Int(),
                    })
                .PrimaryKey(t => t.Numero)
                .ForeignKey("dbo.Categorias", t => t.Categoria_CatId)
                .Index(t => t.Categoria_CatId);
            
            CreateTable(
                "dbo.Usuarios",
                c => new
                    {
                        UsuarioId = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                        Contrasenia = c.String(),
                    })
                .PrimaryKey(t => t.UsuarioId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tarjetas", "Categoria_CatId", "dbo.Categorias");
            DropForeignKey("dbo.Dupla_UsuarioContrasenia", "Categoria_CatId", "dbo.Categorias");
            DropIndex("dbo.Tarjetas", new[] { "Categoria_CatId" });
            DropIndex("dbo.Dupla_UsuarioContrasenia", new[] { "Categoria_CatId" });
            DropTable("dbo.Usuarios");
            DropTable("dbo.Tarjetas");
            DropTable("dbo.Probandoes");
            DropTable("dbo.Dupla_UsuarioContrasenia");
            DropTable("dbo.Categorias");
        }
    }
}
