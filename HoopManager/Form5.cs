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
{
    public partial class Form5 : Form
    {
        string connectionString = "Server=localhost;Database=gestion_basket;Uid=root;Pwd=;";

        public Form5()
        {
            InitializeComponent();
            mostrarDatos();
            MakeCircularButton(cerrarSeesion);
            MakeCircularButton(volver);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void MakeCircularButton(Control btn)
        {
            GraphicsPath path = new GraphicsPath();
            path.AddEllipse(0, 0, btn.Width, btn.Height);
            btn.Region = new Region(path);
        }

        //metodo de mostrar datos de la tabla
        private void mostrarDatos() {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();

                    string query = @"
                        SELECT 
                            j.nombre AS 'Jugador',
                            sh.temporada AS 'Temporada',
                            sh.puntos_media AS 'PTS',
                            sh.rebotes_media AS 'REB',
                            sh.asistencias_media AS 'AST',
                            sh.porcentaje_t3 AS '% T3'
                        FROM stats_historicas sh
                        JOIN jugadores j ON sh.id_jugador = j.id
                        ORDER BY j.nombre ASC, sh.temporada DESC";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);

                        dataGridView1.DataSource = dt;

                        dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                        dataGridView1.AllowUserToAddRows = false; 
                        dataGridView1.ReadOnly = true; 
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar las estadísticas: " + ex.Message);
            }
        }

        private void cerrarSeesion_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void volver_Click_1(object sender, EventArgs e)
        {
            coachorm2 coachForm = new coachorm2();
            coachForm.Show();
            this.Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form5_Load(object sender, EventArgs e)
        {

        }

        private void txtBusqueda_TextChanged(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = (DataTable)dataGridView1.DataSource;
                if (dt != null)
                {
                    // Fíjate en el Replace: busca UNA comilla simple y pone DOS
                    dt.DefaultView.RowFilter = string.Format("jugador LIKE '%{0}%'", txtBusqueda.Text.Replace("'", "''"));
                }
            }
            catch (Exception ex)
            {
                // Mientras programas, nunca dejes un catch vacío. Así si falla, te enteras.
                MessageBox.Show("Error al filtrar: " + ex.Message);
            }
        }
    }
}
