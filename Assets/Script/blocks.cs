using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class blocks : MonoBehaviour
{
    public GameObject[] block;
    public void fblock()
    {
        block[1].SetActive(false);
        block[0].SetActive(true);
    }
    public void sblcok()
    {
        Destroy(gameObject);
    }
}
