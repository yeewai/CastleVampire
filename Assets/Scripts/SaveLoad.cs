using UnityEngine;
using System.Collections;
using System.Collections.Generic; 
using System.Runtime.Serialization.Formatters.Binary; 
using System.IO;
using System;

//Manage saves and persistant data
public static class SaveLoad {
  public static List<Game> savedGames = new List<Game>();
  
  public static void Save() {
    Game.current.saveDate = System.DateTime.Now;
    savedGames.Add(Game.current);
    BinaryFormatter bf = new BinaryFormatter();
    FileStream file = File.Create (Application.persistentDataPath + "/savedGames.ss");
    bf.Serialize(file, SaveLoad.savedGames);
    file.Close();
  }
  
  public static void Load() {
    if(File.Exists(Application.persistentDataPath + "/savedGames.ss")) {
      BinaryFormatter bf = new BinaryFormatter();
      FileStream file = File.Open(Application.persistentDataPath + "/savedGames.ss", FileMode.Open);
      SaveLoad.savedGames = (List<Game>)bf.Deserialize(file);
      file.Close();
    }
  }
}
