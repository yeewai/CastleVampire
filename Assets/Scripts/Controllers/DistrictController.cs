using UnityEngine;
using System.Collections;

public class DistrictController : Singleton<DistrictController> {
  protected DistrictController () {} 
  //public Transform ground;
  District district;

	// Use this for initialization
	void Start () {
    district = Game.Current().districts[0];
    Vector3 theScale = transform.localScale;
    theScale.x = district.buildings.Count * 5;
    transform.localScale = theScale;
    
    //Load Buildings
    
    //Load People
    
    GameObject p = Instantiate(Resources.Load("Person"), new Vector3(0,0,0), Quaternion.identity) as GameObject;
    p.AddComponent<PlayerController>();
    p.GetComponent<PersonController>().SetPerson(Game.Current().player);
    foreach(Person villager in Game.Current().villagers){
      GameObject v = Instantiate(Resources.Load("Person"), new Vector3(0,0,0), Quaternion.identity) as GameObject;
      v.GetComponent<PersonController>().SetPerson(villager);
      v.AddComponent<NPCController>();
    }
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
