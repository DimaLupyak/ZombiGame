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

        private static readonly Object lockObject = new Object();
        private static World instance = null;
        private World()
        {
            Persons = new ObservableCollection<Person>();
            Persons.Add(new Person());
            Persons.Add(new Person());
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
        private Map map;
        public ObservableCollection<Person> Persons { get; set; }



    }
}
