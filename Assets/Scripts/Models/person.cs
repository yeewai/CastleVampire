using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class Person {
  public string name;
  public string hair;
  public Color hairColor;
  public string clothes_body;
  public string clothes_frontArm;
  public string clothes_backArm;
  public string clothes_frontLeg;
  public string clothes_backLeg;
  public Color skintone;
  
  public Person() {
    skintone = ColorHex.HexToColor(skintones()[UnityEngine.Random.Range(0, skintones().Length)]);
    hairColor = ColorHex.generateRandomColor(ColorHex.HexToColor("c6ab7b"));
    //hairColor = ColorHex.HexToColor(randomColors()[UnityEngine.Random.Range(0, randomColors().Length)]);
    //Color skintone = Random.ColorHSV(47.0f/360f, 20f/360f, .07f, .55f, .03f, .75f);
    clothes_body = Person.CharacterOptions()["body"][UnityEngine.Random.Range(0, Person.CharacterOptions()["body"].Count)];
    string clothes = clothes_body.Substring("body".Length);
    clothes_frontArm = "arm" + clothes;
    clothes_backArm = "arm" + clothes;
    clothes_frontLeg = "leg" + clothes;
    clothes_backLeg = "leg" + clothes;
    hair = Person.CharacterOptions()["head"][UnityEngine.Random.Range(0, Person.CharacterOptions()["head"].Count)];
  }
  
  static String[] skintones() {
    return new String[] {"e7caba", "462d21", "76503d", "FFDFC4","F0D5BE","EECEB3","E1B899","E5C298","FFDCB2","E5B887","E5A073","E79E6D","DB9065","CE967C","C67856","BA6C49","A57257","F0C8C9","DDA8A0","B97C6D","A8756C","AD6452","5C3836","CB8442","BD723C","704139","A3866A"};    
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