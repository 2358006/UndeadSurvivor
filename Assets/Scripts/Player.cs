using UnityEngine;
public class Player : MonoBehaviour
{
  public float speed = 0f;
  public Vector2 inputVec = Vector2.zero;
  public Scanner scanner = null;

  Rigidbody2D rigid = null;
  SpriteRenderer spriter = null;
  Animator anim = null;

  void Awake()
  {
    rigid = GetComponent<Rigidbody2D>();
    spriter = GetComponent<SpriteRenderer>();
    anim = GetComponent<Animator>();
    scanner = GetComponent<Scanner>();
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

  void LateUpdate()
  {
    anim.SetFloat("Speed", inputVec.magnitude);

    if (inputVec.x != 0)
    {
      spriter.flipX = inputVec.x < 0;
    }
  }
}