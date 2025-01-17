using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class HUD : MonoBehaviour
{
  public enum InfoType { Exp, Level, Kill, Timer, Health }
  public InfoType type;

  TMP_Text myText = null;
  Slider mySlider = null;

  void Awake()
  {
    myText = GetComponent<TMP_Text>();
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
        myText.text = string.Format("Lv. {0:F0}", GameManager.instance.level);
        break;
      case InfoType.Kill:
        myText.text = string.Format("{0:F0}", GameManager.instance.kill);
        break;
      case InfoType.Timer:
        float remainTime = GameManager.instance.maxTime - GameManager.instance.gameTime;
        int min = Mathf.FloorToInt(remainTime / 60);
        int sec = Mathf.FloorToInt(remainTime % 60);
        myText.text = string.Format("{0:D2}:{1:D2}", min, sec);
        break;
      case InfoType.Health:
        float curHealth = GameManager.instance.health;
        float maxHealth = GameManager.instance.maxHealth;
        mySlider.value = curHealth / maxHealth;
        break;
    }
  }
}