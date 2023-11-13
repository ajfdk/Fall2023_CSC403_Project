using Fall2020_CSC403_Project.code;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

/*
 * This file holds the second level the player is able to access. As of 11/6/2023 this file
 * is still not used and is currently under construction. 
 * 
 */

namespace Fall2020_CSC403_Project
{
    public class LevelTwo : Form
    {
        private Player player;
        private PictureBox Wall2;
        private PictureBox Wall3;
        private PictureBox Wall4;
        private PictureBox Wall6;
        private PictureBox Wall7;
        private PictureBox Wall8;
        private PictureBox Wall9;
        private PictureBox Wall10;
        private PictureBox Wall11;
        private PictureBox Wall1;
        private PictureBox picPlayer;
        private PictureBox Wall5;


        public LevelTwo()
        {
            player = Game.player;
            InitializeComponent();
        }

        // This Function is Auto-generated. Please only edit using the Visual Studio Designer.
        private void InitializeComponent()
        {
            this.Wall2 = new System.Windows.Forms.PictureBox();
            this.Wall3 = new System.Windows.Forms.PictureBox();
            this.Wall4 = new System.Windows.Forms.PictureBox();
            this.Wall5 = new System.Windows.Forms.PictureBox();
            this.Wall6 = new System.Windows.Forms.PictureBox();
            this.Wall7 = new System.Windows.Forms.PictureBox();
            this.Wall8 = new System.Windows.Forms.PictureBox();
            this.Wall9 = new System.Windows.Forms.PictureBox();
            this.Wall10 = new System.Windows.Forms.PictureBox();
            this.Wall11 = new System.Windows.Forms.PictureBox();
            this.Wall1 = new System.Windows.Forms.PictureBox();
            this.picPlayer = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.Wall2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Wall3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Wall4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Wall5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Wall6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Wall7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Wall8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Wall9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Wall10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Wall11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Wall1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picPlayer)).BeginInit();
            this.SuspendLayout();
            // 
            // Wall2
            // 
            this.Wall2.Image = global::Fall2020_CSC403_Project.Properties.Resources.wall;
            this.Wall2.Location = new System.Drawing.Point(-1, 187);
            this.Wall2.Name = "Wall2";
            this.Wall2.Size = new System.Drawing.Size(130, 369);
            this.Wall2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Wall2.TabIndex = 1;
            this.Wall2.TabStop = false;
            // 
            // Wall3
            // 
            this.Wall3.Image = global::Fall2020_CSC403_Project.Properties.Resources.wall;
            this.Wall3.Location = new System.Drawing.Point(587, 732);
            this.Wall3.Name = "Wall3";
            this.Wall3.Size = new System.Drawing.Size(467, 122);
            this.Wall3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Wall3.TabIndex = 2;
            this.Wall3.TabStop = false;
            // 
            // Wall4
            // 
            this.Wall4.Image = global::Fall2020_CSC403_Project.Properties.Resources.wall;
            this.Wall4.Location = new System.Drawing.Point(125, 732);
            this.Wall4.Name = "Wall4";
            this.Wall4.Size = new System.Drawing.Size(467, 122);
            this.Wall4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Wall4.TabIndex = 3;
            this.Wall4.TabStop = false;
            // 
            // Wall5
            // 
            this.Wall5.Image = global::Fall2020_CSC403_Project.Properties.Resources.wall;
            this.Wall5.Location = new System.Drawing.Point(-1, 551);
            this.Wall5.Name = "Wall5";
            this.Wall5.Size = new System.Drawing.Size(130, 280);
            this.Wall5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Wall5.TabIndex = 4;
            this.Wall5.TabStop = false;
            // 
            // Wall6
            // 
            this.Wall6.Image = global::Fall2020_CSC403_Project.Properties.Resources.wall;
            this.Wall6.Location = new System.Drawing.Point(199, -37);
            this.Wall6.Name = "Wall6";
            this.Wall6.Size = new System.Drawing.Size(408, 141);
            this.Wall6.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Wall6.TabIndex = 5;
            this.Wall6.TabStop = false;
            // 
            // Wall7
            // 
            this.Wall7.Image = global::Fall2020_CSC403_Project.Properties.Resources.wall;
            this.Wall7.Location = new System.Drawing.Point(598, -37);
            this.Wall7.Name = "Wall7";
            this.Wall7.Size = new System.Drawing.Size(482, 141);
            this.Wall7.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Wall7.TabIndex = 6;
            this.Wall7.TabStop = false;
            // 
            // Wall8
            // 
            this.Wall8.Image = global::Fall2020_CSC403_Project.Properties.Resources.wall;
            this.Wall8.Location = new System.Drawing.Point(1076, -37);
            this.Wall8.Name = "Wall8";
            this.Wall8.Size = new System.Drawing.Size(482, 141);
            this.Wall8.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Wall8.TabIndex = 7;
            this.Wall8.TabStop = false;
            // 
            // Wall9
            // 
            this.Wall9.Image = global::Fall2020_CSC403_Project.Properties.Resources.wall;
            this.Wall9.Location = new System.Drawing.Point(1048, 732);
            this.Wall9.Name = "Wall9";
            this.Wall9.Size = new System.Drawing.Size(467, 122);
            this.Wall9.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Wall9.TabIndex = 8;
            this.Wall9.TabStop = false;
            // 
            // Wall10
            // 
            this.Wall10.Image = global::Fall2020_CSC403_Project.Properties.Resources.wall;
            this.Wall10.Location = new System.Drawing.Point(325, 425);
            this.Wall10.Name = "Wall10";
            this.Wall10.Size = new System.Drawing.Size(351, 104);
            this.Wall10.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Wall10.TabIndex = 9;
            this.Wall10.TabStop = false;
            // 
            // Wall11
            // 
            this.Wall11.Image = global::Fall2020_CSC403_Project.Properties.Resources.wall;
            this.Wall11.Location = new System.Drawing.Point(613, 101);
            this.Wall11.Name = "Wall11";
            this.Wall11.Size = new System.Drawing.Size(467, 122);
            this.Wall11.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Wall11.TabIndex = 10;
            this.Wall11.TabStop = false;
            // 
            // Wall1
            // 
            this.Wall1.Image = global::Fall2020_CSC403_Project.Properties.Resources.wall;
            this.Wall1.Location = new System.Drawing.Point(667, 425);
            this.Wall1.Name = "Wall1";
            this.Wall1.Size = new System.Drawing.Size(413, 309);
            this.Wall1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Wall1.TabIndex = 11;
            this.Wall1.TabStop = false;
            // 
            // picPlayer
            // 
            this.picPlayer.BackColor = System.Drawing.Color.Transparent;
            this.picPlayer.BackgroundImage = global::Fall2020_CSC403_Project.Properties.Resources.player;
            this.picPlayer.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.picPlayer.Location = new System.Drawing.Point(136, 112);
            this.picPlayer.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.picPlayer.Name = "picPlayer";
            this.picPlayer.Size = new System.Drawing.Size(81, 163);
            this.picPlayer.TabIndex = 12;
            this.picPlayer.TabStop = false;
            // 
            // LevelTwo
            // 
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(1408, 804);
            this.Controls.Add(this.picPlayer);
            this.Controls.Add(this.Wall10);
            this.Controls.Add(this.Wall1);
            this.Controls.Add(this.Wall11);
            this.Controls.Add(this.Wall9);
            this.Controls.Add(this.Wall8);
            this.Controls.Add(this.Wall7);
            this.Controls.Add(this.Wall6);
            this.Controls.Add(this.Wall5);
            this.Controls.Add(this.Wall4);
            this.Controls.Add(this.Wall3);
            this.Controls.Add(this.Wall2);
            this.Name = "LevelTwo";
            this.Text = "Level 2";
            ((System.ComponentModel.ISupportInitialize)(this.Wall2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Wall3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Wall4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Wall5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Wall6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Wall7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Wall8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Wall9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Wall10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Wall11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Wall1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picPlayer)).EndInit();
            this.ResumeLayout(false);

        }
    }
}
