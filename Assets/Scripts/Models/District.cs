using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class District {
  public string name;
  public List<Building> buildings;
  public int buildingCapacity; 
  
  public District(int villagerStartSize) {
    buildingCapacity = UnityEngine.Random.Range(50, 100);
    name = Database.getRandomFromKey("DistrictNames");
    buildings = new List<Building>();
    buildings.Add(new Building("road"));
    while(buildings.Count < buildingCapacity && villagers().Count < villagerStartSize) {
      buildings.Add(new Building());
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
