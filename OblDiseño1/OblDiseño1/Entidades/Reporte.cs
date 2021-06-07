using System.Collections.Generic;

namespace OblDiseño1.Entidades
{
    public class Reporte
    {
        private const int cantidadDeCategoriasSeguridadContraseniaMasUno = 6;
        private Usuario usuario;

        public Reporte(Usuario usuario)
        {
            this.usuario = usuario;

        }

        public reporte ObtenerReporteSeguridadContrasenias()
        {
            List<Categoria> misCategorias = usuario.ObtenerCategorias();
            List<Credencial> misCredenciales = usuario.ObtenerCredenciales();

            paresSeguridad[] misPares = new paresSeguridad[cantidadDeCategoriasSeguridadContraseniaMasUno];
            Dictionary<string, int[]> categoria = new Dictionary<string, int[]>();
            foreach (Categoria cat in misCategorias)
                categoria.Add(cat.Nombre, new int[cantidadDeCategoriasSeguridadContraseniaMasUno]);

            for (int i = 0; i < cantidadDeCategoriasSeguridadContraseniaMasUno; i++)
                misPares[i] = new paresSeguridad(0, null);

            foreach (Credencial dupla in misCredenciales)
            {

                string nombreCategoria = dupla.Categoria.Nombre;
                int nivelSeguridad = dupla.Contraseña.NivelSeguridadContrasenia;
                categoria[nombreCategoria][nivelSeguridad] = categoria[nombreCategoria][nivelSeguridad] + 1;
                misPares[nivelSeguridad].unaListaCredenciales.Add(dupla);
                misPares[nivelSeguridad].cantidad++;
            }

            reporte miReporte = new reporte(misPares, categoria);

            return miReporte;
        }
    }

    public struct reporte
    {
        public paresSeguridad[] duplasPorSeguridad;
        public Dictionary<string, int[]> duplasPorCategoria;

        public reporte(paresSeguridad[] pares, Dictionary<string, int[]> dicionrio)
        {
            duplasPorSeguridad = pares;
            duplasPorCategoria = dicionrio;
        }
    }

    public struct paresSeguridad
    {
        public int cantidad;
        public List<Credencial> unaListaCredenciales;

        public paresSeguridad(int cant, List<Credencial> dupla)
        {
            cantidad = cant;
            unaListaCredenciales = new List<Credencial>();
        }
    }
}
