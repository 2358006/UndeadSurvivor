using UnityEngine;
public class Player : MonoBehaviour
{
  public float speed = 0f;
  Vector2 inputVec = Vector2.zero;
  Rigidbody2D rigid = null;

  void Awake()
  {
    rigid = GetComponent<Rigidbody2D>();
  }

  void Update()
  {
    inputVec.x = Input.GetAxisRaw("Horizontal");
    inputVec.y = Input.GetAxisRaw("Vertical");
  }

  void FixedUpdate()
  {
    Vector2 nextVec = inputVec.normalized * speed * Time.fixedDeltaTime;
    rigid.MovePosition(rigid.position + nextVec);
  }
}