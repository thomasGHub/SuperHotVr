using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tirer : MonoBehaviour
{   [SerializeField] public GameObject cible;
    [SerializeField] private GameObject munition;
    [SerializeField] private Transform munitionParent;
    [SerializeField] private float puissancedefeu = 1f;
    [SerializeField] private int dps;
    // Start is called before the first frame update
    void Start()
    {
        cibler();
    }

    // Update is called once per frame
    void Update()
    {   dps += 1;
       
        if (dps == 300)
        {
            shoot();
            dps = 0;
        }
    }

    void cibler()
    {
        Vector3 dir = (cible.transform.position - this.transform.position).normalized;
        transform.Rotate(dir);
    }
    void shoot()
    {
        GameObject munition_spawn = Instantiate(
                munition,
                transform.position,
                Quaternion.identity,
                munitionParent
                );
        munition_spawn.GetComponent<Rigidbody>().AddForce(transform.forward * puissancedefeu);
        Destroy(munition_spawn, 2f);
    }
}
