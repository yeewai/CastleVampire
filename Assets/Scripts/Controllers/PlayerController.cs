using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
  public float speed = 10f;
  public Animator animator;
  Rigidbody2D rb;
  string state;
  int facing;
  
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
    
    //Change districts (if possible)
    if(Input.GetKeyUp("w") || Input.GetKeyUp("up")) {
      string roadAt = DistrictController.Instance.RoadAt(transform.position.x);
      if ( roadAt == "road-up" || roadAt == "road-both") {
        DistrictController.Instance.ChangeDistrict(-1);
      }
    }
    if (Input.GetKeyUp("s") || Input.GetKeyUp("down")) {
     string roadAt = DistrictController.Instance.RoadAt(transform.position.x);
      if (roadAt == "road-down" || roadAt == "road-both") {
        DistrictController.Instance.ChangeDistrict(1);
      }
    }
  }
}
