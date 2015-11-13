using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Model
{
    class Map
    {
        private AreaType[,] areas { get; set; }
        //aaa
        #region Singleton

            private static readonly Object lockObject = new Object();
        private static Map instance = null;
        private Map()
        {
        }
        public static Map Instance
        {
            get
            {
                if (instance != null) return instance;
                Monitor.Enter(lockObject);
                Map temp = new Map();
                Interlocked.Exchange(ref instance, temp);
                Monitor.Exit(lockObject);
                return instance;
            }
        }
        #endregion
        
        
    }
}
