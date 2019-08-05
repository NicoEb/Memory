namespace Memory
{
    partial class PageChoixNiveaux
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
            this.button5 = new System.Windows.Forms.Button();
            this.buttonIntermediaire = new System.Windows.Forms.Button();
            this.buttonExpert = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // button5
            // 
            this.button5.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.button5.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button5.Location = new System.Drawing.Point(162, 176);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(120, 61);
            this.button5.TabIndex = 23;
            this.button5.Text = "Débutant";
            this.button5.UseVisualStyleBackColor = false;
            this.button5.Click += new System.EventHandler(this.ButtonDebutant_Click);
            // 
            // buttonIntermediaire
            // 
            this.buttonIntermediaire.BackColor = System.Drawing.Color.Green;
            this.buttonIntermediaire.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonIntermediaire.Location = new System.Drawing.Point(332, 175);
            this.buttonIntermediaire.Name = "buttonIntermediaire";
            this.buttonIntermediaire.Size = new System.Drawing.Size(148, 62);
            this.buttonIntermediaire.TabIndex = 22;
            this.buttonIntermediaire.Text = "Intermédiaire";
            this.buttonIntermediaire.UseVisualStyleBackColor = false;
            this.buttonIntermediaire.Click += new System.EventHandler(this.ButtonIntermediaire_Click);
            // 
            // buttonExpert
            // 
            this.buttonExpert.BackColor = System.Drawing.Color.DarkRed;
            this.buttonExpert.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonExpert.Location = new System.Drawing.Point(524, 175);
            this.buttonExpert.Name = "buttonExpert";
            this.buttonExpert.Size = new System.Drawing.Size(125, 61);
            this.buttonExpert.TabIndex = 21;
            this.buttonExpert.Text = "Expert";
            this.buttonExpert.UseVisualStyleBackColor = false;
            this.buttonExpert.Click += new System.EventHandler(this.ButtonExpert_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label1.Location = new System.Drawing.Point(172, 60);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(457, 39);
            this.label1.TabIndex = 24;
            this.label1.Text = "Veuillez choissir votre niveau";
            // 
            // PageChoixNiveaux
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.buttonIntermediaire);
            this.Controls.Add(this.buttonExpert);
            this.Name = "PageChoixNiveaux";
            this.Text = "PageChoixNiveaux";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button buttonIntermediaire;
        private System.Windows.Forms.Button buttonExpert;
        private System.Windows.Forms.Label label1;
    }
}