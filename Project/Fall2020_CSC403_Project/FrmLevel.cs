using Fall2020_CSC403_Project.code;
using System;
using System.Drawing;
using System.Windows.Forms;
using System.Media;
using System.Drawing.Text;
using Fall2020_CSC403_Project.Properties;
using System.Collections.Generic;

namespace Fall2020_CSC403_Project
{
    public partial class FrmLevel : Form
    {
        private Player player;

        private Enemy enemyPoisonPacket;
        private Enemy bossKoolaid;
        private Enemy enemyCheeto;
        private Character[] walls;
        private Character pickup_gold_001;
        private Character cat_pickup;
        private Character snuggiePickup;

        private DateTime timeBegin;
        private FrmBattle frmBattle;
        private static SoundPlayer backgroundMusic;
        private static bool IsMusicPlaying = true;
        private bool pause = true;

        private bool invOpen = false;

        public FrmLevel()
        {
            InitializeComponent();
            backgroundMusic = new SoundPlayer("data/backgroundMusicPlayer.wav");


        }

        private void dataGridViewInventory_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e) {
            if (dataGridViewInventory.Columns[e.ColumnIndex].Name == "ItemImageColumn" && e.Value is Image) {
                e.Value = e.Value;
            }
        }


        private void FrmLevel_Load(object sender, EventArgs e)
        {
            const int PADDING = 7;
            const int NUM_WALLS = 13;

            player = new Player(CreatePosition(picPlayer), CreateCollider(picPlayer, PADDING));
            bossKoolaid = new Enemy(CreatePosition(picBossKoolAid), CreateCollider(picBossKoolAid, PADDING));
            enemyPoisonPacket = new Enemy(CreatePosition(picEnemyPoisonPacket), CreateCollider(picEnemyPoisonPacket, PADDING));
            enemyCheeto = new Enemy(CreatePosition(picEnemyCheeto), CreateCollider(picEnemyCheeto, PADDING));

            pickup_gold_001 = new Character(CreatePosition(pickup_gold), CreateCollider(pickup_gold, PADDING));
            cat_pickup = new Character(CreatePosition(orangeCatPictureBox), CreateCollider(orangeCatPictureBox, PADDING));
            snuggiePickup = new Character(CreatePosition(snuggiePictureBox), CreateCollider(snuggiePictureBox, PADDING));

            bossKoolaid.Img = picBossKoolAid.BackgroundImage;
            enemyPoisonPacket.Img = picEnemyPoisonPacket.BackgroundImage;
            enemyCheeto.Img = picEnemyCheeto.BackgroundImage;

            StartBackgroundMusic();
            IsMusicPlaying = true;

            bossKoolaid.BackgroundColor = Color.Red;
            enemyPoisonPacket.BackgroundColor = Color.Green;
            enemyCheeto.BackgroundColor = Color.FromArgb(255, 245, 161);

            walls = new Character[NUM_WALLS];
            for (int w = 0; w < NUM_WALLS; w++)
            {
                PictureBox pic = Controls.Find("picWall" + w.ToString(), true)[0] as PictureBox;
                walls[w] = new Character(CreatePosition(pic), CreateCollider(pic, PADDING));
            }

            Game.player = player;
            timeBegin = DateTime.Now;

            // Player starts with an item
            Item pgItem = new Item("Peanut's Gauntlet", "lore team add description!", Resources.peanutgauntlet);
            player.inventory.AddItem(pgItem);
            dataGridViewInventory.Dock = DockStyle.Fill;
            dataGridViewInventory.BringToFront();
            dataGridViewInventory.CellFormatting += dataGridViewInventory_CellFormatting;
        }

        public static void ToggleBackgroungMusic()
        {
            if (IsMusicPlaying)
            {
                backgroundMusic.Stop();
                IsMusicPlaying = false;
            }
            else
            {
                backgroundMusic.PlayLooping();
                IsMusicPlaying=true;
            }
        }

        public void StartBackgroundMusic()
        {
            backgroundMusic.PlayLooping();
        }

        private Vector2 CreatePosition(PictureBox pic)
        {
            return new Vector2(pic.Location.X, pic.Location.Y);
        }

        private Collider CreateCollider(PictureBox pic, int padding)
        {
            Rectangle rect = new Rectangle(pic.Location, new Size(pic.Size.Width - padding, pic.Size.Height - padding));
            return new Collider(rect);
        }

        private void FrmLevel_KeyUp(object sender, KeyEventArgs e)
        {
            // this hides the inventory when you let go of 'i'
            if (e.KeyCode == Keys.I) {
                invOpen = false;
                ShowInventoryNow();
            }

            player.ResetMoveSpeed();
        }

        private void tmrUpdateInGameTime_Tick(object sender, EventArgs e)
        {
            TimeSpan span = DateTime.Now - timeBegin;
            string time = span.ToString(@"hh\:mm\:ss");
            lblInGameTime.Text = "Time: " + time.ToString();
        }

