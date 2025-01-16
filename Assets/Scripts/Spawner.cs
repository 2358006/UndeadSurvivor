using UnityEngine;
public class Spawner : MonoBehaviour
{
  public Transform[] spawnPoint = null;
  public SpawnData[] spawnData = null;
  int level = 0;
  float timer = 0f;
  void Awake()
  {
    spawnPoint = GetComponentsInChildren<Transform>();
  }
  void Update()
  {
    timer += Time.deltaTime;
    level = Mathf.Min(Mathf.FloorToInt(GameManager.instance.gameTime / 10f));

    if (timer > (level == 0 ? 0.5f : 0.2f))
    {
      timer = 0f;
      Spawn();
    }
  }
  void Spawn()
  {
    GameObject enemy = GameManager.instance.pool.Get(0);
    enemy.transform.position = spawnPoint[Random.Range(1, spawnPoint.Length)].position;
    enemy.GetComponent<Enemy>().Init(spawnData[level]);
  }
}

[System.Serializable]
public class SpawnData
{
  public float spawnTime = 0f;
  public int spriteType = 0;
  public int health = 0;
  public float speed = 0f;
}