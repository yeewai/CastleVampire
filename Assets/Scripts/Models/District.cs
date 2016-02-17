using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class District {
  public string name;
  public List<Building> buildings;
  public int buildingCapacity; 
  public int index;
  
  public District(int addr) {
    index= addr;
    buildingCapacity = UnityEngine.Random.Range(15, 20);
    name = Database.getRandomFromKey("DistrictNames");
    buildings = new List<Building>();
  }
  
  public List<Person> villagers() {
    List<Person> v = new List<Person>();
    foreach(Building b in buildings) {
      v.AddRange(b.residents);
    }
    return v;
  }
  
  public void generateBuildings(Game currentGame, int villagerCapacity) {
    if (index > 0) {buildings.Add(new Building(0, "road"));} //Hrm. omitting index clause makes an infinite loop...
    for (int j = buildings.Count; 
          buildings.Count < buildingCapacity && currentGame.villagers.Count < villagerCapacity; 
          j++) {
      if (UnityEngine.Random.Range(0, 100) > 90) {buildings.Add(new Building(j, "road"));}
      else {buildings.Add(new Building(j, currentGame));}
    }
    buildings.Add(new Building(buildingCapacity, "road"));
  }
  
}
