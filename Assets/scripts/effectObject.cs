using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class effectObject : MonoBehaviour
{
    // Start is called before the first frame update

    public float lifeTime=0.5f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Destroy(gameObject,lifeTime);
    }
}
