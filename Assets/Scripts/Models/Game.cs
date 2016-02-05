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
  public Person[] villagers; 

  public Game () {
    saveName = "Ohai" + UnityEngine.Random.Range(1, 10);
    //inGameSec = 0;
  }
  
  public static Game Current() {
    if (current == null) {
      Game g = new Game();
      Game.current = g;
    }
    return Game.current;
  }  
  
  //public int GetCurrentHour() {
  //  return (inGameMin / 60) % 24;
  //}
}