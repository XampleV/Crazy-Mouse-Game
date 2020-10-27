using System;
using System.IO;
using System.Windows;
using Newtonsoft.Json;
namespace Crazy_Mouse_Game.functions
{
    class scores
    {
        public static string scoresLocation = @"C:\Users\Public\Documents\scores.json";
        public static dynamic users;
        public static string json;
        public static void MainStart()
        {
            CheckFile();
            LoadScores();
        }
        
        
        public static void CheckFile()
        {
            if (!File.Exists(scoresLocation))
            {
                string defaultJson = "{'highest_score':{'username':'none','time':0}}";
                Root makeFile = JsonConvert.DeserializeObject<Root>(defaultJson);
                string newJson = JsonConvert.SerializeObject(makeFile, Formatting.Indented);
                using (StreamWriter file = File.CreateText(scoresLocation))
                {
                    file.Write(newJson);
                    file.Close();
                }
            }
        }
        public static void LoadScores()
        {
            using (StreamReader r = new StreamReader(scoresLocation))
            {
                json = r.ReadToEnd();
                r.Close();
            }
            users = JsonConvert.DeserializeObject<Root>(json);
            if (users.highest_score.username != "")
            {
                globals.values.highestScoreUsername = users.highest_score.username;
                globals.values.highestTimer = users.highest_score.time;
              
                
            }
        }
        public static void NewHighScore (string username, int newScore)
        {
                users.highest_score.username = username;
                users.highest_score.time = newScore;

                string jsonToBeWritten = JsonConvert.SerializeObject(users, Formatting.Indented);
                using (StreamWriter file = File.CreateText(scoresLocation))
                {
                    file.Write(jsonToBeWritten);
                    file.Close();
                }
            Environment.Exit(1);
        }
    }
    public class HighestScore
    {
        public string username { get; set; }
        public int time { get; set; }
    }

    public class Root
    {
        public HighestScore highest_score { get; set; }
    }


}
