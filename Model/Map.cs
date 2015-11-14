using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Model
{
    class Map
    {
        private AreaType[,] areas { get; set; }
        public int[,] ways { get; private set; }
        #region Singleton

        private static readonly Object lockObject = new Object();
        private static Map instance = null;
        private Map()
        {
            areas = new AreaType[100, 100];
            ways = new int[100, 100];
            //ways = GenMap(100,100);
            //MessageBox.Show(ways[2,4].ToString(), "gdsg", MessageBoxButtons.OK);
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
        #endregion+		rnd	null	System.Random


        //public int[,] GenMap(int x,int y) 
        //{
            
           
        //    int[,] a = new int[x,y];
            
        //    for (int i = 0; i < x;i++ )
        //        for (int o = 0; o < y; o++) 
        //        {
        //            Random rnd = new Random(3);
        //            rnd.Next(a[i, o]);
        //        }

        //    return a;
        //}

        public void SetLand(int x, int y, AreaType land)
        {
            areas[x, y] = land;
            ways[x, y] = (int)land;
        }        
    }
}
