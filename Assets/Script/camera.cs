using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera : MonoBehaviour
{
    public float upspeed;
    Vector3 MoveV;
    void Update()
    {
        MoveV = new Vector3(0,1, 0);
        transform.position += MoveV * Time.deltaTime*upspeed;
    }
}
