using UnityEngine;
public class GameManager : MonoBehaviour
{
  public static GameManager instance = null;
  public PoolManager pool = null;
  public Player player = null;

  void Awake()
  {
    instance = this;
  }
}