using Fall2020_CSC403_Project.code;
using Fall2020_CSC403_Project.Properties;
using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography.X509Certificates;
using System.Runtime.CompilerServices;

namespace Fall2020_CSC403_Project
{

    //DISCLAIMER: This code does nothing of use
    //It works but I couldn't get it to work with the other files
    internal class Difficulty : Form
    {
        private Button normal;
        private Button hard;
        private Button insane;

        public bool normDif = true; // Have the difficulty set to normal by default
        public bool hardDif = false;
        private Label lblNorm;
        private Label lblHard;
        private Label lblInsn;
        public bool insnDif = false;

        public Difficulty()
        {
            InitializeComponent();
        }
        private void InitializeComponent()
        {
            this.normal = new System.Windows.Forms.Button();
            this.hard = new System.Windows.Forms.Button();
            this.insane = new System.Windows.Forms.Button();
            this.lblNorm = new System.Windows.Forms.Label();
            this.lblHard = new System.Windows.Forms.Label();
            this.lblInsn = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // normal
            // 
            this.normal.Font = new System.Drawing.Font("Noto Sans", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.normal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.normal.Location = new System.Drawing.Point(51, 12);
            this.normal.Name = "normal";
            this.normal.Size = new System.Drawing.Size(93, 23);
            this.normal.TabIndex = 0;
            this.normal.Text = "Normal";
            this.normal.UseVisualStyleBackColor = true;
            this.normal.Click += new System.EventHandler(this.normal_Click);
            // 
            // hard
            // 
            this.hard.ForeColor = System.Drawing.Color.Olive;
            this.hard.Location = new System.Drawing.Point(51, 51);
            this.hard.Name = "hard";
            this.hard.Size = new System.Drawing.Size(93, 23);
            this.hard.TabIndex = 1;
            this.hard.Text = "Hard";
            this.hard.UseVisualStyleBackColor = true;
            this.hard.Click += new System.EventHandler(this.hard_Click);
            // 
            // insane
            // 
            this.insane.Font = new System.Drawing.Font("Microsoft YaHei", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.insane.ForeColor = System.Drawing.Color.Maroon;
            this.insane.Location = new System.Drawing.Point(51, 92);
            this.insane.Name = "insane";
            this.insane.Size = new System.Drawing.Size(93, 23);
            this.insane.TabIndex = 2;
            this.insane.Text = "Insane";
            this.insane.UseVisualStyleBackColor = true;
            this.insane.Click += new System.EventHandler(this.insane_Click);
            // 
            // lblNorm
            // 
            this.lblNorm.AutoSize = true;
            this.lblNorm.ForeColor = System.Drawing.Color.Red;
            this.lblNorm.Location = new System.Drawing.Point(146, 17);
            this.lblNorm.Name = "lblNorm";
            this.lblNorm.Size = new System.Drawing.Size(14, 13);
            this.lblNorm.TabIndex = 3;
            this.lblNorm.Text = "X";
            // 
            // lblHard
            // 
            this.lblHard.AutoSize = true;
            this.lblHard.ForeColor = System.Drawing.Color.Red;
            this.lblHard.Location = new System.Drawing.Point(146, 56);
            this.lblHard.Name = "lblHard";
            this.lblHard.Size = new System.Drawing.Size(14, 13);
            this.lblHard.TabIndex = 4;
            this.lblHard.Text = "X";
            // 
            // lblInsn
            // 
            this.lblInsn.AutoSize = true;
            this.lblInsn.ForeColor = System.Drawing.Color.Red;
            this.lblInsn.Location = new System.Drawing.Point(146, 97);
            this.lblInsn.Name = "lblInsn";
            this.lblInsn.Size = new System.Drawing.Size(14, 13);
            this.lblInsn.TabIndex = 5;
            this.lblInsn.Text = "X";
            // 
            // Difficulty
            // 
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(199, 128);
            this.Controls.Add(this.lblInsn);
            this.Controls.Add(this.lblHard);
            this.Controls.Add(this.lblNorm);
            this.Controls.Add(this.insane);
            this.Controls.Add(this.hard);
            this.Controls.Add(this.normal);
            this.Name = "Difficulty";
            this.Text = "Difficulty";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        //This would change the difficulty to normal
        public void normal_Click(object sender, EventArgs e)
        {
            normDif = true;
            hardDif = false;
            insnDif = false;
            lblNorm.Visible = true;
            lblHard.Visible = false;
            lblInsn.Visible = false;
        }

        //This would change the difficulty to hard
        public void hard_Click(object sender, EventArgs e)
        {
            normDif = false;
            hardDif = true;
            insnDif = false;
            lblNorm.Visible = false;
            lblHard.Visible = true;
            lblInsn.Visible = false;
        }

        //This would change the difficulty to insane
        public void insane_Click(object sender, EventArgs e)
        {
            normDif = false;
            hardDif = false;
            insnDif = true;
            lblNorm.Visible = false;
            lblHard.Visible = false;
            lblInsn.Visible = true;
        }
    }
}
