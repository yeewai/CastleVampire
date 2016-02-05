using UnityEngine;
using System.Collections;

public class PersonController : MonoBehaviour {
  public Transform head;
  public Transform body;
  public Transform frontArm;
  public Transform backArm;
  public Transform frontLeg;
  public Transform backLeg;
  
	// Use this for initialization
	void Start () {
    //Transform body = transform.Find("PersonAnimator/characters_body");
    SetItem("characters-clothes1", body);
    SetItem("characters-head1", head);
	}
  
  void SetItem(string itemName, Transform bodypart) {
    GameObject item = new GameObject(); 
    item.transform.parent = bodypart;
    item.transform.localScale = new Vector3(1,1,1);
    item.transform.localPosition = new Vector3(0,0,0);
    SpriteRenderer sr = item.AddComponent<SpriteRenderer>();
    sr.sprite = Resources.Load("Sprites/people/" + itemName, typeof(Sprite)) as Sprite;
    sr.sortingOrder = bodypart.gameObject.GetComponent<SpriteRenderer>().sortingOrder + 1;
  }
}
