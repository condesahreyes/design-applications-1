﻿using OblDiseño1;
using OblDiseño1.Entidades;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Menu = InterfazGrafica.InterfacesMenu.Menu;

namespace InterfazGrafica.InterfazCompartirContraseñas
{
    public partial class InterfazContraseñasCompartidas : Form
    {
        private Sistema sistema;
        private Usuario usuario;
        public InterfazContraseñasCompartidas(ref Sistema sistema, ref Usuario usuario)
        {
            InitializeComponent();
            this.usuario = usuario;
            this.sistema = sistema;
            CargarContraseñasCompartidas();
            CargarContraseñasCompartidasConmigo();
        }

        private void CargarContraseñasCompartidas()
        {
            BindingSource biso = new BindingSource();
            GestorContraseniasCompartidas miGestor = usuario.GestorCompartirContrasenia;
            biso.DataSource = miGestor.ObtenerContraseniasCompartidasPorMi().Keys;

            if (miGestor.ObtenerContraseniasCompartidasPorMi().Count == 0)
            {
                this.dataGridContraseñasCompartidas.Visible = true;
            }
            else
            {
                this.dataGridContraseñasCompartidas.DataSource = biso;
                this.dataGridContraseñasCompartidas.Columns["TipoSitioOApp"].Visible = false;
                this.dataGridContraseñasCompartidas.Columns["Nota"].Visible = false;
                this.dataGridContraseñasCompartidas.Columns["NivelSeguridadContrasenia"].Visible = false;
                this.dataGridContraseñasCompartidas.Columns["DataBrench"].Visible = false;
            }
        }

        private void CargarContraseñasCompartidasConmigo()
        {
            BindingSource biso2 = new BindingSource();
            GestorContraseniasCompartidas miGestor = usuario.GestorCompartirContrasenia;
            List<Dupla_UsuarioContrasenia> listaDuplasCompartidasConmigo = new List<Dupla_UsuarioContrasenia>();

            foreach (var iterador in miGestor.ObtenerContraseniasCompartidasConmigo())
            {
                foreach (var iteradorAuxiliar in iterador.Value)
                    listaDuplasCompartidasConmigo.Add(iteradorAuxiliar);
            }

            biso2.DataSource = listaDuplasCompartidasConmigo;
            if (listaDuplasCompartidasConmigo.Count > 0)
            {
                this.dataGridContraseñasCompartidasConmigo.DataSource = biso2;
                this.dataGridContraseñasCompartidasConmigo.Columns["TipoSitioOApp"].Visible = false;
                this.dataGridContraseñasCompartidasConmigo.Columns["Nota"].Visible = false;
                this.dataGridContraseñasCompartidasConmigo.Columns["NivelSeguridadContrasenia"].Visible = false;
                this.dataGridContraseñasCompartidasConmigo.Columns["DataBrench"].Visible = false;
            }
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
            this.Close();
            InterfazCompartirContraseña interfazCompartirContraseña = new InterfazCompartirContraseña(ref sistema, ref usuario);
            interfazCompartirContraseña.Show();
        }

        private void buttonVolver_Click(object sender, EventArgs e)
        {
            this.Close();
            Menu menu = new Menu(ref sistema, ref usuario);
            menu.Show();
        }

        private void buttonVerUsuariosCompartidos_Click(object sender, EventArgs e)
        {
            GestorContraseniasCompartidas miGestor = usuario.GestorCompartirContrasenia;
            if (miGestor.ObtenerContraseniasCompartidasPorMi().Count == 0)
                MessageBox.Show("Error: No hay contraseñas compartidas aun");
            else
            {
                Dupla_UsuarioContrasenia duplaSeleccionada = (Dupla_UsuarioContrasenia)dataGridContraseñasCompartidas.CurrentRow.DataBoundItem;
                if (duplaSeleccionada == null)
                    MessageBox.Show("Error: debe seleccionar una contrasenia primero");
                else
                {
                    InterfazDejarDeCompartirContrasenia interfazDejarDeCompartirContrasenias = new InterfazDejarDeCompartirContrasenia(ref sistema, ref usuario, ref duplaSeleccionada);
                    this.Close();
                    interfazDejarDeCompartirContrasenias.Show();
                }
            }

        }
    }
}
