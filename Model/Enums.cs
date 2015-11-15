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

    public enum AttackStyle
    {
        Renge,
        Mili
    };

    public enum Side
    {
        Left,
        Right
    };
    //
    public enum BonusType
    {
        Armor,
        DoubleDamage,
        MoveSpead,
    };
}
