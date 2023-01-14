using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MudRoom
{
    internal class Creature
    {
        private static int CREATURESEED = 1;
        private int _ceatureID;
        private int type;

        public Creature(int type) {
            _ceatureID = CREATURESEED;
            this.type = type;
            CREATURESEED++;
        }
    }
}
