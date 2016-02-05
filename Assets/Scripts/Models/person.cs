using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class Person {
  public string name;
  public string hair;
  public string clothes_body;
  public string clothes_frontArm;
  public string clothes_backArm;
  public string clothes_frontLeg;
  public string clothes_backLeg;
  public string skintone;
  
  public Person() {
    skintone = skintones()[UnityEngine.Random.Range(0, skintones().Length)];
    //Color skintone = Random.ColorHSV(47.0f/360f, 20f/360f, .07f, .55f, .03f, .75f);
    clothes_body = Person.CharacterOptions()["body"][UnityEngine.Random.Range(0, Person.CharacterOptions()["body"].Count)];
    clothes_frontArm = "";
    clothes_backArm = "";
    clothes_frontLeg = "";
    clothes_backLeg = "";
    hair = Person.CharacterOptions()["head"][UnityEngine.Random.Range(0, Person.CharacterOptions()["head"].Count)];
  }
  
  static String[] skintones() {
    return new String[] {"e7caba", "462d21"};
    
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