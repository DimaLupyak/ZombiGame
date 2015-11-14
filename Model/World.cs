using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Model.Objects;
using System.Collections.ObjectModel;
using Model.EventArgument;
using System.Windows;

namespace Model
{
    public class World
    {
        #region Singleton

       // delegate void Live();

        private static readonly Object lockObject = new Object();
        private static World instance = null;

        public Map Map { get; set; }
        public ObservableCollection<Person> Persons { get; set; }

        private event EventHandler<LookerEventArgs> Remove;
        private World()
        {
            Map = Map.Instance;
            Persons = new ObservableCollection<Person>();

            Remove += RemovekEvent;
            Random rnd = new Random();
            for (int i = 0; i < 6; i++)
            {
                Persons.Add(new Person(50, rnd.Next(0, 100), rnd.Next(0, 1000), (Side)0));
            }
            for (int i = 0; i < 5; i++)
            {
                Persons.Add(new Person(50, rnd.Next(900, 1000), rnd.Next(0, 1000), (Side)1));
            }
            //Persons.Add(new Person(50, 0, 0, Side.Left));
            //Persons.Add(new Person(50, 500, 200, Side.Right));
            //Persons.Add(new Person(50, 400, 600, Side.Right));
            //Persons.Add(new Person(50, 800, 700, Side.Left));
            foreach (Person person in Persons)
            {
                ThreadPool.QueueUserWorkItem(new WaitCallback(person.Live));
            }
            ThreadPool.QueueUserWorkItem(new WaitCallback(Looker));
        }

        private void Looker(Object stateInfo)
        {
            while (true)
            {
                try
                {
                    foreach (Person unit in Persons)
                    {
                        if (unit.HelthPoint <= 0)
                        {
                            Application.Current.Dispatcher.BeginInvoke(new Func<bool>(() => Persons.Remove(unit)));
                            break;
                            //Remove(this, new LookerEventArgs(unit));
                        }
                    }
                }
                catch(Exception e) { }
            }
        }

        private void RemovekEvent(object sender, LookerEventArgs e)
        {
            Application.Current.Dispatcher.BeginInvoke(new Func<bool>(() =>
            
                Persons.Remove(e.removeUnit)
            ));
                    
        }

        public static World Instance
        {
            get
            {
                if (instance != null) return instance;
                Monitor.Enter(lockObject);
                World temp = new World();
                Interlocked.Exchange(ref instance, temp);
                Monitor.Exit(lockObject);
                return instance;
            }
        }
        #endregion
        



    }
}
