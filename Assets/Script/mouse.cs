using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mouse : MonoBehaviour
{
    public bool isonblock;
    public float d;
    Vector3 MoveV;
    SpriteRenderer sprite;
    int speed;
    public GameObject block;
    bool haveblock;
    public GameObject newblock;
    GameObject hereblock;
    void turn()
    {
        d *= -1;
        transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
    }
    private void Awake()
    {
        haveblock = true;
        speed = 1;
        d = -1;
        sprite = GetComponent<SpriteRenderer>();
        MoveV = Vector3.zero;

    }
    void Move()
    {
        MoveV = new Vector3(d, 0, 0);
        transform.position += MoveV * Time.deltaTime * 2 * speed;
    }
    void Update()
    {
        Move();
        Vector2 front = new Vector2(transform.position.x + d * 0.5f, transform.position.y);
        Debug.DrawRay(front, Vector3.down, new Color(0, 1, 0));
        RaycastHit2D rayHitblock = Physics2D.Raycast(front, Vector3.down, 1, LayerMask.GetMask("block"));
        RaycastHit2D rayHitborder = Physics2D.Raycast(front, Vector3.down, 1, LayerMask.GetMask("border"));
        if (haveblock)
        {
            if (rayHitborder.collider != null)
            {
                turn();
            }
            else if (rayHitblock.collider == null)
            {
                buildblock();  
            }
        }
        else
        {
            if (rayHitborder.collider != null)
            {
                turn();
            }
            else
            if (rayHitblock.collider == null)
            {
                turn();
            }
        }
    }
    void buildblock()
    {
        Destroy(block);
        haveblock = false;
        GameObject nb = Instantiate(newblock, new Vector3(hereblock.transform.position.x + d * 1.5f,
        hereblock.transform.position.y, hereblock.transform.position.z), transform.rotation);
    }        
    public void die()
    {
        Invoke("des", 0.5f);
        GetComponent<Animator>().SetTrigger("die");
        gameObject.tag = "Untagged";
        speed = 0;
    }
    void des()
    {
        Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "block")
        {
            hereblock = collision.gameObject;
        }
    }

}
