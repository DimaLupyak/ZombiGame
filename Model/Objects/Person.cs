using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.EventArgument;
using System.Drawing;
using PathFinder;
using Model;
using System.Collections.ObjectModel;


namespace Model.Objects
{
    public class Person : GameObject
    {
        public String HeroName { set; get; }
        public int HelthPoint { set; get; }
        public int Damage { set; get; }
        public int Armor { set; get; }
        public int MoveSpead { set; get; }
        public int Mana { set; get; }
        public int Range { set; get; }
        public AttackStyle AttackStyle { get; set; }
        public Side Team { set; get; }

        public Person(int helthPoint, int x, int y, Side team) 
        {
            this.HelthPoint = helthPoint;
            this.X = x;
            this.Y = y;
            this.Team = team;
        }

        private bool isAlive() {
            if (HelthPoint <= 0)
            {
                return false;
            }
            else
                return true;
           
        }

        private void Move(ObservableCollection<Person> Persons)
        {
            List<Point> CurentPoints = new List<Point>();
            int minCount = 1000;
            Point bestStep = new Point();
            foreach(Person person in Persons)
            {
                if ((this.X == person.X) && (person.Y == this.Y) && this.Team != person.Team)
                {
                    Map map = Map.Instance;

                    CurentPoints = FindWay.FindPath(map.ways, new Point(this.X, this.Y), new Point(person.X, person.Y));
                    if (CurentPoints.Count < minCount)
                    {
                        bestStep = CurentPoints.First();
                    }
                }
            }
            this.X = bestStep.X;
            this.Y = bestStep.Y;
        }

        public event EventHandler<EnemyAttack_Event> AttackEnemy;

        public void TakingDamage(object sender, EnemyAttack_Event e)
        {
            int realDamage = e.getEnemyDamage() - Armor / 10;
            HelthPoint -= realDamage;
        }

        public void Live()
        {
            while (isAlive())
            {
                Move(World.Instance.Persons);
            }
        }

    }
}
