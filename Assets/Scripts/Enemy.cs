using System;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
public class Enemy : MonoBehaviour
{
  public float speed = 0;
  public float health = 0f;
  public float maxHealth = 0f;
  public RuntimeAnimatorController[] animCon = { null, };
  public Rigidbody2D target = null;

  bool isLive;

  Rigidbody2D rigid = null;
  Collider2D coll = null;
  Animator anim = null;
  SpriteRenderer spriter = null;
  WaitForFixedUpdate wait = null;

  void Awake()
  {
    rigid = GetComponent<Rigidbody2D>();
    coll = GetComponent<Collider2D>();
    anim = GetComponent<Animator>();
    spriter = GetComponent<SpriteRenderer>();
    wait = new WaitForFixedUpdate();
  }

  void FixedUpdate()
  {
    if (!isLive || anim.GetCurrentAnimatorStateInfo(0).IsName("Hit"))
    {
      return;
    }

    Vector2 dirVec = target.position - rigid.position;
    Vector2 nextVec = dirVec.normalized * speed * Time.fixedDeltaTime;
    rigid.MovePosition(rigid.position + nextVec);
    rigid.velocity = Vector2.zero;
  }

  void LateUpdate()
  {
    if (!isLive)
    {
      return;
    }

    spriter.flipX = target.position.x < rigid.position.x;
  }

  void OnEnable()
  {
    target = GameManager.instance.player.GetComponent<Rigidbody2D>();
    isLive = true;
    coll.enabled = true;
    rigid.simulated = true;
    spriter.sortingOrder = 2;
    anim.SetBool("Dead", false);
    health = maxHealth;
  }

  public void Init(SpawnData data)
  {
    anim.runtimeAnimatorController = animCon[data.spriteType];
    speed = data.speed;
    maxHealth = data.health;
    health = data.health;
  }
  void OnTriggerEnter2D(Collider2D collision)
  {
    if (!collision.CompareTag("Bullet") || !isLive)
    {
      return;
    }
    health -= collision.GetComponent<Bullet>().damage;
    StartCoroutine("KnockBack");

    if (health > 0)
    {
      anim.SetTrigger("Hit");
    }
    else
    {
      isLive = false;
      coll.enabled = false;
      rigid.simulated = false;
      spriter.sortingOrder = 1;
      anim.SetBool("Dead", true);
      GameManager.instance.kill++;
      GameManager.instance.GetExp();
      Dead();
    }
  }

  IEnumerator KnockBack()
  {
    yield return null; // 다음 하나의 물리 프레임을 딜레이 시킴
    Vector3 playerPos = GameManager.instance.player.transform.position;
    Vector3 dirPos = transform.position - playerPos;
    rigid.AddForce(dirPos.normalized * 3, ForceMode2D.Impulse);
  }

  void Dead()
  {
    gameObject.SetActive(false);
  }
}