using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class NPCController : MonoBehaviour {
  float speed;
  Animator animator;
  Rigidbody2D rb;
  int facing;
  bool runOnce;
  SpeechBubble speech;
  Person person;
    
	// Use this for initialization
	void Start () {
    animator = transform.Find("PersonAnimator").gameObject.GetComponent<Animator>();
    rb = GetComponent<Rigidbody2D>();
    facing = 1;
    speed = Random.Range(0.5f,2.5f);
    runOnce = false;
    person = GetComponent<PersonController>().person;
    speech = transform.Find("SpeechBubbleCanvas/SpeechBubble").gameObject.GetComponent<SpeechBubble>(); //messy :/
	}
	
	// Update is called once per frame
	void Update () {
    if (Mathf.Abs(transform.position.x - DistrictController.Instance.player.transform.position.x) < 5) {
      speech.Say(person.firstName + " " + person.lastName);
    } else {
      speech.Clear();
    }
    if (!runOnce)
      {StartCoroutine(Move()); runOnce = true;}
	}
  
  IEnumerator Move() {
    while(true) {
      facing *=-1;
      Vector3 theScale = transform.Find("PersonAnimator").localScale;
      theScale.x = Mathf.Abs(theScale.x) * facing;
      transform.Find("PersonAnimator").localScale = theScale;
      yield return StartCoroutine(moving(Random.Range(0f,10f)));
    }
  }
  
  IEnumerator moving(float walkTime) {
    animator.SetTrigger("walk");
    float t = 0;
    while (t < walkTime) {    
      rb.velocity = new Vector2 (speed * facing, rb.velocity.y);
      t += Time.deltaTime;
      yield return null;
    }
  }
}
