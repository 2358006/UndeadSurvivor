using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class HUD : MonoBehaviour
{
  public enum InfoType { Exp, Level, Kill, Time, Health }
  public InfoType type;

  Text myText = null;
  Slider mySlider = null;

  void Awake()
  {
    myText = GetComponent<Text>();
    mySlider = GetComponent<Slider>();
  }

  void LateUpdate()
  {
    switch (type)
    {
      case InfoType.Exp:
        float curExp = GameManager.instance.exp;
        float maxExp = GameManager.instance.nextExp[GameManager.instance.level];
        mySlider.value = curExp / maxExp;
        break;
      case InfoType.Level:
        break;
      case InfoType.Kill:
        break;
      case InfoType.Time:
        break;
      case InfoType.Health:
        break;
    }
  }
}