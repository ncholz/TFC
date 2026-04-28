using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HoopManager
{
    public partial class Form8 : Form
    {
        private Form formularioActivo = null;

        public Form8()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
        }

        private void panel_contenedor_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void CambiarColor_MouseEnter(object sender, EventArgs e)
        {
            if (sender is Control control)
            {
                control.ForeColor = Color.DarkOrange;
            }
        }

        private void CambiarColor_MouseLeave(object sender, EventArgs e)
        {
            if (sender is Control control)
            {
                control.ForeColor = Color.FromArgb(80, 80, 80);
            }
        }

        private void AbrirPantallaHija(Form nuevoFormulario)
        {
            // Si ya hay una pantalla abierta, la cerramos para limpiar memoria
            if (formularioActivo != null)
            {
                formularioActivo.Close();
            }

            formularioActivo = nuevoFormulario;

            // Configuramos el formulario para que se porte como un panel
            nuevoFormulario.TopLevel = false;
            nuevoFormulario.FormBorderStyle = FormBorderStyle.None;
            nuevoFormulario.Dock = DockStyle.Fill;

            // Lo metemos en el panel derecho y lo mostramos
            panel_contenedor.Controls.Add(nuevoFormulario);
            panel_contenedor.Tag = nuevoFormulario;
            nuevoFormulario.BringToFront();
            nuevoFormulario.Show();
        }

        private void abrir_boton_credenciales(object sender, EventArgs e)
        {
            AbrirPantallaHija(new Form9());
        }

        private void abrir_boton_crear_jugadores(object sender, EventArgs e)
        {
            AbrirPantallaHija(new Form10());
        }

        private void abrir_boton_crear_stats_historicas(object sender, EventArgs e)
        {
            AbrirPantallaHija(new Form11());
        }

        private void abrir_boton_crear_partidos(object sender, EventArgs e)
        {
            AbrirPantallaHija(new Form12());
        }

        private void volver_Click(object sender, EventArgs e)
        {

        }
        private void salir_imagen(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void atras_imagen(object sender, EventArgs e)
        {
            login login = new login();
            login.Show();
            this.Close();
        }
    }
}
