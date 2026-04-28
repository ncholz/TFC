namespace HoopManager
{
    partial class Form5
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form5));
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.cerrarSeesion = new AltoControls.AltoButton();
            this.volver = new AltoControls.AltoButton();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.txtBusqueda = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.BackgroundColor = System.Drawing.Color.Navy;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.GridColor = System.Drawing.Color.DarkOrange;
            this.dataGridView1.Location = new System.Drawing.Point(100, 100);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(4);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.Navy;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Verdana", 13.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.DarkOrange;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black;
            this.dataGridView1.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridView1.Size = new System.Drawing.Size(1200, 500);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
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
            this.cerrarSeesion.Location = new System.Drawing.Point(2144, 479);
            this.cerrarSeesion.Margin = new System.Windows.Forms.Padding(4);
            this.cerrarSeesion.Name = "cerrarSeesion";
            this.cerrarSeesion.Radius = 25;
            this.cerrarSeesion.Size = new System.Drawing.Size(97, 86);
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
            this.volver.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.volver.BackColor = System.Drawing.Color.Transparent;
            this.volver.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.volver.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.volver.Font = new System.Drawing.Font("Comic Sans MS", 10F, System.Drawing.FontStyle.Bold);
            this.volver.ForeColor = System.Drawing.Color.Black;
            this.volver.Inactive1 = System.Drawing.Color.Transparent;
            this.volver.Inactive2 = System.Drawing.Color.Transparent;
            this.volver.Location = new System.Drawing.Point(2008, 498);
            this.volver.Margin = new System.Windows.Forms.Padding(4);
            this.volver.Name = "volver";
            this.volver.Radius = 10;
            this.volver.Size = new System.Drawing.Size(47, 42);
            this.volver.Stroke = false;
            this.volver.StrokeColor = System.Drawing.Color.Gray;
            this.volver.TabIndex = 10;
            this.volver.Transparency = false;
            this.volver.Click += new System.EventHandler(this.volver_Click_1);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Verdana", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Navy;
            this.label1.Location = new System.Drawing.Point(87, 9);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(764, 73);
            this.label1.TabIndex = 12;
            this.label1.Text = "Scouteo de jugadores";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(133, 637);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(60, 51);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 26;
            this.pictureBox1.TabStop = false;
            // 
            // txtBusqueda
            // 
            this.txtBusqueda.Font = new System.Drawing.Font("Verdana", 13.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBusqueda.Location = new System.Drawing.Point(199, 647);
            this.txtBusqueda.Name = "txtBusqueda";
            this.txtBusqueda.Size = new System.Drawing.Size(244, 34);
            this.txtBusqueda.TabIndex = 25;
            this.txtBusqueda.Text = "Buscar";
            this.txtBusqueda.TextChanged += new System.EventHandler(this.txtBusqueda_TextChanged);
            // 
            // Form5
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1602, 1033);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.txtBusqueda);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cerrarSeesion);
            this.Controls.Add(this.volver);
            this.Controls.Add(this.dataGridView1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form5";
            this.Text = "Form5";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form5_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private AltoControls.AltoButton cerrarSeesion;
        private AltoControls.AltoButton volver;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox txtBusqueda;
    }
}