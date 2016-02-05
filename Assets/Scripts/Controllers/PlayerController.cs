using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
  //public float moveForce = 365f;
  public float speed = 5f;
  //public float jumpForce = 400.0f;
  public Animator animator;
  Rigidbody2D rb;
  string state;
  int facing;
  //bool onGround;
  
	void Start () {
    animator = transform.Find("PersonAnimator").gameObject.GetComponent<Animator>();
    rb = GetComponent<Rigidbody2D>();
    state = "idle";
    facing = 1;
    //onGround = true;
	}
	
  void FixedUpdate() {
    //Moving left and right
    float h = Input.GetAxis("Horizontal");
    if (h != 0) {
      if (h > 0) {facing = 1;}
      else {facing = -1;}
      Vector3 theScale = transform.localScale;
      theScale.x = Mathf.Abs(theScale.x) * facing;
      transform.localScale = theScale;
                  
      animator.SetTrigger("run");
      //transform.localScale = new Vector3(facing,1,1);
      
      rb.velocity = new Vector2 (speed * h, rb.velocity.y);
      
    } else {
      animator.SetTrigger("idle");
      rb.velocity = new Vector2 (0, rb.velocity.y);
    }
  }
}
