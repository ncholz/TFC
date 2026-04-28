using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HoopManager
{ //partidos
    public partial class Form4 : Form
    {
        string connectionString = "Server=localhost;Database=gestion_basket;Uid=root;Pwd=;";

        public Form4()
        {
            InitializeComponent();
            CargarPartidosJugados();
            MakeCircularButton(cerrarSeesion);
            MakeCircularButton(volver);
        }

        private void volver_Click(object sender, EventArgs e)
        {
            coachorm2 coachorm2 = new coachorm2();
            coachorm2.Show();
            this.Close();

        }

        private void cerrarSeesion_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void tabla_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void MakeCircularButton(Control btn)
        {
            GraphicsPath path = new GraphicsPath();
            path.AddEllipse(0, 0, btn.Width, btn.Height);
            btn.Region = new Region(path);
        }

        //metodo para cargar la tabla con los datos de la base de datos
        private void CargarPartidosJugados()
        {
            if (SesionUsuario.IdEquipoEntrenador == 0)
            {
                MessageBox.Show("No se ha detectado el equipo. Por favor, inicia sesión de nuevo.");
                return;
            }

            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();

                    string query = @"
                        SELECT 
                            p.fecha AS 'Fecha',
                            el.nombre AS 'Local',
                            p.puntos_local AS 'Pts Local',
                            p.puntos_visitante AS 'Pts Visitante',
                            ev.nombre AS 'Visitante'
                        FROM partidos p
                        JOIN equipos el ON p.id_local = el.id
                        JOIN equipos ev ON p.id_visitante = ev.id
                        WHERE p.jugado = 1 
                        AND (p.id_local = @idUsuario OR p.id_visitante = @idUsuario)
                        ORDER BY p.fecha DESC";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@idUsuario", SesionUsuario.IdEquipoEntrenador);

                        MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);

                        tabla.DataSource = dt;

                        tabla.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                        tabla.AllowUserToAddRows = false;
                        tabla.ReadOnly = true;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los partidos: " + ex.Message);
            }
        }
    }
}
