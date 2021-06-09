namespace AccesoDatos.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class BddD1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.EntidadCategorias",
                c => new
                    {
                        CategoriaId = c.Int(nullable: false, identity: true),
                        NombreCategoria = c.String(),
                        usuarioDueño_Nombre = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.CategoriaId)
                .ForeignKey("dbo.EntidadUsuarios", t => t.usuarioDueño_Nombre)
                .Index(t => t.usuarioDueño_Nombre);
            
            CreateTable(
                "dbo.EntidadUsuarios",
                c => new
                    {
                        Nombre = c.String(nullable: false, maxLength: 128),
                        Contrasenia = c.String(),
                    })
                .PrimaryKey(t => t.Nombre);
            
            CreateTable(
                "dbo.EntidadCredencials",
                c => new
                    {
                        CredencialId = c.Int(nullable: false),
                        NombreUsuario = c.String(nullable: false, maxLength: 128),
                        NombreSitioApp = c.String(nullable: false, maxLength: 128),
                        TipoSitioOApp = c.String(),
                        Nota = c.String(),
                        FechaUltimaModificacion = c.DateTime(nullable: false),
                        Categoria_CategoriaId = c.Int(),
                        Contrasenia_ContraseñaId = c.Int(),
                        EntidadUsuario_Nombre = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => new { t.CredencialId, t.NombreUsuario, t.NombreSitioApp })
                .ForeignKey("dbo.EntidadCategorias", t => t.Categoria_CategoriaId)
                .ForeignKey("dbo.EntidadContraseña", t => t.Contrasenia_ContraseñaId)
                .ForeignKey("dbo.EntidadUsuarios", t => t.EntidadUsuario_Nombre)
                .Index(t => t.Categoria_CategoriaId)
                .Index(t => t.Contrasenia_ContraseñaId)
                .Index(t => t.EntidadUsuario_Nombre);
            
            CreateTable(
                "dbo.EntidadContraseña",
                c => new
                    {
                        ContraseñaId = c.Int(nullable: false, identity: true),
                        Contrasenia = c.String(),
                        NivelSeguridadContrasenia = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ContraseñaId);
            
            CreateTable(
                "dbo.EntidadTarjetas",
                c => new
                    {
                        Numero = c.Int(nullable: false, identity: true),
                        NotaOpcional = c.String(),
                        Nombre = c.String(maxLength: 128),
                        Tipo = c.String(),
                        CodigoSeguridad = c.Int(nullable: false),
                        FechaVencimiento = c.DateTime(nullable: false),
                        Categoria_CategoriaId = c.Int(),
                    })
                .PrimaryKey(t => t.Numero)
                .ForeignKey("dbo.EntidadCategorias", t => t.Categoria_CategoriaId)
                .ForeignKey("dbo.EntidadUsuarios", t => t.Nombre)
                .Index(t => t.Nombre)
                .Index(t => t.Categoria_CategoriaId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.EntidadTarjetas", "Nombre", "dbo.EntidadUsuarios");
            DropForeignKey("dbo.EntidadTarjetas", "Categoria_CategoriaId", "dbo.EntidadCategorias");
            DropForeignKey("dbo.EntidadCredencials", "EntidadUsuario_Nombre", "dbo.EntidadUsuarios");
            DropForeignKey("dbo.EntidadCredencials", "Contrasenia_ContraseñaId", "dbo.EntidadContraseña");
            DropForeignKey("dbo.EntidadCredencials", "Categoria_CategoriaId", "dbo.EntidadCategorias");
            DropForeignKey("dbo.EntidadCategorias", "usuarioDueño_Nombre", "dbo.EntidadUsuarios");
            DropIndex("dbo.EntidadTarjetas", new[] { "Categoria_CategoriaId" });
            DropIndex("dbo.EntidadTarjetas", new[] { "Nombre" });
            DropIndex("dbo.EntidadCredencials", new[] { "EntidadUsuario_Nombre" });
            DropIndex("dbo.EntidadCredencials", new[] { "Contrasenia_ContraseñaId" });
            DropIndex("dbo.EntidadCredencials", new[] { "Categoria_CategoriaId" });
            DropIndex("dbo.EntidadCategorias", new[] { "usuarioDueño_Nombre" });
            DropTable("dbo.EntidadTarjetas");
            DropTable("dbo.EntidadContraseña");
            DropTable("dbo.EntidadCredencials");
            DropTable("dbo.EntidadUsuarios");
            DropTable("dbo.EntidadCategorias");
        }
    }
}
