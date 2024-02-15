using System;
using MagicDestroyers.Enums;
using MagicDestroyers.Equipment.Armors.Leather;
using MagicDestroyers.Equipment.Weapons.Sharp;

namespace MagicDestroyers.Characters.Melee
{
    public class Assassin : Melee
    {
        private readonly LightLeatherVest DEFAULT_BODY_ARMOR = new LightLeatherVest();
        private readonly Sword DEFAULT_WEAPON = new Sword();

        public Assassin()
            : this(Consts.Assassin.NAME, 1)
        {
        }

        public Assassin(string name, int level)
            : this(name, level, Consts.Assassin.HEALTH_POINTS)
        {
        }

        public Assassin(string name, int level, int healthPoints)
        {
            base.Name = name;
            base.Level = level;
            base.HealthPoints = healthPoints;
            base.AbilityPoints = Consts.Assassin.ABILITY_POINTS;
            base.BodyArmor = DEFAULT_BODY_ARMOR;
            base.Weapon = DEFAULT_WEAPON;
            base.Faction = Faction.Melee;
            base.IsAlive = true;
            base.Scores = 0;
        }

        public int Raze()
        {
            return base.Weapon.DamagePoints + 10;
        }

        public int BleedToDeath()
        {
            throw new NotImplementedException();
        }

        public int Survival()
        {
            return base.BodyArmor.ArmorPoints + 5;
        }

        public override int Attack()
        {
            return this.Raze();
        }

        public override int SpecialAttack()
        {
            return this.BleedToDeath();
        }

        public override int Defend()
        {
            return this.Survival();
        }
    }
}
