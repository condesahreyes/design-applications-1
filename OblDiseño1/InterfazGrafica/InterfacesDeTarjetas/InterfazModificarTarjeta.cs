﻿using OblDiseño1;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace InterfazGrafica.InterfacesDeTarjetas
{
    public partial class InterfazModificarTarjeta : Form
    {
        private Usuario usuario;
        private Sistema sistema;
        private Tarjeta tarjeta;

        private List<string> categorias;

        public InterfazModificarTarjeta(ref Sistema sistema, ref Usuario usuario, ref Tarjeta tarjeta)
        {
            InitializeComponent();

            this.usuario = usuario;
            this.sistema = sistema;
            this.tarjeta = tarjeta;
            this.categorias = usuario.ListarToStringDeMisCategorias();

            CargarComboCategorias();
            CargarDatosViejos();
        }

        private void CargarComboCategorias()
        {
            for (int i = 0; i < categorias.Count; i++)
            {
                string categoriaMostrar = categorias[i];
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
            string codigoSeguridad = textBoxCodigoSeguridad.Text;
            string nombreCategoria = comboBoxCategorias.Text;
            Categoria categoria = usuario.DevolverCategoria(nombreCategoria);
            string nuevoNumeroTarjeta = textBoxNumeroTarjeta.Text;

            if (nuevoNumeroTarjeta != this.tarjeta.Numero &&
                usuario.RevisarSiLaTarjetaEsMia(nuevoNumeroTarjeta))
            {
                MessageBox.Show("Ya hay una tarjeta registrada con ese numero en el sistema");
            }
            else
            {
                try
                {
                    int codigoSeguridadAConvertir = Int32.Parse(codigoSeguridad);

                    this.tarjeta.Nombre = textBoxNombre.Text;
                    this.tarjeta.Tipo = textBoxTipo.Text;
                    this.tarjeta.Numero = textBoxNumeroTarjeta.Text;
                    this.tarjeta.CodigoSeguridad = codigoSeguridadAConvertir;
                    this.tarjeta.FechaVencimiento = dateTimePicker1.Value;
                    this.tarjeta.Categoria = categoria;
                    this.tarjeta.NotaOpcional = textBoxNotaOpcional.Text;

                    MessageBox.Show("Se modifico correctamente la tarjeta");

                    this.Close();
                    IrAInterfazTarjeta();
                }
                catch (TarjetaIncorrectaException)
                {
                    MessageBox.Show("DATOS ERRONEOS.Por faver recuerde que la Tarjeta " +
                                    "debe cumplir con el siguiente formato: " +
                                    "\n\n" +
                                    "> Nombre: Mínimo 3 y máximo 25 caracteres \n\n" +
                                    "> Tipo: Mínimo 3 y máximo 25 caracteres \n\n" +
                                    "> Número: Enteros de 16 dígitos\n\n" +
                                    "> Código: Enteros de 3 o 4 dígitos, si es American Express deben ser 4 sino 3\n\n" +
                                    "> Fecha: No vacía\n\n" +
                                    "> Nota: Como máximo 250 caracteress\n\n" +
                                    "> Categoría: Se selecciona de las disponibles en el sistema");
                }
                catch (System.FormatException)
                {
                    MessageBox.Show("El codigo de seguridad debe ser un numero de 3 o 4 digitos");
                }
            }
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
