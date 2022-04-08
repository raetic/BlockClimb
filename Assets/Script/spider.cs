using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spider : MonoBehaviour
{
    Vector3 MoveV;
    float t=0;
    private void Awake()
    {
        
    }
    private void Update()
    {
        t += Time.deltaTime;
        if (t < 1f)
            MoveV = new Vector3(0, -1f, 0);
        else if (1f < t&&t<1.7f)
        {
            MoveV = new Vector3(0, 0, 0);
        }
       else if (t > 1.7f)
        {
            MoveV = new Vector3(0, 1f, 0);
        }
       if (t > 2.7f)
        {
            t = 0;
        }
        transform.position += MoveV * Time.deltaTime * 2;
    }
}
