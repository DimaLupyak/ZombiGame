using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Model.Objects;

namespace Model
{
    class World
    {
        #region Singleton

        private static readonly Object lockObject = new Object();
        private static World instance = null;
        private World() { }
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
        private List<Person> units;

        public List<Person> GetUnits()
        {
            return units;
        }


    }
}
