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
	//void Start () {
  // 
	//}
  
  public void SetPerson(Person p) {
    person = p;
  
    //Set skintone
    foreach(Transform bodypart in new Transform[] {head, body, frontArm, backArm, frontLeg, backLeg}) {
      bodypart.gameObject.GetComponent<SpriteRenderer>().color = person.skintone;
    }
    SpriteRenderer hair = SetItem(person.hair, head);
    hair.color = person.hairColor;
    SetItem(person.clothes_body, body);
    SetItem(person.clothes_frontArm, frontArm);
    SetItem(person.clothes_backArm, backArm);
    SetItem(person.clothes_frontLeg, frontLeg);
    SetItem(person.clothes_backLeg, backLeg);
    
    body.gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/people/Base/" + person.GetBody());
    head.gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load("Sprites/people/Base/" + person.GetHead(), typeof(Sprite)) as Sprite;
  }
  
  SpriteRenderer SetItem(string itemName, Transform bodypart) {
    Sprite s = Resources.Load("Sprites/people/" + itemName, typeof(Sprite)) as Sprite;
    if (s != null){
      GameObject item = new GameObject(); 
      item.transform.parent = bodypart;
      item.transform.localScale = new Vector3(1,1,1);
      item.transform.localPosition = new Vector3(0,0,0);
      SpriteRenderer sr = item.AddComponent<SpriteRenderer>();
      sr.sprite = s;
      sr.sortingOrder = bodypart.gameObject.GetComponent<SpriteRenderer>().sortingOrder + 1;
      return sr;
    }
  return null; 
  }
}
