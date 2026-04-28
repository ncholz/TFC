using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient; // No olvides esta referencia

namespace HoopManager
{
    public partial class Form10 : Form
    {
        // Tu cadena de conexión
        string connection = "Server=localhost;Database=gestion_basket;Uid=root;Pwd=;";
        int idSel = 0; // ID del jugador seleccionado
        bool jugadorActivo = true; // <--- NUEVA: Para saber si el seleccionado está activo o no

        Image fondoOriginalEliminar = null;

        public Form10()
        {
            InitializeComponent();
            CargarEquipos();
            CargarJugadores();
            CargarPosiciones();
            fondoOriginalEliminar = btnEliminar.BackgroundImage;

        }

        // --- 1. CARGA DE DATOS ---

        private void CargarPosiciones()
        {
            // Llenamos el combo con las posiciones oficiales
            cmbPosicion.Items.Clear();
            cmbPosicion.Items.Add("Base");
            cmbPosicion.Items.Add("Escolta");
            cmbPosicion.Items.Add("Alero");
            cmbPosicion.Items.Add("Ala-Pivot");
            cmbPosicion.Items.Add("Pivot");
            cmbPosicion.SelectedIndex = -1; // Empezar vacío

        }
        private void CargarJugadores()
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connection))
                {
                    // ELIMINAMOS j.foto_url de la consulta SQL
                    // Modifica la consulta para incluir j.activo
                    string sql = @"SELECT j.id, j.nombre, j.posicion, j.altura_cm, j.dorsal, 
                                   e.nombre AS Equipo, j.id_equipo, j.activo 
                                   FROM jugadores j 
                                   JOIN equipos e ON j.id_equipo = e.id";

                    MySqlDataAdapter da = new MySqlDataAdapter(sql, conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dgvJugadores.DataSource = dt;

                    if (dgvJugadores.Columns["id"] != null) dgvJugadores.Columns["id"].Visible = false;
                    if (dgvJugadores.Columns["id_equipo"] != null) dgvJugadores.Columns["id_equipo"].Visible = false;
                    if (dgvJugadores.Columns["activo"] != null)
                    {
                        dgvJugadores.Columns["activo"].Visible = true;
                        dgvJugadores.Columns["activo"].HeaderText = "Estado (Activo)";
                        dgvJugadores.Columns["activo"].ReadOnly = true;
                    }

                }
            }
            catch (Exception ex) { MessageBox.Show("Error al cargar tabla: " + ex.Message); }
        }

        private void CargarEquipos()
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connection))
                {
                    MySqlDataAdapter da = new MySqlDataAdapter("SELECT id, nombre FROM equipos", conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    cmbEquipo.DataSource = dt;
                    cmbEquipo.DisplayMember = "nombre";
                    cmbEquipo.ValueMember = "id";
                    cmbEquipo.SelectedIndex = -1; // Empezar vacío
                }
            }
            catch (Exception ex) { MessageBox.Show("Error al cargar combos: " + ex.Message); }
        }

        // --- 2. ACCIONES DE BOTONES ---
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNombre.Text) || cmbEquipo.SelectedValue == null || cmbPosicion.SelectedIndex == -1)
            {
                MessageBox.Show("Faltan datos. Nombre, Equipo y Posición son obligatorios.");
                return;
            }

            try
            {
                using (MySqlConnection conn = new MySqlConnection(connection))
                {
                    conn.Open();

                    // --- PASO 1: COMPROBACIÓN DE DORSAL DUPLICADO EN EL MISMO EQUIPO ---
                    // Buscamos si hay alguien con ese dorsal, en ese equipo, que NO sea el jugador actual (id != idSel)
                    string sqlCheck = "SELECT COUNT(*) FROM jugadores WHERE dorsal = @d AND id_equipo = @e AND id != @id";
                    MySqlCommand cmdCheck = new MySqlCommand(sqlCheck, conn);
                    cmdCheck.Parameters.AddWithValue("@d", (int)txtDorsal.Value);
                    cmdCheck.Parameters.AddWithValue("@e", cmbEquipo.SelectedValue);
                    cmdCheck.Parameters.AddWithValue("@id", idSel); // Si es nuevo (0), no coincide con nadie. Si editas, se ignora a sí mismo.

                    int existeDorsal = Convert.ToInt32(cmdCheck.ExecuteScalar());

                    if (existeDorsal > 0)
                    {
                        MessageBox.Show("¡Dorsal repetido! Ya hay un jugador en este equipo con el número " + txtDorsal.Value + ".", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return; // Cortamos la ejecución aquí, no se guarda nada.
                    }
                    // -------------------------------------------------------------------

                    // --- PASO 2: SI EL DORSAL ESTÁ LIBRE, GUARDAMOS NORMALMENTE ---
                    string sql = (idSel == 0)
                    ? "INSERT INTO jugadores (nombre, posicion, altura_cm, dorsal, id_equipo) VALUES (@n, @p, @a, @d, @e)"
                    : "UPDATE jugadores SET nombre=@n, posicion=@p, altura_cm=@a, dorsal=@d, id_equipo=@e WHERE id=@id";

                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@n", txtNombre.Text);
                    cmd.Parameters.AddWithValue("@p", cmbPosicion.Text);
                    cmd.Parameters.AddWithValue("@a", (int)txtAltura.Value);
                    cmd.Parameters.AddWithValue("@d", (int)txtDorsal.Value);
                    cmd.Parameters.AddWithValue("@e", cmbEquipo.SelectedValue);

                    // Ya no añadimos el parámetro @f (el de la foto)
                    if (idSel != 0) cmd.Parameters.AddWithValue("@id", idSel);

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("¡Datos del jugador actualizados!");
                    LimpiarFormulario();
                }
            }
            catch (Exception ex) { MessageBox.Show("Error al guardar: " + ex.Message); }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (idSel == 0) return;

            int idJugador = idSel;
            string nombre = txtNombre.Text;

            // ¿ES UN JUGADOR INACTIVO? -> LO REACTIVAMOS
            if (jugadorActivo == false)
            {
                if (MessageBox.Show($"El jugador {nombre} está inactivo.\n\n¿Deseas volver a DARLO DE ALTA?", "Reactivar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    EjecutarReactivacion(idJugador);
                }
                return; // Salimos de la función para que no intente borrarlo
            }

            // SI ESTÁ ACTIVO, HACEMOS LA LÓGICA DE BORRADO DE SIEMPRE
            if (PuedeBorrarse(idJugador))
            {
                var res = MessageBox.Show($"¿Qué quieres hacer con {nombre}?\n\n" +
                    "• Pulsa 'SÍ' para ELIMINARLO permanentemente (Limpieza total).\n" +
                    "• Pulsa 'NO' para SOLO DESACTIVARLO (Borrado lógico).\n" +
                    "• Pulsa 'CANCELAR' para no hacer nada.",
                    "Opciones de Borrado", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

                if (res == DialogResult.Yes) EjecutarBorradoReal(idJugador);
                else if (res == DialogResult.No) EjecutarBorradoLogico(idJugador);
            }
            else
            {
                var res = MessageBox.Show($"El jugador {nombre} tiene estadísticas registradas.\n\n" +
                    "Por seguridad, no se puede borrar de la base de datos. Solo se permite desactivarlo.\n\n" +
                    "¿Deseas DESACTIVARLO para que no aparezca más en las listas?",
                    "Seguridad de Integridad", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

                if (res == DialogResult.Yes) EjecutarBorradoLogico(idJugador);
            }
        }


        //------------------------------------------------

        private bool PuedeBorrarse(int id)
        {
            using (MySqlConnection conn = new MySqlConnection(connection))
            {
                conn.Open();
                // Consultamos si el ID existe en stats_partidos o stats_historicas
                string sql = @"SELECT 
            (SELECT COUNT(*) FROM stats_partidos WHERE id_jugador = @id) + 
            (SELECT COUNT(*) FROM stats_historicas WHERE id_jugador = @id)";

                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@id", id);

                // Si el total es 0, el jugador no tiene historial y se puede borrar físicamente
                int totalRegistros = Convert.ToInt32(cmd.ExecuteScalar());
                return totalRegistros == 0;
            }
        }

        //----------------------------------------------
        //Jubilar al jugador (activo=false)

        private void EjecutarBorradoLogico(int id)
        {
            using (MySqlConnection conn = new MySqlConnection(connection))
            {
                conn.Open();
                // Cambiamos el estado a false. El registro sigue en la tabla 'jugadores'
                string sql = "UPDATE jugadores SET activo = @estado WHERE id = @id";

                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@estado", false); // El booleano que definimos
                cmd.Parameters.AddWithValue("@id", id);

                cmd.ExecuteNonQuery();

                MessageBox.Show("El jugador ahora está inactivo. Su historial se ha conservado.");
                CargarJugadores(); // Refresca tu DataGridView
            }
        }

        //--------------------------------------------
        //Borrar del todo

        private void EjecutarBorradoReal(int id)
        {
            using (MySqlConnection conn = new MySqlConnection(connection))
            {
                conn.Open();
                string sql = "DELETE FROM jugadores WHERE id = @id";

                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@id", id);

                cmd.ExecuteNonQuery();

                MessageBox.Show("Jugador eliminado permanentemente de la base de datos.");
                CargarJugadores(); // Refresca tu DataGridView
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarFormulario();
        }

        // --- 3. EVENTOS DE SELECCIÓN ---

        // ¡IMPORTANTE! Cambia en el Diseñador el evento CellContentClick por CellClick
        private void dgvJugadores_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow fila = dgvJugadores.Rows[e.RowIndex];

                // Parche anti-crash (DBNull)
                if (fila.IsNewRow || fila.Cells["id"].Value == DBNull.Value) return;

                idSel = Convert.ToInt32(fila.Cells["id"].Value);
                txtNombre.Text = fila.Cells["nombre"].Value.ToString();
                cmbPosicion.Text = fila.Cells["posicion"].Value.ToString();
                txtAltura.Value = Convert.ToDecimal(fila.Cells["altura_cm"].Value);
                txtDorsal.Value = Convert.ToDecimal(fila.Cells["dorsal"].Value);
                cmbEquipo.Text = fila.Cells["Equipo"].Value.ToString();

                // --- LÓGICA DEL BOTÓN CAMALEÓN ---
                jugadorActivo = Convert.ToBoolean(fila.Cells["activo"].Value);

                if (jugadorActivo == false)
                {
                    btnEliminar.BackgroundImage = null; // <--- AQUÍ QUITAMOS LA IMAGEN
                    btnEliminar.Text = "Reactivar";
                    btnEliminar.Font = new Font("Verdana", 13, FontStyle.Regular); // Letra Verdana 13
                    btnEliminar.BackColor = Color.LightGreen; // Un toque verde para indicar que lo "revives"
                }
                else
                {
                    btnEliminar.BackgroundImage = fondoOriginalEliminar; // <--- AQUÍ RESTAURAMOS LA IMAGEN
                    btnEliminar.Text = "";
                    btnEliminar.BackColor = DefaultBackColor; // Vuelve a su color normal
                }
            }
        }

        private void EjecutarReactivacion(int id)
        {
            using (MySqlConnection conn = new MySqlConnection(connection))
            {
                conn.Open();
                string sql = "UPDATE jugadores SET activo = true WHERE id = @id";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();

                MessageBox.Show("¡El jugador ha sido reactivado y vuelve a estar disponible en el equipo!", "Jugador de vuelta", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LimpiarFormulario();
            }
        }

        // --- 4. AYUDANTES ---
        private void LimpiarFormulario()
        {
            jugadorActivo = true;
            btnEliminar.BackColor = DefaultBackColor;
            idSel = 0;
            txtNombre.Clear();
            txtAltura.Value = 0;
            txtDorsal.Value = 0;
            cmbPosicion.SelectedIndex = -1;
            cmbEquipo.SelectedIndex = -1;
            CargarJugadores(); // Refrescar la tabla siempre
        }

        // Metodos vacíos que ya tenías (puedes borrarlos si no los usas)
        private void txtNombre_TextChanged(object sender, EventArgs e) { }
        private void txtDorsal_ValueChanged(object sender, EventArgs e) { }
        private void txtAltura_ValueChanged(object sender, EventArgs e) { }
        private void cmbPosicion_SelectedIndexChanged(object sender, EventArgs e) { }
        private void cmbEquipo_SelectedIndexChanged(object sender, EventArgs e) { }

        private void Form10_Load(object sender, EventArgs e)
        {

        }

        private void txtBusqueda_TextChanged(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = (DataTable)dgvJugadores.DataSource;
                if (dt != null)
                {
                    // Fíjate en el Replace: busca UNA comilla simple y pone DOS
                    dt.DefaultView.RowFilter = string.Format("nombre LIKE '%{0}%'", txtBusqueda.Text.Replace("'", "''"));
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