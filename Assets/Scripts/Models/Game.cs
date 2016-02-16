using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System;

[System.Serializable]
public class Game { 
  public static Game current;
  
  public string saveName;
  public DateTime saveDate;
  //public int inGameMin;
  public Person player;
  public List<Person> villagers; 
  public List<District> districts;
  public District currentDistrict;
  public int largestDistrictSize;

  public Game () {
    saveName = "Ohai" + UnityEngine.Random.Range(1, 10);
    villagers = new List<Person>();
    //inGameSec = 0;
    districts = new List<District>();
    largestDistrictSize = 0;
    player = new Person(this);
  }
  
  void populateGame(int villagerStartSize) {
    for (int i = 0; (villagers.Count < villagerStartSize); i++) {
      District d = new District(i);
      districts.Add(d);
      d.generateBuildings(this, villagerStartSize);
      largestDistrictSize = Mathf.Max(largestDistrictSize, d.buildings.Count);
    }
    Debug.Log("There are " + districts.Count + " districts");
    Debug.Log("There are " + villagers.Count + " villagers");
    currentDistrict = districts[0];
  }
  
  public static Game Current() {
    if (current == null) {
      Game.current = new Game();
      Game.current.populateGame(UnityEngine.Random.Range(40, 60));
    }
    return Game.current;
  }  
  
  public void SetNextDistrict(int direction=1) {
    int newIndex = currentDistrict.index + direction;
    if (newIndex < districts.Count && newIndex >= 0) {
      currentDistrict = districts[newIndex];
    }
  }
  
  public List<Building> buildings(){
    List<Building>bl = new List<Building>(); 
    foreach (District d in districts) {
      bl.AddRange(d.buildings);
    }
    return bl;
  }
  
  public List<Building> FindRequirementBuildings(List<string> requirements) {
    List<Building> bl = new List<Building>();
    foreach(string rType in requirements) {
      foreach(Building b in buildings()){
        if (object.Equals(b.buildingType.Trim(), rType.Trim()) && b.requirementFor == null) {
          bl.Add(b);
          break;
        }
      }
    }
    return bl;
  }
  
  //public int GetCurrentHour() {
  //  return (inGameMin / 60) % 24;
  //}
}