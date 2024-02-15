namespace MagicDestroyers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using MagicDestroyers.Characters;
    using MagicDestroyers.Characters.Melee;
    using MagicDestroyers.Characters.Spellcasters;

    public class EntryPoint
    {
        public static void Main()
        {
            bool gameOver = false;

            Random rng = new Random();
            
            Melee currentMelee;
            Spellcaster currentSpellcaster;

            List<Melee> meleeTeam = new List<Melee>();
            List<Spellcaster> spellTeam = new List<Spellcaster>();

            List<Character> characters = new List<Character>()
            {
                new Warrior(),
                new Knight(),
                new Assassin(),
                new Mage(),
                new Necromancer(),
                new Druid()
            };

            //*
            meleeTeam = characters.OfType<Melee>().ToList();
            spellTeam = characters.OfType<Spellcaster>().ToList();

            //*/

            meleeTeam = characters.Where(c => c is Melee).Cast<Melee>().ToList();
            spellTeam = characters.Where(c => c is Spellcaster).Cast<Spellcaster>().ToList();
            
            

            PlayersInfo.Initialization(characters);

            while (!gameOver)
            {
                currentMelee = meleeTeam[rng.Next(0, meleeTeam.Count)];
                currentSpellcaster = spellTeam[rng.Next(0, spellTeam.Count)];

                currentSpellcaster.TakeDamage(currentMelee.Attack(), currentMelee.Name, currentMelee.GetType().ToString());

                if (!currentSpellcaster.IsAlive)
                {
                    currentMelee.WonBattle();
                    spellTeam.Remove(currentSpellcaster);

                    if (spellTeam.Count == 0)
                    {
                        Tools.ColorfulWriteLine("\nMelee team wins!", ConsoleColor.Red);
                        break;
                    }
                    else
                    {
                        currentSpellcaster = spellTeam[rng.Next(0, spellTeam.Count)];
                    }
                }

                currentMelee.TakeDamage(currentSpellcaster.Attack(), currentSpellcaster.Name, currentSpellcaster.GetType().ToString());

                if (!currentMelee.IsAlive)
                {
                    currentSpellcaster.WonBattle();
                    meleeTeam.Remove(currentMelee);

                    if (meleeTeam.Count == 0)
                    {
                        Tools.ColorfulWriteLine("\nSpell team wins!", ConsoleColor.Red);

                        break;
                    }
                    else
                    {
                        currentMelee = meleeTeam[rng.Next(0, meleeTeam.Count)];
                    }
                }
            }
            
            PlayersInfo.UpdateFullInfo(characters);

            PlayersInfo.Save(characters);

            PlayersInfo.PrintFullInfo();
        }
    }
}
