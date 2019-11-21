using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneratorObstacle : MonoBehaviour
{
    public GameObject obstaclePrefabs;
    [Range(0,10)]
    public float spawnRandomRange;
    [Range(0,10)]
    public float timeBetween;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Spawn", 0.0f, timeBetween);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
   void Spawn()
    {
        Vector3 randomPosition= new Vector3(0f, Random.Range(-spawnRandomRange, spawnRandomRange),0f);
        /* Otra Forma de hacerlo
        randomPosition.x = 0f;
        randomPosition.y = Random.Range(-spawnRandomRange, spawnRandomRange);
        randomPosition.z = 0f;*/
        Instantiate(obstaclePrefabs, transform.position + randomPosition, Quaternion.identity);
    }
   
}
