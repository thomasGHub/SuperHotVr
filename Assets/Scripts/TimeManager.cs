using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody rigid;

    void Awake()
    {
        rigid = gameObject.GetComponent<Rigidbody>();
        Time.timeScale = 0.01f;
    }

    // Update is called once per frame
    void Update()
    {
        if (rigid.velocity != Vector3.zero)
        {
            if (Time.timeScale < 0.5f)
            {
                Time.timeScale *= 2;
            }
            else
            {
                Time.timeScale = 1f;
            }
        }
        else if (Time.timeScale >= 0.002f)
        {
            Time.timeScale /= 2;
        }
        else
        {
            Time.timeScale = 0.001f;
        }
    }
}
