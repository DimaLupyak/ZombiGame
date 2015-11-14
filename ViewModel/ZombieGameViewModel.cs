using Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ViewModel
{
    
    public class ZombieGameViewModel : INotifyPropertyChanged
    {
        #region Properties
        public World World { get; set; }
        #endregion
        #region Constructor
        public ZombieGameViewModel()
        {
            World = World.Instance;
            StartGame = new Command(arg => StartGameClickMethod());
        }

        public void StartGameClickMethod()
        {
            World.StartGame();
        }

        public ICommand StartGame { get; set; }

        #endregion
        #region Implement INotyfyPropertyChanged members

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        #endregion
    }
}
