using OblDiseño1.ControladoresPorEntidad;
using System.Windows.Forms;
using AccesoDatos;
using OblDiseño1;
using System;

namespace InterfazGrafica.InterfacesDeTarjetas
{
    public partial class InterfazEliminarTarjeta : Form
    {
        private Usuario usuario;
        private Tarjeta tarjeta;

        private IRepositorio<Tarjeta> tarjetaRepositorio;
        private ControladorTarjeta controladorTarjeta;

        public InterfazEliminarTarjeta(ref Usuario usuario, ref Tarjeta tarjeta)
        {
            InitializeComponent();
            this.usuario = usuario;
            this.tarjeta = tarjeta;

            CrearManejadoresTarjeta();
            tarjetaRepositorio = new TarjetaRepositorio(this.usuario);
        }

        private void CrearManejadoresTarjeta()
        {
            tarjetaRepositorio = new TarjetaRepositorio(this.usuario);
            controladorTarjeta = new ControladorTarjeta(this.usuario, tarjetaRepositorio);
        }

        private void buttonAceptar_Click(object sender, EventArgs e)
        {
            controladorTarjeta.EliminarLaTarjeta(tarjeta);
            IrAInterfazTarjeta();
        }

        private void buttonCancelar_Click(object sender, EventArgs e)
        {
            IrAInterfazTarjeta();
        }

        private void IrAInterfazTarjeta()
        {
            this.Close();
        }
    }
}
