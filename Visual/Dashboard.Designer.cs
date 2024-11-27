namespace Visual
{
    partial class Dashboard
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.btnusuario = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.btnservicio = new System.Windows.Forms.Button();
            this.btnempleado = new System.Windows.Forms.Button();
            this.btncliente = new System.Windows.Forms.Button();
            this.btncita = new System.Windows.Forms.Button();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panelHijo = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(113)))), ((int)(((byte)(137)))), ((int)(((byte)(255)))));
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.btnusuario);
            this.panel1.Controls.Add(this.button5);
            this.panel1.Controls.Add(this.btnservicio);
            this.panel1.Controls.Add(this.btnempleado);
            this.panel1.Controls.Add(this.btncliente);
            this.panel1.Controls.Add(this.btncita);
            this.panel1.Controls.Add(this.panel4);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(212, 673);
            this.panel1.TabIndex = 0;
            // 
            // button2
            // 
            this.button2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button2.Dock = System.Windows.Forms.DockStyle.Top;
            this.button2.Location = new System.Drawing.Point(0, 493);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(212, 60);
            this.button2.TabIndex = 8;
            this.button2.Text = "Iniciar Bot";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.Dock = System.Windows.Forms.DockStyle.Top;
            this.button1.Location = new System.Drawing.Point(0, 433);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(212, 60);
            this.button1.TabIndex = 7;
            this.button1.Text = "Usuarios";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // btnusuario
            // 
            this.btnusuario.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnusuario.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnusuario.Location = new System.Drawing.Point(0, 373);
            this.btnusuario.Name = "btnusuario";
            this.btnusuario.Size = new System.Drawing.Size(212, 60);
            this.btnusuario.TabIndex = 6;
            this.btnusuario.Text = "Productos";
            this.btnusuario.UseVisualStyleBackColor = true;
            this.btnusuario.Click += new System.EventHandler(this.btnusuario_Click);
            // 
            // button5
            // 
            this.button5.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.button5.Location = new System.Drawing.Point(0, 613);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(212, 60);
            this.button5.TabIndex = 5;
            this.button5.Text = "SALIR";
            this.button5.UseVisualStyleBackColor = true;
            // 
            // btnservicio
            // 
            this.btnservicio.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnservicio.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnservicio.Location = new System.Drawing.Point(0, 313);
            this.btnservicio.Name = "btnservicio";
            this.btnservicio.Size = new System.Drawing.Size(212, 60);
            this.btnservicio.TabIndex = 4;
            this.btnservicio.Text = "Servicios";
            this.btnservicio.UseVisualStyleBackColor = true;
            this.btnservicio.Click += new System.EventHandler(this.btnservicio_Click);
            // 
            // btnempleado
            // 
            this.btnempleado.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnempleado.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnempleado.Location = new System.Drawing.Point(0, 253);
            this.btnempleado.Name = "btnempleado";
            this.btnempleado.Size = new System.Drawing.Size(212, 60);
            this.btnempleado.TabIndex = 3;
            this.btnempleado.Text = "Empleados";
            this.btnempleado.UseVisualStyleBackColor = true;
            this.btnempleado.Click += new System.EventHandler(this.btnempleado_Click);
            // 
            // btncliente
            // 
            this.btncliente.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btncliente.Dock = System.Windows.Forms.DockStyle.Top;
            this.btncliente.Location = new System.Drawing.Point(0, 193);
            this.btncliente.Name = "btncliente";
            this.btncliente.Size = new System.Drawing.Size(212, 60);
            this.btncliente.TabIndex = 2;
            this.btncliente.Text = "Clientes";
            this.btncliente.UseVisualStyleBackColor = true;
            this.btncliente.Click += new System.EventHandler(this.btncliente_Click);
            // 
            // btncita
            // 
            this.btncita.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btncita.Dock = System.Windows.Forms.DockStyle.Top;
            this.btncita.Location = new System.Drawing.Point(0, 133);
            this.btncita.Name = "btncita";
            this.btncita.Size = new System.Drawing.Size(212, 60);
            this.btncita.TabIndex = 1;
            this.btncita.Text = "Cita";
            this.btncita.UseVisualStyleBackColor = true;
            this.btncita.Click += new System.EventHandler(this.button1_Click);
            // 
            // panel4
            // 
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(212, 133);
            this.panel4.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Controls.Add(this.label1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(212, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(970, 64);
            this.panel2.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Left;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 22.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(132, 42);
            this.label1.TabIndex = 0;
            this.label1.Text = "MENU";
            // 
            // panelHijo
            // 
            this.panelHijo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(235)))), ((int)(((byte)(255)))));
            this.panelHijo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelHijo.Location = new System.Drawing.Point(212, 64);
            this.panelHijo.Name = "panelHijo";
            this.panelHijo.Size = new System.Drawing.Size(970, 609);
            this.panelHijo.TabIndex = 1;
            // 
            // Dashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1182, 673);
            this.Controls.Add(this.panelHijo);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "Dashboard";
            this.Text = "Form1";
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panelHijo;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button btnservicio;
        private System.Windows.Forms.Button btnempleado;
        private System.Windows.Forms.Button btncliente;
        private System.Windows.Forms.Button btncita;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnusuario;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
    }
}

