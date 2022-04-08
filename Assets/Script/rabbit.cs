using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rabbit : MonoBehaviour
{
    public bool isonblock;
    public float d;
    Vector3 MoveV;
    SpriteRenderer sprite;
   int speed;
    void turn()
    {
        d *= -1;
        transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
    }
    private void Awake()
    {
        speed = 1;
        d = -1;
        sprite = GetComponent<SpriteRenderer>();
        MoveV = Vector3.zero;
    
    }
    void Move()
    {
        MoveV = new Vector3(d, 0, 0);
        transform.position += MoveV * Time.deltaTime * 2*speed;
    }
    void Update()
    {
        Move();
        Vector2 front = new Vector2(transform.position.x + d*0.5f, transform.position.y);
        Debug.DrawRay(front, Vector3.down, new Color(0, 1, 0));
        RaycastHit2D rayHit = Physics2D.Raycast(front, Vector3.down, 1, LayerMask.GetMask("block"));
        RaycastHit2D rayHitborder = Physics2D.Raycast(front, Vector3.down, 1, LayerMask.GetMask("border"));
        if (rayHitborder.collider != null)
        {
            turn();
        }
        else
        if (rayHit.collider == null)
        {
            turn();
        }
    }
  public void die()
    {
        Invoke("des", 0.8f);
        GetComponent<Animator>().SetTrigger("die");
        gameObject.tag = "Untagged";
        speed = 0;
    }
    void des()
    {
        Destroy(gameObject);
    }
}
