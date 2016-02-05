using UnityEngine;
using System;

[System.Serializable]
public class Person {
  public string name;
  public string hair;
  public string clothes_body;
  public string clothes_frontArm;
  public string clothes_backArm;
  public string clothes_frontLeg;
  public string clothes_backLeg;
  public string skintone;
  
  public Person() {
    skintone = "e7caba";
    clothes_body = "characters-clothes1";
    clothes_frontArm = "";
    clothes_backArm = "";
    clothes_frontLeg = "";
    clothes_backLeg = "";
    hair = "characters-head1";
  }
} 