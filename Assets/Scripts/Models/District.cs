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
    name = names()[UnityEngine.Random.Range(0, names().Length)];
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
  
  static String[] names() {
    return new String[] {"e7caba", "462d21", "76503d", "FFDFC4","F0D5BE","EECEB3","E1B899","E5C298","FFDCB2","E5B887","E5A073","E79E6D","DB9065","CE967C","C67856","BA6C49","A57257","F0C8C9","DDA8A0","B97C6D","A8756C","AD6452","5C3836","CB8442","BD723C","704139","A3866A"};    
  }
}
