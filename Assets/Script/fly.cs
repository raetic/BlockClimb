using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fly : MonoBehaviour
{
    Rigidbody2D rigid;
    public float fSpeed=0;
    Vector3 MoveV;
    float d;
    float l;
    float t=0;
    float maxh;
    float minh;
    bool mborder;
  int speed;
    SpriteRenderer sprite;
    private void Awake()
    {
        speed = 1;
        sprite = GetComponent<SpriteRenderer>();
        maxh = transform.position.y + 2;
        minh = transform.position.y - 2;
        rigid = GetComponent<Rigidbody2D>();
        Think();
    }
    void Think()
    {
        d = Random.Range(-1, 2);
       while(d == 0)
        {
            d = Random.Range(-1, 2);
        }
        l = Random.Range(-1, 2);
        while(l == 0)
        {
            l = Random.Range(-1, 2);
        }
        Invoke("Think", 2);
    }
    private void Update()
    {
        Vector2 front = new Vector2(transform.position.x + d * 0.5f, transform.position.y);
        Debug.DrawRay(front, Vector3.down, new Color(0, 1, 0));
        RaycastHit2D rayHit = Physics2D.Raycast(front, Vector3.down, 1, LayerMask.GetMask("border"));
        if (rayHit.collider != null)
        {
            d *= -1;
        }
        if (d < 0)
        {
            sprite.flipX = false;
        }
        else if(d>0)
        {
            sprite.flipX = true;
        }
        if (transform.position.y > maxh||transform.position.y<minh)
        {
            l *= -1;
        }
        
        if (t < 2)
        {
            t += Time.deltaTime;
            fSpeed += Time.deltaTime;
        }
        else if (t < 4){
            t += Time.deltaTime;
            fSpeed -= Time.deltaTime;
        }
        else
        {
            t = 0;
        }
        MoveV = new Vector3(d, l, 0) ;
        transform.position += MoveV *Time.deltaTime* fSpeed*speed;
    }


    public void die()
    {
        Invoke("des", 1f);
        GetComponent<Animator>().SetTrigger("die");
        gameObject.tag = "Untagged";
        speed = 0;
    }
    void des()
    {
        Destroy(gameObject);
    }
}
