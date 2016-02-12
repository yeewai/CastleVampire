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
  
  
  public Person(Game currentGame, string vtype=null) {
    if (vtype != null) {
      villagerType = vtype;
    } else {
      string key;
      List<Building> buildings = currentGame.buildings();
      Database.reshuffle(buildings);
    
      if (buildings.Count > 0) {
        while (buildings[0].buildingType.Trim() == "road") {Database.reshuffle(buildings);}
        key = buildings[0].buildingType;
      }
      else {
        List<string> bTypes = new List<string>(Database.getBuildingRequirements().Keys); 
        key = Database.getRandomFrom(bTypes);
      }
      villagerType = BuildingVillagerType.Get(key);
    }
    
    gender = "male";
    if(UnityEngine.Random.Range(-1f,1f) < 0) {gender = "female";}
    
    lastName = Database.getRandomFromKey("LastNames");
    if (gender == "male") {firstName = Database.getRandomFromKey("FirstNamesMale");}
    else {firstName = Database.getRandomFromKey("FirstNamesFemale");}
    
    skintone = ColorHex.HexToColor(Database.getRandomFromKey("Skintones"));
    hairColor = ColorHex.generateRandomColor(ColorHex.HexToColor("c6ab7b"));
    //clothes_body = Database.getRandomFrom(Database.CharacterOptions()["body"]);
    //clothes = clothes_body.Substring("body".Length);
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
      case "crusader":
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
      case "scholar":
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
      case "scholar":
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
      case "crusader":
        s += "flippedtriangle";
        break;
      case "noble":
      case "mayor":
        s += "diamond";
        break;
    }
    return s + "_" + gender;
  }
  
  //static readonly String[] villagerTypes = new String[] {"peasant", "healer", "shopkeeper", "priest", "virgin", "damsel", "detective", "witch", "warrior", "cleric", "thief", "adventurer", "barbarian", "noble", "naturalist", "mayor"};
} 

static class BuildingVillagerType {
  static Dictionary<string, string> _dict = new Dictionary<string, string> {
    {"house", "peasant"},
  	{"shrine", "healer"},
  	{"shop", "shopkeeper"},
  	{"maypole", "virgin"},
  	{"bar", "warrior"},
  	{"den", "thief"},
  	{"fountain", "damsel"},
  	{"church", "priest"},
  	{"library", "scholar"},
  	{"abbey", "cleric"},
  	{"camp", "crusader"},
  	{"witch hut", "witch"},
  	{"bulletin board", "adventurer"},
  	{"garden", "noble"},
  	{"university", "naturalist"}
  };

  public static string Get(string word) {
	  string result;
	  if (_dict.TryGetValue(word, out result)) { return result; }
	  else { return null; }
  }
}