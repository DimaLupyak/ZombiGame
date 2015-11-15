using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.EventArgument;
using System.Drawing;
using Model;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Threading;
using System.Windows.Forms;

namespace Model.Objects
{
    public class Person : GameObject, INotifyPropertyChanged
    {
        #region Fields
        protected String heroName;
        protected int helthPoint;
        protected int damage;
        protected int armor;
        protected int moveSpead;
        protected int mana;
        protected int range;
        protected AttackStyle attackStyle;
        protected Vektor vektor;

        #endregion
        #region Properties
        public Side Team { get; set; }
        public Person Goal { get; set; }
        public int Size { get; private set; }
        new public int X
        {
            get { return x; }
            set
            {
                x = value;
                OnPropertyChanged("X");

            }
        }

        new public int Y
        {
            get { return y; }
            set
            {
                y = value;
                OnPropertyChanged("Y");

            }
        }

        public Vektor Vektor
        {
            get { return vektor; }
            set
            {
                vektor = value;
                OnPropertyChanged("Vektor");

            }
        }

        public int HelthPoint
        {
            get { return helthPoint; }
            set
            {
                helthPoint = value;
                OnPropertyChanged("HelthPoint");

            }
        }



        public Person(int helthPoint, int x, int y, Side team)
        {
            this.HelthPoint = helthPoint;
            this.x = x;
            this.y = y;
            this.Team = team;
            this.damage = 2;
            range = 5;
            Size = (int)SystemInformation.VirtualScreen.Height / 20;

        }

        private bool isAlive()
        {
            if (HelthPoint <= 0)
            {
                return false;
            }
            else
                return true;

        }
        #endregion


        private void Move()
        {
            if (Goal != null)
            {
                List<Point> CurentPoints = new List<Point>();
                CurentPoints = FindWay.FindPath(World.Instance.Map.Areas, new Point(X, Y), new Point(Goal.X, Goal.Y));
                try
                {
                    Point bestStep = CurentPoints[1];
                    X = bestStep.X;
                    Y = bestStep.Y;
                }
                catch (Exception e) { }
            }


        }

        public event EventHandler<EnemyAttack_Event> AttackEnemy;
        public void TakingDamage(object sender, EnemyAttack_Event e)
        {
            int realDamage = e.getEnemyDamage() - armor / 10;
            HelthPoint -= realDamage;

            if (HelthPoint <= 0)
            {
                EventArgs ex = new EventArgs();
                if (RemoveMe != null)
                {
                    RemoveMe(this, ex);
                }

            }
        }



        public void Live(Object stateInfo)
        {
            while (HelthPoint >= 0)
            {
                //if(Goal == null)
                //{
                Goal = FindGoal(World.Instance.Persons);
                //}
                if (Goal != null)
                {
                    if (Math.Abs(X - Goal.X) < range && Math.Abs(Y - Goal.Y) < range)
                    {
                        AttackEnemy += Goal.TakingDamage;
                        AttackEnemy(this, new EnemyAttack_Event(damage));
                    }
                    else
                    {
                        Move();
                    }
                }
                Thread.Sleep(100);
            }
        }

        private Person FindGoal(ObservableCollection<Person> Persons)
        {

            Person goal = null;
            int minDistance = Int32.MaxValue;
            try {
                foreach (Person person in Persons)
                {
                    if (this.Equals(person)) continue;
                    if (Team == person.Team) continue;
                    int distanse = Math.Abs(X - person.X) + Math.Abs(Y - person.Y);
                    if (minDistance > distanse)
                    {
                        minDistance = distanse;
                        goal = person;
                    }
                }
            }
            catch (Exception e) { }
            return goal;
        }

        #region Implement INotyfyPropertyChanged members

        public event PropertyChangedEventHandler PropertyChanged;
        public event EventHandler RemoveMe;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        #endregion

    }
}
