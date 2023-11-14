using System.Drawing;

namespace Fall2020_CSC403_Project.code {

    public class Enemy : BattleCharacter {

        public Image Img { get; set; }
        public bool Flip = false;


        public Color BackgroundColor { get; set; }


        /// <param name="initPos">this is the initial position of the enemy</param>
        /// <param name="collider">this is the collider for the enemy</param>
        public Enemy(Vector2 initPos, Collider collider) : base(initPos, collider) {
        }
    }
}
