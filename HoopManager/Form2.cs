using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq; 
using System.Windows.Forms;

namespace HoopManager
{
    public partial class Form2 : Form
    {
        string connectionString = "Server=localhost;Database=gestion_basket;Uid=root;Pwd=;";

        private int _idJugador;

        public Form2(int idJugador)
        {
            InitializeComponent();
            _idJugador = idJugador;
            this.FormBorderStyle = FormBorderStyle.None;
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            CargarNombreJugador();
            AnalizarYRecomendar();
            MakeCircularButton(cerrarSeesion);
            MakeCircularButton(altoButton1);
        }

        private void CargarNombreJugador()
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    string sql = "SELECT nombre FROM jugadores WHERE id = @id";
                    using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", _idJugador);
                        object result = cmd.ExecuteScalar();

                        if (result != null)
                            bienvenida.Text = "Entrenamientos recomendados para: " + result.ToString();
                        else
                            bienvenida.Text = "Jugador no encontrado";
                    }
                }
            }
            catch { bienvenida.Text = "Error al cargar nombre"; }
        }

        private void AnalizarYRecomendar()
        {
            double porcentajeTriples = 0;
            double mediaPerdidas = 0;
            double porcentajeTirosLibres = 0;
            bool hayDatos = false;

            string sqlStats = @"
                SELECT 
                    IFNULL(SUM(t3_metidos), 0) as T3_In, 
                    IFNULL(SUM(t3_intentados), 0) as T3_Out,
                    IFNULL(SUM(tl_metidos), 0) as TL_In,
                    IFNULL(SUM(tl_intentados), 0) as TL_Out,
                    IFNULL(AVG(perdidas), 0) as MediaPerdidas
                FROM stats_partidos 
                WHERE id_jugador = @id 
                ORDER BY fecha DESC 
                LIMIT 4";

            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    using (MySqlCommand cmd = new MySqlCommand(sqlStats, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", _idJugador);
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                double t3Met = Convert.ToDouble(reader["T3_In"]);
                                double t3Int = Convert.ToDouble(reader["T3_Out"]);
                                if (t3Int > 0) porcentajeTriples = (t3Met / t3Int) * 100;

                                mediaPerdidas = Convert.ToDouble(reader["MediaPerdidas"]);

                                double tlMet = Convert.ToDouble(reader["TL_In"]);
                                double tlInt = Convert.ToDouble(reader["TL_Out"]);
                                if (tlInt > 0) porcentajeTirosLibres = (tlMet / tlInt) * 100;

                                if (t3Int > 0 || tlInt > 0 || mediaPerdidas > 0) hayDatos = true;
                            }
                        }
                    }
                }

                List<string> tiposDetectados = new List<string>();
                string mensajeAlerta = "Áreas a mejorar:\n";

                if (!hayDatos)
                {
                    tiposDetectados.Add("'TACTICA_DEFENSA'");
                    bienvenida.Text += " (Sin datos - Plan Táctico Asignado)";
                }
                else
                {
                    if (porcentajeTriples < 50)
                    {
                        tiposDetectados.Add("'MEJORA_TRIPLES'");
                        mensajeAlerta += $"- % Triples bajo ({porcentajeTriples:F1}%)\n";
                    }

                    if (mediaPerdidas > 3)
                    {
                        tiposDetectados.Add("'TRANSICION'");
                        mensajeAlerta += $"- Muchas pérdidas ({mediaPerdidas:F1} pp)\n";
                    }

                    if (porcentajeTirosLibres > 0 && porcentajeTirosLibres < 60)
                    {
                        tiposDetectados.Add("'MEJORA_TIRO'");
                        mensajeAlerta += $"- Fallo en Tiros Libres ({porcentajeTirosLibres:F1}%)\n";
                    }
                }

                if (tiposDetectados.Count > 0)
                {
                    tablaEntrenamientos.Visible = true;
                    if (hayDatos) MessageBox.Show(mensajeAlerta);

                    CargarGridConEjercicios(tiposDetectados);
                }
                else
                {
                    tablaEntrenamientos.Visible = false;
                    bienvenida.Text = "JUGADOR EN ESTADO ÓPTIMO";
                    bienvenida.ForeColor = Color.Green;
                    MessageBox.Show("Este jugador no requiere entrenamiento específico.\n\nRecomendación: Seguir con entrenamiento habitual.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al analizar stats: " + ex.Message);
            }
        }
        private void CargarGridConEjercicios(List<string> listaTipos)
        {
            try
            {
                DataTable tabla = new DataTable();

                string tiposParaSQL = string.Join(",", listaTipos);

                string query = $"SELECT nombre AS Ejercicio, descripcion AS Instrucciones, tipo AS Categoria FROM entrenamientos WHERE tipo IN ({tiposParaSQL})";

                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        using (MySqlDataAdapter adapter = new MySqlDataAdapter(cmd))
                        {
                            adapter.Fill(tabla);
                        }
                    }
                }

                tablaEntrenamientos.DataSource = null;
                tablaEntrenamientos.Columns.Clear();

                tablaEntrenamientos.DataSource = tabla;
                tablaEntrenamientos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error cargando ejercicios: " + ex.Message);
            }
        }

        private void tablaEntrenamientos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void volver_Click(object sender, EventArgs e)
        {
            FormCoachVerJugadores verJugadoresForm = new FormCoachVerJugadores();
            verJugadoresForm.Show();
            this.Close();
        }

        private void cerrarSeesion_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void altoButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void MakeCircularButton(Control btn)
        {
            GraphicsPath path = new GraphicsPath();
            path.AddEllipse(0, 0, btn.Width, btn.Height);
            btn.Region = new Region(path);
        }

        private void cerrar_ventana(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}