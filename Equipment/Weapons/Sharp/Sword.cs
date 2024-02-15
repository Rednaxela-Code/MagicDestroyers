using System;
using MagicDestroyers.Equipment.Interfaces;

namespace MagicDestroyers.Equipment.Weapons.Sharp
{
    public class Sword : Sharp, IBuff
    {
        private const int DEFAULT_DAMAGE_POINTS = 10;

        public Sword()
            : this(DEFAULT_DAMAGE_POINTS)
        {
        }

        public Sword(int armorPoints)
        {
            this.DamagePoints = armorPoints;
        }

        public void Bloodthirst()
        {
            throw new NotImplementedException();
        }

        public void Buff()
        {
            this.Bloodthirst();
            // More buff abilities...
            // ...
        }

        public override void SpecialAbility()
        {
            this.Buff();
        }
    }
}
