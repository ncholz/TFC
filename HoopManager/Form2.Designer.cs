namespace HoopManager
{
    partial class Form2
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form2));
            this.tablaEntrenamientos = new System.Windows.Forms.DataGridView();
            this.bienvenida = new System.Windows.Forms.Label();
            this.cerrarSeesion = new AltoControls.AltoButton();
            this.altoButton1 = new AltoControls.AltoButton();
            this.volver = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.tablaEntrenamientos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.volver)).BeginInit();
            this.SuspendLayout();
            // 
            // tablaEntrenamientos
            // 
            this.tablaEntrenamientos.BackgroundColor = System.Drawing.Color.DarkOrange;
            this.tablaEntrenamientos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tablaEntrenamientos.GridColor = System.Drawing.Color.Navy;
            this.tablaEntrenamientos.Location = new System.Drawing.Point(0, 0);
            this.tablaEntrenamientos.Margin = new System.Windows.Forms.Padding(4);
            this.tablaEntrenamientos.Name = "tablaEntrenamientos";
            this.tablaEntrenamientos.RowHeadersWidth = 51;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Verdana", 13.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tablaEntrenamientos.RowsDefaultCellStyle = dataGridViewCellStyle1;
            this.tablaEntrenamientos.Size = new System.Drawing.Size(834, 403);
            this.tablaEntrenamientos.TabIndex = 0;
            this.tablaEntrenamientos.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.tablaEntrenamientos_CellContentClick);
            // 
            // bienvenida
            // 
            this.bienvenida.AutoSize = true;
            this.bienvenida.BackColor = System.Drawing.Color.DarkOrange;
            this.bienvenida.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bienvenida.Location = new System.Drawing.Point(26, 336);
            this.bienvenida.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.bienvenida.Name = "bienvenida";
            this.bienvenida.Size = new System.Drawing.Size(61, 20);
            this.bienvenida.TabIndex = 1;
            this.bienvenida.Text = "label1";
            // 
            // cerrarSeesion
            // 
            this.cerrarSeesion.Active1 = System.Drawing.Color.Transparent;
            this.cerrarSeesion.Active2 = System.Drawing.Color.Transparent;
            this.cerrarSeesion.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cerrarSeesion.BackColor = System.Drawing.Color.Transparent;
            this.cerrarSeesion.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.cerrarSeesion.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.cerrarSeesion.Font = new System.Drawing.Font("Comic Sans MS", 10F, System.Drawing.FontStyle.Bold);
            this.cerrarSeesion.ForeColor = System.Drawing.Color.Black;
            this.cerrarSeesion.Inactive1 = System.Drawing.Color.Transparent;
            this.cerrarSeesion.Inactive2 = System.Drawing.Color.Transparent;
            this.cerrarSeesion.Location = new System.Drawing.Point(1701, 218);
            this.cerrarSeesion.Margin = new System.Windows.Forms.Padding(4);
            this.cerrarSeesion.Name = "cerrarSeesion";
            this.cerrarSeesion.Radius = 25;
            this.cerrarSeesion.Size = new System.Drawing.Size(103, 87);
            this.cerrarSeesion.Stroke = false;
            this.cerrarSeesion.StrokeColor = System.Drawing.Color.Gray;
            this.cerrarSeesion.TabIndex = 3;
            this.cerrarSeesion.Transparency = false;
            this.cerrarSeesion.Click += new System.EventHandler(this.cerrarSeesion_Click);
            // 
            // altoButton1
            // 
            this.altoButton1.Active1 = System.Drawing.Color.Transparent;
            this.altoButton1.Active2 = System.Drawing.Color.Transparent;
            this.altoButton1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.altoButton1.BackColor = System.Drawing.Color.Transparent;
            this.altoButton1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.altoButton1.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.altoButton1.Font = new System.Drawing.Font("Comic Sans MS", 10F, System.Drawing.FontStyle.Bold);
            this.altoButton1.ForeColor = System.Drawing.Color.Black;
            this.altoButton1.Inactive1 = System.Drawing.Color.Transparent;
            this.altoButton1.Inactive2 = System.Drawing.Color.Transparent;
            this.altoButton1.Location = new System.Drawing.Point(1544, 237);
            this.altoButton1.Margin = new System.Windows.Forms.Padding(4);
            this.altoButton1.Name = "altoButton1";
            this.altoButton1.Radius = 10;
            this.altoButton1.Size = new System.Drawing.Size(63, 68);
            this.altoButton1.Stroke = false;
            this.altoButton1.StrokeColor = System.Drawing.Color.Gray;
            this.altoButton1.TabIndex = 4;
            this.altoButton1.Transparency = false;
            this.altoButton1.Click += new System.EventHandler(this.altoButton1_Click);
            // 
            // volver
            // 
            this.volver.BackColor = System.Drawing.Color.DarkOrange;
            this.volver.Image = ((System.Drawing.Image)(resources.GetObject("volver.Image")));
            this.volver.Location = new System.Drawing.Point(30, 270);
            this.volver.Name = "volver";
            this.volver.Size = new System.Drawing.Size(69, 63);
            this.volver.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.volver.TabIndex = 11;
            this.volver.TabStop = false;
            this.volver.Click += new System.EventHandler(this.cerrar_ventana);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(831, 396);
            this.Controls.Add(this.volver);
            this.Controls.Add(this.altoButton1);
            this.Controls.Add(this.cerrarSeesion);
            this.Controls.Add(this.bienvenida);
            this.Controls.Add(this.tablaEntrenamientos);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form2";
            this.Text = "Form2";
            this.Load += new System.EventHandler(this.Form2_Load);
            ((System.ComponentModel.ISupportInitialize)(this.tablaEntrenamientos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.volver)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView tablaEntrenamientos;
        private System.Windows.Forms.Label bienvenida;
        private AltoControls.AltoButton cerrarSeesion;
        private AltoControls.AltoButton altoButton1;
        private System.Windows.Forms.PictureBox volver;
    }
}