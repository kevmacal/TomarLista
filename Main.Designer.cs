
namespace TomarLista
{
    partial class Main
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
            this.mainMenu = new System.Windows.Forms.MenuStrip();
            this.clasesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nuevaClaseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cbParalelo = new System.Windows.Forms.ComboBox();
            this.cbMateria = new System.Windows.Forms.ComboBox();
            this.flpMain = new System.Windows.Forms.FlowLayoutPanel();
            this.btnSave = new System.Windows.Forms.Button();
            this.lProfesor = new System.Windows.Forms.Label();
            this.btnNewClass = new System.Windows.Forms.Button();
            this.mainMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainMenu
            // 
            this.mainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.clasesToolStripMenuItem});
            this.mainMenu.Location = new System.Drawing.Point(0, 0);
            this.mainMenu.Name = "mainMenu";
            this.mainMenu.Size = new System.Drawing.Size(800, 24);
            this.mainMenu.TabIndex = 0;
            this.mainMenu.Text = "Menu Principal";
            // 
            // clasesToolStripMenuItem
            // 
            this.clasesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nuevaClaseToolStripMenuItem});
            this.clasesToolStripMenuItem.Name = "clasesToolStripMenuItem";
            this.clasesToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
            this.clasesToolStripMenuItem.Text = "Clases";
            this.clasesToolStripMenuItem.Visible = false;
            // 
            // nuevaClaseToolStripMenuItem
            // 
            this.nuevaClaseToolStripMenuItem.Name = "nuevaClaseToolStripMenuItem";
            this.nuevaClaseToolStripMenuItem.Size = new System.Drawing.Size(139, 22);
            this.nuevaClaseToolStripMenuItem.Text = "Nueva Clase";
            this.nuevaClaseToolStripMenuItem.Click += new System.EventHandler(this.nuevaClaseToolStripMenuItem_Click);
            // 
            // cbParalelo
            // 
            this.cbParalelo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbParalelo.FormattingEnabled = true;
            this.cbParalelo.Location = new System.Drawing.Point(12, 27);
            this.cbParalelo.Name = "cbParalelo";
            this.cbParalelo.Size = new System.Drawing.Size(121, 21);
            this.cbParalelo.TabIndex = 1;
            this.cbParalelo.Visible = false;
            // 
            // cbMateria
            // 
            this.cbMateria.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbMateria.FormattingEnabled = true;
            this.cbMateria.Location = new System.Drawing.Point(12, 55);
            this.cbMateria.Name = "cbMateria";
            this.cbMateria.Size = new System.Drawing.Size(121, 21);
            this.cbMateria.TabIndex = 2;
            this.cbMateria.Visible = false;
            // 
            // flpMain
            // 
            this.flpMain.AutoScroll = true;
            this.flpMain.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flpMain.Location = new System.Drawing.Point(12, 83);
            this.flpMain.Name = "flpMain";
            this.flpMain.Size = new System.Drawing.Size(776, 342);
            this.flpMain.TabIndex = 3;
            this.flpMain.WrapContents = false;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(139, 55);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(87, 23);
            this.btnSave.TabIndex = 4;
            this.btnSave.Text = "Guardar";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Visible = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // lProfesor
            // 
            this.lProfesor.AutoSize = true;
            this.lProfesor.Location = new System.Drawing.Point(12, 428);
            this.lProfesor.Name = "lProfesor";
            this.lProfesor.Size = new System.Drawing.Size(0, 13);
            this.lProfesor.TabIndex = 5;
            // 
            // btnNewClass
            // 
            this.btnNewClass.Location = new System.Drawing.Point(139, 27);
            this.btnNewClass.Name = "btnNewClass";
            this.btnNewClass.Size = new System.Drawing.Size(87, 23);
            this.btnNewClass.TabIndex = 6;
            this.btnNewClass.Text = "Nueva Clase";
            this.btnNewClass.UseVisualStyleBackColor = true;
            this.btnNewClass.Visible = false;
            this.btnNewClass.Click += new System.EventHandler(this.btnNewClass_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnNewClass);
            this.Controls.Add(this.lProfesor);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.flpMain);
            this.Controls.Add(this.cbMateria);
            this.Controls.Add(this.cbParalelo);
            this.Controls.Add(this.mainMenu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MainMenuStrip = this.mainMenu;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Main";
            this.Text = "TomarLista";
            this.mainMenu.ResumeLayout(false);
            this.mainMenu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip mainMenu;
        private System.Windows.Forms.ToolStripMenuItem clasesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nuevaClaseToolStripMenuItem;
        private System.Windows.Forms.ComboBox cbParalelo;
        private System.Windows.Forms.ComboBox cbMateria;
        private System.Windows.Forms.FlowLayoutPanel flpMain;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label lProfesor;
        private System.Windows.Forms.Button btnNewClass;
    }
}

