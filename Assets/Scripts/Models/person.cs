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
  public Color skintone;
  public string clothes;
  public string villagerType;
  public string gender;
  public int strength;
  public int bloodPts;
  public int intelligence;
  public int magic;
  
  public string clothes_body;     //obsolete soon
  public string clothes_frontArm; //obsolete soon
  public string clothes_backArm;  //obsolete soon
  public string clothes_frontLeg; //obsolete soon
  public string clothes_backLeg;  //obsolete soon
  
  
  public Person(string vtype=null) {
    villagerType = vtype;
    if (villagerType == null) {villagerType = Database.getRandomFrom(villagerTypes);}
    
    gender = "male";
    if(UnityEngine.Random.Range(-1f,1f) > 0) {gender = "female";}
    
    lastName = Database.getRandomFromKey("LastNames");
    if (gender == "male") {firstName = Database.getRandomFromKey("FirstNamesMale");}
    else {firstName = Database.getRandomFromKey("FirstNamesFemale");}
    
    skintone = ColorHex.HexToColor(Database.getRandomFromKey("Skintones"));
    hairColor = ColorHex.generateRandomColor(ColorHex.HexToColor("c6ab7b"));
    //clothes_body = Database.getRandomFrom(Database.CharacterOptions()["body"]);
    //clothes = clothes_body.Substring("body".Length);
    //clothes_frontArm = "arm" + clothes; //soon to be obsolete
    //clothes_backArm = "arm" + clothes;  //soon to be obsolete
    //clothes_frontLeg = "leg" + clothes; //soon to be obsolete
    //clothes_backLeg = "leg" + clothes;  //soon to be obsolete
    hair = Database.getRandomFrom(Database.CharacterOptions()["head"]);
  }
  
  public string GetHead() {
    string s = "people_head_";
    switch (villagerType) {
      case "peasant":
      case "healer":
      case "virgin":
      case "warrior":
      case "noble":
    		s += "circle";
    		break;
    	case "cleric":
      case "barbarian":
      case "naturalist":
    		s += "square";
    		break;
      case "shopkeeper":
      case "priest":
        s += "flippedtriangle";
        break;
      case "damsel":
      case "mayor":
      case "adventurer":
        s += "diamond";
        break;
      case "detective":
      case "witch":
      case "thief":
        s += "triangle";
        break;
    	}
    return s;
  }
  
  public string GetBody() {
    string s = "people_body_";
    switch (villagerType) {
      case "peasant":
      case "shopkeeper":
      case "thief":
      case "naturalist":
        s += "circle";
        break;
      case "healer":
      case "priest":
      case "detective":
      case "cleric":
        s += "square";
        break;
      case "virgin":
      case "damsel":
      case "witch":
        s += "triangle";
        break;
      case "warrior":
      case "adventurer":
      case "barbarian":
        s += "flippedtriangle";
        break;
      case "noble":
      case "mayor":
        s += "diamond";
        break;
    }
    return s + "_" + gender;
  }
  
  static readonly String[] villagerTypes = new String[] {"peasant", "healer", "shopkeeper", "priest", "virgin", "damsel", "detective", "witch", "warrior", "cleric", "thief", "adventurer", "barbarian", "noble", "naturalist", "mayor"};
} 