using OblDiseño1;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InterfazGrafica.InterfacesDeContrasenias
{
    public partial class InterfazAgregarContrasenia : Form
    {
        private Usuario usuario;
        private Sistema sistema;
        public InterfazAgregarContrasenia(ref Sistema sistema, ref Usuario usuario)
        {
            InitializeComponent();
            this.usuario = usuario;
            this.sistema = sistema;
            AgregarCategorias();    
        }

        private void AgregarCategorias()
        {
            var bindingSource = new BindingSource();
            bindingSource.DataSource = usuario.ObtenerCategorias();
            this.comboBoxCategoria.DataSource = bindingSource.DataSource;
            this.comboBoxCategoria.SelectedIndex = 0;
        }


        private void btnAgregarCategoria_Click(object sender, EventArgs e)
        {
            try
            {
                string nombreUsuario = textBoxNombre.Text;
                string contrasenia = textBoxContrasenia.Text;
                string nombreSitio = textBoxNombreSitioApp.Text;
                string nota = textBoxNota.Text;
                Categoria categoria = (Categoria)comboBoxCategoria.SelectedItem;
                Dupla_UsuarioContrasenia dupla = new Dupla_UsuarioContrasenia(nombreUsuario, contrasenia, nombreSitio, nota, categoria);
                usuario.AgregarDupla(dupla);
                IrAContraseñas();
            }
            catch (Exepcion_DatosDeContraseniaInvalidos)
            {
                MessageBox.Show("DATOS ERRONEOS. Por faver recuerde que la Contraseña " +
                                "debe cumplir con el siguiente formato: " +
                                "\n\n" +
                                "> Nombre de Usuario: Mínimo 5 caracteres y máximo 25\n\n" +
                                "> Contraseña: Mínimo 5 caracteres y máximo 25\n\n" +
                                "> Sitio: Mínimo 3 caracteres y máximo 25\n\n" +
                                "> Categoría: Se selecciona de las disponibles en el sistema");
            }
            catch (Exepcion_InvalidUsuarioData)
            {
                MessageBox.Show("Error: este usuario ya esta registado para este sitio en el sistema");
            }
        }


        private void IrAContraseñas()
        {
            InterfazContrasenia interfazContrasenia = new InterfazContrasenia(ref usuario, ref sistema);
            interfazContrasenia.Show();
            this.Close();
        }

        private void btnCancelarCategoria_Click(object sender, EventArgs e)
        {
            IrAContraseñas();
        }

        private void butto_GenerarContrasenia_Click(object sender, EventArgs e)
        {
            string nuevaContra = "";
            Interfaz_GenerarContrasenia genContra = new Interfaz_GenerarContrasenia(ref usuario, ref sistema);
            genContra.ShowDialog();
            string posibleNuevaContra = genContra.ObtenerNuevaContrasenia();
            if (!posibleNuevaContra.Equals(""))
            {
                nuevaContra = genContra.ObtenerNuevaContrasenia();
            }
            this.textBoxContrasenia.Text = nuevaContra;
        }
    }
}
