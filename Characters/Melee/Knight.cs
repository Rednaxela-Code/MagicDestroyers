using System;
using MagicDestroyers.Enums;
using MagicDestroyers.Equipment.Armors.Heavy;
using MagicDestroyers.Equipment.Weapons.Blunt;

namespace MagicDestroyers.Characters.Melee
{
    public class Knight : Melee
    {
        private readonly Chainlink DEFAULT_BODY_ARMOR = new Chainlink();
        private readonly Hammer DEFAULT_WEAPON = new Hammer();

        public Knight()
            : this(Consts.Knight.NAME, 1)
        {
        }

        public Knight(string name, int level)
            : this(name, level, Consts.Knight.HEALTH_POINTS)
        {
        }

        public Knight(string name, int level, int healthPoints)
        {
            base.Name = name;
            base.Level = level;
            base.HealthPoints = healthPoints;
            base.AbilityPoints = Consts.Knight.ABILITY_POINTS;
            base.BodyArmor = DEFAULT_BODY_ARMOR;
            base.Weapon = DEFAULT_WEAPON;
            base.Faction = Faction.Melee;
            base.IsAlive = true;
            base.Scores = 0;
        }

        public int HolyBlow()
        {
            return base.Weapon.DamagePoints + 10;
        }

        public int PurifySoul()
        {
            throw new NotImplementedException();
        }

        public int RighteousWings()
        {
            return base.BodyArmor.ArmorPoints + 5;
        }

        public override int Attack()
        {
            return this.HolyBlow();
        }

        public override int SpecialAttack()
        {
            return this.PurifySoul();
        }

        public override int Defend()
        {
            return this.RighteousWings();
        }
    }
}
