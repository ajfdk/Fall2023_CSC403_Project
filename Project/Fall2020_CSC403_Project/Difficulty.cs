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
    public class Difficulty : Form
    {
        private Button normal;
        private Button hard;
        private Button insane;

        public int setDif = 1;

        public Difficulty()
        {
            InitializeComponent();
        }
        private void InitializeComponent()
        {
            this.normal = new System.Windows.Forms.Button();
            this.hard = new System.Windows.Forms.Button();
            this.insane = new System.Windows.Forms.Button();
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
            // Difficulty
            // 
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(199, 128);
            this.Controls.Add(this.insane);
            this.Controls.Add(this.hard);
            this.Controls.Add(this.normal);
            this.Name = "Difficulty";
            this.Text = "Difficulty";
            this.ResumeLayout(false);

        }

        public void normal_Click(object sender, EventArgs e)
        {
            setDif = 1;
        }

        public void hard_Click(object sender, EventArgs e)
        {
            setDif = 2;
        }

        public void insane_Click(object sender, EventArgs e)
        {
            setDif = 3;
        }
    }
}
