namespace regRutas
{
    partial class Inicio
    {
        /// <summary>
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén utilizando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben eliminar; false en caso contrario, false.</param>
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
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.rut = new System.Windows.Forms.TextBox();
            this.mod = new System.Windows.Forms.Label();
            this.tot = new System.Windows.Forms.Label();
            this.error = new System.Windows.Forms.Label();
            this.pri = new System.Windows.Forms.TextBox();
            this.ult = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(126, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(92, 51);
            this.button1.TabIndex = 0;
            this.button1.Text = "SELECCIONAR CARPETA \"docus\"";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(126, 187);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(92, 23);
            this.button2.TabIndex = 1;
            this.button2.Text = "MODIFICAR";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // rut
            // 
            this.rut.Enabled = false;
            this.rut.Location = new System.Drawing.Point(12, 68);
            this.rut.Multiline = true;
            this.rut.Name = "rut";
            this.rut.Size = new System.Drawing.Size(317, 40);
            this.rut.TabIndex = 2;
            // 
            // mod
            // 
            this.mod.AutoSize = true;
            this.mod.Location = new System.Drawing.Point(99, 275);
            this.mod.Name = "mod";
            this.mod.Size = new System.Drawing.Size(35, 13);
            this.mod.TabIndex = 3;
            this.mod.Text = "label1";
            this.mod.Visible = false;
            // 
            // tot
            // 
            this.tot.AutoSize = true;
            this.tot.Location = new System.Drawing.Point(99, 251);
            this.tot.Name = "tot";
            this.tot.Size = new System.Drawing.Size(35, 13);
            this.tot.TabIndex = 4;
            this.tot.Text = "label2";
            this.tot.Visible = false;
            // 
            // error
            // 
            this.error.AutoSize = true;
            this.error.Location = new System.Drawing.Point(68, 214);
            this.error.Name = "error";
            this.error.Size = new System.Drawing.Size(28, 13);
            this.error.TabIndex = 5;
            this.error.Text = "error";
            this.error.Visible = false;
            // 
            // pri
            // 
            this.pri.Location = new System.Drawing.Point(71, 142);
            this.pri.Name = "pri";
            this.pri.Size = new System.Drawing.Size(63, 20);
            this.pri.TabIndex = 6;
            this.pri.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.pri_KeyPress);
            // 
            // ult
            // 
            this.ult.Location = new System.Drawing.Point(224, 142);
            this.ult.Name = "ult";
            this.ult.Size = new System.Drawing.Size(63, 20);
            this.ult.TabIndex = 7;
            this.ult.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ult_KeyPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(68, 111);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(177, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "RANGO DE FOLIOS A MODIFICAR";
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(12, 142);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 33);
            this.label4.TabIndex = 9;
            this.label4.Text = "PRIMER FOLIO";
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(168, 142);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(50, 29);
            this.label5.TabIndex = 10;
            this.label5.Text = "ULTIMO FOLIO";
            // 
            // Inicio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(340, 295);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.ult);
            this.Controls.Add(this.pri);
            this.Controls.Add(this.error);
            this.Controls.Add(this.tot);
            this.Controls.Add(this.mod);
            this.Controls.Add(this.rut);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Name = "Inicio";
            this.Text = "MODIFICAR RUTAS DE ARCHIVOS";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox rut;
        private System.Windows.Forms.Label mod;
        private System.Windows.Forms.Label tot;
        private System.Windows.Forms.Label error;
        private System.Windows.Forms.TextBox pri;
        private System.Windows.Forms.TextBox ult;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
    }
}

