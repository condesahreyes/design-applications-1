﻿using OblDiseño1.ControladoresPorEntidad;
using System.Collections.Generic;
using System.Windows.Forms;
using OblDiseño1;
using System;

namespace InterfazGrafica.InterfacesDeContrasenias
{
    public partial class InterfazAgregarContrasenia : Form
    {
        private Usuario usuario;

        private ControladorCategoria controladorCategoria;
        private ControladorCredencial controladorCredencial;

        public InterfazAgregarContrasenia(ref Usuario usuario)
        {
            InitializeComponent();
            this.usuario = usuario;

            CrearManejadoresCredencial();
            CrearManejadoresCategoria();
            AgregarCategorias();
        }

        private void CrearManejadoresCredencial()
        {
            controladorCredencial = new ControladorCredencial(this.usuario);
        }

        private void CrearManejadoresCategoria()
        {
            controladorCategoria = new ControladorCategoria(this.usuario);
        }

        private void AgregarCategorias()
        {
            List<Categoria> categorias = controladorCategoria.ObtenerCategorias();

            var bindingSource = new BindingSource();
            bindingSource.DataSource = categorias;
            this.comboBoxCategoria.DataSource = bindingSource.DataSource;
            this.comboBoxCategoria.SelectedIndex = 0;
        }

        private void btnAgregarCategoria_Click(object sender, EventArgs e)
        {
            try
            {
                DarDeAltaCredencial();
                IrAContraseñas();
            }
            catch (ExepcionDatosDeContraseniaInvalidos)
            {
                MostrarCualesSonLosDatosCorrectos();
            }
            catch (ExepcionInvalidUsuarioData)
            {
                MostrarMensajeUsuarioYaRegistrado();
            }
            catch (ExepcionObjetosRepetidos)
            {
                MostrarMensajeUsuarioYaRegistrado();
            }
        }

        private void DarDeAltaCredencial()
        {
            string nombreUsuario = textBoxNombre.Text;
            string contraseña = textBoxContrasenia.Text;
            string nombreSitio = textBoxNombreSitioApp.Text;
            string nota = textBoxNota.Text;

            Categoria categoria = (Categoria)comboBoxCategoria.SelectedItem;
            controladorCredencial.CrearCredencial(nombreUsuario, contraseña, nombreSitio, nota, categoria);

            MessageBox.Show("Se ha agregado la contraseña con éxito");
        }

        private void MostrarCualesSonLosDatosCorrectos()
        {
            MessageBox.Show("DATOS ERRONEOS. Por faver recuerde que la Contraseña " +
                "debe cumplir con el siguiente formato: " +
                "\n\n" +
                "> Nombre de Usuario: Mínimo 5 caracteres y máximo 25\n\n" +
                "> Contraseña: Mínimo 5 caracteres y máximo 25\n\n" +
                "> Sitio: Mínimo 3 caracteres y máximo 25\n\n" +
                "> Categoría: Se selecciona de las disponibles en el sistema");
        }

        private void MostrarMensajeUsuarioYaRegistrado()
        {
            MessageBox.Show("Error: este usuario ya esta registado para este sitio en el sistema");
        }

        private void btnCancelarCategoria_Click(object sender, EventArgs e)
        {
            IrAContraseñas();
        }

        private void IrAContraseñas()
        {
            InterfazContrasenia interfazContrasenia = new InterfazContrasenia(ref usuario);
            interfazContrasenia.Show();
            this.Close();
        }

        private void butto_GenerarContrasenia_Click(object sender, EventArgs e)
        {
            InterfazGenerarContrasenia generarContrasenia = new InterfazGenerarContrasenia();

            string nuevaContrasenia = "";
            generarContrasenia.ShowDialog();
            string posibleNuevaContra = generarContrasenia.ObtenerNuevaContrasenia();

            if (!posibleNuevaContra.Equals(""))
                nuevaContrasenia = generarContrasenia.ObtenerNuevaContrasenia();

            this.textBoxContrasenia.Text = nuevaContrasenia;
        }

        private void btnSugerencias_Click(object sender, EventArgs e)
        {
            string posibleContraseña = textBoxContrasenia.Text;

            string mensaje = "";

            mensaje = EsContraseñaSegura(posibleContraseña, mensaje);

            mensaje = EsContraseñaDuplicada(posibleContraseña, mensaje);

            mensaje = EsContraseñaVulnerada(posibleContraseña, mensaje);

            MessageBox.Show(mensaje);
        }

        private string EsContraseñaSegura(string posibleContraseña, string mensaje)
        {
            bool segura = controladorCredencial.ObtenerSiEsContraseniaSegura(posibleContraseña);

            if (segura)
                mensaje = mensaje + "Es una contraseña segura \n";
            else
                mensaje = mensaje + "No es una contraseña segura \n";

            return mensaje;
        }

        private string EsContraseñaDuplicada(string posibleContraseña, string mensaje)
        {
            bool duplicada = controladorCredencial.ObtenerSiEsContraseniaDuplicada(posibleContraseña, null);

            if (duplicada)
                mensaje = mensaje + "Es una contraseña duplicada \n";

            return mensaje;
        }

        private string EsContraseñaVulnerada(string posibleContraseña, string mensaje)
        {
            bool vulnerada = controladorCredencial.ObtenerSiEsContraseñaVulnerada(posibleContraseña);

            if (vulnerada)
                mensaje = mensaje + "Es una contraseña vulnerada \n";

            return mensaje;
        }
    }
}
