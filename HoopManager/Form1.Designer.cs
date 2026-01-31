namespace HoopManager
{
    partial class login
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(login));
            this.cajaContenido = new System.Windows.Forms.GroupBox();
            this.botonLogin = new AltoControls.AltoButton();
            this.altoButton1 = new AltoControls.AltoButton();
            this.password = new System.Windows.Forms.TextBox();
            this.user = new System.Windows.Forms.TextBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.cajaContenido.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // cajaContenido
            // 
            this.cajaContenido.BackColor = System.Drawing.Color.White;
            this.cajaContenido.Controls.Add(this.botonLogin);
            this.cajaContenido.Controls.Add(this.altoButton1);
            this.cajaContenido.Controls.Add(this.password);
            this.cajaContenido.Controls.Add(this.user);
            this.cajaContenido.Controls.Add(this.pictureBox2);
            this.cajaContenido.Location = new System.Drawing.Point(272, 146);
            this.cajaContenido.Margin = new System.Windows.Forms.Padding(2);
            this.cajaContenido.Name = "cajaContenido";
            this.cajaContenido.Padding = new System.Windows.Forms.Padding(2);
            this.cajaContenido.Size = new System.Drawing.Size(550, 417);
            this.cajaContenido.TabIndex = 0;
            this.cajaContenido.TabStop = false;
            this.cajaContenido.Enter += new System.EventHandler(this.cajaContenido_Enter);
            // 
            // botonLogin
            // 
            this.botonLogin.Active1 = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(168)))), ((int)(((byte)(183)))));
            this.botonLogin.Active2 = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(164)))), ((int)(((byte)(183)))));
            this.botonLogin.BackColor = System.Drawing.Color.Transparent;
            this.botonLogin.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.botonLogin.Font = new System.Drawing.Font("Comic Sans MS", 10F, System.Drawing.FontStyle.Bold);
            this.botonLogin.ForeColor = System.Drawing.Color.Black;
            this.botonLogin.Inactive1 = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(188)))), ((int)(((byte)(210)))));
            this.botonLogin.Inactive2 = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(167)))), ((int)(((byte)(188)))));
            this.botonLogin.Location = new System.Drawing.Point(378, 319);
            this.botonLogin.Name = "botonLogin";
            this.botonLogin.Radius = 10;
            this.botonLogin.Size = new System.Drawing.Size(65, 30);
            this.botonLogin.Stroke = false;
            this.botonLogin.StrokeColor = System.Drawing.Color.Gray;
            this.botonLogin.TabIndex = 5;
            this.botonLogin.Text = "Entrar";
            this.botonLogin.Transparency = false;
            this.botonLogin.Click += new System.EventHandler(this.botonLogin_Click);
            // 
            // altoButton1
            // 
            this.altoButton1.Active1 = System.Drawing.Color.Transparent;
            this.altoButton1.Active2 = System.Drawing.Color.Transparent;
            this.altoButton1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.altoButton1.BackColor = System.Drawing.Color.Transparent;
            this.altoButton1.BackgroundImage = global::HoopManager.Properties.Resources.foto_canasta;
            this.altoButton1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.altoButton1.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.altoButton1.Font = new System.Drawing.Font("Comic Sans MS", 10F, System.Drawing.FontStyle.Bold);
            this.altoButton1.ForeColor = System.Drawing.Color.Black;
            this.altoButton1.Inactive1 = System.Drawing.Color.Transparent;
            this.altoButton1.Inactive2 = System.Drawing.Color.Transparent;
            this.altoButton1.Location = new System.Drawing.Point(0, 0);
            this.altoButton1.Name = "altoButton1";
            this.altoButton1.Radius = 50;
            this.altoButton1.Size = new System.Drawing.Size(305, 417);
            this.altoButton1.Stroke = false;
            this.altoButton1.StrokeColor = System.Drawing.Color.Gray;
            this.altoButton1.TabIndex = 1;
            this.altoButton1.Transparency = false;
            // 
            // password
            // 
            this.password.Location = new System.Drawing.Point(364, 262);
            this.password.Name = "password";
            this.password.Size = new System.Drawing.Size(100, 20);
            this.password.TabIndex = 4;
            this.password.Text = "Contraseña";
            this.password.TextChanged += new System.EventHandler(this.password_TextChanged);
            // 
            // user
            // 
            this.user.Location = new System.Drawing.Point(364, 219);
            this.user.Name = "user";
            this.user.Size = new System.Drawing.Size(100, 20);
            this.user.TabIndex = 3;
            this.user.Text = "Usuario";
            this.user.TextChanged += new System.EventHandler(this.user_TextChanged);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::HoopManager.Properties.Resources.logo_HoopManager_SinFondo;
            this.pictureBox2.Location = new System.Drawing.Point(277, 0);
            this.pictureBox2.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(273, 199);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 2;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Click += new System.EventHandler(this.pictureBox2_Click);
            // 
            // login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ClientSize = new System.Drawing.Size(1050, 696);
            this.Controls.Add(this.cajaContenido);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "login";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "login";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.login_Load);
            this.cajaContenido.ResumeLayout(false);
            this.cajaContenido.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox cajaContenido;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.TextBox password;
        private System.Windows.Forms.TextBox user;
        private AltoControls.AltoButton altoButton1;
        private AltoControls.AltoButton botonLogin;
    }


}

