using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class breakblock : MonoBehaviour
{
    public int bn;
    public GameObject blocks;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "head")
        {
            Invoke("Des", 0.05f);
        }
    }
    void Des()
    {
        if (bn == 0)
        {
            Destroy(blocks);
        }
        Destroy(gameObject);
    }
    
}
