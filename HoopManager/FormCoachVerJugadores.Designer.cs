namespace HoopManager
{
    partial class FormCoachVerJugadores
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tablaJugadores = new System.Windows.Forms.DataGridView();
            this.botonConsultas = new AltoControls.AltoButton();
            this.name = new System.Windows.Forms.TextBox();
            this.position = new System.Windows.Forms.TextBox();
            this.height = new System.Windows.Forms.TextBox();
            this.dorsal = new System.Windows.Forms.TextBox();
            this.altoButton1 = new AltoControls.AltoButton();
            this.limpiarCampos = new AltoControls.AltoButton();
            ((System.ComponentModel.ISupportInitialize)(this.tablaJugadores)).BeginInit();
            this.SuspendLayout();
            // 
            // tablaJugadores
            // 
            this.tablaJugadores.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tablaJugadores.Location = new System.Drawing.Point(550, 40);
            this.tablaJugadores.Name = "tablaJugadores";
            this.tablaJugadores.Size = new System.Drawing.Size(393, 291);
            this.tablaJugadores.TabIndex = 0;
            this.tablaJugadores.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.tablaJugadores_CellContentClick);
            // 
            // botonConsultas
            // 
            this.botonConsultas.Active1 = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(168)))), ((int)(((byte)(183)))));
            this.botonConsultas.Active2 = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(164)))), ((int)(((byte)(183)))));
            this.botonConsultas.BackColor = System.Drawing.Color.Transparent;
            this.botonConsultas.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.botonConsultas.Font = new System.Drawing.Font("Comic Sans MS", 10F, System.Drawing.FontStyle.Bold);
            this.botonConsultas.ForeColor = System.Drawing.Color.Black;
            this.botonConsultas.Inactive1 = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(188)))), ((int)(((byte)(210)))));
            this.botonConsultas.Inactive2 = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(167)))), ((int)(((byte)(188)))));
            this.botonConsultas.Location = new System.Drawing.Point(550, 367);
            this.botonConsultas.Name = "botonConsultas";
            this.botonConsultas.Radius = 10;
            this.botonConsultas.Size = new System.Drawing.Size(143, 46);
            this.botonConsultas.Stroke = false;
            this.botonConsultas.StrokeColor = System.Drawing.Color.Gray;
            this.botonConsultas.TabIndex = 1;
            this.botonConsultas.Text = "Consultar";
            this.botonConsultas.Transparency = false;
            this.botonConsultas.Click += new System.EventHandler(this.botonConsultas_Click);
            // 
            // name
            // 
            this.name.Location = new System.Drawing.Point(160, 113);
            this.name.Name = "name";
            this.name.Size = new System.Drawing.Size(173, 20);
            this.name.TabIndex = 3;
            this.name.Text = "Nombre";
            this.name.TextChanged += new System.EventHandler(this.name_TextChanged);
            // 
            // position
            // 
            this.position.Location = new System.Drawing.Point(160, 139);
            this.position.Name = "position";
            this.position.Size = new System.Drawing.Size(173, 20);
            this.position.TabIndex = 4;
            this.position.Text = "Posicion";
            this.position.TextChanged += new System.EventHandler(this.position_TextChanged);
            // 
            // height
            // 
            this.height.Location = new System.Drawing.Point(160, 165);
            this.height.Name = "height";
            this.height.Size = new System.Drawing.Size(173, 20);
            this.height.TabIndex = 5;
            this.height.Text = "Altura(cm)";
            this.height.TextChanged += new System.EventHandler(this.height_TextChanged);
            // 
            // dorsal
            // 
            this.dorsal.Location = new System.Drawing.Point(160, 191);
            this.dorsal.Name = "dorsal";
            this.dorsal.Size = new System.Drawing.Size(173, 20);
            this.dorsal.TabIndex = 6;
            this.dorsal.Text = "Dorsal";
            this.dorsal.TextChanged += new System.EventHandler(this.dorsal_TextChanged);
            // 
            // altoButton1
            // 
            this.altoButton1.Active1 = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(168)))), ((int)(((byte)(183)))));
            this.altoButton1.Active2 = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(164)))), ((int)(((byte)(183)))));
            this.altoButton1.BackColor = System.Drawing.Color.Transparent;
            this.altoButton1.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.altoButton1.Font = new System.Drawing.Font("Comic Sans MS", 10F, System.Drawing.FontStyle.Bold);
            this.altoButton1.ForeColor = System.Drawing.Color.Black;
            this.altoButton1.Inactive1 = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(188)))), ((int)(((byte)(210)))));
            this.altoButton1.Inactive2 = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(167)))), ((int)(((byte)(188)))));
            this.altoButton1.Location = new System.Drawing.Point(550, 444);
            this.altoButton1.Name = "altoButton1";
            this.altoButton1.Radius = 10;
            this.altoButton1.Size = new System.Drawing.Size(143, 58);
            this.altoButton1.Stroke = false;
            this.altoButton1.StrokeColor = System.Drawing.Color.Gray;
            this.altoButton1.TabIndex = 8;
            this.altoButton1.Text = "Ver entrenamientos recomendados";
            this.altoButton1.Transparency = false;
            // 
            // limpiarCampos
            // 
            this.limpiarCampos.Active1 = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(168)))), ((int)(((byte)(183)))));
            this.limpiarCampos.Active2 = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(164)))), ((int)(((byte)(183)))));
            this.limpiarCampos.BackColor = System.Drawing.Color.Transparent;
            this.limpiarCampos.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.limpiarCampos.Font = new System.Drawing.Font("Comic Sans MS", 10F, System.Drawing.FontStyle.Bold);
            this.limpiarCampos.ForeColor = System.Drawing.Color.Black;
            this.limpiarCampos.Inactive1 = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(188)))), ((int)(((byte)(210)))));
            this.limpiarCampos.Inactive2 = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(167)))), ((int)(((byte)(188)))));
            this.limpiarCampos.Location = new System.Drawing.Point(32, 305);
            this.limpiarCampos.Name = "limpiarCampos";
            this.limpiarCampos.Radius = 10;
            this.limpiarCampos.Size = new System.Drawing.Size(102, 40);
            this.limpiarCampos.Stroke = false;
            this.limpiarCampos.StrokeColor = System.Drawing.Color.Gray;
            this.limpiarCampos.TabIndex = 9;
            this.limpiarCampos.Text = "Limpiar campos";
            this.limpiarCampos.Transparency = false;
            this.limpiarCampos.Click += new System.EventHandler(this.limpiarCampos_Click);
            // 
            // FormCoachVerJugadores
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1049, 654);
            this.Controls.Add(this.limpiarCampos);
            this.Controls.Add(this.altoButton1);
            this.Controls.Add(this.dorsal);
            this.Controls.Add(this.height);
            this.Controls.Add(this.position);
            this.Controls.Add(this.name);
            this.Controls.Add(this.botonConsultas);
            this.Controls.Add(this.tablaJugadores);
            this.Name = "FormCoachVerJugadores";
            this.Text = "Form2";
            ((System.ComponentModel.ISupportInitialize)(this.tablaJugadores)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView tablaJugadores;
        private AltoControls.AltoButton botonConsultas;
        private System.Windows.Forms.TextBox name;
        private System.Windows.Forms.TextBox position;
        private System.Windows.Forms.TextBox height;
        private System.Windows.Forms.TextBox dorsal;
        private AltoControls.AltoButton altoButton1;
        private AltoControls.AltoButton limpiarCampos;
    }
}