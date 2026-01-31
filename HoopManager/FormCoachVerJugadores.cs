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
        public FormCoachVerJugadores()
        {
            InitializeComponent();
            CargarJugadoresDelEquipo();
        }
        
        private void botonConsultas_Click(object sender, EventArgs e)
        {
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
                }
                catch
                {
                    MessageBox.Show("Error al seleccionar el jugador.");
                }
            }
        }



        private void CargarJugadoresDelEquipo()
        {
            string query = "SELECT nombre, posicion, altura_cm, dorsal FROM jugadores WHERE id_equipo = @id_equipo";
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
    }
}
