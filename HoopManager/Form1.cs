using MySql.Data.MySqlClient;
using System;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace HoopManager
{
    public partial class login : Form
    {

        String conectionString = "Server=localhost;Database=gestion_basket;Uid=root;Pwd=;";
        public login()
        {
            InitializeComponent();
            RedondearEsquinas(altoButton1, 50, true, false, false, true);
            RedondearEsquinas(cajaContenido, 50, true, true, true, true);

        }

        private void login_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {

        }

        private void cajaContenido_Enter(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void user_TextChanged(object sender, EventArgs e)
        { 
            
        }

        private void password_TextChanged(object sender, EventArgs e)
        {

        }

        private void botonLogin_Click(object sender, EventArgs e)
        {

            String username = user.Text;
            String passwordText = password.Text;
            String role = "";

            string query = "SELECT * FROM usuarios WHERE nombre_usuario = @username AND password = @password";
            using (MySqlConnection connection = new MySqlConnection(conectionString))
            {
                try
                {
                    connection.Open();
                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@username", username);
                        command.Parameters.AddWithValue("@password", passwordText);
                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                if (reader.Read())
                                {
                                    role = reader["rol"].ToString();
                                    if (reader["rol"] != DBNull.Value)
                                    {
                                        SesionUsuario.IdEquipoEntrenador = Convert.ToInt32(reader["id_equipo"]);
                                    }
                                }
                            // Credenciales válidas
                                if (role.Equals("entrenador"))
                                {
                                    coachorm2 coachForm = new coachorm2();
                                    coachForm.Show();
                                    this.Hide();
                                }
                                else 
                                {
                                    Form adminForm = new Form();
                                    adminForm.Show();
                                    this.Hide();
                                }
                                MessageBox.Show("Inicio de sesión exitoso");
                            }
                            else
                            { // Credenciales inválidas
                                MessageBox.Show("Usuario o contraseña incorrectos");
                            }
                        }
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al conectar a la base de datos: " + ex.Message);
                }

            }
        }

        public void RedondearEsquinas(Control control, int radio, bool topLeft, bool topRight, bool bottomRight, bool bottomLeft)
        {
            System.Drawing.Drawing2D.GraphicsPath path = new System.Drawing.Drawing2D.GraphicsPath();
            int d = radio * 2;

            if (topLeft) path.AddArc(0, 0, d, d, 180, 90);
            else path.AddLine(0, 0, 0, 0);

            if (topRight) path.AddArc(control.Width - d, 0, d, d, 270, 90);
            else path.AddLine(control.Width, 0, control.Width, 0);

            if (bottomRight) path.AddArc(control.Width - d, control.Height - d, d, d, 0, 90);
            else path.AddLine(control.Width, control.Height, control.Width, control.Height);

            if (bottomLeft) path.AddArc(0, control.Height - d, d, d, 90, 90);
            else path.AddLine(0, control.Height, 0, control.Height);

            path.CloseFigure();
            control.Region = new Region(path);
        }

        
    }
}
