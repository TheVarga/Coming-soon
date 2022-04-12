using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    float t;

    private void Start()
    {
        t = Time.deltaTime;
    }
    // Update is called once per frame
    void Update()
    {
        transform.Translate(0, t, 0);
    }
    
}
