using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] obstaclePrefabs;
    private Vector3 spawnPos;
    private float starDelay = 2;
    private float repeatRate = 2;
    private PlayerController playerController;

    //private Vector3 spawnPos = new Vector3(x: 30, y: 0, z: 0);
    // Start is called before the first frame update
    void Start()
    {
        
        spawnPos = transform.position; //30,0,0
        InvokeRepeating("SpawnObstacle",starDelay,repeatRate);
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
    }

void SpawnObstacle()
    {
        if (!playerController.GameOver)
        {
            GameObject obstaclePrefab = obstaclePrefabs[Random.Range(0, obstaclePrefabs.Length)];
            Instantiate(obstaclePrefab, spawnPos, obstaclePrefab.transform.rotation);
        }
    }
}
