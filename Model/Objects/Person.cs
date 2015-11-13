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
        private String heroName { set; get; }
        private int helthPoint { set; get; }
        private int damage { set; get; }
        private int armor { set; get; }
        private int moveSpead { set; get; }
        private int mana { set; get; }
        private int range { set; get; }
        private AttackStyle attackStyle { get; set; }
        private Side team { set; get; }

        public Person(int helthPoint, int x, int y, Side team) 
        {
            this.helthPoint = helthPoint;
            this.X = x;
            this.Y = y;
            this.team = team;
        }

        private bool isAlive() {
            if (helthPoint <= 0)
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
                if ((this.X == person.X) && (person.Y == this.Y) && this.team != person.team)
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
            int realDamage = e.getEnemyDamage() - armor / 10;
            helthPoint -= realDamage;
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
