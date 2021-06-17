using Menu = InterfazGrafica.InterfacesMenu.Menu;
using CapaDeComunicación.ControladoresPorEntidad;
using OblDiseño1.ControladoresPorEntidad;
using System.Collections.Generic;
using OblDiseño1.Entidades;
using System.Windows.Forms;
using OblDiseño1;
using System;

namespace InterfazGrafica.InterfazCompartirContraseñas
{
    public partial class InterfazContraseñasCompartidas : Form
    {
        private Usuario usuario;
        GestorContraseniasCompartidas miGestor;
        ControladorRegistroCredencialCompartida controladorRegistroCredencialCompartida;
        ControladorCredencial controladorCredencial;

        public InterfazContraseñasCompartidas(ref Usuario usuario)
        {
            InitializeComponent();

            this.usuario = usuario;
            this.controladorRegistroCredencialCompartida = new ControladorRegistroCredencialCompartida(this.usuario);
            this.controladorCredencial = new ControladorCredencial(this.usuario);
            miGestor = usuario.GestorCompartirContrasenia;
            miGestor.BorrarDatosDeGestor();

            CargarGestor();
            CargarContraseñasCompartidas();
            CargarContraseñasCompartidasConmigo();
        }

        private void CargarGestor()
        {
            List<Credencial> contraseñasQueComparto = controladorRegistroCredencialCompartida.
                ObtenerTodasLasCredencialesQueComparto();
            List<Credencial> contraseñasQueMeComparten = controladorRegistroCredencialCompartida.
                ObtenerTodasLasCredencialesQueMeComparten();

            List<Usuario> usuariosQueMeCompartenAlgunaCredencial = controladorRegistroCredencialCompartida.
                ObtenerUsuariosQueMeCompartenAlgunaCredencial();

            foreach (var credencial in contraseñasQueComparto)
            {
                List<Usuario> usuariosALosQueComparto = controladorRegistroCredencialCompartida.
                    ObtenerTodosLosUsuariosALosQueCompartoUnaCredencial(credencial);
                miGestor.ObtenerContraseniasCompartidasPorMi().Add(credencial, usuariosALosQueComparto);
            }

            foreach (var usuarioQueMeComparteAlgunaCred in usuariosQueMeCompartenAlgunaCredencial)
            {
                List<Credencial> credencialesQueMeComparteElUsuario = controladorRegistroCredencialCompartida.
                    ObtenerCredencialesQueMeComparteElUsuario(usuarioQueMeComparteAlgunaCred);
                miGestor.ObtenerContraseniasCompartidasConmigo().Add(usuarioQueMeComparteAlgunaCred, 
                    credencialesQueMeComparteElUsuario);
            }
        }

        private void CargarContraseñasCompartidas()
        {
            BindingSource biso = new BindingSource();

            this.dataGridContraseñasCompartidas.AllowUserToAddRows = false;
            miGestor = usuario.GestorCompartirContrasenia;

            biso.DataSource = miGestor.ObtenerContraseniasCompartidasPorMi().Keys;

            if (miGestor.ObtenerContraseniasCompartidasPorMi().Count == 0)
            {
                this.dataGridContraseñasCompartidas.Visible = true;
            }
            else
            {
                this.dataGridContraseñasCompartidas.DataSource = biso;
                HacerAlgunasColumnasNoVisiblesDelDataGridContraseñasCompartidas();
                ModificarNombreDeColumnasDataGridContraseñasCompartidas();
            }
        }

        private void HacerAlgunasColumnasNoVisiblesDelDataGridContraseñasCompartidas()
        {
            this.dataGridContraseñasCompartidas.Columns["ObtenerNivelSeguridad"].Visible = false;
            this.dataGridContraseñasCompartidas.Columns["ObtenerContraseña"].Visible = false;
            this.dataGridContraseñasCompartidas.Columns["TipoSitioOApp"].Visible = false;
            this.dataGridContraseñasCompartidas.Columns["DataBrench"].Visible = false;
            this.dataGridContraseñasCompartidas.Columns["Contraseña"].Visible = false;
            this.dataGridContraseñasCompartidas.Columns["Nota"].Visible = false;
        }

        private void ModificarNombreDeColumnasDataGridContraseñasCompartidas()
        {
            this.dataGridContraseñasCompartidas.Columns["NombreUsuario"].HeaderText = "Usuario Nombre";
            this.dataGridContraseñasCompartidas.Columns["NombreSitioApp"].HeaderText = "Sitio";
            this.dataGridContraseñasCompartidas.Columns["FechaUltimaModificacion"].HeaderText =
                "Ultima Modificación";
            this.dataGridContraseñasCompartidas.Columns["Categoria"].HeaderText = "Categoría";
        }

