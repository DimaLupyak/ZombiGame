using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public enum AreaType
    {
        Grass=0,
        Water=1,
        Hill=2,
        Swamp=3
    };
    
    enum AttackStyle
    {
        Renge,
        Mili
    };

    public enum Side
    {
        Left,
        Right
    };

    enum BonusType
    {
        Armor,
        DoubleDamage,
        MoveSpead,
    };
}
