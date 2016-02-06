using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public static class Database {
  public static T getRandomFrom<T>(List<T> l) {
    return l[UnityEngine.Random.Range(0, l.Count)];
  }
  public static T getRandomFrom<T>(T[] l) {
    return l[UnityEngine.Random.Range(0, l.Length)];
  }
  
  public static string getRandomFromKey(string key) {
    return getRandomFrom(getFromKey(key));
  }
  
  static Dictionary<string, string[]> data;
  public static string[] getFromKey(string key) {
    if (data == null) {
      data = new Dictionary<string, string[]>();
      string path = Application.dataPath + "/Resources/Data/";
      foreach (string file in System.IO.Directory.GetFiles(path)) {
        if (file.Substring(file.Length - 4) != "meta") {
         string k = file.Substring(path.Length);
         k = k.Split('.')[0];
         data.Add(k, ((TextAsset)Resources.Load("Data/" + k)).text.Split('\n'));
        }
      }
    }
    
    return data[key];
  }
  
  static Dictionary<string, List<string>> characterOptions;
  public static Dictionary<string, List<string>> CharacterOptions() {
    if (characterOptions == null) {
      //populate the character options
      characterOptions = new Dictionary<string, List<string>>();
      
      foreach(string key in new string[] {"head", "body"}) {
        List<string> options = new List<string>();
        
        string path = Application.dataPath + "/Resources/Sprites/people/";
        foreach (string file in System.IO.Directory.GetFiles(path + key)) {
           if (file.Substring(file.Length - 4) != "meta") {
             string s = file.Substring(path.Length);
             options.Add(s.Split('.')[0]);
           }
        }
        characterOptions.Add(key, options);
      }
    }
    return characterOptions;
  }
}