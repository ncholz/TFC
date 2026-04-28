namespace HoopManager
{
    partial class Form4
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form4));
            this.cerrarSeesion = new AltoControls.AltoButton();
            this.volver = new AltoControls.AltoButton();
            this.tabla = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.tabla)).BeginInit();
            this.SuspendLayout();
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
            this.cerrarSeesion.Location = new System.Drawing.Point(2273, 596);
            this.cerrarSeesion.Margin = new System.Windows.Forms.Padding(4);
            this.cerrarSeesion.Name = "cerrarSeesion";
            this.cerrarSeesion.Radius = 25;
            this.cerrarSeesion.Size = new System.Drawing.Size(97, 78);
            this.cerrarSeesion.Stroke = false;
            this.cerrarSeesion.StrokeColor = System.Drawing.Color.Gray;
            this.cerrarSeesion.TabIndex = 6;
            this.cerrarSeesion.Transparency = false;
            this.cerrarSeesion.Click += new System.EventHandler(this.cerrarSeesion_Click);
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
            this.volver.Location = new System.Drawing.Point(2139, 619);
            this.volver.Margin = new System.Windows.Forms.Padding(4);
            this.volver.Name = "volver";
            this.volver.Radius = 10;
            this.volver.Size = new System.Drawing.Size(49, 39);
            this.volver.Stroke = false;
            this.volver.StrokeColor = System.Drawing.Color.Gray;
            this.volver.TabIndex = 5;
            this.volver.Transparency = false;
            this.volver.Click += new System.EventHandler(this.volver_Click);
            // 
            // tabla
            // 
            this.tabla.BackgroundColor = System.Drawing.Color.Navy;
            this.tabla.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tabla.GridColor = System.Drawing.Color.Orange;
            this.tabla.Location = new System.Drawing.Point(100, 100);
            this.tabla.Margin = new System.Windows.Forms.Padding(4);
            this.tabla.Name = "tabla";
            this.tabla.RowHeadersWidth = 51;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Navy;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Verdana", 13.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.DarkOrange;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black;
            this.tabla.RowsDefaultCellStyle = dataGridViewCellStyle1;
            this.tabla.Size = new System.Drawing.Size(1200, 500);
            this.tabla.TabIndex = 7;
            this.tabla.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.tabla_CellContentClick);
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
            this.label1.Size = new System.Drawing.Size(722, 73);
            this.label1.TabIndex = 13;
            this.label1.Text = "Historial de partidos";
            // 
            // Form4
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1602, 1033);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tabla);
            this.Controls.Add(this.cerrarSeesion);
            this.Controls.Add(this.volver);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form4";
            this.Text = "Form4";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.tabla)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private AltoControls.AltoButton cerrarSeesion;
        private AltoControls.AltoButton volver;
        private System.Windows.Forms.DataGridView tabla;
        private System.Windows.Forms.Label label1;
    }
}