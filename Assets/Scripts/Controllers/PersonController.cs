using UnityEngine;
using System.Collections;

public class PersonController : MonoBehaviour {
  public Transform head;
  public Transform body;
  public Transform frontArm;
  public Transform backArm;
  public Transform frontLeg;
  public Transform backLeg;
  
  public Person person;
  
	// Use this for initialization
	void Start () {
    person = new Person();
    
    //Set skintone
    foreach(Transform bodypart in new Transform[] {head, body, frontArm, backArm, frontLeg, backLeg}) {
      bodypart.gameObject.GetComponent<SpriteRenderer>().color = ColorHex.HexToColor(person.skintone);
    }
    SetItem(person.hair, head);
    SetItem(person.clothes_body, body);
    SetItem(person.clothes_frontArm, frontArm);
    SetItem(person.clothes_backArm, backArm);
    SetItem(person.clothes_frontLeg, frontLeg);
    SetItem(person.clothes_backLeg, backLeg);
	}
  
  void SetItem(string itemName, Transform bodypart) {
    Sprite s = Resources.Load("Sprites/people/" + itemName, typeof(Sprite)) as Sprite;
    if (s != null){
      GameObject item = new GameObject(); 
      item.transform.parent = bodypart;
      item.transform.localScale = new Vector3(1,1,1);
      item.transform.localPosition = new Vector3(0,0,0);
      SpriteRenderer sr = item.AddComponent<SpriteRenderer>();
      sr.sprite = s;
      sr.sortingOrder = bodypart.gameObject.GetComponent<SpriteRenderer>().sortingOrder + 1;
    }
    
  }
}
