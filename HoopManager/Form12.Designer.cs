namespace HoopManager
{
    partial class Form12
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form12));
            this.cmbLocal = new System.Windows.Forms.ListBox();
            this.cmbVisitante = new System.Windows.Forms.ListBox();
            this.dtpFecha = new System.Windows.Forms.DateTimePicker();
            this.Jornada = new System.Windows.Forms.Label();
            this.dgvPartidos = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.numJornada = new AltoControls.AltoNMUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.btnGestionarStats = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPartidos)).BeginInit();
            this.SuspendLayout();
            // 
            // cmbLocal
            // 
            this.cmbLocal.BackColor = System.Drawing.Color.White;
            this.cmbLocal.Font = new System.Drawing.Font("Verdana", 13.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbLocal.FormattingEnabled = true;
            this.cmbLocal.ItemHeight = 26;
            this.cmbLocal.Location = new System.Drawing.Point(202, 212);
            this.cmbLocal.Name = "cmbLocal";
            this.cmbLocal.Size = new System.Drawing.Size(158, 134);
            this.cmbLocal.TabIndex = 0;
            this.cmbLocal.SelectedIndexChanged += new System.EventHandler(this.cmbLocal_SelectedIndexChanged);
            // 
            // cmbVisitante
            // 
            this.cmbVisitante.BackColor = System.Drawing.Color.White;
            this.cmbVisitante.Font = new System.Drawing.Font("Verdana", 13.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbVisitante.FormattingEnabled = true;
            this.cmbVisitante.ItemHeight = 26;
            this.cmbVisitante.Location = new System.Drawing.Point(466, 212);
            this.cmbVisitante.Name = "cmbVisitante";
            this.cmbVisitante.Size = new System.Drawing.Size(158, 134);
            this.cmbVisitante.TabIndex = 1;
            this.cmbVisitante.SelectedIndexChanged += new System.EventHandler(this.cmbVisitante_SelectedIndexChanged);
            // 
            // dtpFecha
            // 
            this.dtpFecha.Font = new System.Drawing.Font("Verdana", 13.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFecha.Location = new System.Drawing.Point(935, 226);
            this.dtpFecha.Name = "dtpFecha";
            this.dtpFecha.Size = new System.Drawing.Size(194, 34);
            this.dtpFecha.TabIndex = 2;
            this.dtpFecha.ValueChanged += new System.EventHandler(this.dtpFecha_ValueChanged);
            // 
            // Jornada
            // 
            this.Jornada.AutoSize = true;
            this.Jornada.Font = new System.Drawing.Font("Verdana", 13.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Jornada.Location = new System.Drawing.Point(880, 312);
            this.Jornada.Name = "Jornada";
            this.Jornada.Size = new System.Drawing.Size(114, 28);
            this.Jornada.TabIndex = 3;
            this.Jornada.Text = "Jornada";
            // 
            // dgvPartidos
            // 
            this.dgvPartidos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvPartidos.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvPartidos.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Verdana", 7.8F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvPartidos.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvPartidos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPartidos.GridColor = System.Drawing.Color.DarkOrange;
            this.dgvPartidos.Location = new System.Drawing.Point(161, 571);
            this.dgvPartidos.Name = "dgvPartidos";
            this.dgvPartidos.RowHeadersWidth = 51;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.DarkOrange;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Verdana", 13.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.Navy;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White;
            this.dgvPartidos.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvPartidos.RowTemplate.Height = 24;
            this.dgvPartidos.Size = new System.Drawing.Size(1098, 436);
            this.dgvPartidos.TabIndex = 17;
            this.dgvPartidos.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPartidos_CellContentClickk);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 13.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(389, 276);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 28);
            this.label1.TabIndex = 18;
            this.label1.Text = "VS";
            // 
            // numJornada
            // 
            this.numJornada.Font = new System.Drawing.Font("Verdana", 13.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numJornada.ForeColor = System.Drawing.SystemColors.Info;
            this.numJornada.Location = new System.Drawing.Point(1000, 292);
            this.numJornada.Name = "numJornada";
            this.numJornada.SignColor = System.Drawing.SystemColors.Window;
            this.numJornada.Size = new System.Drawing.Size(160, 54);
            this.numJornada.TabIndex = 24;
            this.numJornada.Value = 0D;
            this.numJornada.Click += new System.EventHandler(this.numJornada_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Verdana", 13.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(197, 172);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(169, 28);
            this.label2.TabIndex = 25;
            this.label2.Text = "Equipo local";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Verdana", 13.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(461, 172);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(219, 28);
            this.label3.TabIndex = 26;
            this.label3.Text = "Equipo visitante";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Verdana", 28.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(84, 75);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(646, 57);
            this.label4.TabIndex = 27;
            this.label4.Text = "GESTIÓN DE PARTIDOS";
            // 
            // btnGuardar
            // 
            this.btnGuardar.BackColor = System.Drawing.Color.Transparent;
            this.btnGuardar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnGuardar.BackgroundImage")));
            this.btnGuardar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnGuardar.Font = new System.Drawing.Font("Verdana", 7.8F);
            this.btnGuardar.Location = new System.Drawing.Point(856, 415);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(150, 39);
            this.btnGuardar.TabIndex = 28;
            this.btnGuardar.UseVisualStyleBackColor = false;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click_1);
            // 
            // btnEliminar
            // 
            this.btnEliminar.BackColor = System.Drawing.Color.Transparent;
            this.btnEliminar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnEliminar.BackgroundImage")));
            this.btnEliminar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnEliminar.Font = new System.Drawing.Font("Verdana", 7.8F);
            this.btnEliminar.Location = new System.Drawing.Point(1025, 415);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(150, 39);
            this.btnEliminar.TabIndex = 29;
            this.btnEliminar.UseVisualStyleBackColor = false;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click_1);
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.BackColor = System.Drawing.Color.Transparent;
            this.btnLimpiar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnLimpiar.BackgroundImage")));
            this.btnLimpiar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnLimpiar.Font = new System.Drawing.Font("Verdana", 7.8F);
            this.btnLimpiar.Location = new System.Drawing.Point(1189, 415);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(150, 39);
            this.btnLimpiar.TabIndex = 30;
            this.btnLimpiar.UseVisualStyleBackColor = false;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click_1);
            // 
            // btnGestionarStats
            // 
            this.btnGestionarStats.BackColor = System.Drawing.Color.Transparent;
            this.btnGestionarStats.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnGestionarStats.Font = new System.Drawing.Font("Verdana", 13.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGestionarStats.Location = new System.Drawing.Point(935, 475);
            this.btnGestionarStats.Name = "btnGestionarStats";
            this.btnGestionarStats.Size = new System.Drawing.Size(314, 39);
            this.btnGestionarStats.TabIndex = 31;
            this.btnGestionarStats.Text = "Gestionar estadisticas";
            this.btnGestionarStats.UseVisualStyleBackColor = false;
            this.btnGestionarStats.Click += new System.EventHandler(this.btnGestionarStats_Click_1);
            // 
            // Form12
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.ClientSize = new System.Drawing.Size(1490, 1099);
            this.Controls.Add(this.btnGestionarStats);
            this.Controls.Add(this.btnLimpiar);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.numJornada);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvPartidos);
            this.Controls.Add(this.Jornada);
            this.Controls.Add(this.dtpFecha);
            this.Controls.Add(this.cmbVisitante);
            this.Controls.Add(this.cmbLocal);
            this.Location = new System.Drawing.Point(300, 0);
            this.Name = "Form12";
            this.Text = "Form12";
            this.Load += new System.EventHandler(this.Form12_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPartidos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox cmbLocal;
        private System.Windows.Forms.ListBox cmbVisitante;
        private System.Windows.Forms.DateTimePicker dtpFecha;
        private System.Windows.Forms.Label Jornada;
        private System.Windows.Forms.DataGridView dgvPartidos;
        private System.Windows.Forms.Label label1;
        private AltoControls.AltoNMUpDown numJornada;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.Button btnGestionarStats;
    }
}