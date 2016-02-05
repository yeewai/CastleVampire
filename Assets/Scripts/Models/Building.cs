using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Building {
  public string name;
  public string buildingType; 
  public List<Person> residents; 
  
  public Building() {
    buildingType = Database.getRandomFrom(buildingTypes);
    residents = new List<Person>();
    for(int i = 0; i < UnityEngine.Random.Range(1,8); i ++) {
      residents.Add(new Person());
    }
    name = residents[0].lastName + "'s " + buildingType;
  }
  
  public Building(string s) {
    if (s == "road") {
      buildingType = "road";
      name = "Road";
      residents = new List<Person>();
    }
  }
  
  static readonly String[] buildingTypes = new String[] {"House", "Inn", "Altar", "Maypole", "Shop"};
}
