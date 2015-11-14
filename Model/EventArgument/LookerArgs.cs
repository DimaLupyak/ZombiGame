using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.Objects;

namespace Model.EventArgument
{
    class LookerEventArgs : EventArgs
    {
        public Person removeUnit;

        public LookerEventArgs(Person unit)
        {
            this.removeUnit = unit;
        }
        
    }
}
