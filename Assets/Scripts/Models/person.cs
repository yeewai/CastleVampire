using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class Person {
  public string firstName;
  public string lastName;
  public string hair;
  public Color hairColor;
  public string clothes_body;
  public string clothes_frontArm;
  public string clothes_backArm;
  public string clothes_frontLeg;
  public string clothes_backLeg;
  public Color skintone;
  
  public Person() {
    skintone = ColorHex.HexToColor(Database.getRandomFromKey("Skintones"));
    hairColor = ColorHex.generateRandomColor(ColorHex.HexToColor("c6ab7b"));
    clothes_body = Database.getRandomFrom(Database.CharacterOptions()["body"]);
    string clothes = clothes_body.Substring("body".Length);
    clothes_frontArm = "arm" + clothes;
    clothes_backArm = "arm" + clothes;
    clothes_frontLeg = "leg" + clothes;
    clothes_backLeg = "leg" + clothes;
    hair = Database.getRandomFrom(Database.CharacterOptions()["head"]);
  }
} 