using System;
using System.Windows.Forms; // ¡Esto es vital para que la ventana funcione!
using System.Windows.Forms.Integration;

namespace Prueba_pizarra
{
    // ¡Ojo aquí! Tiene que decir ": Form" para que sepa que es una ventana
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            ElementHost hostPizarra = new ElementHost();
            hostPizarra.Dock = DockStyle.Fill;
            PizarraTactical miPizarraWPF = new PizarraTactical();
            hostPizarra.Child = miPizarraWPF;
            this.Controls.Add(hostPizarra);
        }
    }
}