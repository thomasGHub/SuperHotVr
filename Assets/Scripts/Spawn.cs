using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public static Spawn instance;
    [SerializeField] GameObject ennemy;
    public List<Transform> spawnPos = new List<Transform>();
    GameObject enemy;
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        Spawning();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Spawning()
    {
        int rand = Random.Range(0, spawnPos.Count);
        enemy = Instantiate
                (
                ennemy,
                 spawnPos[rand].position,
                 Quaternion.Euler(new Vector3(0f, 0f, 0f))
                );
    }
}
