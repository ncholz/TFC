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
    public partial class coachorm2 : Form
    {
        public coachorm2()
        {
            InitializeComponent();
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
    }
}
