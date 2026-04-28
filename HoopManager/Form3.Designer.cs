namespace HoopManager
{
    partial class Form3
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form3));
            this.tablaLiga = new System.Windows.Forms.DataGridView();
            this.volver = new AltoControls.AltoButton();
            this.cerrarSeesion = new AltoControls.AltoButton();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.tablaLiga)).BeginInit();
            this.SuspendLayout();
            // 
            // tablaLiga
            // 
            this.tablaLiga.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tablaLiga.BackgroundColor = System.Drawing.Color.Navy;
            this.tablaLiga.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Verdana", 13.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.tablaLiga.DefaultCellStyle = dataGridViewCellStyle1;
            this.tablaLiga.GridColor = System.Drawing.Color.DarkOrange;
            this.tablaLiga.Location = new System.Drawing.Point(100, 100);
            this.tablaLiga.Margin = new System.Windows.Forms.Padding(4);
            this.tablaLiga.Name = "tablaLiga";
            this.tablaLiga.RowHeadersWidth = 51;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.Navy;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Verdana", 13.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.DarkOrange;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            this.tablaLiga.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.tablaLiga.Size = new System.Drawing.Size(1200, 500);
            this.tablaLiga.TabIndex = 0;
            this.tablaLiga.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.tablaLiga_CellContentClick);
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
            this.volver.Location = new System.Drawing.Point(2147, 638);
            this.volver.Margin = new System.Windows.Forms.Padding(4);
            this.volver.Name = "volver";
            this.volver.Radius = 10;
            this.volver.Size = new System.Drawing.Size(39, 37);
            this.volver.Stroke = false;
            this.volver.StrokeColor = System.Drawing.Color.Gray;
            this.volver.TabIndex = 1;
            this.volver.Transparency = false;
            this.volver.Click += new System.EventHandler(this.volver_Click_1);
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
            this.cerrarSeesion.Location = new System.Drawing.Point(2285, 607);
            this.cerrarSeesion.Margin = new System.Windows.Forms.Padding(4);
            this.cerrarSeesion.Name = "cerrarSeesion";
            this.cerrarSeesion.Radius = 25;
            this.cerrarSeesion.Size = new System.Drawing.Size(79, 68);
            this.cerrarSeesion.Stroke = false;
            this.cerrarSeesion.StrokeColor = System.Drawing.Color.Gray;
            this.cerrarSeesion.TabIndex = 4;
            this.cerrarSeesion.Transparency = false;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Verdana", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Navy;
            this.label1.Location = new System.Drawing.Point(87, 9);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(705, 73);
            this.label1.TabIndex = 14;
            this.label1.Text = "Tabla de temporada";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // Form3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1602, 1033);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cerrarSeesion);
            this.Controls.Add(this.volver);
            this.Controls.Add(this.tablaLiga);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form3";
            this.Text = "Form3";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.tablaLiga)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView tablaLiga;
        private AltoControls.AltoButton volver;
        private AltoControls.AltoButton cerrarSeesion;
        private System.Windows.Forms.Label label1;
    }
}