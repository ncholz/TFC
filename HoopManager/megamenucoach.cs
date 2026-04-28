using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace HoopManager
{
    public partial class megamenucoach : Form
    {
        private Form formularioActivo = null;
        private int idEquipoLogueado;
        public megamenucoach(int idEquipo)
        {
            this.idEquipoLogueado = idEquipo;
            this.FormBorderStyle = FormBorderStyle.None;
            InitializeComponent();
        }

        private void CargarLogoEquipo()
        {
            try
            {
                // Tu ruta específica del disco E
                string rutaCarpeta = @"E:\material usado en tfc\logos_equipos";
                // Construimos el nombre: "4.png" (por ejemplo)
                string nombreArchivo = idEquipoLogueado.ToString() + ".png";
                string rutaCompleta = Path.Combine(rutaCarpeta, nombreArchivo);

                if (File.Exists(rutaCompleta))
                {
                    // Cargamos la imagen en el pictureBox1
                    pictureBox1.Image = Image.FromFile(rutaCompleta);
                    pictureBox1.SizeMode = PictureBoxSizeMode.Zoom; // Para que encaje bien
                }
                else
                {
                    // Si no existe la foto, podrías poner una por defecto o dejarlo vacío
                    Console.WriteLine("No se encontró el logo en: " + rutaCompleta);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar el logo del equipo: " + ex.Message);
            }
        }

        private void megamenucoach_Load(object sender, EventArgs e)
        {
            // Llamamos a la función de la foto nada más cargar el menú
            CargarLogoEquipo();
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

        private void boton1_Click(object sender, EventArgs e)
        {
            AbrirPantallaHija(new Form3());
        }

        private void panel_lateral_Paint(object sender, PaintEventArgs e)
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


        private void abrir_boton_mi_plantilla(object sender, EventArgs e)
        {
            AbrirPantallaHija(new FormCoachVerJugadores());
        }

        private void abrir_boton_pizarra(object sender, EventArgs e)
        {
            AbrirPantallaHija(new FormPizarra());
            
        }

        private void abrir_boton_ver_partidos(object sender, EventArgs e)
        {
            AbrirPantallaHija(new Form4());
        }

        private void abrir_boton_clasificacion(object sender, EventArgs e)
        {
            AbrirPantallaHija(new Form3());
        }

        private void abrir_boton_ojear(object sender, EventArgs e)
        {
            AbrirPantallaHija(new Form5());
        }

        private void abrir_boton_estadisticas_liga(object sender, EventArgs e)
        {
            AbrirPantallaHija(new Form6());
        }

        private void panel8_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel_contenedor_Paint(object sender, PaintEventArgs e)
        {

        }


        private void pictureBox1_Click(object sender, EventArgs e)
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
    }


}
