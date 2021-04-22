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
            List<string> categorias = usuario.ListarCategorias();
            for (int i = 0; i < categorias.Count; i++)
            {
                string categoriaMostrar = categorias[i];
                comboBoxCategoria.Items.Add(categoriaMostrar);
            }

        }

        private void btnAgregarCategoria_Click(object sender, EventArgs e)
        {
            string nombreUsuario = textBoxNombre.Text;
            string contrasenia = textBoxContrasenia.Text;
            string nombreSitio = textBoxNombreSitioApp.Text;
            string nombreCategoria = comboBoxCategoria.Text;
            string nota = textBoxNota.Text;
            Categoria categoria = new Categoria(nombreCategoria);
            Dupla_UsuarioContrasenia dupla = new Dupla_UsuarioContrasenia(nombreUsuario, contrasenia, nombreSitio, nota, categoria);
            usuario.AgregarDupla(dupla);
            IrAContraseñas();

        }

        private void IrAContraseñas()
        {
            this.Hide();
            InterfazContrasenia interfazContrasenia = new InterfazContrasenia(ref usuario, ref sistema);
            interfazContrasenia.Show();
        }

        private void comboBoxCategoria_SelectedIndexChanged(object sender, EventArgs e)
        {

            
        }

        private void btnCancelarCategoria_Click(object sender, EventArgs e)
        {
            IrAContraseñas();
        }
    }
}
