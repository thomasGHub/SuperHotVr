using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    [SerializeField] GameObject ennemy;

    // Start is called before the first frame update
    void Start()
    {
        Spawning();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void Spawning()
    {
        Instantiate
                (
                ennemy,
                 new Vector3(0f,0f,0f),
                 Quaternion.Euler(new Vector3(0f, 0f, 0f))
                );

    }

}
