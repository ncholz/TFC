using System;
using System.Windows.Forms;
using System.Windows.Forms.Integration;

namespace HoopManager
{
    public partial class FormPizarra : Form
    {
        public FormPizarra()
        {
            InitializeComponent();

            ElementHost hostPizarra = new ElementHost();
            hostPizarra.Dock = DockStyle.Fill;

            hostPizarra.BackColorTransparent = true;

            UserControl1 miPizarraWPF = new UserControl1();

            hostPizarra.Child = miPizarraWPF;

            this.Controls.Add(hostPizarra);
        }

        private void FormPizarra_Load(object sender, EventArgs e)
        {
        }
    }
}