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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tablaJugadores = new System.Windows.Forms.DataGridView();
            this.name = new System.Windows.Forms.TextBox();
            this.position = new System.Windows.Forms.TextBox();
            this.height = new System.Windows.Forms.TextBox();
            this.dorsal = new System.Windows.Forms.TextBox();
            this.altoButton1 = new AltoControls.AltoButton();
            this.limpiarCampos = new AltoControls.AltoButton();
            this.cerrarSeesion = new AltoControls.AltoButton();
            this.volver = new AltoControls.AltoButton();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.tablaJugadores)).BeginInit();
            this.SuspendLayout();
            // 
            // tablaJugadores
            // 
            this.tablaJugadores.BackgroundColor = System.Drawing.Color.Navy;
            this.tablaJugadores.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tablaJugadores.GridColor = System.Drawing.Color.DarkOrange;
            this.tablaJugadores.Location = new System.Drawing.Point(100, 100);
            this.tablaJugadores.Margin = new System.Windows.Forms.Padding(4);
            this.tablaJugadores.Name = "tablaJugadores";
            this.tablaJugadores.RowHeadersWidth = 51;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Navy;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Verdana", 13.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.DarkOrange;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black;
            this.tablaJugadores.RowsDefaultCellStyle = dataGridViewCellStyle1;
            this.tablaJugadores.Size = new System.Drawing.Size(1200, 500);
            this.tablaJugadores.TabIndex = 0;
            this.tablaJugadores.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.tablaJugadores_CellContentClick);
            // 
            // name
            // 
            this.name.Font = new System.Drawing.Font("Verdana", 13.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.name.Location = new System.Drawing.Point(468, 641);
            this.name.Margin = new System.Windows.Forms.Padding(4);
            this.name.Name = "name";
            this.name.Size = new System.Drawing.Size(229, 34);
            this.name.TabIndex = 3;
            this.name.Text = "Nombre";
            this.name.TextChanged += new System.EventHandler(this.name_TextChanged);
            // 
            // position
            // 
            this.position.Font = new System.Drawing.Font("Verdana", 13.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.position.Location = new System.Drawing.Point(468, 697);
            this.position.Margin = new System.Windows.Forms.Padding(4);
            this.position.Name = "position";
            this.position.Size = new System.Drawing.Size(229, 34);
            this.position.TabIndex = 4;
            this.position.Text = "Posicion";
            this.position.TextChanged += new System.EventHandler(this.position_TextChanged);
            // 
            // height
            // 
            this.height.Font = new System.Drawing.Font("Verdana", 13.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.height.Location = new System.Drawing.Point(468, 749);
            this.height.Margin = new System.Windows.Forms.Padding(4);
            this.height.Name = "height";
            this.height.Size = new System.Drawing.Size(229, 34);
            this.height.TabIndex = 5;
            this.height.Text = "Altura(cm)";
            this.height.TextChanged += new System.EventHandler(this.height_TextChanged);
            // 
            // dorsal
            // 
            this.dorsal.Font = new System.Drawing.Font("Verdana", 13.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dorsal.Location = new System.Drawing.Point(468, 801);
            this.dorsal.Margin = new System.Windows.Forms.Padding(4);
            this.dorsal.Name = "dorsal";
            this.dorsal.Size = new System.Drawing.Size(229, 34);
            this.dorsal.TabIndex = 6;
            this.dorsal.Text = "Dorsal";
            this.dorsal.TextChanged += new System.EventHandler(this.dorsal_TextChanged);
            // 
            // altoButton1
            // 
            this.altoButton1.Active1 = System.Drawing.Color.SandyBrown;
            this.altoButton1.Active2 = System.Drawing.Color.SandyBrown;
            this.altoButton1.BackColor = System.Drawing.Color.Transparent;
            this.altoButton1.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.altoButton1.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.altoButton1.ForeColor = System.Drawing.Color.Navy;
            this.altoButton1.Inactive1 = System.Drawing.Color.DarkOrange;
            this.altoButton1.Inactive2 = System.Drawing.Color.DarkOrange;
            this.altoButton1.Location = new System.Drawing.Point(809, 641);
            this.altoButton1.Margin = new System.Windows.Forms.Padding(4);
            this.altoButton1.Name = "altoButton1";
            this.altoButton1.Radius = 10;
            this.altoButton1.Size = new System.Drawing.Size(191, 71);
            this.altoButton1.Stroke = false;
            this.altoButton1.StrokeColor = System.Drawing.Color.Gray;
            this.altoButton1.TabIndex = 8;
            this.altoButton1.Text = "Ver entrenamientos recomendados";
            this.altoButton1.Transparency = false;
            this.altoButton1.Click += new System.EventHandler(this.altoButton1_Click);
            // 
            // limpiarCampos
            // 
            this.limpiarCampos.Active1 = System.Drawing.Color.SandyBrown;
            this.limpiarCampos.Active2 = System.Drawing.Color.SandyBrown;
            this.limpiarCampos.BackColor = System.Drawing.Color.Transparent;
            this.limpiarCampos.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.limpiarCampos.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.limpiarCampos.ForeColor = System.Drawing.Color.Navy;
            this.limpiarCampos.Inactive1 = System.Drawing.Color.DarkOrange;
            this.limpiarCampos.Inactive2 = System.Drawing.Color.DarkOrange;
            this.limpiarCampos.Location = new System.Drawing.Point(809, 739);
            this.limpiarCampos.Margin = new System.Windows.Forms.Padding(4);
            this.limpiarCampos.Name = "limpiarCampos";
            this.limpiarCampos.Radius = 10;
            this.limpiarCampos.Size = new System.Drawing.Size(191, 71);
            this.limpiarCampos.Stroke = false;
            this.limpiarCampos.StrokeColor = System.Drawing.Color.Gray;
            this.limpiarCampos.TabIndex = 9;
            this.limpiarCampos.Text = "Limpiar campos";
            this.limpiarCampos.Transparency = false;
            this.limpiarCampos.Click += new System.EventHandler(this.limpiarCampos_Click);
            // 
            // cerrarSeesion
            // 
            this.cerrarSeesion.Active1 = System.Drawing.Color.Transparent;
            this.cerrarSeesion.Active2 = System.Drawing.Color.Transparent;
            this.cerrarSeesion.BackColor = System.Drawing.Color.Transparent;
            this.cerrarSeesion.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.cerrarSeesion.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.cerrarSeesion.Font = new System.Drawing.Font("Comic Sans MS", 10F, System.Drawing.FontStyle.Bold);
            this.cerrarSeesion.ForeColor = System.Drawing.Color.Black;
            this.cerrarSeesion.Inactive1 = System.Drawing.Color.Transparent;
            this.cerrarSeesion.Inactive2 = System.Drawing.Color.Transparent;
            this.cerrarSeesion.Location = new System.Drawing.Point(2257, 534);
            this.cerrarSeesion.Margin = new System.Windows.Forms.Padding(4);
            this.cerrarSeesion.Name = "cerrarSeesion";
            this.cerrarSeesion.Radius = 25;
            this.cerrarSeesion.Size = new System.Drawing.Size(72, 64);
            this.cerrarSeesion.Stroke = false;
            this.cerrarSeesion.StrokeColor = System.Drawing.Color.Gray;
            this.cerrarSeesion.TabIndex = 11;
            this.cerrarSeesion.Transparency = false;
            this.cerrarSeesion.Click += new System.EventHandler(this.cerrarSeesion_Click_1);
            // 
            // volver
            // 
            this.volver.Active1 = System.Drawing.Color.Transparent;
            this.volver.Active2 = System.Drawing.Color.Transparent;
            this.volver.BackColor = System.Drawing.Color.Transparent;
            this.volver.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.volver.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.volver.Font = new System.Drawing.Font("Comic Sans MS", 10F, System.Drawing.FontStyle.Bold);
            this.volver.ForeColor = System.Drawing.Color.Black;
            this.volver.Inactive1 = System.Drawing.Color.Transparent;
            this.volver.Inactive2 = System.Drawing.Color.Transparent;
            this.volver.Location = new System.Drawing.Point(2121, 545);
            this.volver.Margin = new System.Windows.Forms.Padding(4);
            this.volver.Name = "volver";
            this.volver.Radius = 10;
            this.volver.Size = new System.Drawing.Size(45, 37);
            this.volver.Stroke = false;
            this.volver.StrokeColor = System.Drawing.Color.Gray;
            this.volver.TabIndex = 10;
            this.volver.Transparency = false;
            this.volver.Click += new System.EventHandler(this.volver_Click_1);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Verdana", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Navy;
            this.label2.Location = new System.Drawing.Point(87, 9);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(407, 73);
            this.label2.TabIndex = 18;
            this.label2.Text = "Mi plantilla";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 13.8F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(172, 641);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(249, 28);
            this.label1.TabIndex = 19;
            this.label1.Text = "Nombre completo:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Verdana", 13.8F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(291, 697);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(130, 28);
            this.label3.TabIndex = 20;
            this.label3.Text = "Posición:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Verdana", 13.8F, System.Drawing.FontStyle.Bold);
            this.label4.Location = new System.Drawing.Point(322, 751);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(99, 28);
            this.label4.TabIndex = 21;
            this.label4.Text = "Altura:";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Verdana", 13.8F, System.Drawing.FontStyle.Bold);
            this.label5.Location = new System.Drawing.Point(317, 803);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(104, 28);
            this.label5.TabIndex = 22;
            this.label5.Text = "Dorsal:";
            // 
            // FormCoachVerJugadores
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1582, 1033);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cerrarSeesion);
            this.Controls.Add(this.volver);
            this.Controls.Add(this.limpiarCampos);
            this.Controls.Add(this.altoButton1);
            this.Controls.Add(this.dorsal);
            this.Controls.Add(this.height);
            this.Controls.Add(this.position);
            this.Controls.Add(this.name);
            this.Controls.Add(this.tablaJugadores);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FormCoachVerJugadores";
            this.Text = "Form2";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FormCoachVerJugadores_Load);
            ((System.ComponentModel.ISupportInitialize)(this.tablaJugadores)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView tablaJugadores;
        private System.Windows.Forms.TextBox name;
        private System.Windows.Forms.TextBox position;
        private System.Windows.Forms.TextBox height;
        private System.Windows.Forms.TextBox dorsal;
        private AltoControls.AltoButton altoButton1;
        private AltoControls.AltoButton limpiarCampos;
        private AltoControls.AltoButton cerrarSeesion;
        private AltoControls.AltoButton volver;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
    }
}