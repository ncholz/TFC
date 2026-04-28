namespace HoopManager
{
    partial class Form11
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form11));
            this.cmbJugador = new System.Windows.Forms.ListBox();
            this.txtTemporada = new System.Windows.Forms.TextBox();
            this.numPuntos = new System.Windows.Forms.NumericUpDown();
            this.numRebotes = new System.Windows.Forms.NumericUpDown();
            this.numAsistencias = new System.Windows.Forms.NumericUpDown();
            this.numTriple = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.dgvStatsHistoricas = new System.Windows.Forms.DataGridView();
            this.label6 = new System.Windows.Forms.Label();
            this.txtBusqueda = new System.Windows.Forms.TextBox();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label7 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numPuntos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numRebotes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numAsistencias)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numTriple)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStatsHistoricas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // cmbJugador
            // 
            this.cmbJugador.Font = new System.Drawing.Font("Verdana", 13.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbJugador.FormattingEnabled = true;
            this.cmbJugador.ItemHeight = 26;
            this.cmbJugador.Location = new System.Drawing.Point(470, 199);
            this.cmbJugador.Name = "cmbJugador";
            this.cmbJugador.Size = new System.Drawing.Size(161, 108);
            this.cmbJugador.TabIndex = 0;
            this.cmbJugador.SelectedIndexChanged += new System.EventHandler(this.cmbJugador_SelectedIndexChanged);
            // 
            // txtTemporada
            // 
            this.txtTemporada.Font = new System.Drawing.Font("Verdana", 13.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTemporada.Location = new System.Drawing.Point(743, 242);
            this.txtTemporada.Name = "txtTemporada";
            this.txtTemporada.Size = new System.Drawing.Size(159, 34);
            this.txtTemporada.TabIndex = 1;
            this.txtTemporada.TextChanged += new System.EventHandler(this.txtTemporada_TextChanged);
            // 
            // numPuntos
            // 
            this.numPuntos.DecimalPlaces = 1;
            this.numPuntos.Font = new System.Drawing.Font("Verdana", 13.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numPuntos.Location = new System.Drawing.Point(613, 406);
            this.numPuntos.Maximum = new decimal(new int[] {
            1000000000,
            0,
            0,
            0});
            this.numPuntos.Name = "numPuntos";
            this.numPuntos.Size = new System.Drawing.Size(183, 34);
            this.numPuntos.TabIndex = 2;
            this.numPuntos.ValueChanged += new System.EventHandler(this.numPuntos_ValueChanged);
            // 
            // numRebotes
            // 
            this.numRebotes.DecimalPlaces = 1;
            this.numRebotes.Font = new System.Drawing.Font("Verdana", 13.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numRebotes.Location = new System.Drawing.Point(821, 406);
            this.numRebotes.Maximum = new decimal(new int[] {
            100000000,
            0,
            0,
            0});
            this.numRebotes.Name = "numRebotes";
            this.numRebotes.Size = new System.Drawing.Size(190, 34);
            this.numRebotes.TabIndex = 3;
            this.numRebotes.ValueChanged += new System.EventHandler(this.numRebotes_ValueChanged);
            // 
            // numAsistencias
            // 
            this.numAsistencias.DecimalPlaces = 1;
            this.numAsistencias.Font = new System.Drawing.Font("Verdana", 13.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numAsistencias.Location = new System.Drawing.Point(1029, 406);
            this.numAsistencias.Maximum = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.numAsistencias.Name = "numAsistencias";
            this.numAsistencias.Size = new System.Drawing.Size(239, 34);
            this.numAsistencias.TabIndex = 4;
            this.numAsistencias.ValueChanged += new System.EventHandler(this.numAsistencias_ValueChanged);
            // 
            // numTriple
            // 
            this.numTriple.DecimalPlaces = 1;
            this.numTriple.Font = new System.Drawing.Font("Verdana", 13.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numTriple.Location = new System.Drawing.Point(1287, 406);
            this.numTriple.Name = "numTriple";
            this.numTriple.Size = new System.Drawing.Size(112, 34);
            this.numTriple.TabIndex = 5;
            this.numTriple.ValueChanged += new System.EventHandler(this.numTriple_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 13.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(608, 369);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(182, 26);
            this.label1.TabIndex = 7;
            this.label1.Text = "Puntos media";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Verdana", 13.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(816, 369);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(196, 26);
            this.label2.TabIndex = 8;
            this.label2.Text = "Rebotes media";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Verdana", 13.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(1024, 369);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(237, 26);
            this.label3.TabIndex = 9;
            this.label3.Text = "Asistencias media";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Verdana", 13.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(1282, 369);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(115, 26);
            this.label4.TabIndex = 10;
            this.label4.Text = "% triple";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Verdana", 13.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(743, 211);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(151, 26);
            this.label5.TabIndex = 14;
            this.label5.Text = "Temporada";
            // 
            // dgvStatsHistoricas
            // 
            this.dgvStatsHistoricas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvStatsHistoricas.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvStatsHistoricas.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Verdana", 7.8F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvStatsHistoricas.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvStatsHistoricas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvStatsHistoricas.Location = new System.Drawing.Point(244, 632);
            this.dgvStatsHistoricas.Name = "dgvStatsHistoricas";
            this.dgvStatsHistoricas.RowHeadersWidth = 51;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.DarkOrange;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Verdana", 13.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.Navy;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White;
            this.dgvStatsHistoricas.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvStatsHistoricas.RowTemplate.Height = 24;
            this.dgvStatsHistoricas.Size = new System.Drawing.Size(1044, 367);
            this.dgvStatsHistoricas.TabIndex = 15;
            this.dgvStatsHistoricas.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvStatsHistoricas_CellClick);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Verdana", 28.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(84, 75);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(1113, 57);
            this.label6.TabIndex = 16;
            this.label6.Text = "GESTIÓN DE ESTADISTICAS HISTORICAS";
            // 
            // txtBusqueda
            // 
            this.txtBusqueda.Font = new System.Drawing.Font("Verdana", 13.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBusqueda.Location = new System.Drawing.Point(200, 406);
            this.txtBusqueda.Name = "txtBusqueda";
            this.txtBusqueda.Size = new System.Drawing.Size(311, 34);
            this.txtBusqueda.TabIndex = 17;
            this.txtBusqueda.Text = "Buscar";
            this.txtBusqueda.TextChanged += new System.EventHandler(this.txtBusqueda_TextChanged_1);
            // 
            // btnGuardar
            // 
            this.btnGuardar.BackColor = System.Drawing.Color.Transparent;
            this.btnGuardar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnGuardar.BackgroundImage")));
            this.btnGuardar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnGuardar.Font = new System.Drawing.Font("Verdana", 7.8F);
            this.btnGuardar.Location = new System.Drawing.Point(721, 527);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(150, 39);
            this.btnGuardar.TabIndex = 18;
            this.btnGuardar.UseVisualStyleBackColor = false;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // btnEliminar
            // 
            this.btnEliminar.BackColor = System.Drawing.Color.Transparent;
            this.btnEliminar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnEliminar.BackgroundImage")));
            this.btnEliminar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnEliminar.Font = new System.Drawing.Font("Verdana", 7.8F);
            this.btnEliminar.Location = new System.Drawing.Point(908, 527);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(150, 39);
            this.btnEliminar.TabIndex = 19;
            this.btnEliminar.UseVisualStyleBackColor = false;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.BackColor = System.Drawing.Color.Transparent;
            this.btnLimpiar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnLimpiar.BackgroundImage")));
            this.btnLimpiar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnLimpiar.Font = new System.Drawing.Font("Verdana", 7.8F);
            this.btnLimpiar.Location = new System.Drawing.Point(1091, 527);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(150, 39);
            this.btnLimpiar.TabIndex = 20;
            this.btnLimpiar.UseVisualStyleBackColor = false;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(134, 389);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(60, 51);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 26;
            this.pictureBox1.TabStop = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Verdana", 13.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(471, 168);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(111, 26);
            this.label7.TabIndex = 27;
            this.label7.Text = "Jugador";
            this.label7.Click += new System.EventHandler(this.label7_Click);
            // 
            // Form11
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.ClientSize = new System.Drawing.Size(1490, 1099);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btnLimpiar);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.txtBusqueda);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.dgvStatsHistoricas);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.numTriple);
            this.Controls.Add(this.numAsistencias);
            this.Controls.Add(this.numRebotes);
            this.Controls.Add(this.numPuntos);
            this.Controls.Add(this.txtTemporada);
            this.Controls.Add(this.cmbJugador);
            this.Location = new System.Drawing.Point(300, 0);
            this.Name = "Form11";
            this.Text = "Form11";
            this.Load += new System.EventHandler(this.Form11_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numPuntos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numRebotes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numAsistencias)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numTriple)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStatsHistoricas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox cmbJugador;
        private System.Windows.Forms.TextBox txtTemporada;
        private System.Windows.Forms.NumericUpDown numPuntos;
        private System.Windows.Forms.NumericUpDown numRebotes;
        private System.Windows.Forms.NumericUpDown numAsistencias;
        private System.Windows.Forms.NumericUpDown numTriple;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridView dgvStatsHistoricas;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtBusqueda;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label7;
    }
}