using UnityEngine;
using System.Collections;

public class DistrictController : Singleton<DistrictController> {
  protected DistrictController () {} 
  //public Transform ground;
  District district;
  District nextDistrict;
  public GameObject player; 
  public Transform LeftBoundary;
  public Transform RightBoundary;
  
  public float buildingWidth = 5;

	// Use this for initialization
	void Start () {
    Vector3 theScale = transform.localScale;
    theScale.x = Game.Current().largestDistrictSize * 5;
    transform.localScale = theScale;
    
    DrawCurrentDistrict();
    player = Instantiate(Resources.Load("Person"), new Vector3(10,2,0), Quaternion.identity) as GameObject;
    player.AddComponent<PlayerController>();
    player.GetComponent<PersonController>().SetPerson(Game.Current().player);
    Camera.main.GetComponent<CameraController>().target = player.transform;
	}
  
  public void DrawCurrentDistrict() {
    district = Game.Current().currentDistrict;
    if (district.index + 1 < Game.Current().districts.Count ) {
      nextDistrict = Game.Current().districts[district.index + 1];
    } else {
      nextDistrict = null;
    }
    
    //Set Boundaries
    LeftBoundary.position = new Vector3(-0.5f * buildingWidth, 0, 0);
    RightBoundary.position = new Vector3((district.buildings.Count - 1 + 0.5f) * buildingWidth, 0, 0);
    
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
    if (nextDistrict != null) {
      for (int i = 0; i < nextDistrict.buildings.Count; i ++) {
        SpriteRenderer sr = DrawBuilding(nextDistrict.buildings[i], new Vector3(i * buildingWidth,-3f,-3));
        sr.color *= new Color(0.25f, 0.25f, 0.25f, 0.5f);
        sr.sortingOrder = 1000;
      }
    }
    
    //Draw road
    for (int i = 0; i < district.buildings.Count; i ++) {
      DrawRoad(RoadAt(i),new Vector3(i * buildingWidth,0,0));
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
  
  public void ChangeDistrict(int direction=1) {
    ClearDistrict();
    Game.Current().SetNextDistrict(direction);
    DrawCurrentDistrict();
  }
	
  SpriteRenderer DrawBuilding(Building building, Vector3 pos) {
    GameObject b = Instantiate(Resources.Load("building"), pos, Quaternion.identity) as GameObject;
    SpriteRenderer sr = b.GetComponent<SpriteRenderer>();
    sr.sprite = Resources.Load<Sprite>("Sprites/buildings/" + building.buildingType);
    sr.color = building.color;
    return sr;
  }
  
  void DrawRoad(string dir, Vector3 pos) {
    GameObject b = Instantiate(Resources.Load("building"), pos, Quaternion.identity) as GameObject;
    SpriteRenderer sr = b.GetComponent<SpriteRenderer>();
    sr.sprite = Resources.Load<Sprite>("Sprites/road/" + dir);
    //sr.color = building.color;
  }
  
  public Building BuildingAt(float xPos) {
    return BuildingAt(xPos, district);
  }
  public Building BuildingAtLowerDistrict(float xPos) {
    return BuildingAt(xPos, nextDistrict);
  }
  public Building BuildingAt(float xPos, District d) {
    int i = (int)(xPos/buildingWidth); 
    if (i > d.buildings.Count) {return new Building(i, "road");}
    if (d != null && i >= 0) {return d.buildings[i];}
    return null;
  }
  
  public string RoadAt(float xPos) {
    return RoadAt((int)(xPos/buildingWidth)); 
  }
  public string RoadAt(int i) {
    if (i >= district.buildings.Count) {return "invalid";}
    if (nextDistrict != null 
          && i < nextDistrict.buildings.Count 
          && nextDistrict.buildings[i].buildingType == "road") { 
      if (district.buildings[i].buildingType == "road") {
        return "road-both";
      } else {
        return "road-down";
      }
    }
    else if (district.buildings[i].buildingType == "road") { return "road-up"; } 
    else { return "road"; }
  }
}
