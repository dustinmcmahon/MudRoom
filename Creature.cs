using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MudRoom
{
    internal class Creature
    {
        // GLABALS FOR EASY CHANGING LATER
        private static String PLAYER = "Player";
        private static String NPC = "NPC";
        private static String MOB = "Enemy";
        private int _ceatureID;
        private int type;

        public Creature(int creatureID, int type) {
            _ceatureID = creatureID;
            this.type = type;
        }

        public override String ToString() {
            var typeString = "";
            switch (type) {
                case 0:
                    typeString = PLAYER;
                    break;
                case 1:
                    typeString = NPC;
                    break;
                case 2:
                    typeString = MOB;
                    break;
            }
            return $"Creature #{_ceatureID} is a {typeString}";
        }
    }
}
