using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.EventArgument;

namespace Model.Objects
{
    class Person : GameObject
    {
        private String heroName { set; get; }
        private int helthPoint { set; get; }
        private int damage { set; get; }
        private int armor { set; get; }
        private int moveSpead { set; get; }
        private int mana { set; get; }
        private int range { set; get; }
        private AttackStyle attackStyle { get; set; }
        private Side team { set; get; }

        public event EventHandler<EnemyAttack_Event> AttackEnemy;

        public void TakingDamage(object sender, EnemyAttack_Event e)
        {
            int realDamage = e.getEnemyDamage() - armor / 10;
            helthPoint -= realDamage;
        }

        public void Live()
        {
        }
    }
}
