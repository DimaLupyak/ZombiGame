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

        private Map map;
        public ObservableCollection<Person> Persons { get; set; }
        private World()
        {
            map = Map.Instance;
            Persons = new ObservableCollection<Person>();
            Person firstPersone = new Person(50, 0, 0, Side.Left);
            Person secondPerson = new Person(20, 99, 99, Side.Right);
            Person secondPerson3 = new Person(20, 0, 99, Side.Right);
            Persons.Add(firstPersone);
            Persons.Add(secondPerson);
            Persons.Add(secondPerson3);
            Thread threadPersoneFirst = new Thread(new ThreadStart(firstPersone.Live));
            threadPersoneFirst.Start();

            Thread threadPersoneSecond = new Thread(new ThreadStart(secondPerson.Live));
            threadPersoneSecond.Start();
            Thread threadPersoneFirst3 = new Thread(new ThreadStart(secondPerson3.Live));
            threadPersoneFirst3.Start();
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
