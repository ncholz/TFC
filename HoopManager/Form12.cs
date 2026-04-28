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
    public partial class Form12 : Form
    {
        // --- VARIABLES GLOBALES ---
        string connection = "Server=localhost;Database=gestion_basket;Uid=root;Pwd=;";
        int idSel = 0; // 0 = Crear un partido nuevo | >0 = Actualizar un partido existente

        public Form12()
        {
            InitializeComponent();
            CargarEquipos();
            CargarPartidos();
            LimpiarFormulario();
        }

        // --- 1. CARGA DE DATOS ---

        private void CargarEquipos()
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connection))
                {
                    string sql = "SELECT id, nombre FROM equipos ORDER BY nombre ASC";
                    MySqlDataAdapter da = new MySqlDataAdapter(sql, conn);

                    DataTable dtL = new DataTable();
                    da.Fill(dtL);
                    cmbLocal.DataSource = dtL;
                    cmbLocal.DisplayMember = "nombre";
                    cmbLocal.ValueMember = "id";
                    cmbLocal.SelectedIndex = -1;

                    DataTable dtV = new DataTable();
                    da.Fill(dtV);
                    cmbVisitante.DataSource = dtV;
                    cmbVisitante.DisplayMember = "nombre";
                    cmbVisitante.ValueMember = "id";
                    cmbVisitante.SelectedIndex = -1;
                }
            }
            catch (Exception ex) { MessageBox.Show("Error al cargar equipos: " + ex.Message); }
        }

        private void CargarPartidos()
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connection))
                {
                    string sql = @"SELECT p.id, p.jornada, p.fecha, 
                                   el.nombre AS Local, p.puntos_local AS Pts_L, 
                                   ev.nombre AS Visitante, p.puntos_visitante AS Pts_V, 
                                   p.id_local, p.id_visitante 
                                   FROM partidos p 
                                   JOIN equipos el ON p.id_local = el.id 
                                   JOIN equipos ev ON p.id_visitante = ev.id 
                                   ORDER BY p.jornada DESC, p.fecha DESC";

                    MySqlDataAdapter da = new MySqlDataAdapter(sql, conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    dgvPartidos.DataSource = dt;

                    if (dgvPartidos.Columns["id"] != null) dgvPartidos.Columns["id"].Visible = false;
                    if (dgvPartidos.Columns["id_local"] != null) dgvPartidos.Columns["id_local"].Visible = false;
                    if (dgvPartidos.Columns["id_visitante"] != null) dgvPartidos.Columns["id_visitante"].Visible = false;
                }
            }
            catch (Exception ex) { MessageBox.Show("Error al cargar la lista de partidos: " + ex.Message); }
        }

        // --- 2. VALIDACIÓN DE CALENDARIO ---

        // Verifica si el equipo ya juega en esa jornada (ignora el partido actual si estamos editándolo)
        private bool EquipoOcupado(int idEquipo, int numJornada, int idPartidoIgnorar)
        {
            using (MySqlConnection conn = new MySqlConnection(connection))
            {
                conn.Open();
                string sql = "SELECT COUNT(*) FROM partidos WHERE jornada = @jor AND (id_local = @id OR id_visitante = @id) AND id != @idIgnorar";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@jor", numJornada);
                cmd.Parameters.AddWithValue("@id", idEquipo);
                cmd.Parameters.AddWithValue("@idIgnorar", idPartidoIgnorar);

                return Convert.ToInt32(cmd.ExecuteScalar()) > 0;
            }
        }

        // --- 3. SELECCIÓN EN LA TABLA Y AYUDANTES ---

        private void dgvPartidos_CellContentClickk(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow fila = dgvPartidos.Rows[e.RowIndex];

                idSel = Convert.ToInt32(fila.Cells["id"].Value);

                numJornada.Value = Convert.ToDouble(fila.Cells["jornada"].Value);
                dtpFecha.Value = Convert.ToDateTime(fila.Cells["fecha"].Value);

                cmbLocal.SelectedValue = fila.Cells["id_local"].Value;
                cmbVisitante.SelectedValue = fila.Cells["id_visitante"].Value;

                btnGuardar.Text = "";
                btnEliminar.Enabled = true;

                // ¡LA CLAVE! Bloqueamos los desplegables para que no se pueda cambiar al rival
                cmbLocal.Enabled = false;
                cmbVisitante.Enabled = false;
            }
        }

        private void LimpiarFormulario()
        {
            idSel = 0;
            btnGuardar.Text = "";
            numJornada.Value = 1;
            dtpFecha.Value = DateTime.Now;
            cmbLocal.SelectedIndex = -1;
            cmbVisitante.SelectedIndex = -1;

            // Volvemos a habilitar los desplegables para poder crear nuevos partidos
            cmbLocal.Enabled = true;
            cmbVisitante.Enabled = true;
            btnEliminar.Enabled = false; // Desactivar si no hay nada seleccionado

            CargarPartidos();
        }

        // --- 4. ACCIONES DE BOTONES ---

        private void btnGuardar_Click_1(object sender, EventArgs e)
        {
            if (cmbLocal.SelectedValue == null || cmbVisitante.SelectedValue == null)
            {
                MessageBox.Show("Debes seleccionar ambos equipos.", "Faltan datos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int local = Convert.ToInt32(cmbLocal.SelectedValue);
            int visitante = Convert.ToInt32(cmbVisitante.SelectedValue);
            int jornada = (int)numJornada.Value;

            if (local == visitante)
            {
                MessageBox.Show("Un equipo no puede jugar contra sí mismo.", "Error de lógica", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // NUEVA VALIDACIÓN: ¿Ya tienen partido en esta jornada? (Pasamos idSel por si estamos editando la fecha de un partido)
            if (EquipoOcupado(local, jornada, idSel) || EquipoOcupado(visitante, jornada, idSel))
            {
                MessageBox.Show($"¡Error! Uno de los equipos ya tiene asignado un partido en la Jornada {jornada}.", "Conflicto de Calendario", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }

            try
            {
                using (MySqlConnection conn = new MySqlConnection(connection))
                {
                    conn.Open();

                    // Si idSel > 0 (Editar), SOLO actualizamos la Jornada y la Fecha. El rival NO se toca.
                    string sql = (idSel == 0)
                        ? "INSERT INTO partidos (jornada, fecha, id_local, id_visitante, puntos_local, puntos_visitante, jugado) VALUES (@jor, @fec, @loc, @vis, 0, 0, 0)"
                        : "UPDATE partidos SET puntos_local = @pl, puntos_visitante = @pv, jugado = 1 WHERE id = @id";

                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@jor", jornada);
                    cmd.Parameters.AddWithValue("@fec", dtpFecha.Value.ToString("yyyy-MM-dd"));

                    if (idSel == 0)
                    {
                        cmd.Parameters.AddWithValue("@loc", local);
                        cmd.Parameters.AddWithValue("@vis", visitante);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@id", idSel);
                    }

                    cmd.ExecuteNonQuery();

                    MessageBox.Show(idSel == 0 ? "¡Partido programado con éxito!" : "¡Datos del partido actualizados!");
                    LimpiarFormulario();
                }
            }
            catch (Exception ex) { MessageBox.Show("Error al guardar: " + ex.Message); }
        }

        private void btnEliminar_Click_1(object sender, EventArgs e)
        {
            if (idSel == 0) return;

            if (MessageBox.Show("¿Borrar este partido? Se perderán todas las estadísticas de los jugadores de este encuentro.", "Confirmación crítica", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                try
                {
                    using (MySqlConnection conn = new MySqlConnection(connection))
                    {
                        conn.Open();
                        new MySqlCommand("DELETE FROM partidos WHERE id = " + idSel, conn).ExecuteNonQuery();
                    }
                    LimpiarFormulario();
                    MessageBox.Show("Partido eliminado.");
                }
                catch (Exception ex) { MessageBox.Show("Error al eliminar: " + ex.Message); }
            }
        }

        private void btnLimpiar_Click_1(object sender, EventArgs e)
        {
            LimpiarFormulario();
        }

        // --- 5. ABRIR GESTIÓN DE ESTADÍSTICAS (Actualizado para solucionar fallos) ---
        private void btnGestionarStats_Click_1(object sender, EventArgs e)
        {
            if (idSel == 0)
            {
                MessageBox.Show("Primero selecciona un partido de la lista haciendo clic sobre él.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            Form13 frmStats = new Form13(idSel);
            frmStats.TopLevel = false;
            frmStats.FormBorderStyle = FormBorderStyle.None;
            frmStats.Dock = DockStyle.Fill;

            // EVENTO AUTOMÁTICO: Cuando se cierre el Form13, recargamos la tabla para ver el marcador nuevo
            frmStats.FormClosed += (s, args) =>
            {
                CargarPartidos();
                this.Show();
            };

            // Buscamos el panel padre de este formulario
            Panel panelPadre = this.Parent as Panel;

            if (panelPadre != null)
            {
                this.Hide();
                panelPadre.Controls.Add(frmStats);
                frmStats.BringToFront();
                frmStats.Show();
            }
            else
            {
                // Si abres el form suelto para probar
                frmStats.TopLevel = true;
                frmStats.ShowDialog();
                CargarPartidos();
            }
        }

        // --- EVENTOS VACÍOS DEL DISEÑADOR ---
        private void cmbLocal_SelectedIndexChanged(object sender, EventArgs e) { }
        private void cmbVisitante_SelectedIndexChanged(object sender, EventArgs e) { }
        private void dtpFecha_ValueChanged(object sender, EventArgs e) { }
        private void dgvPartidos_CellContentClick_1(object sender, DataGridViewCellEventArgs e) { }
        private void numJornada_Click(object sender, EventArgs e) { }
        private void Form12_Load(object sender, EventArgs e) { }
    }
}