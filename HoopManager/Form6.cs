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
    public partial class Form6 : Form
    {
        string connectionString = "Server=localhost;Database=gestion_basket;Uid=root;Pwd=;";
        public Form6()
        {
            
            this.WindowState = FormWindowState.Maximized; //poner mejor desde las propiedades cuando vaya
            InitializeComponent();
            MakeCircularButton(cerrarSeesion);
            MakeCircularButton(volver);
            muestraDatosGenerales();

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void volver_Click(object sender, EventArgs e)
        {
            coachorm2 coachForm = new coachorm2();
            coachForm.Show();
            this.Close();
        }

        private void cerrarSeesion_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void muestraDatosGenerales()
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();

                    string query = @"
                SELECT 
                    j.nombre AS 'Jugador',
                    e.nombre AS 'Equipo',
                    COUNT(sp.id) AS 'PJ',
                    ROUND(AVG(sp.puntos), 1) AS 'PPP',
                    ROUND(AVG(sp.reb_ofensivos + sp.reb_defensivos), 1) AS 'RPP',
                    ROUND(AVG(sp.asistencias), 1) AS 'APP',
                    ROUND(AVG(sp.valoracion), 1) AS 'VAL'
                FROM stats_partidos sp
                JOIN jugadores j ON sp.id_jugador = j.id
                JOIN equipos e ON j.id_equipo = e.id
                GROUP BY j.id, j.nombre, e.nombre
                ORDER BY AVG(sp.puntos) DESC";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);

                        dataGridView1.DataSource = dt;

                        dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                        dataGridView1.AllowUserToAddRows = false;
                        dataGridView1.ReadOnly = true;
                        dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar las estadísticas generales: " + ex.Message);
            }
        }

        private void MakeCircularButton(Control btn)
        {
            GraphicsPath path = new GraphicsPath();
            path.AddEllipse(0, 0, btn.Width, btn.Height);
            btn.Region = new Region(path);
        }

        private void Form6_Load(object sender, EventArgs e)
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
