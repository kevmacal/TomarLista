
namespace TomarLista
{
    partial class Login
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
            this.loginPB = new System.Windows.Forms.PictureBox();
            this.lUser = new System.Windows.Forms.Label();
            this.lPass = new System.Windows.Forms.Label();
            this.tbUser = new System.Windows.Forms.TextBox();
            this.tbPass = new System.Windows.Forms.TextBox();
            this.btnLogin = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.loginPB)).BeginInit();
            this.SuspendLayout();
            // 
            // loginPB
            // 
            this.loginPB.Image = global::TomarLista.Properties.Resources.loginBar;
            this.loginPB.Location = new System.Drawing.Point(0, 0);
            this.loginPB.Name = "loginPB";
            this.loginPB.Size = new System.Drawing.Size(310, 60);
            this.loginPB.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.loginPB.TabIndex = 0;
            this.loginPB.TabStop = false;
            // 
            // lUser
            // 
            this.lUser.AutoSize = true;
            this.lUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lUser.Location = new System.Drawing.Point(45, 88);
            this.lUser.Name = "lUser";
            this.lUser.Size = new System.Drawing.Size(55, 16);
            this.lUser.TabIndex = 1;
            this.lUser.Text = "Usuario";
            // 
            // lPass
            // 
            this.lPass.AutoSize = true;
            this.lPass.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lPass.Location = new System.Drawing.Point(23, 115);
            this.lPass.Name = "lPass";
            this.lPass.Size = new System.Drawing.Size(77, 16);
            this.lPass.TabIndex = 2;
            this.lPass.Text = "Contraseña";
            // 
            // tbUser
            // 
            this.tbUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbUser.Location = new System.Drawing.Point(106, 85);
            this.tbUser.Name = "tbUser";
            this.tbUser.Size = new System.Drawing.Size(156, 22);
            this.tbUser.TabIndex = 3;
            // 
            // tbPass
            // 
            this.tbPass.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbPass.Location = new System.Drawing.Point(106, 112);
            this.tbPass.Name = "tbPass";
            this.tbPass.PasswordChar = '*';
            this.tbPass.Size = new System.Drawing.Size(156, 22);
            this.tbPass.TabIndex = 4;
            // 
            // btnLogin
            // 
            this.btnLogin.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogin.Location = new System.Drawing.Point(142, 140);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(75, 25);
            this.btnLogin.TabIndex = 5;
            this.btnLogin.Text = "Ingresar";
            this.btnLogin.UseVisualStyleBackColor = true;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSalir.Location = new System.Drawing.Point(223, 140);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(75, 25);
            this.btnSalir.TabIndex = 6;
            this.btnSalir.Text = "Salir";
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ClientSize = new System.Drawing.Size(310, 177);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.btnLogin);
            this.Controls.Add(this.tbPass);
            this.Controls.Add(this.tbUser);
            this.Controls.Add(this.lPass);
            this.Controls.Add(this.lUser);
            this.Controls.Add(this.loginPB);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Login";
            this.Text = "Login";
            ((System.ComponentModel.ISupportInitialize)(this.loginPB)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox loginPB;
        private System.Windows.Forms.Label lUser;
        private System.Windows.Forms.Label lPass;
        private System.Windows.Forms.TextBox tbUser;
        private System.Windows.Forms.TextBox tbPass;
        private System.Windows.Forms.Button btnLogin;
        protected internal System.Windows.Forms.Button btnSalir;
    }
}