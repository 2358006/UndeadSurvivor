using UnityEngine;
public class GameManager : MonoBehaviour
{
  public static GameManager instance = null;
  [Header("# Game Control")]
  public float gameTime = 0f;
  public float maxTime = 20f;

  [Header("# Player Info")]
  public int health = 0;
  public int maxHealth = 0;
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

  void Start()
  {
    health = maxHealth;
  }

  void Update()
  {
    gameTime += Time.deltaTime;
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