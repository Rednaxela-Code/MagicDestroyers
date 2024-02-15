using System;
using MagicDestroyers.Equipment.Interfaces;

namespace MagicDestroyers.Equipment.Weapons.Blunt
{
    public class Staff : Blunt, IBuff
    {
        private const int DEFAULT_WEAPONSTAMINA = 10;
        private const int DEFAULT_WEAPONDAMAGE = 11;
        private const int DEFAULT_STAMINA = 1;

        public Staff()
            : this(DEFAULT_WEAPONDAMAGE)
        {

        }
        public Staff(int damage)
            :this(damage, 10)
        {

        }

        public Staff(float stamina)
            : this(10, DEFAULT_WEAPONSTAMINA)
        {

        }

        public Staff(int damage = DEFAULT_WEAPONDAMAGE, int stamina = DEFAULT_WEAPONSTAMINA)
        {
            this.DamagePoints = damage;
        }


        //public Staff()
        //    : this(DEFAULT_DAMAGE_POINTS)
        //{
        //}

        //public Staff(int armorPoints)
        //{
        //    this.DamagePoints = armorPoints;
        //}

        public override void SpecialAbility()
        {
            this.Buff();
        }

        public void Buff()
        {
            this.Empower();
            // More buff abilities...
            // ...
        }

        public void Empower()
        {
            throw new NotImplementedException();
        }
    }
}