        private void tmrPlayerMove_Tick(object sender, EventArgs e)
        {
            // move player
            if (pause == false)
            {
                player.Move();
            }

            // check collision with walls
            if (HitAWall(player))
            {
                player.MoveBack();
            }
            // check collision with gold pick ups
            if (HitAChar(player, pickup_gold_001))
            {
                pickUpGold(player); // updates gold counter
                // need to hide image
                pickup_gold.Dispose();

                // need to destroy this item
                pickup_gold_001.Collider.RemoveMe();
                Invalidate();
                //this.pickup_gold_001.Collider.MovePosition(0, 0);

            }
            if (HitAChar(player, cat_pickup)){
                Item cat = new Item("cat", "does cat like things", Resources.orangecat);
                player.inventory.AddItem(cat);
                orangeCatPictureBox.Dispose();
                cat_pickup.Collider.RemoveMe();
                Invalidate();
            }
            if (HitAChar(player, snuggiePickup)) {
                Item snuggie = new Item("Flaming hot cheetos Snuggie", "protects from cold icy environments.", Resources.snuggie);
                player.inventory.AddItem(snuggie);
                snuggiePictureBox.Dispose();
                snuggiePickup.Collider.RemoveMe();
                Invalidate();
            }

            // check collision with enemies
            if (HitAChar(player, enemyPoisonPacket))
            {
                Fight(enemyPoisonPacket);
            }
            else if (HitAChar(player, enemyCheeto))
            {
                Fight(enemyCheeto);
            }
            if (HitAChar(player, bossKoolaid))
            {
                Fight(bossKoolaid);
            }

            // update player's picture box
            picPlayer.Location = new Point((int)player.Position.x, (int)player.Position.y);
            updateOnGoldDisplay();
        }

        private bool HitAWall(Character c)
        {
            bool hitAWall = false;
            for (int w = 0; w < walls.Length; w++)
            {
                if (c.Collider.Intersects(walls[w].Collider))
                {
                    hitAWall = true;
                    break;
                }
            }
            return hitAWall;
        }

        private bool HitAChar(Character you, Character other)
        {
            return you.Collider.Intersects(other.Collider);
        }

        private void Fight(Enemy enemy)
        {
            player.ResetMoveSpeed();
            player.MoveBack();
            frmBattle = FrmBattle.GetInstance(enemy);
            frmBattle.Show();

            if (enemy == bossKoolaid)
            {
                frmBattle.SetupForBossBattle();
            }

        }
        private void pickUpGold(Player player) {
            player.updateGold(5);
            goldDisplay.Text = player.gold.ToString();
        }
        public void updateOnGoldDisplay() {
            goldDisplay.Text = player.gold.ToString();
        }

        private void FrmLevel_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Left:
                    player.GoLeft();
                    break;

                case Keys.Right:
                    player.GoRight();
                    break;

                case Keys.Up:
                    player.GoUp();
                    break;

                case Keys.Down:
                    player.GoDown();
                    break;
                // shows the inventory when you hold down 'i'
                case Keys.I:
                    invOpen = true;
                    ShowInventoryNow();
                    break;

                // open the character screen when pressing escape key on keyboard.
                case Keys.Escape:
                    CharacterScreen character = new CharacterScreen();
                    character.Show();
                    break;
                case Keys.M:
                    pause = true;
                    Menu();
                    break;
                default:
                    player.ResetMoveSpeed();
                    break;
            }
        }

        private void ShowInventoryNow() {
            if (invOpen) {
                dataGridViewInventory.Rows.Clear();
                List<Item> invItems = player.inventory.GetItems();
                foreach (Item item in invItems) {
                    dataGridViewInventory.Rows.Add(item.Name, item.ItemImage, item.Description);
                }
                dataGridViewInventory.Visible = true;
            }
            else {
                dataGridViewInventory.Visible = false;
            }
        }

        private void Menu()
                {
                    if (playcontrolmenu.Visible != true)
                    {
                        playcontrolmenu.Enabled = true;
                        playcontrolmenu.Visible = true;
                    }
                    else
                    {
                        playcontrolmenu.Enabled = false;
                        playcontrolmenu.Visible = false;

                    }
                }

            
        

        private void lblInGameTime_Click(object sender, EventArgs e)
        {

        }

        private void Label1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e) {

        }

        private void picEnemyPoisonPacket_Click(object sender, EventArgs e) {

        }

        // handles the button press to open the settings menu
        private void settings_button_Click(object sender, EventArgs e)
        {
            // place opener for settings here.
        }

        private void playcontrolmenu_Click_1(object sender, EventArgs e)
        {
            MouseEventArgs me = (MouseEventArgs)e;
            Point coordinates = me.Location;
            if (175<coordinates.X && coordinates.X < 383 && 215 < coordinates.Y && coordinates.Y < 285)
            
            {
                pause = false;
                Menu();

            }
            else if (175 < coordinates.X && coordinates.X < 383 && 294 < coordinates.Y && coordinates.Y < 360)
           
            {
                Close();
            }
        }
            
        private void StartGame()
        {

        }
        private void CloseGame()
            {
                Close();
            }

        private void pictureBox3_Click(object sender, EventArgs e)
            {
                CloseGame();
            }
        }
    }
