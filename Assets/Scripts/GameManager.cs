using UnityEngine;
public class GameManager : MonoBehaviour
{
  public static GameManager instance = null;
  [Header("# Game Control")]
  public float gameTime = 0f;
  public float maxTime = 20f;

  [Header("# Player Info")]
  public int level = 0;
  public int kill = 0;
  public int exp = 0;
  public int[] nextExp = { 3, 5, 10, 100, 150, 210, 280, 360, 450, 600 };

  [Header("# Game Object")]
  public PoolManager pool = null;
  public Player player = null;

  void Awake()
  {
    instance = this;
  }

  void Update()
  {
    gameTime += Time.deltaTime;

    if (gameTime > 0.2f)
    {
      gameTime = 0f;
    }
  }

  public void GetExp()
  {
    exp++;
    if (exp == nextExp[level])
    {
      level++;
      exp = 0;
    }
  }
}