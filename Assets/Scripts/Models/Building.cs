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
    setBuildingType(currentGame);
    
    string ownerName = generateResidents(currentGame);
    if (residents.Count < 1) { ownerName = Database.getRandomFrom(currentGame.villagers).lastName; }
    name =  ownerName + "'s " + buildingType;
  }
  
  public Building(int addr, string s) {
    address = addr;
    if (s == "road") {
      buildingType = "road";
      name = "Road";
      residents = new List<Person>();
    }
  }
  
  void setBuildingType(Game currentGame){
    List<string> bTypes = new List<string>(Database.getBuildingRequirements().Keys); //[TODO]town hall not in DB
    Database.reshuffle(bTypes); 
    
    for(int i = 0; i < bTypes.Count; i++) {
      List<string> reqs = Database.getBuildingRequirements()[bTypes[i]];
      List<Building> reqBs = currentGame.FindRequirementBuildings(reqs);
      if (reqBs.Count == reqs.Count) {
        buildingType = bTypes[i];
        foreach(Building b in reqBs) {b.requirementFor = this;}
        return;
      }
    }
  }
  
  string generateResidents(Game currentGame) {
    residents = new List<Person>();
    if(buildingType.Trim() == "house"){
      for(int j = 0; j < UnityEngine.Random.Range(1,8); j ++) {
        residents.Add(new Person(currentGame));
      }
      currentGame.villagers.AddRange(residents);
      return residents[0].lastName;
    }
    return "";
  }
}
