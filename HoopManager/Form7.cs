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
    public partial class Form7 : Form
    {
        public Form7()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            // 1. Aumentamos el valor de la barra de 1 en 1
            progressBar1.Value += 1;

            // 2. Si llega al 100% (han pasado 3 segundos)
            if (progressBar1.Value >= 100)
            {
                timer1.Stop(); // Paramos el motor
                this.DialogResult = DialogResult.OK; // Marcamos éxito
                this.Close(); // Cerramos la pantalla de carga
            }
        }

        private void progressBar1_Click(object sender, EventArgs e)
        {

        }

        private void Form7_Load(object sender, EventArgs e)
        {

        }
    }
}
