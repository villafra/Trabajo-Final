
namespace Trabajo_Final
{
    partial class frmCambioPass
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
            this.cambiarPass = new Presentación.CambiarPass();
            this.SuspendLayout();
            // 
            // cambiarPass1
            // 
            this.cambiarPass.Location = new System.Drawing.Point(15, 18);
            this.cambiarPass.Name = "cambiarPass1";
            this.cambiarPass.Size = new System.Drawing.Size(349, 266);
            this.cambiarPass.TabIndex = 0;
            // 
            // frmCambioPass
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(378, 302);
            this.Controls.Add(this.cambiarPass);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmCambioPass";
            this.Text = "frmCambioPass";
            this.ResumeLayout(false);

        }

        #endregion

        private Presentación.CambiarPass cambiarPass;
    }
}