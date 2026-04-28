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
    public partial class coachorm2 : Form
    {
        public coachorm2()
        {
            InitializeComponent();
            
            MakeCircularButton(cerrarSeesion);
            RedondearEsquinas(altoButton1,50,true, true, true, true);
            RedondearEsquinas(altoButton2,50,true, true, true, true);
            RedondearEsquinas(altoButton4,50,true, true, true, true);
            RedondearEsquinas(altoButton5,50,true, true, true, true);
            RedondearEsquinas(altoButton6,50,true, true, true, true);
            RedondearEsquinas(altoButton7,50,true, true, true, true);
        }

        private void altoNMUpDown1_Click(object sender, EventArgs e)
        {

        }

        private void altoButton1_Click(object sender, EventArgs e)
        {
            //al hacer click me lleva a la pantalla de ver jugadores
            FormCoachVerJugadores verJugadoresForm = new FormCoachVerJugadores();
            verJugadoresForm.Show();
            this.Hide();
        }

        private void altoButton2_Click(object sender, EventArgs e)
        {
            //al hacer click me lleva a la pantalla de ver clasificacion
            Form3 clasificacionForm = new Form3();
            clasificacionForm.Show();
            this.Hide();
        }

        private void volver_Click(object sender, EventArgs e)
        {
            login pantallaInicio = new login();
            pantallaInicio.Show();
            this.Close();
        }

        private void cerrarSeesion_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }


        private void altoButton5_Click(object sender, EventArgs e) //ver todos los partidos jugados
        {
            Form4 form4 = new Form4();
            form4.Show();
            this.Hide();
        }

        private void MakeCircularButton(Control btn)
        {
            GraphicsPath path = new GraphicsPath();
            path.AddEllipse(0, 0, btn.Width, btn.Height);
            btn.Region = new Region(path);
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

        private void altoButton4_Click(object sender, EventArgs e)
        {
            Form5 form5 = new Form5();
            form5.Show();
            this.Hide();
        }

        private void altoButton6_Click(object sender, EventArgs e)
        {
            Form6 formstatsgenerales= new Form6();
            formstatsgenerales.Show();
            this.Hide();
        }
    }
}
