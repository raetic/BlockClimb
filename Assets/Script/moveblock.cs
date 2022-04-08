using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveblock : MonoBehaviour
{
    public float speed;
    float d;
    Vector3 MoveV;
    public Vector3[] dirChange;
    public GameObject Player;
    private void Awake()
    {
        d = 1;
        MoveV = Vector3.zero;
    }
    void Move()
    {
        MoveV = new Vector3(d, 0, 0);
        transform.position += MoveV * Time.deltaTime*2*speed;
    }
    void Update()
    {
        Move();
        if (transform.position.x<dirChange[0].x)
        {
            d = 1;
        }
        if (transform.position.x > dirChange[1].x)
        {
        
            d = -1;
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.name == "foot")
        {
            Player.transform.position += MoveV * Time.deltaTime * 2*speed;
        }
    }
}
