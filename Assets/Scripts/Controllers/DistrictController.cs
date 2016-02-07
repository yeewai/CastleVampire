using UnityEngine;
using System.Collections;

public class DistrictController : Singleton<DistrictController> {
  protected DistrictController () {} 
  //public Transform ground;
  District district;
  public GameObject player; 
  
  public float buildingWidth = 5;

	// Use this for initialization
	void Start () {
    DrawCurrentDistrict();
    player = Instantiate(Resources.Load("Person"), new Vector3(10,2,0), Quaternion.identity) as GameObject;
    player.AddComponent<PlayerController>();
    player.GetComponent<PersonController>().SetPerson(Game.Current().player);
    Camera.main.GetComponent<CameraController>().target = player.transform;
	}
  
  public void DrawCurrentDistrict() {
    district = Game.Current().currentDistrict;
    Vector3 theScale = transform.localScale;
    theScale.x = district.buildings.Count * 5;
    transform.localScale = theScale;
    
    //Load Buildings
    for (int i = 0; i < district.buildings.Count; i ++) {
      Vector3 pos = new Vector3(i * buildingWidth,0.75f,0);
      DrawBuilding(district.buildings[i], pos);
      
      foreach(Person villager in district.buildings[i].residents){
        GameObject v = Instantiate(Resources.Load("Person"), pos, Quaternion.identity) as GameObject;
        v.GetComponent<PersonController>().SetPerson(villager);
        v.AddComponent<NPCController>();
      }
    }
    
    //load below district's buildings
    if (district.index + 1 < Game.Current().districts.Count ) {
      District nextD = Game.Current().districts[district.index + 1];
      for (int i = 0; i < nextD.buildings.Count; i ++) {
        SpriteRenderer sr = DrawBuilding(nextD.buildings[i], new Vector3(i * buildingWidth,-3f,0));
        sr.color *= new Color(0.25f, 0.25f, 0.25f, 0.5f);
        sr.sortingOrder = 1000;
      }
    }
  }
  
  public void ClearDistrict() {
    foreach(GameObject obj in GameObject.FindGameObjectsWithTag("Building")) {
      Destroy(obj);
    }
    foreach(GameObject obj in GameObject.FindGameObjectsWithTag("People")) {
      if (obj != player) {Destroy(obj);}
    }
  }
	
  SpriteRenderer DrawBuilding(Building building, Vector3 pos) {
    GameObject b = Instantiate(Resources.Load("building"), pos, Quaternion.identity) as GameObject;
    SpriteRenderer sr = b.GetComponent<SpriteRenderer>();
    sr.sprite = Resources.Load<Sprite>("Sprites/buildings/" + building.buildingType);
    sr.color = building.color;
    return sr;
  }
  
  public Building BuildingAt(float xPos) {
    int i = (int)(xPos/buildingWidth); 
    if (i >= 0 && i < district.buildings.Count) {return district.buildings[i];}
    return null;
  }
  
	// Update is called once per frame
	void Update () {
	
	}
}
