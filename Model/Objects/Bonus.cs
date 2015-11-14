using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Objects
{
    public class Bonus : INotifyPropertyChanged
    {
        #region Fields

        protected BonusType bonusType;
        protected int efectTime;
        protected int buf;
        #endregion

        #region Properties
        public BonusType BonusType
        {
            get { return bonusType; }
            set
            {
                bonusType = value;
                OnPropertyChanged("BonusType");

            }
        }
        public int EfectTime
        {
            get { return efectTime; }
            set
            {
                efectTime = value;
                OnPropertyChanged("EfectTime");

            }
        }
        public int Buf
        {
            get { return buf; }
            set
            {
                buf = value;
                OnPropertyChanged("Buf");

            }
        }
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
