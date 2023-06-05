namespace Trabajo_Final
{
    partial class frmBienvenida
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
            this.picboxPrincipal = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.picboxPrincipal)).BeginInit();
            this.SuspendLayout();
            // 
            // picboxPrincipal
            // 
            this.picboxPrincipal.Image = global::Trabajo_Final.Properties.Resources.Picture3;
            this.picboxPrincipal.Location = new System.Drawing.Point(572, 252);
            this.picboxPrincipal.Margin = new System.Windows.Forms.Padding(4);
            this.picboxPrincipal.Name = "picboxPrincipal";
            this.picboxPrincipal.Size = new System.Drawing.Size(500, 500);
            this.picboxPrincipal.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picboxPrincipal.TabIndex = 11;
            this.picboxPrincipal.TabStop = false;
            // 
            // frmBienvenida
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(1644, 1005);
            this.Controls.Add(this.picboxPrincipal);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmBienvenida";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Bienvenida";
            ((System.ComponentModel.ISupportInitialize)(this.picboxPrincipal)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox picboxPrincipal;
    }
}