using System;
using System.Collections.Generic;
using MagicDestroyers.Characters;
using MagicDestroyers.Characters.Melee;
using MagicDestroyers.Characters.Spellcasters;

namespace MagicDestroyers
{
    public class EntryPoint
    {
        static void Main()
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
            
            foreach (var character in characters)
            {
                if (character is Melee)
                {
                    meleeTeam.Add((Melee)character);
                }
                else if (character is Spellcaster)
                {
                    spellTeam.Add((Spellcaster)character);
                }
            }

            PlayersInfo.Initialize(characters);

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
