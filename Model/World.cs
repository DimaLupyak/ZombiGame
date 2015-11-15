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
        private bool flag = true;

        public Map Map { get; set; }
        public ObservableCollection<Person> Persons { get; set; }
        private World()
        {
            Map = Map.Instance;
            Persons = new ObservableCollection<Person>();

            CreateUnite(20);
        }
        private int sideCount = 25;
        private int man = 0;
        private int zombe = 0;
        public int Vinner { get; set; }

        private void checkPersonList(ObservableCollection<Person> pers)
        {
            try
            {
                lock (lockObject)
                {
                    if (flag)
                    {
                        int c = 0;
                        int k = 0;
                        foreach (Person person in pers)
                        {
                            if (person.Team.ToString() == "Right") c++;
                            if (person.Team.ToString() == "Left") k++;
                        }
                        if (c == pers.Count)
                        {
                            
                            MessageBox.Show("Zombies winner!");

                            flag = false;
                        }
                        if (k == pers.Count)
                        {
                            
                            MessageBox.Show("Humans winner!");
                            flag = false;
                        }
                    }
                 }
             }catch (Exception e) { }
        }
   

        private void RemoveUnitEvent(object sender, EventArgs e)
        {
            Application.Current.Dispatcher.BeginInvoke(new Func<bool>(() => Persons.Remove((Person)sender)));
            checkPersonList(Persons);
            

        }

        public void StartGame()
        {
            ThreadManager.StartSread(Persons);
        }

        public void CreateUnite(int sideCount)
        {
            Random rnd = new Random();
            int x;
            int y;
            for (int i = 0; i < sideCount; i++)
            {
                do
                {
                    x = rnd.Next(0, 10);
                    y = rnd.Next(0, 99);
                } while (Map.Instance.Areas[x / 10, y / 10] == AreaType.Water);

                Persons.Add(new Person(100, x, y, (Side)0));
                Persons[i].RemoveMe += RemoveUnitEvent;
            }
            for (int i = 0; i < 5; i++)
            {
                do
                {
                    x = rnd.Next(90, 99);
                    y = rnd.Next(0, 99);
                } while (Map.Instance.Areas[x / 10, y / 10] == AreaType.Water);
                Person person = new Person(100, x, y, (Side)1);
                person.RemoveMe += RemoveUnitEvent;
                Persons.Add(person);
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
