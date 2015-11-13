using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.EventArgument
{
    public class EnemyAttack_Event :EventArgs
    {
        private int EnemyDamage;

        public int getEnemyDamage()
        {
            return EnemyDamage;
        }
    }
}
