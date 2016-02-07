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
    if(Input.GetKeyUp("w") || Input.GetKeyUp("up") || Input.GetKeyUp("s") || Input.GetKeyUp("down")) {
      if (DistrictController.Instance.BuildingAt(transform.position.x).buildingType == "road") {
        DistrictController.Instance.ClearDistrict();
        if (Input.GetKeyUp("w") || Input.GetKeyUp("up")) {Game.Current().SetNextDistrict(-1);}
        else {Game.Current().SetNextDistrict();}
        DistrictController.Instance.DrawCurrentDistrict();
      }
    }
  }
}
