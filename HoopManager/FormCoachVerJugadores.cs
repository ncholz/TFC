using MySql.Data.MySqlClient;
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

    public partial class FormCoachVerJugadores : Form
    {
        String conectionString = "Server=localhost;Database=gestion_basket;Uid=root;Pwd=;";
        private int _idJugadroSeleccionado = -1;
        public FormCoachVerJugadores()
        {
            InitializeComponent();
            CargarJugadoresDelEquipo();
        }
        

        private void tablaJugadores_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                try
                {
                    DataGridViewRow fila = tablaJugadores.Rows[e.RowIndex];
                    name.Text = fila.Cells["nombre"].Value.ToString();
                    position.Text = fila.Cells["posicion"].Value.ToString();
                    height.Text = fila.Cells["altura_cm"].Value.ToString();
                    dorsal.Text = fila.Cells["dorsal"].Value.ToString();

                    if (fila.Cells["id"].Value != null)
                    {
                        _idJugadroSeleccionado = Convert.ToInt32(fila.Cells["id"].Value);
                    }
                }
                catch
                {
                    MessageBox.Show("Error al seleccionar el jugador.");
                }
            }
        }



        private void CargarJugadoresDelEquipo()
        {
            string query = "SELECT id, nombre, posicion, altura_cm, dorsal FROM jugadores WHERE id_equipo = @id_equipo AND activo = TRUE";
            DataTable tablaJug = new DataTable();

            try
            {
                using (MySqlConnection connection = new MySqlConnection(conectionString))
                {
                    connection.Open();
                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@id_equipo", SesionUsuario.IdEquipoEntrenador);
                        using (MySqlDataAdapter adapter = new MySqlDataAdapter(command))
                        {
                            adapter.Fill(tablaJug);
                        }
                    }
                }
                tablaJugadores.DataSource = tablaJug;
                tablaJugadores.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                if (tablaJug.Columns["id"] != null)
                {
                    tablaJugadores.Columns["id"].Visible = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los jugadores: " + ex.Message);
            }
        }


        private void id_TextChanged(object sender, EventArgs e)
        {

        }

        private void name_TextChanged(object sender, EventArgs e)
        {

        }

        private void position_TextChanged(object sender, EventArgs e)
        {

        }

        private void height_TextChanged(object sender, EventArgs e)
        {

        }

        private void dorsal_TextChanged(object sender, EventArgs e)
        {

        }

        private void limpiarCampos_Click(object sender, EventArgs e)
        {
            name.Text = "";
            position.Text = "";
            height.Text = "";
            dorsal.Text = "";
        }

        private void altoButton1_Click(object sender, EventArgs e)
        {
            if (_idJugadroSeleccionado != -1)
            {
                Form2 formEntreno = new Form2(_idJugadroSeleccionado);
                formEntreno.ShowDialog();
            }
            else
            {
                MessageBox.Show("Por favor, selecciona primero un jugador de la lista.");
            }
        }

        private void volver_Click(object sender, EventArgs e)
        {
            
        }

        private void cerrarSeesion_Click(object sender, EventArgs e)
        {
            //al darle se cierra la app
            Application.Exit();
        }

        private void volver_Click_1(object sender, EventArgs e)
        {
            // Al hacer click en volver, volvemos a la pantalla de menu coach
            coachorm2 menuCoach = new coachorm2();
            menuCoach.Show();
            this.Close();
        }

        private void cerrarSeesion_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void FormCoachVerJugadores_Load(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}
