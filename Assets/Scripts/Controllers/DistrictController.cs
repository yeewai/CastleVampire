using UnityEngine;
using System.Collections;

public class DistrictController : Singleton<DistrictController> {
  protected DistrictController () {} 
  //public Transform ground;
  District district;
  public GameObject player; 

	// Use this for initialization
	void Start () {
    district = Game.Current().districts[0];
    Vector3 theScale = transform.localScale;
    theScale.x = district.buildings.Count * 5;
    transform.localScale = theScale;
    
    //Load Buildings
    for (int i = 0; i < district.buildings.Count; i ++) {
      Vector3 pos = new Vector3(i * 5,0.75f,0);
      GameObject b = Instantiate(Resources.Load("building"), pos, Quaternion.identity) as GameObject;
      SpriteRenderer sr = b.GetComponent<SpriteRenderer>();
      sr.sprite = Resources.Load<Sprite>("Sprites/buildings/" + district.buildings[i].buildingType);
      sr.color = district.buildings[i].color;
      foreach(Person villager in district.buildings[i].residents){
        GameObject v = Instantiate(Resources.Load("Person"), pos, Quaternion.identity) as GameObject;
        v.GetComponent<PersonController>().SetPerson(villager);
        v.AddComponent<NPCController>();
      }
    }
    
    player = Instantiate(Resources.Load("Person"), new Vector3(10,2,0), Quaternion.identity) as GameObject;
    player.AddComponent<PlayerController>();
    player.GetComponent<PersonController>().SetPerson(Game.Current().player);
    Camera.main.GetComponent<CameraController>().target = player.transform;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
