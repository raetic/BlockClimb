using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Rigidbody2D rigid;
    public float maxspeed;
    public float jumpPower;
    SpriteRenderer sprite;
    Animator anim;
    public foot fo;
    public GameObject[] life;
    public int lifecount;
    bool isHit;
    public GM gm;
    private void Awake()
    {
        anim = GetComponent<Animator>();
        rigid = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();   
    }
    private void Update()
    {
        Jump();
        Attack();
    }
    void Jump()
    {
        if (Input.GetButtonDown("Jump")&&fo.isAir==false&&!isHit)
        {
            fo.isAir = true;
            anim.SetBool("isJump", true);
            rigid.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
        }
    }
    void Attack()
    {
        if (Input.GetButtonDown("Fire1")&&gameObject.tag!="Attack")
        {
          
            anim.SetTrigger("Attack");
            gameObject.tag = "Attack";
            Invoke("nonAttack", 0.5f);
     
        }
    }
    void nonAttack()
    {
        gameObject.tag = "Player";
    }
    void Move()
    {
        float h;
        if (rigid.velocity.x != 0)
        {
            anim.SetBool("isWalk", true);
        }
        else anim.SetBool("isWalk", false);
        if (!isHit)
            h = Input.GetAxisRaw("Horizontal");
        else
        {
            h = 0;
        }
        if (h > 0)
        {
            transform.localScale = new Vector3(-0.8f, 0.8f, 0);
        }
        if(h<0)
        {
            transform.localScale = new Vector3(0.8f, 0.8f, 0);
        }
        rigid.AddForce(Vector2.right * h, ForceMode2D.Impulse);
      if (rigid.velocity.x > maxspeed)
        {       
            rigid.velocity = new Vector2(maxspeed, rigid.velocity.y);
        }
        if (rigid.velocity.x < -1 * maxspeed)
        {         
            rigid.velocity = new Vector2(-1 * maxspeed, rigid.velocity.y);
        }
        if (rigid.velocity.y > jumpPower)
        {
            rigid.velocity = new Vector2(rigid.velocity.x, jumpPower);
        }
        if (rigid.velocity.y < -1 * jumpPower)
        {
            rigid.velocity = new Vector2(rigid.velocity.x, -1 * jumpPower);
        }
        if (Input.GetButtonUp("Horizontal"))
        {
            rigid.velocity = new Vector2(rigid.velocity.normalized.x * 0.5f, rigid.velocity.y);
        }
    }
    private void FixedUpdate()
    {
        if(gameObject.tag=="Player")
        Move();
       
    }
    void onHit(GameObject e)
    {
        sprite.color = new Color(1, 1, 1, 0.5f);
        isHit = true;
        int dirc = e.transform.position.x - transform.position.x > 0 ? -5 : 5;
        rigid.AddForce(new Vector2(dirc, 0.01f) * 120, ForceMode2D.Impulse);
        if (lifecount == 3)
        {
            life[2].SetActive(false);
        }
       else if (lifecount == 2)
        {
            life[1].SetActive(false);
        }
      else if (lifecount == 1)
        {
            life[0].SetActive(false);
        }
        else
        {
            gm.gameover();
        }
        lifecount--;
        Invoke("HitPossible", 0.5f);
    }
    void HitPossible()
    {
        sprite.color = new Color(1, 1, 1,1f);
        isHit = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "deadline")
        {
            gm.gameover();
        }
        if (collision.gameObject.tag == "enemy")
        {
            if (gameObject.tag != "Attack")
            {
                if (!isHit)
                    onHit(collision.gameObject);
            }
            else
            {
                if (collision.gameObject.name == "rabbit")
                    collision.gameObject.GetComponent<rabbit>().die();
                if (collision.gameObject.name == "flyenemy")
                    collision.gameObject.GetComponent<fly>().die();
                if (collision.gameObject.name == "mouse")
                    collision.gameObject.GetComponent<mouse>().die();
            }
        }
        if (collision.gameObject.tag == "goal")
        {
            Destroy(collision.gameObject);
            gm.nextstage();

        }
        if (collision.gameObject.tag == "clock")
        {
            Destroy(collision.gameObject);
            gm.lefttime += 20;
        }
    }
}
