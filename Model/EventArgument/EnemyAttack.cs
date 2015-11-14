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

        public EnemyAttack_Event(int damage)
        {
            EnemyDamage = damage;
        }
        public int getEnemyDamage()
        {
            return EnemyDamage;
        }
    }
}
