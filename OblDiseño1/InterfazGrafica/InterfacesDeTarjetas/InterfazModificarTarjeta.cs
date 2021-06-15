﻿using OblDiseño1.ControladoresPorFuncionalidad;
using System.Collections.Generic;
using System.Windows.Forms;
using AccesoDatos;
using OblDiseño1;
using System;

namespace InterfazGrafica.InterfacesDeTarjetas
{
    public partial class InterfazModificarTarjeta : Form
    {
        private Usuario usuario;
        private Sistema sistema;
        private Tarjeta tarjeta;

        private ControladorObtener controladorObtener = new ControladorObtener();
        private IRepositorio<Categoria> repositorioCategoria;
        private IRepositorio<Tarjeta> repositorioTarjeta;

        public InterfazModificarTarjeta(ref Sistema sistema, ref Usuario usuario, ref Tarjeta tarjeta)
        {
            InitializeComponent();

            this.usuario = usuario;
            this.sistema = sistema;
            this.tarjeta = tarjeta;

            repositorioCategoria = new CategoriaRepositorio(this.usuario);
            repositorioTarjeta = new TarjetaRepositorio(this.usuario);

            CargarComboCategorias();
            CargarDatosViejos();
        }

        private void CargarComboCategorias()
        {
            List<Categoria> categorias = controladorObtener.ObtenerCategorias(repositorioCategoria);

            foreach (var recorredorCategoria in categorias)
            {
                string categoriaMostrar = recorredorCategoria.Nombre;
                comboBoxCategorias.Items.Add(categoriaMostrar);
            }
        }

        private void CargarDatosViejos()
        {
            textBoxNombre.Text = tarjeta.Nombre;
            textBoxTipo.Text = tarjeta.Tipo;
            textBoxNumeroTarjeta.Text = tarjeta.Numero.ToString();
            textBoxCodigoSeguridad.Text = tarjeta.CodigoSeguridad.ToString();
            dateTimePicker1.Value = tarjeta.FechaVencimiento;
            comboBoxCategorias.Text = tarjeta.Categoria.Nombre;
            textBoxNotaOpcional.Text = tarjeta.NotaOpcional;
        }

        private void Aceptar_Click(object sender, EventArgs e)
        {
            string nuevoNumeroTarjeta = textBoxNumeroTarjeta.Text;

            if (nuevoNumeroTarjeta != this.tarjeta.Numero &&
                controladorObtener.ExisteTarjeta(nuevoNumeroTarjeta, repositorioTarjeta))
            {
                MessageBox.Show("Ya hay una tarjeta registrada con ese numero en el sistema");
            }
            else
            {
                try
                {
                    ModificarTarjeta();
                    MessageBox.Show("Se modifico correctamente la tarjeta");
                    IrAInterfazTarjeta();
                }
                catch (ExepcionTarjetaIncorrecta)
                {
                    MostrarCualesSonLosDatosCorrectos();
                }
                catch (System.FormatException)
                {
                    MessageBox.Show("El codigo de seguridad debe ser un numero de 3 o 4 digitos");
                }
            }
        }

        private void ModificarTarjeta()
        {
            string codigoSeguridad = textBoxCodigoSeguridad.Text;
            string nombreCategoria = comboBoxCategorias.Text;

            Categoria categoria = new Categoria(nombreCategoria);

            int codigoSeguridadAConvertir = Int32.Parse(codigoSeguridad);

            ControladorModificar controladorModificar = new ControladorModificar();

            Tarjeta nuevaTarjeta = new Tarjeta();
            nuevaTarjeta.Nombre = textBoxNombre.Text;
            nuevaTarjeta.Tipo = textBoxTipo.Text;
            nuevaTarjeta.Numero = textBoxNumeroTarjeta.Text;
            nuevaTarjeta.CodigoSeguridad = codigoSeguridadAConvertir;
            nuevaTarjeta.FechaVencimiento = dateTimePicker1.Value;
            nuevaTarjeta.Categoria = categoria;
            nuevaTarjeta.NotaOpcional = textBoxNotaOpcional.Text;

            controladorModificar.ModificarTarjeta(this.tarjeta, nuevaTarjeta, repositorioTarjeta);
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
            this.Close();
            InterfazTarjeta interfazTarjeta = new InterfazTarjeta(ref usuario, ref sistema);
            interfazTarjeta.Show();
        }
    }
}
