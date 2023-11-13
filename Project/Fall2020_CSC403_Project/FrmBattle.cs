using Fall2020_CSC403_Project.code;
using Fall2020_CSC403_Project.Properties;
using System;
using System.Drawing;
using System.Media;
using System.Windows.Forms;
using NAudio.Wave;

namespace Fall2020_CSC403_Project
{
    public partial class FrmBattle : Form
    {
        public static FrmBattle instance = null;
        private Enemy enemy;
        private Player player;
        private static int charbattle;

        private WaveOutEvent waveOut;
        private AudioFileReader audioFile;
        
        int uses = new int();
        int used = new int();
        bool Identified = new bool();
        bool Deflected = new bool();

        private FrmBattle()
        {
            InitializeComponent();
            player = Game.player;
            PlayAudio("data/backgroundMusicPlayer.wav");
        }

        private void PlayAudio(string filePath)
        {
            waveOut = new WaveOutEvent();
            audioFile = new AudioFileReader(filePath);
            waveOut.Init(audioFile);
            waveOut.Play();
        }

        private void SetVolume(float volume)
        {
            if (waveOut != null)
            {
                waveOut.Volume = volume;
            }
        }

        private void trackBarVolume_Scroll(object sender, EventArgs e)
        {
            TrackBar trackBar = (TrackBar)sender;
            float volume = trackBar.Value / 100f; // Convert to a scale of 0 to 1
            SetVolume(volume);
        }
        public void Setup()
        {
            // update for this enemy
            picEnemy.BackgroundImage = enemy.Img;
            picEnemy.Refresh();
            BackColor = enemy.BackgroundColor;
            picBossBattle.Visible = false;
            lblEnemyHealthFull.Visible = false;
            lblAction.Visible = false;
            Identified = false;
            Deflected = false;
            getplayer();

            // Observer pattern as well as making the used of the heal
            enemy.AttackEvent += PlayerDamage;
            player.AttackEvent += EnemyDamage;
            used = 2;

            // show health
            UpdateHealthBars();
        }

        private void getplayer()
        {
            switch (charbattle)
            {
                case 1:
                    picPlayer.BackgroundImage = Properties.Resources.cat;
                    break;
                case 2:
                    picPlayer.BackgroundImage = Properties.Resources.hk;
                    break;
                case 0:
                    picPlayer.BackgroundImage = Properties.Resources.player;

                    break;
               
            }
        }


        public void SetupForBossBattle()
        {
            picBossBattle.Location = Point.Empty;
            picBossBattle.Size = ClientSize;
            picBossBattle.Visible = true;

            SoundPlayer simpleSound = new SoundPlayer(Resources.final_battle);
            simpleSound.Play();

            string audioFilePath = "data/backgroundMusicPLayer.wav";
            waveOut = new WaveOutEvent();
            audioFile = new AudioFileReader(audioFilePath); 
            waveOut.Init(audioFile); 
            waveOut.Play();
            tmrFinalBattle.Enabled = true;


        }

        public static FrmBattle GetInstance(Enemy enemy)
        {
            if (instance == null)
            {
                instance = new FrmBattle();
                instance.enemy = enemy;
                instance.Setup();
            }
            return instance;
        }

        public static FrmBattle GetInstance(Enemy enemy, int charactorchoice)
        {
            charbattle = charactorchoice;
            if (instance == null)
            {
                instance = new FrmBattle();
                instance.enemy = enemy;
                instance.Setup();
            }
            return instance;
        }

        private void UpdateHealthBars()
        {
            float playerHealthPer = player.Health / (float)player.MaxHealth;
            float enemyHealthPer = enemy.Health / (float)enemy.MaxHealth;

            const int MAX_HEALTHBAR_WIDTH = 226;
            lblPlayerHealthFull.Width = (int)(MAX_HEALTHBAR_WIDTH * playerHealthPer);
            lblEnemyHealthFull.Width = (int)(MAX_HEALTHBAR_WIDTH * enemyHealthPer);

            lblPlayerHealthFull.Text = player.Health.ToString();
            lblEnemyHealthFull.Text = enemy.Health.ToString();

        }


