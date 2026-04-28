using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace HoopManager
{
    public partial class Form3 : Form
    { //puntuaciones
        string connectionString = "Server=localhost;Database=gestion_basket;Uid=root;Pwd=;";

        public Form3()
        {
            InitializeComponent();
            this.Load += Form3_Load;
            MakeCircularButton(cerrarSeesion);
            MakeCircularButton(volver);

        }

        private void Form3_Load(object sender, EventArgs e)
        {
            CargarClasificacion();
            ConfigurarDiseñoTabla();
        }

        private void CargarClasificacion()
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();

                    // Calculo la tabla sumando los partidos jugados
                    string sql = @"
                        SELECT 
                            e.nombre AS Equipo,
                            SUM(CASE 
                                WHEN p.jugado = 1 AND (
                                    (p.id_local = e.id AND p.puntos_local > p.puntos_visitante) OR 
                                    (p.id_visitante = e.id AND p.puntos_visitante > p.puntos_local)
                                ) THEN 1 ELSE 0 END) AS Victorias,
                            
                            SUM(CASE 
                                WHEN p.jugado = 1 AND (
                                    (p.id_local = e.id AND p.puntos_local < p.puntos_visitante) OR 
                                    (p.id_visitante = e.id AND p.puntos_visitante < p.puntos_local)
                                ) THEN 1 ELSE 0 END) AS Derrotas,

                            SUM(CASE 
                                WHEN p.id_local = e.id THEN p.puntos_local 
                                WHEN p.id_visitante = e.id THEN p.puntos_visitante 
                                ELSE 0 END) AS Puntos_a_Favor,

                            SUM(CASE 
                                WHEN p.id_local = e.id THEN p.puntos_visitante 
                                WHEN p.id_visitante = e.id THEN p.puntos_local 
                                ELSE 0 END) AS Punten_en_Contra,

                            SUM(CASE 
                                WHEN p.id_local = e.id THEN (p.puntos_local - p.puntos_visitante)
                                WHEN p.id_visitante = e.id THEN (p.puntos_visitante - p.puntos_local)
                                ELSE 0 END) AS Diferencia_de_puntos

                        FROM equipos e
                        LEFT JOIN partidos p ON (e.id = p.id_local OR e.id = p.id_visitante) AND p.jugado = 1
                        GROUP BY e.id, e.nombre
                        ORDER BY Victorias DESC, Diferencia_de_puntos DESC, Puntos_a_Favor DESC";

                    DataTable dt = new DataTable();
                    MySqlDataAdapter adapter = new MySqlDataAdapter(sql, conn);
                    adapter.Fill(dt);

                    dt.Columns.Add("Pos", typeof(int)).SetOrdinal(0);
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        dt.Rows[i]["Pos"] = i + 1;
                    }

                    tablaLiga.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar la clasificación: " + ex.Message);
            }
        }

        private void ConfigurarDiseñoTabla()
        {
            if (tablaLiga.Columns.Count > 0)
            {
                //bloque el ordenado
                foreach (DataGridViewColumn col in tablaLiga.Columns)
                {
                    col.SortMode = DataGridViewColumnSortMode.NotSortable;
                }


                tablaLiga.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                tablaLiga.Columns["Pos"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                tablaLiga.Columns["Victorias"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                tablaLiga.Columns["Derrotas"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                tablaLiga.Columns["Diferencia_de_puntos"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                tablaLiga.Columns["Pos"].Width = 40;

                if (tablaLiga.Rows.Count > 0)
                {
                    tablaLiga.Rows[0].DefaultCellStyle.BackColor = Color.LightGreen;
                    tablaLiga.Rows[0].DefaultCellStyle.Font = new Font(tablaLiga.Font, FontStyle.Bold);
                }
            }
        }

        private void tablaLiga_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }


        private void volver_Click_1(object sender, EventArgs e)
        {
            HoopManager.coachorm2 menuEntrenador = new HoopManager.coachorm2();
            menuEntrenador.Show();
            this.Close();
        }

        private void cerrarSesion_Click(object sender, EventArgs e)
        {
            //boton de cerrar aplicacion
            Application.Exit();
        }

        private void MakeCircularButton(Control btn)
        {
            GraphicsPath path = new GraphicsPath();
            path.AddEllipse(0, 0, btn.Width, btn.Height);
            btn.Region = new Region(path);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}