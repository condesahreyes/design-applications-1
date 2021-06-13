namespace AccesoDatos.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Migracion : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.EntidadCategorias",
                c => new
                    {
                        CategoriaId = c.Int(nullable: false, identity: true),
                        NombreCategoria = c.String(),
                        CredencialId = c.Int(nullable: false),
                        UsuarioNombre = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.CategoriaId)
                .ForeignKey("dbo.EntidadUsuarios", t => t.UsuarioNombre, cascadeDelete: true)
                .Index(t => t.UsuarioNombre);
            
            CreateTable(
                "dbo.EntidadCredencials",
                c => new
                    {
                        CredencialId = c.Int(nullable: false),
                        NombreUsuario = c.String(),
                        ContraseniaId = c.Int(nullable: false),
                        NombreSitioApp = c.String(),
                        UsuarioGestorNombre = c.String(nullable: false, maxLength: 128),
                        TipoSitioOApp = c.String(),
                        Nota = c.String(),
                        IdCategoria = c.Int(nullable: false),
                        FechaUltimaModificacion = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.CredencialId)
                .ForeignKey("dbo.EntidadCategorias", t => t.IdCategoria, cascadeDelete: true)
                .ForeignKey("dbo.EntidadContraseña", t => t.CredencialId)
                .ForeignKey("dbo.EntidadUsuarios", t => t.UsuarioGestorNombre)
                .Index(t => t.CredencialId)
                .Index(t => t.UsuarioGestorNombre)
                .Index(t => t.IdCategoria);
            
            CreateTable(
                "dbo.EntidadContraseña",
                c => new
                    {
                        ContraseniaId = c.Int(nullable: false, identity: true),
                        Contrasenia = c.String(),
                        NivelSeguridadContrasenia = c.Int(nullable: false),
                        CredencialId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ContraseniaId);
            
            CreateTable(
                "dbo.EntidadUsuarios",
                c => new
                    {
                        Nombre = c.String(nullable: false, maxLength: 128),
                        Contrasenia = c.String(),
                    })
                .PrimaryKey(t => t.Nombre);
            
            CreateTable(
                "dbo.EntidadTarjetas",
                c => new
                    {
                        TarjetaId = c.Int(nullable: false, identity: true),
                        Numero = c.String(),
                        UsuarioGestorNombre = c.String(nullable: false, maxLength: 128),
                        NotaOpcional = c.String(),
                        Nombre = c.String(),
                        Tipo = c.String(),
                        CodigoSeguridad = c.Int(nullable: false),
                        FechaVencimiento = c.DateTime(nullable: false),
                        IdCategoria = c.Int(nullable: false),
                        UsuarioGestorNombreCategoria = c.String(),
                    })
                .PrimaryKey(t => t.TarjetaId)
                .ForeignKey("dbo.EntidadCategorias", t => t.IdCategoria, cascadeDelete: true)
                .ForeignKey("dbo.EntidadUsuarios", t => t.UsuarioGestorNombre)
                .Index(t => t.UsuarioGestorNombre)
                .Index(t => t.IdCategoria);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.EntidadCategorias", "UsuarioNombre", "dbo.EntidadUsuarios");
            DropForeignKey("dbo.EntidadCredencials", "UsuarioGestorNombre", "dbo.EntidadUsuarios");
            DropForeignKey("dbo.EntidadTarjetas", "UsuarioGestorNombre", "dbo.EntidadUsuarios");
            DropForeignKey("dbo.EntidadTarjetas", "IdCategoria", "dbo.EntidadCategorias");
            DropForeignKey("dbo.EntidadCredencials", "CredencialId", "dbo.EntidadContraseña");
            DropForeignKey("dbo.EntidadCredencials", "IdCategoria", "dbo.EntidadCategorias");
            DropIndex("dbo.EntidadTarjetas", new[] { "IdCategoria" });
            DropIndex("dbo.EntidadTarjetas", new[] { "UsuarioGestorNombre" });
            DropIndex("dbo.EntidadCredencials", new[] { "IdCategoria" });
            DropIndex("dbo.EntidadCredencials", new[] { "UsuarioGestorNombre" });
            DropIndex("dbo.EntidadCredencials", new[] { "CredencialId" });
            DropIndex("dbo.EntidadCategorias", new[] { "UsuarioNombre" });
            DropTable("dbo.EntidadTarjetas");
            DropTable("dbo.EntidadUsuarios");
            DropTable("dbo.EntidadContraseña");
            DropTable("dbo.EntidadCredencials");
            DropTable("dbo.EntidadCategorias");
        }
    }
}
