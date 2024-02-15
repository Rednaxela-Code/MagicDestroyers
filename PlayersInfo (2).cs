using System;
using System.Collections.Generic;
using System.IO;
using MagicDestroyers.Characters;

namespace MagicDestroyers
{
    public static class PlayersInfo
    {
        private static string playersInfoDirectoryPath = @"Info\";
        private static string playersInfoFileName = "PlayersInfo.txt";
        private static DirectoryInfo playersInfoDir = new DirectoryInfo(playersInfoDirectoryPath);
        private static FileInfo playersInfoFile = new FileInfo(playersInfoDirectoryPath + playersInfoFileName);
        private static List<string[]> fullInfo = new List<string[]>();

        public static void Initialization(List<Character> characters)
        {
            if (!playersInfoDir.Exists)
            {
                playersInfoDir.Create();
            }

            if (!playersInfoFile.Exists)
            {
                playersInfoFile.Create().Close();

                using (StreamWriter sw = playersInfoFile.CreateText())
                {
                    foreach (var character in characters)
                    {
                        sw.WriteLine($"{character.Name},{character.Scores},{character.Level}");
                    }
                }
            }

            using (StreamReader sr = playersInfoFile.OpenText())
            {
                string line = string.Empty;

                while ((line = sr.ReadLine()) != null)
                {
                    fullInfo.Add(line.Split(','));
                }
            }

            for (int i = 0; i < characters.Count; i++)
            {
                for (int j = 0; j < characters.Count; j++)
                {
                    if (characters[i].Name == fullInfo[j][0])
                    {
                        characters[i].Scores = Convert.ToInt32(fullInfo[j][1]);
                        characters[i].Level = Convert.ToInt32(fullInfo[j][2]);
                    }
                }
            }
        }

        public static void Save(List<Character> characters)
        {
            using (StreamWriter sw = playersInfoFile.CreateText())
            {
                foreach (var character in characters)
                {
                    sw.WriteLine(string.Join(",", $"{character.Name},{character.Scores},{character.Level}"));
                }
            }
        }

        public static void UpdateFullInfo(List<Character> characters)
        {
            for (int i = 0; i < fullInfo.Count; i++)
            {
                fullInfo[i] = ($"{characters[i].Name},{characters[i].Scores},{characters[i].Level}").Split(',');
            }
        }

        public static void PrintFullInfo()
        {
            foreach (var character in fullInfo)
            {
                Console.WriteLine($"Name: {character[0]}, Score: {character[1]}, Level: {character[2]}");
            }
        }

        public static void Reset(List<Character> characters)
        {
            foreach (var character in characters)
            {
                character.Scores = 0;
                character.Level = 1;
            }

            fullInfo.Clear();
            playersInfoFile.Delete();
        }

        // public static void RetrieveFullInfo()
        // {
           
        // }
                      
        // public static void UpdateScores()
        // {
           
        // }
           
        // public static void RetrieveScores()
        // {
           
        // }
           
        // public static void PrintScores()
        // {
           
        // }
           
        // public static void EraseScores()
        // {
           
        // }
           
        // public static void UpdateLevels()
        // {
           
        // }
           
        // public static void RetrieveLevels()
        // {
           
        // }
           
        // public static void PrintLevels()
        // {
           
        // }
           
        // public static void EraseLevels()
        // {
           
        // }
    }
}
