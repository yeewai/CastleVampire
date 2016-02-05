using UnityEngine;
using System.Collections;

public class NPCController : MonoBehaviour {
  float speed;
  Animator animator;
  Rigidbody2D rb;
  int facing;
  bool runOnce;
    
	// Use this for initialization
	void Start () {
    animator = transform.Find("PersonAnimator").gameObject.GetComponent<Animator>();
    rb = GetComponent<Rigidbody2D>();
    facing = 1;
    speed = Random.Range(1f,3.5f);
    runOnce = false;
	}
	
	// Update is called once per frame
	void Update () {
    if (!runOnce)
      {StartCoroutine(Move()); runOnce = true;}
	}
  
  IEnumerator Move() {
    while(true) {
      facing *=-1;
      Vector3 theScale = transform.localScale;
      theScale.x = Mathf.Abs(theScale.x) * facing;
      transform.localScale = theScale;
      yield return StartCoroutine(moving(Random.Range(0f,5f)));
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
