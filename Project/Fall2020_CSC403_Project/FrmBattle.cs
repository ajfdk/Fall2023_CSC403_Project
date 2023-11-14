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

        private FrmBattle()
        {
            InitializeComponent();
            player = Game.player; //start background music
            PlayAudio("data/backgroundMusicPlayer.wav"); //start background music
        }

        //play audio file method
        private void PlayAudio(string filePath)
        {
            waveOut = new WaveOutEvent();
            audioFile = new AudioFileReader(filePath); //read audio file
            waveOut.Init(audioFile);
            waveOut.Play(); //start playing audio
        }

        private void SetVolume(float volume)
        {
            if (waveOut != null) //check for non null output device
            {
                waveOut.Volume = volume; //adjust volume setting
            }
        }

        //volume controll scroll event
        private void trackBarVolume_Scroll(object sender, EventArgs e)
        {
            TrackBar trackBar = (TrackBar)sender; //cast sender to trackbar
            float volume = trackBar.Value / 100f; // Convert to a scale of 0 to 1
            SetVolume(volume); //apply volume change
        }
        public void Setup()
        {
            // update for this enemy
            picEnemy.BackgroundImage = enemy.Img;
            picEnemy.Refresh();
            BackColor = enemy.BackgroundColor;
            picBossBattle.Visible = false;
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
            switch (charbattle) //switch in charracterbattle
            {
                case 1:
                    picPlayer.BackgroundImage = Properties.Resources.cat; //set player image to cat
                    break;
                case 2:
                    picPlayer.BackgroundImage = Properties.Resources.hk; //set player image to hello kitty
                    break;
                case 0:
                    picPlayer.BackgroundImage = Properties.Resources.player; //set player image to default

                    break;
               
            }
        }


        public void SetupForBossBattle()
        {
            picBossBattle.Location = Point.Empty;
            picBossBattle.Size = ClientSize;
            picBossBattle.Visible = true;

            SoundPlayer simpleSound = new SoundPlayer(Resources.final_battle);
            simpleSound.Play(); //play the sound

            string audioFilePath = "data/backgroundMusicPLayer.wav"; //path to audio file
            waveOut = new WaveOutEvent();
            audioFile = new AudioFileReader(audioFilePath); 
            waveOut.Init(audioFile); //initialize audio output with file reader
            waveOut.Play(); //play audio file
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
            charbattle = charactorchoice; //assign characterchoice for the battle
            if (instance == null)
            {
                instance = new FrmBattle();
                instance.enemy = enemy;
                instance.Setup(); //set up instance with enemy and character choice
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
            player.OnAttack(-(plyrChance.Next(2, 10)));

            if (enemy.Health > 0) {

                var nmyChance = new Random();
                enemy.OnAttack(-(nmyChance.Next(3, 9)));
            }

            UpdateHealthBars();
            if (player.Health <= 0 || enemy.Health <= 0) {
                player.updateGold(10); // player gets gold for winning (and losing because you're worth it mr peanut)
                instance = null;
                Close();
            }
        }


        //This is a button to heal for a random amount but can only be used a certain set number of times
        //It also stops the health at 20 if the heal would overflow
        //Addeed extra functionality that shows the number of heals readily available
        private void btnHeal_Click(object sender, EventArgs e)
        {
            if (player.Health > 0 && enemy.Health > 0)
            {
                if (uses < 2 && player.Health != 20)
                {
                    uses++;
                    var plyrChance = new Random();
                    player.AlterHealth(plyrChance.Next(5, 7));

                    if (enemy.Health != 20)
                    {
                        enemy.AlterHealth(1);

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
        //Added extra functionality to show if succesful or not
        private void btnDeflect_Click(object sender, EventArgs e)
        {
            var chance = new Random();
            var percent = chance.Next(0, 4);

            if (enemy.Health > 0 && percent > 1)
            {
                var nmyChance = new Random();
                enemy.OnAttack(-(nmyChance.Next(2, 6)));
                this.btnDeflect.Text = "Failed";
            }

            if (enemy.Health > 0 && percent <= 1)
            {
                var plyrChance = new Random();
                player.OnAttack(-(plyrChance.Next(5, 8)));
                this.btnDeflect.Text = "Success";
            }

            UpdateHealthBars();
            
            if (player.Health <= 0 || enemy.Health <= 0)
            {
                instance = null;
                Close();
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
