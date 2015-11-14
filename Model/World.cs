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


       // delegate void Live();

        private static readonly Object lockObject = new Object();
        private static World instance = null;

        public Map Map { get; set; }
        public ObservableCollection<Person> Persons { get; set; }
        private World()
        {
            Map = Map.Instance;
            Persons = new ObservableCollection<Person>();

            CreateUnite();

            ThreadManager.StartSread(Persons);

           // ThreadPool.QueueUserWorkItem(new WaitCallback(Looker));
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
                        }
                    }
                }
                catch(Exception e) { }
            }
        }

        public void CreateUnite()
        {
            Random rnd = new Random();
            int x;
            int y;
            for (int i = 0; i < 4; i++)
            {
                do
                {
                    x = rnd.Next(0, 10);
                    y = rnd.Next(0, 99);
                } while (Map.Instance.Areas[x / 10, y / 10] == AreaType.Water);

                Persons.Add(new Person(100, x, y, (Side)0));
            }
            for (int i = 0; i < 4; i++)
            {
                do
                {
                    x = rnd.Next(90, 99);
                    y = rnd.Next(0, 99);
                } while (Map.Instance.Areas[x / 10, y / 10] == AreaType.Water);

                Persons.Add(new Person(100, x, y, (Side)1));
            }
        }

        #region Singleton
        public static World Instance
        {
            get
            {
                if (instance == null)
                    instance = new World();
                return instance;
               
            }
        }
        #endregion
    }
}
