using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Model.Objects;
using System.Collections.ObjectModel;

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
        private World()
        {
            Map = Map.Instance;
            Persons = new ObservableCollection<Person>();
            Random rnd = new Random();
            for(int i = 0; i < 3; i++)
            {
                Persons.Add(new Person(50, rnd.Next(100,800), rnd.Next(100, 400), (Side)rnd.Next(0, 2)));
            }
            //Persons.Add(new Person(50, 0, 0, Side.Left));
            //Persons.Add(new Person(50, 0, 200, Side.Right));
            //Persons.Add(new Person(50, 400, 600, Side.Right));
            //Persons.Add(new Person(50, 800, 700, Side.Left));
            foreach (Person person in Persons)
            {
                new Thread(new ThreadStart(person.Live)).Start();
            }
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
