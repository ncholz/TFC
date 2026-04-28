using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace HoopManager
{
    public partial class Form11 : Form
    {
        // --- VARIABLES GLOBALES ---
        string connection = "Server=localhost;Database=gestion_basket;Uid=root;Pwd=;";
        int idSel = 0;
        string temporadaCargada = ""; // <--- NUEVA MEMORIA: Recuerda el año original

        public Form11()
        {
            InitializeComponent();
            CargarJugadores();
            CargarStats();
            LimpiarFormulario();
        }

        // --- 1. CARGA DE DATOS ---

        private void CargarJugadores()
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connection))
                {
                    MySqlDataAdapter da = new MySqlDataAdapter("SELECT id, nombre FROM jugadores ORDER BY nombre ASC", conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    cmbJugador.DataSource = dt;
                    cmbJugador.DisplayMember = "nombre";
                    cmbJugador.ValueMember = "id";
                    cmbJugador.SelectedIndex = -1;
                }
            }
            catch (Exception ex) { MessageBox.Show("Error al cargar jugadores: " + ex.Message); }
        }

        private void CargarStats()
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connection))
                {
                    string sql = @"SELECT s.id, j.nombre AS Jugador, s.temporada, s.puntos_media, 
                                   s.rebotes_media, s.asistencias_media, s.porcentaje_t3, s.id_jugador
                                   FROM stats_historicas s 
                                   JOIN jugadores j ON s.id_jugador = j.id";
                    MySqlDataAdapter da = new MySqlDataAdapter(sql, conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dgvStatsHistoricas.DataSource = dt;

                    if (dgvStatsHistoricas.Columns["id"] != null) dgvStatsHistoricas.Columns["id"].Visible = false;
                    if (dgvStatsHistoricas.Columns["id_jugador"] != null) dgvStatsHistoricas.Columns["id_jugador"].Visible = false;
                }
            }
            catch (Exception ex) { MessageBox.Show("Error al cargar estadísticas: " + ex.Message); }
        }

        // --- 2. EL BOTÓN GUARDAR "INTELIGENTE" ---

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (cmbJugador.SelectedValue == null || string.IsNullOrWhiteSpace(txtTemporada.Text))
            {
                MessageBox.Show("Faltan datos. Selecciona un jugador y escribe la temporada.");
                return;
            }

            // 🧠 MAGIA DE AUTODETECCIÓN:
            // Si teníamos un registro cargado (idSel != 0) pero el texto de la temporada 
            // ya no coincide con la que cargamos, asumimos que quieres crear el año siguiente.
            if (idSel != 0 && txtTemporada.Text.Trim() != temporadaCargada)
            {
                idSel = 0; // Cortamos el cable: ahora se comportará como un INSERT nuevo.
            }

            try
            {
                using (MySqlConnection conn = new MySqlConnection(connection))
                {
                    conn.Open();

                    // COMPROBACIÓN ANTI-DUPLICADOS
                    string sqlCheck = "SELECT COUNT(*) FROM stats_historicas WHERE id_jugador = @j AND temporada = @t AND id != @id";
                    MySqlCommand cmdCheck = new MySqlCommand(sqlCheck, conn);
                    cmdCheck.Parameters.AddWithValue("@j", cmbJugador.SelectedValue);
                    cmdCheck.Parameters.AddWithValue("@t", txtTemporada.Text);
                    cmdCheck.Parameters.AddWithValue("@id", idSel);

                    if (Convert.ToInt32(cmdCheck.ExecuteScalar()) > 0)
                    {
                        MessageBox.Show("¡Ojo! Ya tienes guardada la temporada " + txtTemporada.Text + " para este jugador.");
                        return;
                    }

                    // GUARDAR O ACTUALIZAR
                    string sql = (idSel == 0)
                        ? "INSERT INTO stats_historicas (id_jugador, temporada, puntos_media, rebotes_media, asistencias_media, porcentaje_t3) VALUES (@j, @t, @p, @r, @a, @t3)"
                        : "UPDATE stats_historicas SET id_jugador=@j, temporada=@t, puntos_media=@p, rebotes_media=@r, asistencias_media=@a, porcentaje_t3=@t3 WHERE id=@id";

                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@j", cmbJugador.SelectedValue);
                    cmd.Parameters.AddWithValue("@t", txtTemporada.Text);
                    cmd.Parameters.AddWithValue("@p", numPuntos.Value);
                    cmd.Parameters.AddWithValue("@r", numRebotes.Value);
                    cmd.Parameters.AddWithValue("@a", numAsistencias.Value);
                    cmd.Parameters.AddWithValue("@t3", numTriple.Value);

                    if (idSel != 0) cmd.Parameters.AddWithValue("@id", idSel);

                    cmd.ExecuteNonQuery();
                    MessageBox.Show(idSel == 0 ? "¡Nueva temporada registrada!" : "¡Datos actualizados!");

                    LimpiarFormulario();
                }
            }
            catch (Exception ex) { MessageBox.Show("Error al guardar: " + ex.Message); }
        }

        // --- 3. OTROS BOTONES ---

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (idSel == 0) return;

            if (MessageBox.Show("¿Borrar esta estadística?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                try
                {
                    using (MySqlConnection conn = new MySqlConnection(connection))
                    {
                        conn.Open();
                        new MySqlCommand("DELETE FROM stats_historicas WHERE id = " + idSel, conn).ExecuteNonQuery();
                    }
                    LimpiarFormulario();
                }
                catch (Exception ex) { MessageBox.Show("Error al eliminar: " + ex.Message); }
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarFormulario();
        }

        // --- 4. SELECCIÓN EN LA TABLA ---

        private void dgvStatsHistoricas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow fila = dgvStatsHistoricas.Rows[e.RowIndex];

                // --> EL PARCHE: Si es la fila vacía del final o no hay ID, salimos <--
                if (fila.IsNewRow || fila.Cells["id"].Value == DBNull.Value)
                {
                    return;
                }

                idSel = Convert.ToInt32(fila.Cells["id"].Value);

                cmbJugador.SelectedValue = fila.Cells["id_jugador"].Value;

                txtTemporada.Text = fila.Cells["temporada"].Value.ToString();
                temporadaCargada = txtTemporada.Text;

                numPuntos.Value = Convert.ToDecimal(fila.Cells["puntos_media"].Value);
                numRebotes.Value = Convert.ToDecimal(fila.Cells["rebotes_media"].Value);
                numAsistencias.Value = Convert.ToDecimal(fila.Cells["asistencias_media"].Value);
                numTriple.Value = Convert.ToDecimal(fila.Cells["porcentaje_t3"].Value);

            }
        }

        // --- 5. AYUDANTES ---

        private void LimpiarFormulario()
        {
            idSel = 0;
            temporadaCargada = ""; // Limpiamos la memoria

            cmbJugador.SelectedIndex = -1;
            txtTemporada.Clear();
            numPuntos.Value = 0;
            numRebotes.Value = 0;
            numAsistencias.Value = 0;
            numTriple.Value = 0;

            CargarStats();
        }

        // --- 6. EVENTOS VACÍOS ---
        private void Form11_Load(object sender, EventArgs e) { }
        private void txtTemporada_TextChanged(object sender, EventArgs e) { }
        private void cmbJugador_SelectedIndexChanged(object sender, EventArgs e) { }
        private void numPuntos_ValueChanged(object sender, EventArgs e) { }
        private void numRebotes_ValueChanged(object sender, EventArgs e) { }
        private void numAsistencias_ValueChanged(object sender, EventArgs e) { }
        private void numTriple_ValueChanged(object sender, EventArgs e) { }
        private void dgvStatsHistoricas_CellContentClick(object sender, DataGridViewCellEventArgs e) { }

        

        private void txtBusqueda_TextChanged_1(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = (DataTable)dgvStatsHistoricas.DataSource;
                if (dt != null)
                {
                    // Fíjate que he cambiado 'j.nombre' por 'Jugador' que es el nombre de la columna en la tabla visual
                    dt.DefaultView.RowFilter = string.Format("Jugador LIKE '%{0}%'", txtBusqueda.Text.Replace("'", "''"));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al filtrar: " + ex.Message);
            }
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }
    }
}