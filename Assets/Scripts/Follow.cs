using UnityEngine;
using UnityEngine.UI;
public class Follow : MonoBehaviour
{
  RectTransform rect = null;

  void Awake()
  {
    rect = GetComponent<RectTransform>();
  }

  void FixedUpdate()
  {
    rect.position = Camera.main.WorldToScreenPoint(GameManager.instance.player.transform.position);
  }
}