        private void CargarContraseñasCompartidasConmigo()
        {
            BindingSource biso2 = new BindingSource();
            this.dataGridContraseñasCompartidas.AllowUserToAddRows = false;
            this.miGestor = usuario.GestorCompartirContrasenia;

            List<Credencial> listaCredencialesCompartidasConmigo = new List<Credencial>();
            foreach (var iterador in this.miGestor.ObtenerContraseniasCompartidasConmigo())
            {
                foreach (var iteradorAuxiliar in iterador.Value)
                    listaCredencialesCompartidasConmigo.Add(iteradorAuxiliar);
            }

            biso2.DataSource = listaCredencialesCompartidasConmigo;

            if (this.miGestor.ObtenerContraseniasCompartidasConmigo().Count == 0)
            {
                this.dataGridContraseñasCompartidasConmigo.Visible = true;
            }
            else
            {
                this.dataGridContraseñasCompartidasConmigo.DataSource = biso2;
                HacerAlgunasColumnasNoVisiblesDelDataGridContraseñasCompartidasConmigo();
                ModificarNombreDeColumnasDataGridContraseñasCompartidasConmigo();
            }

        }

        private void HacerAlgunasColumnasNoVisiblesDelDataGridContraseñasCompartidasConmigo()
        {
            this.dataGridContraseñasCompartidasConmigo.Columns["ObtenerNivelSeguridad"].Visible = false;
            this.dataGridContraseñasCompartidasConmigo.Columns["ObtenerContraseña"].Visible = false;
            this.dataGridContraseñasCompartidasConmigo.Columns["TipoSitioOApp"].Visible = false;
            this.dataGridContraseñasCompartidasConmigo.Columns["DataBrench"].Visible = false;
            this.dataGridContraseñasCompartidasConmigo.Columns["Contraseña"].Visible = false;
            this.dataGridContraseñasCompartidasConmigo.Columns["Nota"].Visible = false;
        }

        private void ModificarNombreDeColumnasDataGridContraseñasCompartidasConmigo()
        {
            this.dataGridContraseñasCompartidasConmigo.Columns["NombreUsuario"].HeaderText = "Usuario Nombre";
            this.dataGridContraseñasCompartidasConmigo.Columns["NombreSitioApp"].HeaderText = "Sitio";
            this.dataGridContraseñasCompartidasConmigo.Columns["FechaUltimaModificacion"].HeaderText =
                "Ultima Modificación";
            this.dataGridContraseñasCompartidasConmigo.Columns["Categoria"].HeaderText = "Categoría";
        }

        private void InterfazContraseñasCompartidas_Load(object sender, EventArgs e)
        {
            if (this.dataGridContraseñasCompartidasConmigo.Rows.Count > 0)
                this.dataGridContraseñasCompartidasConmigo.ClearSelection();

            if (this.dataGridContraseñasCompartidas.Rows.Count > 0)
                this.dataGridContraseñasCompartidas.ClearSelection();
        }

        private void buttonCompartir_Click(object sender, EventArgs e)
        {
            if (controladorCredencial.ObtenerTodasMisCredenciales().Count > 0)
            {
                this.Close();
                InterfazCompartirContraseña interfazCompartirContraseña =
                    new InterfazCompartirContraseña(ref usuario);
                interfazCompartirContraseña.Show();
            }
            else
                MessageBox.Show("No existen credenciales registradas aun");
        }

        private void buttonVolver_Click(object sender, EventArgs e)
        {
            this.Close();
            Menu menu = new Menu(ref usuario);
            menu.Show();
        }

        private void buttonVerUsuariosCompartidos_Click(object sender, EventArgs e)
        {
            GestorContraseniasCompartidas miGestor = usuario.GestorCompartirContrasenia;
            if (miGestor.ObtenerContraseniasCompartidasPorMi().Count == 0)
                MessageBox.Show("Error: No hay contraseñas compartidas aun");
            else
            {
                Credencial credencialSeleccionada = (Credencial)dataGridContraseñasCompartidas.
                    CurrentRow.DataBoundItem;

                if (credencialSeleccionada == null)
                    MessageBox.Show("Error: debe seleccionar una contrasenia primero");
                else
                    IrADejarDeCompartirContrasenia(ref credencialSeleccionada);
            }
        }

        private void IrADejarDeCompartirContrasenia(ref Credencial credencialSeleccionada)
        {
            InterfazDejarDeCompartirContrasenia interfazDejarDeCompartirContrasenias =
                new InterfazDejarDeCompartirContrasenia(ref usuario, ref credencialSeleccionada);
            this.Close();
            interfazDejarDeCompartirContrasenias.Show();
        }
    }
}
