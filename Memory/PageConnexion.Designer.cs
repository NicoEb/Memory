namespace Memory
{
    partial class PageConnexion
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
            this.Connexion = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.textBoxMdP = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.textBoxPseudo = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // Connexion
            // 
            this.Connexion.Location = new System.Drawing.Point(385, 249);
            this.Connexion.Name = "Connexion";
            this.Connexion.Size = new System.Drawing.Size(110, 53);
            this.Connexion.TabIndex = 30;
            this.Connexion.Text = "Connexion";
            this.Connexion.UseVisualStyleBackColor = true;
            this.Connexion.Click += new System.EventHandler(this.Connexion_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Palatino Linotype", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(233, 178);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(121, 26);
            this.label9.TabIndex = 29;
            this.label9.Text = "Mot de passe";
            // 
            // textBoxMdP
            // 
            this.textBoxMdP.Location = new System.Drawing.Point(360, 184);
            this.textBoxMdP.Name = "textBoxMdP";
            this.textBoxMdP.Size = new System.Drawing.Size(147, 20);
            this.textBoxMdP.TabIndex = 28;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Palatino Linotype", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(281, 142);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(73, 26);
            this.label10.TabIndex = 27;
            this.label10.Text = "Pseudo";
            // 
            // textBoxPseudo
            // 
            this.textBoxPseudo.Location = new System.Drawing.Point(360, 148);
            this.textBoxPseudo.Name = "textBoxPseudo";
            this.textBoxPseudo.Size = new System.Drawing.Size(147, 20);
            this.textBoxPseudo.TabIndex = 26;
            // 
            // PageConnexion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Highlight;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.Connexion);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.textBoxMdP);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.textBoxPseudo);
            this.Name = "PageConnexion";
            this.Text = "PageConnexion";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Connexion;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox textBoxMdP;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox textBoxPseudo;
    }
}