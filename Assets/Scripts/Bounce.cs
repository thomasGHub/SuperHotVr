using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bounce : MonoBehaviour
{
    public float force;
    float actualForce;
    Rigidbody rigid;

 
    void Start()
    {
        rigid = GetComponent<Rigidbody>();
        rigid.AddForce(Physics.gravity);

    }


    void Update()
    {
        
    }
}
