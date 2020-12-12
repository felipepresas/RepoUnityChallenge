using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{

    public GameObject[] enemies;
    private int animalIndex;

    private float spawnRangeX = 16f;
    private float spawnPosZ = 28f;

    [SerializeField]
    private float starDelay = 2f;
    [SerializeField]
    private float spawnInterval = 1.2f;

    private void Start()
    {
        spawnPosZ = transform.position.z;
        InvokeRepeating ("SpawnRamdonAnimal", starDelay, spawnInterval);
    }


    private void SpawnRamdonAnimal()
    {
        //Posicion del enemigo
        float xRange = Random.Range(-spawnRangeX, spawnRangeX);
        Vector3 spawnPos = new Vector3(x: xRange, y: 0, spawnPosZ);

        //llama al enemigo
        animalIndex = Random.Range(0, enemies.Length);
        Instantiate(enemies[animalIndex], spawnPos, enemies[animalIndex].transform.rotation);
    }


}
