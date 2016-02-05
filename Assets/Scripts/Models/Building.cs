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
    buildingType = buildingTypes()[UnityEngine.Random.Range(0, buildingTypes().Length)];
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
  
  static String[] buildingTypes() {
    return new String[] {"House", "Inn", "Altar", "Maypole", "Shop"};
  }
  static String[] names() {
    return new String[] {"e7caba", "462d21", "76503d", "FFDFC4","F0D5BE","EECEB3","E1B899","E5C298","FFDCB2","E5B887","E5A073","E79E6D","DB9065","CE967C","C67856","BA6C49","A57257","F0C8C9","DDA8A0","B97C6D","A8756C","AD6452","5C3836","CB8442","BD723C","704139","A3866A"};    
  }
}
