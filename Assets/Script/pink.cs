using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pink : MonoBehaviour
{
    Rigidbody2D rigid;
    public float maxspeed;
    public float jumpPower;
    SpriteRenderer sprite;
    Animator anim;
    public foot fo;
    float h;
    public bool isdie;
    private void Awake()
    {
        h = 0;
        anim = GetComponent<Animator>();
        rigid = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
    }
    private void Update()
    {
        if (Input.GetButtonDown("Jump") && fo.isAir == false)
        {
            Invoke("Jump", 0.3f);
        }
        if (Input.GetButtonDown("Fire1") && gameObject.tag != "Attack")
        {
            Invoke("Attack", 0.3f);

        }
    }
    void Jump()
    {
        fo.isAir = true;
        rigid.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
    }
    void Attack()
    {
        anim.SetTrigger("attack");
        gameObject.tag = "Attack";
        Invoke("nonAttack", 0.5f);
    }
    void nonAttack()
    {
        gameObject.tag = "Player";
    }
    void Move()
    {

        if (rigid.velocity.x != 0)
        {
            anim.SetBool("iswalk", true);
        }
        else anim.SetBool("iswalk", false);
    
        if (h > 0)
        {
            transform.localScale = new Vector3(-0.8f, 0.8f, 0);
        }
        if (h < 0)
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
        if (gameObject.tag == "Player")
            Move();
        h = Input.GetAxisRaw("Horizontal");
    }
 
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "deadline")
        {
            isdie = true;
            gameObject.SetActive(false);
        }
        if (collision.gameObject.tag == "enemy")
        {
            if (gameObject.tag != "Attack")
            {      
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
    
    }
}
