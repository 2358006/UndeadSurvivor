using System.Security.Cryptography;
using Unity.VisualScripting;
using UnityEngine;
public class RePosition : MonoBehaviour
{
  void OnTriggerExit2D(Collider2D collision)
  {
    if (!collision.CompareTag("Area"))
    {
      return;
    }

    Vector3 playerPos = GameManager.instance.player.transform.position;
    Vector3 myPos = transform.position;
    float diffX = Mathf.Abs(playerPos.x - myPos.x);
    float diffY = Mathf.Abs(playerPos.y - myPos.y);

    Vector3 playerDir = GameManager.instance.player.inputVec;
    float dirX = playerDir.x < 0 ? -1 : 1;
    float dirY = playerDir.y < 0 ? -1 : 1;

    switch (transform.tag)
    {
      case "Ground":
        if (diffX > diffY)
        {
          transform.Translate(Vector3.right * dirX * 40);
        }
        else if (diffY > diffX)
        {
          transform.Translate(Vector3.up * dirY * 40);
        }
        break;

      case "Enemy":
        if (collision.enabled)
        {
          transform.Translate(playerDir * 20 + new Vector3(Random.Range(-3, 3), Random.Range(-3, 3), 0f));
        }
        break;
    }
  }
}