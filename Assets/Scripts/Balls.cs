using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Balls : MonoBehaviour
{
    public Vector3 startForce;
    

    // Start is called before the first frame update
    void Start()
    {
        Rigidbody rigidbody = GetComponent<Rigidbody>();
        rigidbody.AddForce(startForce, ForceMode.Impulse);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public float speed
    {
        get { return Time.deltaTime; }
        set
        {
            if (value < 0.0f) 
            { 
             value = 5.0f; 
            }
            else 
            { 
             value = -value; 
            }
        }
    }

}
