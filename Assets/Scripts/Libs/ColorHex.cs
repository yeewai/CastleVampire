using UnityEngine;
using System;

public class ColorHex{
  // Note that Color32 and Color implictly convert to each other. You may pass a Color object to this method without first casting it.
  public static string ColorToHex(Color32 color)
  {
  	string hex = color.r.ToString("X2") + color.g.ToString("X2") + color.b.ToString("X2");
  	return hex;
  }
 
  public static Color HexToColor(string hex)
  {
  	byte r = byte.Parse(hex.Substring(0,2), System.Globalization.NumberStyles.HexNumber);
  	byte g = byte.Parse(hex.Substring(2,2), System.Globalization.NumberStyles.HexNumber);
  	byte b = byte.Parse(hex.Substring(4,2), System.Globalization.NumberStyles.HexNumber);
  	return new Color32(r,g,b, 255);
  }
  
  public static Color generateRandomColor(Color mix) {
      float red;
      float green;
      float blue;

      // mix the color
      //if (mix != null) {
          red = ((UnityEngine.Random.Range(0, 256)/256f) + mix.r) / 2f;
          green = ((UnityEngine.Random.Range(0, 256)/256f) + mix.g) / 2f;
          blue = ((UnityEngine.Random.Range(0, 256)/256f) + mix.b) / 2f;
      //}
      return new Color(red, green, blue);;
  }
  
}
