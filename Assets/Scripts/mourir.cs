using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mourir : MonoBehaviour
{
    [SerializeField] GameObject Armedropped;
    private static LayerMask armelayer;
    // Start is called before the first frame update
    void Awake()
    {
        armelayer = LayerMask.NameToLayer("armelayer");
    }

    // Update is called once per frame
    void Update()
    {   
        
    }
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.layer == armelayer)
        {
            Instantiate
                (
                Armedropped,
                 new Vector3(0f, 0f, 0f),
                 Quaternion.Euler(new Vector3(0f, 0f, 0f))
                );
            Destroy(gameObject); }
    }

}
