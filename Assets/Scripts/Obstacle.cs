using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    [Range(0, 10)]
    public float speedObstacle;
    [Range(0,60)]
    public float timeToDestroy;
    void Start()
    {
        Destroy(gameObject, timeToDestroy);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = transform.position + Vector3.left * speedObstacle * Time.deltaTime;
    }
}
