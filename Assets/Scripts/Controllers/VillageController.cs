using UnityEngine;
using System.Collections;

public class VillageController : Singleton<VillageController> {
  protected VillageController () {} 

	// Use this for initialization
	void Start () {
    GameObject p = Instantiate(Resources.Load("Person"), new Vector3(0,0,0), Quaternion.identity) as GameObject;
    p.AddComponent<PlayerController>();
    p.GetComponent<PersonController>().SetPerson(Game.Current().player);
    foreach(Person villager in Game.Current().villagers){
      GameObject v = Instantiate(Resources.Load("Person"), new Vector3(0,0,0), Quaternion.identity) as GameObject;
      v.GetComponent<PersonController>().SetPerson(villager);
    }
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
