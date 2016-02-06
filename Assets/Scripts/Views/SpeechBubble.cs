using UnityEngine;
using System.Collections;

public class SpeechBubble : MonoBehaviour {
  public GameObject Obj;
 
  public Camera mCamera;
  private RectTransform rt;

  void Start ()
  {
      rt = GetComponent<RectTransform>();
  }

  void Update ()
  {
      if (Obj != null)
      {
          Vector2 pos;
          RectTransformUtility.ScreenPointToLocalPointInRectangle(rt, Obj.transform.position, mCamera, out pos);
          rt.position = pos;
      }
  }
}