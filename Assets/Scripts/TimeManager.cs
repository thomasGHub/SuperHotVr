using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody rigid;
    Vector3 archiveSpeed;
    float lerpT;
    float timeDest;

    void Awake()
    {
        rigid = gameObject.GetComponent<Rigidbody>();
        Time.timeScale = 0.01f;
        archiveSpeed = Vector3.zero;
    }

    float sigmoid(int x)
    {
        int e = 2;
        if (x == 0)
        {
            return 0.01F;
        }
        else
        {
            return (float) (Math.Pow(e,x) / (Math.Pow(e, x) + 1));
        }
    }
    // Update is called once per frame
    void Update()
    {
        if ((rigid.velocity - archiveSpeed).magnitude >= 1)
        {
            lerpT = .1F;
            timeDest = sigmoid((int) rigid.velocity.magnitude);
            Time.timeScale = Mathf.Lerp(Time.timeScale, timeDest, lerpT);
        }
        else
        {
            lerpT += .1F;
            Time.timeScale = Mathf.Lerp(Time.timeScale, timeDest, lerpT);
        }
    }
}
