using OblDiseño1.ControladoresPorFuncionalidad;
using System.Windows.Forms;
using AccesoDatos;
using OblDiseño1;
using System;

namespace InterfazGrafica.InterfacesDeTarjetas
{
    public partial class InterfazEliminarTarjeta : Form
    {
        private Usuario usuario;
        private Sistema sistema;
        private Tarjeta tarjeta;

        ControladorEliminar controladorEliminar = new ControladorEliminar();
        IRepositorio<Tarjeta> tarjetaRepositorio;

        public InterfazEliminarTarjeta(ref Sistema sistema, ref Usuario usuario, ref Tarjeta tarjeta)
        {
            InitializeComponent();
            this.usuario = usuario;
            this.sistema = sistema;
            this.tarjeta = tarjeta;
            tarjetaRepositorio = new TarjetaRepositorio(this.usuario);
        }

        private void buttonAceptar_Click(object sender, EventArgs e)
        {
            controladorEliminar.EliminarTarjeta(tarjeta, tarjetaRepositorio);
            IrAInterfazTarjeta();
        }

        private void buttonCancelar_Click(object sender, EventArgs e)
        {
            IrAInterfazTarjeta();
        }

        private void IrAInterfazTarjeta()
        {
            this.Close();
            InterfazTarjeta interfazTarjeta = new InterfazTarjeta(ref usuario, ref sistema);
            interfazTarjeta.Show();
        }
    }
}