        //This is a button that makes the player and enemy both attack for random amounts of damage
        private void btnAttack_Click(object sender, EventArgs e) {
            var plyrChance = new Random();
            var lblHold = (plyrChance.Next(2, 10));
            player.OnAttack(-lblHold);
            this.lblAction.Text = "Enemy Hit For " + lblHold;

            if (enemy.Health > 0) {

                var nmyChance = new Random();
                var lbl2Hold = (nmyChance.Next(3, 9));
                enemy.OnAttack(-lbl2Hold);
                this.lblSelf.Text = "You Were Hit For " + lbl2Hold;
            }

            UpdateHealthBars();
            if (player.Health <= 0 || enemy.Health <= 0) {
                player.updateGold(10); // player gets gold for winning (and losing because you're worth it mr peanut)
                instance = null;
                Close();
            }
        }


        //This is a button to heal for a random amount but can only be used a certain set number of times
        //It also stops the health at 20 if the heal would overflow, has a use count, and
        //Label descriptors are used so show the amounts healed for
        private void btnHeal_Click(object sender, EventArgs e)
        {
            if (player.Health > 0 && enemy.Health > 0)
            {
                if (uses < 2 && player.Health != 20)
                {
                    uses++;
                    var plyrChance = new Random();
                    var lblHold = (plyrChance.Next(5, 7));
                    player.AlterHealth(lblHold);
                    this.lblSelf.Text = "You Healed For " + lblHold;

                    if (enemy.Health != 20)
                    {
                        enemy.AlterHealth(1);
                        this.lblAction.Text = "Enemy Restored Health";

                        if (enemy.Health > 20)
                        {
                            enemy.SetHealth(20);
                        }
                    }

                    if (player.Health > 20)
                    {
                        player.SetHealth(20);
                    }

                    used -= 1;
                    this.btnHeal.Text = "Heal: " + used;
                    UpdateHealthBars();
                }
            }
        }

        //This is an infinite use button that has a chance to deflect the enemies attack back at them for damage
        //Descriptor labels are used to show if the random chance was successful or not
        private void btnDeflect_Click(object sender, EventArgs e)
        {
            var chance = new Random();
            var percent = chance.Next(0, 4);

            if (enemy.Health > 0 && percent > 1)
            {
                var nmyChance = new Random();
                var lbl2Hold = nmyChance.Next(2, 6);
                enemy.OnAttack(-lbl2Hold);
                this.lblSelf.Text = "Failed Deflect, Hit For " + lbl2Hold;
                this.lblAction.Text = "Successful Hit";
            }

            if (enemy.Health > 0 && percent <= 1)
            {
                Deflected = true;
                var plyrChance = new Random();
                var lblHold = plyrChance.Next(5, 8);
                player.OnAttack(-lblHold);
                this.lblSelf.Text = "Successful Deflect";
                this.lblAction.Text = "Attack Deflected For " + lblHold;
            }

            UpdateHealthBars();
            
            if (player.Health <= 0 || enemy.Health <= 0)
            {
                instance = null;
                Close();
            }
        }

        //This is a single use button to identify the enemies stats (health, strength, battle descriptors),
        //
        private void btnIdentify_Click(object sender, EventArgs e)
        {
            if (Identified == false)
            {
                if (player.Health == 20 && Deflected == false)
                {
                    var nmyChance = new Random();
                    var lbl2Hold = nmyChance.Next(2, 4);
                    enemy.OnAttack(-lbl2Hold);
                    this.lblSelf.Text = "Ambush Attacked, Hit For " + lbl2Hold;
                    UpdateHealthBars();
                }
                lblEnemyHealthFull.Visible = true;
                lblAction.Visible = true;
                this.lblStr.Text = "Strength: " + player.getStrength();
                this.lblAction.Text = "Identified";
                Identified = true;
            }

        }

            private void EnemyDamage(int amount)
        {
            enemy.AlterHealth(amount);
        }

        private void PlayerDamage(int amount)
        {
            player.AlterHealth(amount);
        }

        private void tmrFinalBattle_Tick(object sender, EventArgs e)
        {
            picBossBattle.Visible = false;
            tmrFinalBattle.Enabled = false;
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {

        }
    }
}
