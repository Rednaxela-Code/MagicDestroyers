using System;
using MagicDestroyers.Enums;
using MagicDestroyers.Equipment.Armors.Leather;
using MagicDestroyers.Equipment.Weapons.Blunt;

namespace MagicDestroyers.Characters.Spellcasters
{
    public class Druid : Spellcaster
    {

        private readonly LightLeatherVest DEFAULT_BODY_ARMOR = new LightLeatherVest();
        private readonly Staff DEFAULT_WEAPON = new Staff();

        public Druid()
            : this(Consts.Druid.NAME, 1)
        {
        }

        public Druid(string name, int level)
            : this(name, level, Consts.Druid.HEALTH_POINTS)
        {
        }

        public Druid(string name, int level, int healthPoints)
        {
            this.Name = name;
            this.Level = level;
            this.HealthPoints = healthPoints;
            this.ManaPoints = Consts.Druid.MANA_POINTS;
            this.BodyArmor = DEFAULT_BODY_ARMOR;
            this.Weapon = DEFAULT_WEAPON;
            this.Faction = Faction.Spellcaster;
            base.IsAlive = true;
            base.Scores = 0;
        }

        public int Moonfire()
        {
            return base.Weapon.DamagePoints + 10;
        }

        public int Starburst()
        {
            throw new NotImplementedException();
        }

        public int OneWithTheNature()
        {
            return base.BodyArmor.ArmorPoints + 5;
        }

        public override int Attack()
        {
            return this.Moonfire();
        }

        public override int SpecialAttack()
        {
            return this.Starburst();
        }

        public override int Defend()
        {
            return this.OneWithTheNature();
        }
    }
}
