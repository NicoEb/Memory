﻿namespace JeuxMemory
{
    partial class Admin
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
            this.button2 = new System.Windows.Forms.Button();
            this.BtRetour = new System.Windows.Forms.Button();
            this.sup_J = new System.Windows.Forms.Label();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.listView1 = new System.Windows.Forms.ListView();
            this.SuspendLayout();
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(536, 72);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 7;
            this.button2.Text = "Supprimer";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.ButtonSupprimer);
            // 
            // BtRetour
            // 
            this.BtRetour.Location = new System.Drawing.Point(15, 291);
            this.BtRetour.Name = "BtRetour";
            this.BtRetour.Size = new System.Drawing.Size(97, 31);
            this.BtRetour.TabIndex = 6;
            this.BtRetour.Text = "Retour";
            this.BtRetour.UseVisualStyleBackColor = true;
            this.BtRetour.Click += new System.EventHandler(this.ButtonRetour);
            // 
            // sup_J
            // 
            this.sup_J.AutoSize = true;
            this.sup_J.Location = new System.Drawing.Point(203, 80);
            this.sup_J.Name = "sup_J";
            this.sup_J.Size = new System.Drawing.Size(86, 13);
            this.sup_J.TabIndex = 5;
            this.sup_J.Text = "Supprimer joueur";
            // 
            // comboBox2
            // 
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(312, 72);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(180, 21);
            this.comboBox2.TabIndex = 4;
            // 
            // listView1
            // 
            this.listView1.Location = new System.Drawing.Point(486, 230);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(234, 108);
            this.listView1.TabIndex = 8;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.SelectedIndexChanged += new System.EventHandler(this.listView1_SelectedIndexChanged);
            // 
            // Admin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(791, 467);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.BtRetour);
            this.Controls.Add(this.sup_J);
            this.Controls.Add(this.comboBox2);
            this.Name = "Admin";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button BtRetour;
        private System.Windows.Forms.Label sup_J;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.ListView listView1;
    }
}