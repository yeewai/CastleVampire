using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SpeechBubble : MonoBehaviour {
  public Text speechText;
  
  void Start () {
    if (speechText.text == "") {gameObject.SetActive(false);}
  }

  public void Say(string text) {
    speechText.text = text;
    if (speechText.text == "") {gameObject.SetActive(false);}
    else {gameObject.SetActive(true);}
  }
  
  public void Clear() {
    speechText.text = "";
    gameObject.SetActive(false);
  }
}