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
  
  public District(int addr, int villagerStartSize) {
    index= addr;
    buildingCapacity = UnityEngine.Random.Range(15, 20);
    name = Database.getRandomFromKey("DistrictNames");
    buildings = new List<Building>();
    if (index > 0) {buildings.Add(new Building(0, "road"));}
    for (int i = 1; (buildings.Count < buildingCapacity && villagers().Count < villagerStartSize); i++) {
      if (index > 0 && UnityEngine.Random.Range(0, 100) > 90) {buildings.Add(new Building(i, "road"));}
      else {buildings.Add(new Building(i));}
    }
  }
  
  public List<Person> villagers() {
    List<Person> v = new List<Person>();
    foreach(Building b in buildings) {
      v.AddRange(b.residents);
    }
    return v;
  }
  
}
