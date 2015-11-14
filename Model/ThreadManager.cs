using Model.Objects;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Model
{
    class ThreadManager
    {
        public static void StartSread(ObservableCollection<Person> units)
        {
            foreach(Person unit in units)
            {
                ThreadPool.QueueUserWorkItem(new WaitCallback(unit.Live));
            }
        }
    }
}
