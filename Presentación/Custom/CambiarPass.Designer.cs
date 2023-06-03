namespace Presentación
{
    partial class CambiarPass
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

        #region Código generado por el Diseñador de componentes

        /// <summary> 
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnConfirmar = new System.Windows.Forms.Button();
            this.grpPass = new System.Windows.Forms.GroupBox();
            this.btnSeePass2 = new System.Windows.Forms.Button();
            this.txtpass2 = new System.Windows.Forms.TextBox();
            this.txtpass1 = new System.Windows.Forms.TextBox();
            this.lblPass2 = new System.Windows.Forms.Label();
            this.lblPass1 = new System.Windows.Forms.Label();
            this.btnSeePass1 = new System.Windows.Forms.Button();
            this.grpPass.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackgroundImage = global::Trabajo_Final.Properties.Resources.puerta_de_salida;
            this.btnCancelar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnCancelar.FlatAppearance.BorderSize = 0;
            this.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelar.Font = new System.Drawing.Font("Nirmala UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelar.ForeColor = System.Drawing.Color.Gold;
            this.btnCancelar.Location = new System.Drawing.Point(18, 198);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(63, 58);
            this.btnCancelar.TabIndex = 41;
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnConfirmar
            // 
            this.btnConfirmar.BackgroundImage = global::Trabajo_Final.Properties.Resources.clave;
            this.btnConfirmar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnConfirmar.FlatAppearance.BorderSize = 0;
            this.btnConfirmar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConfirmar.Font = new System.Drawing.Font("Nirmala UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConfirmar.ForeColor = System.Drawing.Color.Gold;
            this.btnConfirmar.Location = new System.Drawing.Point(246, 198);
            this.btnConfirmar.Name = "btnConfirmar";
            this.btnConfirmar.Size = new System.Drawing.Size(63, 58);
            this.btnConfirmar.TabIndex = 40;
            this.btnConfirmar.UseVisualStyleBackColor = true;
            this.btnConfirmar.Click += new System.EventHandler(this.btnConfirmar_Click);
            // 
            // grpPass
            // 
            this.grpPass.Controls.Add(this.btnSeePass2);
            this.grpPass.Controls.Add(this.btnSeePass1);
            this.grpPass.Controls.Add(this.txtpass2);
            this.grpPass.Controls.Add(this.txtpass1);
            this.grpPass.Controls.Add(this.lblPass2);
            this.grpPass.Controls.Add(this.lblPass1);
            this.grpPass.Location = new System.Drawing.Point(29, 3);
            this.grpPass.Name = "grpPass";
            this.grpPass.Size = new System.Drawing.Size(291, 189);
            this.grpPass.TabIndex = 44;
            this.grpPass.TabStop = false;
            // 
            // btnSeePass2
            // 
            this.btnSeePass2.BackgroundImage = global::Trabajo_Final.Properties.Resources.eye;
            this.btnSeePass2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnSeePass2.FlatAppearance.BorderSize = 0;
            this.btnSeePass2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSeePass2.Font = new System.Drawing.Font("Nirmala UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSeePass2.ForeColor = System.Drawing.Color.Gold;
            this.btnSeePass2.Location = new System.Drawing.Point(214, 118);
            this.btnSeePass2.Name = "btnSeePass2";
            this.btnSeePass2.Size = new System.Drawing.Size(44, 41);
            this.btnSeePass2.TabIndex = 49;
            this.btnSeePass2.UseVisualStyleBackColor = true;
            this.btnSeePass2.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnSeePass2_MouseDown);
            this.btnSeePass2.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btnSeePass2_MouseUp);
            // 
            // txtpass2
            // 
            this.txtpass2.Location = new System.Drawing.Point(36, 128);
            this.txtpass2.Name = "txtpass2";
            this.txtpass2.PasswordChar = '●';
            this.txtpass2.Size = new System.Drawing.Size(155, 22);
            this.txtpass2.TabIndex = 47;
            this.txtpass2.Click += new System.EventHandler(this.txtpass2_Click);
            this.txtpass2.Enter += new System.EventHandler(this.txtpass2_Enter);
            // 
            // txtpass1
            // 
            this.txtpass1.Location = new System.Drawing.Point(33, 55);
            this.txtpass1.Name = "txtpass1";
            this.txtpass1.PasswordChar = '●';
            this.txtpass1.Size = new System.Drawing.Size(155, 22);
            this.txtpass1.TabIndex = 46;
            this.txtpass1.Click += new System.EventHandler(this.txtpass1_Click);
            this.txtpass1.Enter += new System.EventHandler(this.txtpass1_Enter);
            // 
            // lblPass2
            // 
            this.lblPass2.AutoSize = true;
            this.lblPass2.Location = new System.Drawing.Point(33, 95);
            this.lblPass2.Name = "lblPass2";
            this.lblPass2.Size = new System.Drawing.Size(159, 17);
            this.lblPass2.TabIndex = 45;
            this.lblPass2.Text = "Repita Nueva Password";
            // 
            // lblPass1
            // 
            this.lblPass1.AutoSize = true;
            this.lblPass1.Location = new System.Drawing.Point(33, 19);
            this.lblPass1.Name = "lblPass1";
            this.lblPass1.Size = new System.Drawing.Size(165, 17);
            this.lblPass1.TabIndex = 44;
            this.lblPass1.Text = "Ingrese Nueva Password";
            // 
            // btnSeePass1
            // 
            this.btnSeePass1.BackgroundImage = global::Trabajo_Final.Properties.Resources.eye;
            this.btnSeePass1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnSeePass1.FlatAppearance.BorderSize = 0;
            this.btnSeePass1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSeePass1.Font = new System.Drawing.Font("Nirmala UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSeePass1.ForeColor = System.Drawing.Color.Gold;
            this.btnSeePass1.Location = new System.Drawing.Point(214, 45);
            this.btnSeePass1.Name = "btnSeePass1";
            this.btnSeePass1.Size = new System.Drawing.Size(44, 41);
            this.btnSeePass1.TabIndex = 48;
            this.btnSeePass1.UseVisualStyleBackColor = true;
            this.btnSeePass1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnSeePass1_MouseDown);
            this.btnSeePass1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btnSeePass1_MouseUp);
            // 
            // CambiarPass
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnConfirmar);
            this.Controls.Add(this.grpPass);
            this.Name = "CambiarPass";
            this.Size = new System.Drawing.Size(349, 266);
            this.grpPass.ResumeLayout(false);
            this.grpPass.PerformLayout();
            this.ResumeLayout(false);

        }

        private void Txtpass2_Enter(object sender, System.EventArgs e)
        {
            throw new System.NotImplementedException();
        }

        #endregion
        private System.Windows.Forms.Button btnConfirmar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.GroupBox grpPass;
        private System.Windows.Forms.Button btnSeePass2;
        private System.Windows.Forms.Button btnSeePass1;
        private System.Windows.Forms.TextBox txtpass2;
        private System.Windows.Forms.TextBox txtpass1;
        private System.Windows.Forms.Label lblPass2;
        private System.Windows.Forms.Label lblPass1;
    }
}
