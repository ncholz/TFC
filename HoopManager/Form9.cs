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
    public partial class Form9 : Form
    {
        string connection = "Server=localhost;Database=gestion_basket;Uid=root;Pwd=;";
        int idSel = 0;
        public Form9()
        {
            InitializeComponent();
            CargarEquipos();
            CargarUsuarios();
            cmbRol.Items.Add("admin");
            cmbRol.Items.Add("entrenador");
        }

        private void Form9_Load(object sender, EventArgs e)
        {

        }

        // CARGAR DATOS
        private void CargarUsuarios()
        {
            using (MySqlConnection conn = new MySqlConnection(connection))
            {
                string sql = "SELECT u.id, u.nombre_usuario, u.password, u.nombre_completo, u.rol, e.nombre AS Equipo FROM usuarios u LEFT JOIN equipos e ON u.id_equipo = e.id";
                MySqlDataAdapter da = new MySqlDataAdapter(sql, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvUsuarios.DataSource = dt;
                dgvUsuarios.Columns["id"].Visible = false;
            }
        }

        private void CargarEquipos()
        {
            using (MySqlConnection conn = new MySqlConnection(connection))
            {
                MySqlDataAdapter da = new MySqlDataAdapter("SELECT id, nombre FROM equipos", conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                cmbEquipo.DataSource = dt;
                cmbEquipo.DisplayMember = "nombre"; cmbEquipo.ValueMember = "id";
                cmbEquipo.SelectedIndex = -1;
            }
        }

       

        

        // SELECCIONAR (Evento CellDoubleClick del Grid)
        private void dgvUsuarios_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                // Obtenemos la fila seleccionada
                DataGridViewRow fila = dgvUsuarios.Rows[e.RowIndex];

                // Guardamos el ID
                idSel = Convert.ToInt32(fila.Cells["id"].Value);

                // Cargamos los textos para que veas que se ha seleccionado bien
                txtUsuario.Text = fila.Cells["nombre_usuario"].Value.ToString();
                txtPassword.Text = fila.Cells["password"].Value.ToString();
                txtNombreCompleto.Text = fila.Cells["nombre_completo"].Value.ToString();
                cmbRol.Text = fila.Cells["rol"].Value.ToString();
                cmbEquipo.Text = fila.Cells["Equipo"].Value.ToString();

                // Opcional: Cambia el color del botón eliminar para saber que ya puedes borrar
                btnEliminar.BackColor = Color.LightCoral;
            }
        }

        private void Limpiar() { idSel = 0; Controls.OfType<TextBox>().ToList().ForEach(t => t.Clear()); CargarUsuarios(); }

        private void btnGuardar_Click_1(object sender, EventArgs e)
        {
            // 1. EL PORTERO: Comprobamos que ningún campo clave esté vacío
            if (string.IsNullOrWhiteSpace(txtUsuario.Text) ||
                string.IsNullOrWhiteSpace(txtPassword.Text) ||
                string.IsNullOrWhiteSpace(txtNombreCompleto.Text) ||
                string.IsNullOrWhiteSpace(cmbRol.Text))
            {
                MessageBox.Show("¡Ojo! Tienes que rellenar el Usuario, la Contraseña, el Nombre y elegir un Rol antes de guardar.", "Campos vacíos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; // Esto hace que el código se pare aquí y no guarde nada en la base de datos
            }

            using (MySqlConnection conn = new MySqlConnection(connection))
            {
                try
                {
                    conn.Open();

                    // 2. SI ES NUEVO (idSel == 0), COMPROBAMOS SI EL NOMBRE YA EXISTE
                    if (idSel == 0)
                    {
                        string checkSql = "SELECT COUNT(*) FROM usuarios WHERE nombre_usuario = @u";
                        MySqlCommand checkCmd = new MySqlCommand(checkSql, conn);
                        checkCmd.Parameters.AddWithValue("@u", txtUsuario.Text);
                        int existe = Convert.ToInt32(checkCmd.ExecuteScalar());

                        if (existe > 0)
                        {
                            MessageBox.Show("¡Error! El nombre de usuario '" + txtUsuario.Text + "' ya está en uso. Elige otro.", "Usuario duplicado", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return; // Cortamos el código aquí para que no intente el INSERT
                        }
                    }

                    // 3. PROCEDEMOS A GUARDAR O ACTUALIZAR
                    string sql = (idSel == 0)
                        ? "INSERT INTO usuarios (nombre_usuario, password, nombre_completo, rol, id_equipo) VALUES (@u, @p, @n, @r, @e)"
                        : "UPDATE usuarios SET nombre_usuario=@u, password=@p, nombre_completo=@n, rol=@r, id_equipo=@e WHERE id=@id";

                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@u", txtUsuario.Text);
                    cmd.Parameters.AddWithValue("@p", txtPassword.Text);
                    cmd.Parameters.AddWithValue("@n", txtNombreCompleto.Text);
                    cmd.Parameters.AddWithValue("@r", cmbRol.Text);

                    // Si es admin, id_equipo es NULL
                    object idEq = (cmbRol.Text == "admin" || cmbEquipo.SelectedValue == null) ? DBNull.Value : cmbEquipo.SelectedValue;
                    cmd.Parameters.AddWithValue("@e", idEq);

                    if (idSel != 0) cmd.Parameters.AddWithValue("@id", idSel);

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Usuario guardado con éxito.", "Guardado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Limpiar();

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error inesperado: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnEliminar_Click_1(object sender, EventArgs e)
        {
            if (idSel == 0)
            {
                MessageBox.Show("Por favor, selecciona primero un usuario de la tabla haciendo clic en su fila.");
                return;
            }

            // Pedimos confirmación (Para no borrar por error)
            DialogResult confirm = MessageBox.Show("¿Seguro que quieres borrar este usuario?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (confirm == DialogResult.Yes)
            {
                try
                {
                    using (MySqlConnection conn = new MySqlConnection(connection))
                    {
                        conn.Open();
                        string sql = "DELETE FROM usuarios WHERE id = @id";
                        MySqlCommand cmd = new MySqlCommand(sql, conn);
                        cmd.Parameters.AddWithValue("@id", idSel);

                        cmd.ExecuteNonQuery();
                    }

                    MessageBox.Show("Usuario eliminado con éxito.");
                    btnEliminar.BackColor = DefaultBackColor; // Reset color
                    Limpiar(); // Esto refresca la tabla
                }
                catch (Exception ex)
                {
                    // Si hay un error de MySQL, aquí te dirá exactamente QUÉ pasa
                    MessageBox.Show("No se pudo eliminar: " + ex.Message);
                }
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void dgvUsuarios_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Verificamos que se haya hecho clic en una fila real y no en el encabezado
            if (e.RowIndex >= 0)
            {
                // 1. Obtenemos la fila completa
                DataGridViewRow fila = dgvUsuarios.Rows[e.RowIndex];

                // --> EL PARCHE: Si es la fila vacía del final o el ID es nulo, no hacemos nada y salimos <--
                if (fila.IsNewRow || fila.Cells["id"].Value == DBNull.Value)
                {
                    return;
                }

                // 2. Guardamos el ID en la variable global para poder eliminar o editar luego
                idSel = Convert.ToInt32(fila.Cells["id"].Value);

                // 3. Pasamos los datos de las celdas a los cuadros de texto
                txtUsuario.Text = fila.Cells["nombre_usuario"].Value.ToString();
                txtPassword.Text = fila.Cells["password"].Value.ToString();
                txtNombreCompleto.Text = fila.Cells["nombre_completo"].Value.ToString();
                cmbRol.Text = fila.Cells["rol"].Value.ToString();

                // 4. Manejamos el equipo
                string nombreEquipo = fila.Cells["Equipo"].Value.ToString();
                if (string.IsNullOrEmpty(nombreEquipo))
                {
                    cmbEquipo.SelectedIndex = -1;
                }
                else
                {
                    cmbEquipo.Text = nombreEquipo;
                }
            }
        }

        private void cmbRol_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txtBusqueda_TextChanged(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = (DataTable)dgvUsuarios.DataSource;
                if (dt != null)
                {
                    // Fíjate en el Replace: busca UNA comilla simple y pone DOS
                    dt.DefaultView.RowFilter = string.Format("nombre_usuario LIKE '%{0}%'", txtBusqueda.Text.Replace("'", "''"));
                }
            }
            catch (Exception ex)
            {
                // Mientras programas, nunca dejes un catch vacío. Así si falla, te enteras.
                MessageBox.Show("Error al filtrar: " + ex.Message);
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
