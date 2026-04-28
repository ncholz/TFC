using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace HoopManager
{
    public partial class Form13 : Form
    {
        // --- CONTROL DE INSTANCIA ÚNICA (AQUÍ ESTÁ LA MAGIA) ---
        private static Form13 instanciaUnica = null;

        public static void Abrir(int idPartido)
        {
            if (instanciaUnica == null || instanciaUnica.IsDisposed)
            {
                instanciaUnica = new Form13(idPartido);
                instanciaUnica.Show();
            }
            else
            {
                instanciaUnica.BringToFront(); // Si ya está abierta, la trae al frente
            }
        }

        // --- CONFIGURACIÓN ---
        string connection = "Server=localhost;Database=gestion_basket;Uid=root;Pwd=;";
        int idPartidoActual;
        int idLocal, idVisitante;
        string nombreLocal, nombreVisitante;
        int idStatSeleccionada = 0; // Para saber qué fila de la tabla stats_partidos borrar

        public Form13(int idPartido)
        {
            InitializeComponent();
            this.idPartidoActual = idPartido;

            this.FormBorderStyle = FormBorderStyle.None;

            ObtenerDatosDelPartido(); // Trae IDs y Nombres
            ConfigurarFiltroEquipos(); // Pone nombres a los RadioButtons
            CargarJugadoresFiltrados(); // Carga la primera lista (locales)
            RefrescarPantalla();
        }

        // --- MOTOR DE CÁLCULO ---

        private void CalcularTodo()
        {
            // Calculamos puntos para la valoración (aunque no haya numPuntos)
            decimal ptsJugador = (numT2M.Value * 2) + (numT3M.Value * 3) + (numTLM.Value * 1);

            decimal positivos = ptsJugador + numRebO.Value + numRebD.Value + numAsistencias.Value + numRobos.Value + numTapones.Value;

            // Usamos Math.Max para evitar problemas si los valores son negativos
            decimal fallosT2 = Math.Max(0, numT2I.Value - numT2M.Value);
            decimal fallosT3 = Math.Max(0, numT3I.Value - numT3M.Value);
            decimal fallosTL = Math.Max(0, numTLI.Value - numTLM.Value);

            decimal negativas = fallosT2 + fallosT3 + fallosTL + numPerdidas.Value + numFaltas.Value;

            numValoracion.Value = positivos - negativas;
        }

        // --- LÓGICA DE BASE DE DATOS ---

        private void ObtenerDatosDelPartido()
        {
            using (MySqlConnection conn = new MySqlConnection(connection))
            {
                string sql = @"SELECT p.id_local, p.id_visitante, el.nombre AS local, ev.nombre AS visitante 
                               FROM partidos p 
                               JOIN equipos el ON p.id_local = el.id 
                               JOIN equipos ev ON p.id_visitante = ev.id 
                               WHERE p.id = @id";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@id", idPartidoActual);
                conn.Open();

                using (MySqlDataReader r = cmd.ExecuteReader())
                {
                    if (r.Read())
                    {
                        idLocal = (int)r["id_local"];
                        idVisitante = (int)r["id_visitante"];
                        nombreLocal = r["local"].ToString();
                        nombreVisitante = r["visitante"].ToString();
                    }
                }
            }
        }

        private void ConfigurarFiltroEquipos()
        {
            rbLocales.Text = nombreLocal + " (Local)";
            rbVisitantes.Text = nombreVisitante + " (Visitante)";
            rbLocales.Checked = true; // Por defecto empezamos con locales
        }

        private void CargarJugadoresFiltrados()
        {
            // Filtramos según el RadioButton marcado
            int idEquipo = rbLocales.Checked ? idLocal : idVisitante;

            using (MySqlConnection conn = new MySqlConnection(connection))
            {
                // Solo cargamos jugadores que estén activos
                string sql = "SELECT id, nombre FROM jugadores WHERE id_equipo = @ide AND activo = 1 ORDER BY nombre ASC";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@ide", idEquipo);
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                cmbJugador.DataSource = dt;
                cmbJugador.DisplayMember = "nombre";
                cmbJugador.ValueMember = "id";
                cmbJugador.SelectedIndex = -1;
            }
        }

        private void RefrescarPantalla()
        {
            CargarTablaStats();
            ActualizarMarcadorReal();
        }

        private void CargarTablaStats()
        {
            using (MySqlConnection conn = new MySqlConnection(connection))
            {
                string sql = @"
                SELECT 
                    sp.id, 
                    j.nombre AS Jugador, 
                    e.nombre AS Equipo,
                    CASE 
                        WHEN j.id_equipo = p.id_local THEN '(Local)' 
                        ELSE '(Visitante)' 
                    END AS Rol,
                    sp.puntos AS Puntos, 
                    sp.valoracion AS Valoración, 
                    sp.id_jugador 
                FROM stats_partidos sp
                JOIN jugadores j ON sp.id_jugador = j.id
                JOIN equipos e ON j.id_equipo = e.id
                JOIN partidos p ON sp.id_partido = p.id
                WHERE sp.id_partido = @idp
                ORDER BY Rol DESC, Puntos DESC";

                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@idp", idPartidoActual);

                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                dgvStatsPartido.DataSource = dt;

                if (dgvStatsPartido.Columns["id"] != null) dgvStatsPartido.Columns["id"].Visible = false;
                if (dgvStatsPartido.Columns["id_jugador"] != null) dgvStatsPartido.Columns["id_jugador"].Visible = false;

                
            }
        }

        private void ActualizarMarcadorReal()
        {
            using (MySqlConnection conn = new MySqlConnection(connection))
            {
                conn.Open();
                string sql = "SELECT COALESCE(SUM(sp.puntos), 0) FROM stats_partidos sp JOIN jugadores j ON sp.id_jugador = j.id WHERE sp.id_partido = @idp AND j.id_equipo = @ide";

                MySqlCommand cmdL = new MySqlCommand(sql, conn);
                cmdL.Parameters.AddWithValue("@idp", idPartidoActual);
                cmdL.Parameters.AddWithValue("@ide", idLocal);
                int ptsL = Convert.ToInt32(cmdL.ExecuteScalar());

                MySqlCommand cmdV = new MySqlCommand(sql, conn);
                cmdV.Parameters.AddWithValue("@idp", idPartidoActual);
                cmdV.Parameters.AddWithValue("@ide", idVisitante);
                int ptsV = Convert.ToInt32(cmdV.ExecuteScalar());

                lblMarcador.Text = ptsL + " - " + ptsV;

                string sqlUpd = "UPDATE partidos SET puntos_local=@pl, puntos_visitante=@pv WHERE id=@idp";
                MySqlCommand cmdUpd = new MySqlCommand(sqlUpd, conn);
                cmdUpd.Parameters.AddWithValue("@pl", ptsL);
                cmdUpd.Parameters.AddWithValue("@pv", ptsV);
                cmdUpd.Parameters.AddWithValue("@idp", idPartidoActual);
                cmdUpd.ExecuteNonQuery();
            }
        }

        // --- EVENTOS DE CONTROLES ---

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (cmbJugador.SelectedValue == null)
            {
                MessageBox.Show("Selecciona un jugador primero.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (numT2M.Value > numT2I.Value || numT3M.Value > numT3I.Value || numTLM.Value > numTLI.Value)
            {
                MessageBox.Show("Error de lógica: Un jugador no puede meter más tiros de los que ha intentado.", "Revisa los datos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; // Frenamos la ejecución, no se guarda nada
            }

            CalcularTodo();
            decimal ptsParaBD = (numT2M.Value * 2) + (numT3M.Value * 3) + (numTLM.Value * 1);

            try
            {
                using (MySqlConnection conn = new MySqlConnection(connection))
                {
                    conn.Open();
                    string sqlCheck = "SELECT id FROM stats_partidos WHERE id_jugador = @j AND id_partido = @p";
                    MySqlCommand cmdCheck = new MySqlCommand(sqlCheck, conn);
                    cmdCheck.Parameters.AddWithValue("@j", cmbJugador.SelectedValue);
                    cmdCheck.Parameters.AddWithValue("@p", idPartidoActual);
                    object existe = cmdCheck.ExecuteScalar();

                    string sql = (existe != null)
                        ? "UPDATE stats_partidos SET minutos=@m, puntos=@pt, t2_metidos=@t2m, t2_intentados=@t2i, t3_metidos=@t3m, t3_intentados=@t3i, tl_metidos=@tlm, tl_intentados=@tli, reb_ofensivos=@ro, reb_defensivos=@rd, asistencias=@a, robos=@rob, tapones=@tap, perdidas=@per, faltas=@f, valoracion=@v WHERE id=@idS"
                        : "INSERT INTO stats_partidos (id_jugador, id_partido, minutos, puntos, t2_metidos, t2_intentados, t3_metidos, t3_intentados, tl_metidos, tl_intentados, reb_ofensivos, reb_defensivos, asistencias, robos, tapones, perdidas, faltas, valoracion) VALUES (@j, @p, @m, @pt, @t2m, @t2i, @t3m, @t3i, @tlm, @tli, @ro, @rd, @a, @rob, @tap, @per, @f, @v)";

                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@m", numMinutos.Value);
                    cmd.Parameters.AddWithValue("@pt", ptsParaBD);
                    cmd.Parameters.AddWithValue("@t2m", numT2M.Value); cmd.Parameters.AddWithValue("@t2i", numT2I.Value);
                    cmd.Parameters.AddWithValue("@t3m", numT3M.Value); cmd.Parameters.AddWithValue("@t3i", numT3I.Value);
                    cmd.Parameters.AddWithValue("@tlm", numTLM.Value); cmd.Parameters.AddWithValue("@tli", numTLI.Value);
                    cmd.Parameters.AddWithValue("@ro", numRebO.Value); cmd.Parameters.AddWithValue("@rd", numRebD.Value);
                    cmd.Parameters.AddWithValue("@a", numAsistencias.Value);
                    cmd.Parameters.AddWithValue("@rob", numRobos.Value);
                    cmd.Parameters.AddWithValue("@tap", numTapones.Value);
                    cmd.Parameters.AddWithValue("@per", numPerdidas.Value);
                    cmd.Parameters.AddWithValue("@f", numFaltas.Value);
                    cmd.Parameters.AddWithValue("@v", numValoracion.Value);

                    if (existe != null) cmd.Parameters.AddWithValue("@idS", existe);
                    else
                    {
                        cmd.Parameters.AddWithValue("@j", cmbJugador.SelectedValue);
                        cmd.Parameters.AddWithValue("@p", idPartidoActual);
                    }

                    cmd.ExecuteNonQuery();
                }

                LimpiarFormulario(); // Esto ahora refrescará el DataGridView y el Marcador
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LimpiarFormulario()
        {
            foreach (Control c in this.Controls) if (c is NumericUpDown n) n.Value = 0;
            cmbJugador.SelectedIndex = -1;
            idStatSeleccionada = 0;
            RefrescarPantalla();
        }

        private void dgvStatsPartido_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow fila = dgvStatsPartido.Rows[e.RowIndex];
                idStatSeleccionada = Convert.ToInt32(fila.Cells["id"].Value);
                int idJugadorSel = Convert.ToInt32(fila.Cells["id_jugador"].Value);

                using (MySqlConnection conn = new MySqlConnection(connection))
                {
                    conn.Open();
                    string sqlEq = "SELECT id_equipo FROM jugadores WHERE id = @idj";
                    MySqlCommand cmdEq = new MySqlCommand(sqlEq, conn);
                    cmdEq.Parameters.AddWithValue("@idj", idJugadorSel);
                    int idEq = Convert.ToInt32(cmdEq.ExecuteScalar());

                    if (idEq == idLocal) rbLocales.Checked = true;
                    else rbVisitantes.Checked = true;

                    CargarJugadoresFiltrados();
                    cmbJugador.SelectedValue = idJugadorSel;

                    MySqlCommand cmd = new MySqlCommand("SELECT * FROM stats_partidos WHERE id = @ids", conn);
                    cmd.Parameters.AddWithValue("@ids", fila.Cells["id"].Value);
                    using (MySqlDataReader r = cmd.ExecuteReader())
                    {
                        if (r.Read())
                        {
                            numMinutos.Value = Convert.ToDecimal(r["minutos"]);
                            numT2M.Value = Convert.ToDecimal(r["t2_metidos"]); numT2I.Value = Convert.ToDecimal(r["t2_intentados"]);
                            numT3M.Value = Convert.ToDecimal(r["t3_metidos"]); numT3I.Value = Convert.ToDecimal(r["t3_intentados"]);
                            numTLM.Value = Convert.ToDecimal(r["tl_metidos"]); numTLI.Value = Convert.ToDecimal(r["tl_intentados"]);
                            numRebO.Value = Convert.ToDecimal(r["reb_ofensivos"]); numRebD.Value = Convert.ToDecimal(r["reb_defensivos"]);
                            numAsistencias.Value = Convert.ToDecimal(r["asistencias"]);
                            numRobos.Value = Convert.ToDecimal(r["robos"]);
                            numTapones.Value = Convert.ToDecimal(r["tapones"]);
                            numPerdidas.Value = Convert.ToDecimal(r["perdidas"]);
                            numFaltas.Value = Convert.ToDecimal(r["faltas"]);
                            CalcularTodo();
                        }
                    }
                }
            }
        }

        private void dgvStatsPartido_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            foreach (DataGridViewRow row in dgvStatsPartido.Rows)
            {
                if (row.Cells["Rol"].Value != null)
                {
                    if (row.Cells["Rol"].Value.ToString() == "(Local)")
                        row.DefaultCellStyle.BackColor = Color.AliceBlue;
                    else
                        row.DefaultCellStyle.BackColor = Color.LavenderBlush;
                }
            }
        }

        private void rbLocales_CheckedChanged(object sender, EventArgs e)
        {
            if (rbLocales.Checked) CargarJugadoresFiltrados();
        }

        private void rbVisitantes_CheckedChanged(object sender, EventArgs e)
        {
            if (rbVisitantes.Checked) CargarJugadoresFiltrados();
        }

        // --- CONEXIÓN DE EVENTOS AUTOMÁTICOS ---
        private void numT2M_ValueChanged(object sender, EventArgs e) => CalcularTodo();
        private void numT2I_ValueChanged(object sender, EventArgs e) => CalcularTodo();
        private void numT3M_ValueChanged(object sender, EventArgs e) => CalcularTodo();
        private void numT3I_ValueChanged(object sender, EventArgs e) => CalcularTodo();
        private void numTLM_ValueChanged(object sender, EventArgs e) => CalcularTodo();
        private void numTLI_ValueChanged(object sender, EventArgs e) => CalcularTodo();
        private void numRebO_ValueChanged(object sender, EventArgs e) => CalcularTodo();
        private void numRebD_ValueChanged(object sender, EventArgs e) => CalcularTodo();
        private void numAsistencias_ValueChanged(object sender, EventArgs e) => CalcularTodo();
        private void numRobos_ValueChanged(object sender, EventArgs e) => CalcularTodo();
        private void numTapones_ValueChanged(object sender, EventArgs e) => CalcularTodo();
        private void numPerdidas_ValueChanged(object sender, EventArgs e) => CalcularTodo();
        private void numFaltas_ValueChanged(object sender, EventArgs e) => CalcularTodo();
        private void btnLimpiar_Click(object sender, EventArgs e) => LimpiarFormulario();

        // Métodos vacíos del diseñador
        private void lblMarcador_Click(object sender, EventArgs e) { }
        private void cmbJugador_SelectedIndexChanged(object sender, EventArgs e) { }
        private void numMinutos_ValueChanged(object sender, EventArgs e) { }
        private void Form13_Load(object sender, EventArgs e) { }
        private void numValoracion_ValueChanged(object sender, EventArgs e) { }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void label15_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Valoración_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void dgvStatsPartido_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (idStatSeleccionada == 0)
            {
                MessageBox.Show("Por favor, selecciona primero una fila de la tabla para eliminarla.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            DialogResult confirmacion = MessageBox.Show("¿Estás seguro de que quieres borrar este registro estadístico?", "Confirmar borrado", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (confirmacion == DialogResult.Yes)
            {
                try
                {
                    using (MySqlConnection conn = new MySqlConnection(connection))
                    {
                        conn.Open();
                        string sql = "DELETE FROM stats_partidos WHERE id = @id";
                        MySqlCommand cmd = new MySqlCommand(sql, conn);
                        cmd.Parameters.AddWithValue("@id", idStatSeleccionada);
                        cmd.ExecuteNonQuery();
                    }

                    LimpiarFormulario();
                    MessageBox.Show("Registro eliminado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al eliminar: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void atras(object sender, EventArgs e)
        {
            ActualizarMarcadorReal();
            this.Close();
        }
    }
}