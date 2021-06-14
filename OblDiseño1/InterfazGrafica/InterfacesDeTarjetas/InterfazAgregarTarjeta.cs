using OblDiseño1.ControladoresPorFuncionalidad;
using System.Collections.Generic;
using System.Windows.Forms;
using AccesoDatos;
using OblDiseño1;
using System;

namespace InterfazGrafica.InterfacesDeTarjetas
{
    public partial class InterfazAgregarTarjeta : Form
    {
        private Usuario usuario;
        private Sistema sistema;

        private ControladorAlta controladorAlta = new ControladorAlta();
        private ControladorObtener controladorObtener = new ControladorObtener();

        private IRepositorio<Categoria> repositorioCategoria;

        public InterfazAgregarTarjeta(ref Usuario usuario, ref Sistema sistema)
        {
            InitializeComponent();

            this.usuario = usuario;
            this.sistema = sistema;

            repositorioCategoria = new CategoriaRepositorio(this.usuario);

            CargarOpcionesDeCategoria();
        }

        private void CargarOpcionesDeCategoria()
        {
            List<Categoria> categorias = controladorObtener.ObtenerCategorias(repositorioCategoria);

            foreach (var recorredorCategoria in categorias)
            {
                string categoriaMostrar = recorredorCategoria.Nombre;
                comboBoxCategorias.Items.Add(categoriaMostrar);
            }
        }

        private void Agregar_Click(object sender, EventArgs e)
        {
            try
            {
                DarDeAltaTarjeta();
                MessageBox.Show("Se ha dado de alta la Tarjeta con éxito");
                IrAInterfazTarjeta();
            }

            catch (ExepcionObjetosRepetidos)
            {
                MessageBox.Show("Ya existe una tarjeta con el mismo numero");
            }
            catch (ExepcionTarjetaIncorrecta)
            {
                MostrarCualesSonLosDatosCorrectos();
            }
            catch (System.FormatException)
            {
                MessageBox.Show("El codigo de seguridad debe ser un numero de 3 o 4 digitos");
            }
            catch (ExepcionInvalidCategoriaData)
            {
                MessageBox.Show("Debe seleccionar una categoria");
            }
        }

        private void DarDeAltaTarjeta()
        {
            string nombreTarjeta = textBoxNombre.Text;
            string tipoTarjeta = textBoxTipo.Text;
            string numeroTarjeta = textBoxNumeroTarjeta.Text;
            string codigoSeguridad = textBoxCodigoSeguridad.Text;
            DateTime fecha = dateTimePicker1.Value;
            string nombreCategoria = comboBoxCategorias.Text;
            string notaOpcional = textBoxNotaOpcional.Text;

            Categoria categoria = new Categoria(nombreCategoria);

            int codigoSeguridadAConvertir = Int32.Parse(codigoSeguridad);
            Tarjeta nuevaTarjeta = new Tarjeta(nombreTarjeta, tipoTarjeta,
                numeroTarjeta, codigoSeguridadAConvertir, fecha, categoria, notaOpcional);

            IRepositorio<Tarjeta> tarjetaRepositorio = new TarjetaRepositorio(this.usuario);

            controladorAlta.AgregarTarjeta(nuevaTarjeta, tarjetaRepositorio);
        }

        private void MostrarCualesSonLosDatosCorrectos()
        {
            MessageBox.Show("DATOS ERRONEOS.Por faver recuerde que la Tarjeta " +
                            "debe cumplir con el siguiente formato: " +
                            "\n\n" +
                            "> Nombre: Mínimo 3 y máximo 25 caracteres \n\n" +
                            "> Tipo: Mínimo 3 y máximo 25 caracteres \n\n" +
                            "> Número: Enteros de 16 dígitos\n\n" +
                            "> Código: Enteros de 3 o 4 dígitos\n\n" +
                            "> Fecha: No vacía\n\n" +
                            "> Nota: Como máximo 250 caracteress\n\n" +
                            "> Categoría: Se selecciona de las disponibles en el sistema");
        }

        private void IrAInterfazTarjeta()
        {
            this.Close();
            InterfazTarjeta interfazTarjeta = new InterfazTarjeta(ref usuario, ref sistema);
            interfazTarjeta.Show();
        }

        private void Cancelar_Click(object sender, EventArgs e)
        {
            IrAInterfazTarjeta();
        }
    }
}


