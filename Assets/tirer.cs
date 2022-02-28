using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tirer : MonoBehaviour
{   [SerializeField] private GameObject cible;
    [SerializeField] private GameObject arme;
    private float dist;
    // Start is called before the first frame update
    void Start()
    {
       dist = Vector3.Distance(cible.transform.position, transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        dist = Vector3.Distance(cible.transform.position, transform.position);
        if (dist < 20)
        {

        }
    }
}
