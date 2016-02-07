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
    player = new Person();
    villagers = new List<Person>();
    //inGameSec = 0;
    districts = new List<District>();
    largestDistrictSize = 0;
    int villagerStartSize = UnityEngine.Random.Range(100, 120);
    for (int i = 0; (villagers.Count < villagerStartSize); i++) {
      District d = new District(i, villagerStartSize - villagers.Count);
      districts.Add(d);
      largestDistrictSize = Mathf.Max(largestDistrictSize, d.buildings.Count);
      villagers.AddRange(d.villagers());
    }
    Debug.Log("There are " + districts.Count + " districts");
    currentDistrict = districts[0];
  }
  
  public static Game Current() {
    if (current == null) {
      Game.current = new Game();
    }
    return Game.current;
  }  
  
  public void SetNextDistrict(int direction=1) {
    int newIndex = currentDistrict.index + direction;
    if (newIndex < districts.Count && newIndex >= 0) {
      currentDistrict = districts[newIndex];
    }
  }
  
  //public int GetCurrentHour() {
  //  return (inGameMin / 60) % 24;
  //}
}