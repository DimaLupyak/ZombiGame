using Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace ViewModel
{
    
    public class ZombieGameViewModel : INotifyPropertyChanged
    {
        #region Properties
        public World World { get; set; }
        public int ButtonWidth { get; set; }
        #endregion
        #region Constructor
        public ZombieGameViewModel()
        {
            World = World.Instance;
            StartGame = new Command(arg => StartGameClickMethod());
            Exit = new Command(arg => ExitClickMethod());
            ButtonWidth = (int)(SystemParameters.WorkArea.Width - SystemParameters.WorkArea.Height) / 3; ;
        }

        private void StartGameClickMethod()
        {
            World.Instance.StartGame();
        }
        private void ExitClickMethod()
        {
            Environment.Exit(0);
        }
        public ICommand StartGame { get; set; }
        public ICommand Exit { get; set; }
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
