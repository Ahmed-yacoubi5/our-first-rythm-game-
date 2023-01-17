using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class beatScroller : MonoBehaviour
{
    // Start is called before the first frame update
    public float beatTempo;
    public bool hasStarted;
    void Start()
    {
        beatTempo = beatTempo/12f;
    }

    // Update is called once per frame
    void Update()
    {
        if (!hasStarted)
        {
           /* if(Input.anyKeyDown)
            {
                hasStarted = true;
            }*/
        }
        else
        {
            transform.position -= new Vector3(0f, beatTempo*Time.deltaTime, 0f);
        }
    }
}