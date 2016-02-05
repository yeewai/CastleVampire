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

  public Game () {
    saveName = "Ohai" + UnityEngine.Random.Range(1, 10);
    player = new Person();
    villagers = new List<Person>();
    //inGameSec = 0;
    districts = new List<District>();
    int villagerStartSize = UnityEngine.Random.Range(100, 120);
    while (villagers.Count < villagerStartSize) {
      District d = new District(villagerStartSize - villagers.Count);
      districts.Add(d);
      villagers.AddRange(d.villagers());
    }
    Debug.Log("There are " + villagers.Count + " villagers in this village");
  }
  
  public static Game Current() {
    if (current == null) {
      Game.current = new Game();
    }
    return Game.current;
  }  
  
  //public int GetCurrentHour() {
  //  return (inGameMin / 60) % 24;
  //}
}