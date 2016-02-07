using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SpeechBubble : MonoBehaviour {
  public Text speechText;
  public Text Name;
  public PersonController pc;
  
  void Start () {
    if (speechText.text == "") {gameObject.SetActive(false);}
    Name.text = "<b>" + pc.person.firstName.ToUpper() + " " + pc.person.lastName.ToUpper() + "</b>";
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