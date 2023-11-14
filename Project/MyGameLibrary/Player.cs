using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fall2020_CSC403_Project.code {
    public class Player : BattleCharacter {
        public int gold = 0;
        public int player_gold_bag_capacity = 5000;

        public Player(Vector2 initPos, Collider collider) : base(initPos, collider) {
          
        }
        // accepts an int and adds that to the players gold.
        public void updateGold(int gUpdate) {
            if (gUpdate == 0) return;

            if (gUpdate < 0) {
                if (Math.Abs(gUpdate) >= this.gold)
                    this.gold = 0;
                else
                    this.gold += gUpdate;
            }
            else
                this.gold += gUpdate;

            if (this.gold > player_gold_bag_capacity) {
                this.gold = player_gold_bag_capacity;
            }
        }
    }
}
