using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Building {
  public string name;
  public string buildingType; 
  public Color color;
  public List<Person> residents; 
  public int address;
  public Building requirementFor;
  
  public Building(int addr, Game currentGame) {
    address = addr;
    color = ColorHex.generateRandomColor(ColorHex.HexToColor("c6ab7b"));
    
    //Set building type
    List<string> bTypes = new List<string>(Database.getBuildingRequirements().Keys); 
    Database.reshuffle(bTypes); 
    
    bool isBuilt = false;
    for(int i = 0; isBuilt == false; i++) {
      List<string> reqs = Database.getBuildingRequirements()[bTypes[i]];
      List<Building> reqBs = new List<Building>();
      if (reqs.Count > 0){ reqBs = currentGame.FindRequirementBuildings(reqs);}
      if (reqBs.Count == reqs.Count) {
        buildingType = bTypes[i];
        foreach(Building b in reqBs) {b.requirementFor = this;}
        isBuilt = true;
      }
    }
    
    
    residents = new List<Person>();
    for(int j = 0; j < UnityEngine.Random.Range(1,8); j ++) {
      residents.Add(new Person(currentGame));
    }
    name = residents[0].lastName + "'s " + buildingType;
  }
  
  public Building(int addr, string s) {
    address = addr;
    if (s == "road") {
      buildingType = "road";
      name = "Road";
      residents = new List<Person>();
    }
  }
  
  //static readonly String[] buildingTypes = new String[] {"house", "shrine", "shop", "maypole", "bar", "den", "fountain", "church", "library", "abbot", "camp", "witch hut", "bulletin board", "garden", "university"}; 
  //town hall
}
