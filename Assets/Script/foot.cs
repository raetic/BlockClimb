using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class foot : MonoBehaviour
{
    // Start is called before the first frame update
    public bool isAir;
    public Animator anim;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "block")
        {
            isAir = false;
            anim.SetBool("isJump", false);
        }
    }

}
