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
            this.FormBorderStyle = FormBorderStyle.None;
            //RedondearEsquinas(altoButton1, 50, true, false, false, true);
            //RedondearEsquinas(cajaContenido, 50, true, true, true, true);
            //RedondearEsquinas(cerrarSeesion, 20, true, true, true, true);

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

        private void user_enter(object sender, EventArgs e)
        {
            if (user.Text == "Usuario")
            {
                user.Text = "";
            }
            
        }

        private void user_leave(object sender, EventArgs e)
        {
            if (user.Text == "")
            {
                user.Text = "Usuario";
            }
        }

        private void password_TextChanged(object sender, EventArgs e)
        {
            if (password.Text != "Contraseña" && password.Text != "")
            {
                password.PasswordChar = '*';
            }
        }

        private void password_Enter(object sender, EventArgs e)
        {
            if (password.Text == "Contraseña")
            {
                password.Text = "";
            }
        }

        private void password_Leave(object sender, EventArgs e)
        {
            if (password.Text == "")
            {
                password.Text = "Contraseña";
                password.PasswordChar = '\0'; 
            }
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
                                    if (reader["id_equipo"] != DBNull.Value)
                                    {
                                        SesionUsuario.IdEquipoEntrenador = Convert.ToInt32(reader["id_equipo"]);
                                    }
                                }

                                this.Hide();

                                using (Form7 pantallaCarga = new Form7())
                                {
                                    pantallaCarga.ShowDialog();
                                }

                                if (role.Equals("entrenador"))
                                {
                                    int idEquipo = SesionUsuario.IdEquipoEntrenador;
                                 
                                    megamenucoach menucoach= new megamenucoach(idEquipo);
                                    menucoach.Show();
                                }
                                else
                                {
                                    Form8 adminForm = new Form8();
                                    adminForm.Show();
                                }
                            }
                            else
                            {
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

        private void cerrarSeesion_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void altoButton1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click_2(object sender, EventArgs e)
        {

        }


        private void button1_Click(object sender, EventArgs e)
        {
            if (password.Text != "Contraseña")
            {
                if (password.PasswordChar == '*')
                {
                    password.PasswordChar = '\0'; 
                }
                else
                {
                    password.PasswordChar = '*'; 
                }
            }
        }
    }
}
