using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject enemyPrefabs;
    private float spawnRange = 9;
    private int enemyCount,enemyWave=1;
    public GameObject powerUpPrephab;
    void Start()
    {
        SpawnEnemyWave(enemyWave);
    }
    void Update()
    {
        enemyCount=GameObject.FindObjectsOfType<Enemy>().Length;
        if (enemyCount == 0)
        {
            enemyWave++;
            SpawnEnemyWave(enemyWave);
            Instantiate( powerUpPrephab,GenerateSpawnPosition(),powerUpPrephab.transform.rotation);
        }
    }
    ///<summary>
    ///Genera una posicion aleatoria
    ///<summary>
    ///<returns>Devuelve una posicion aleatoria dentro de la zona de juego<returns>
    private Vector3 GenerateSpawnPosition()
    {
        float spawnPositionX = Random.Range(-spawnRange, spawnRange);
        float spawnPositionz = Random.Range(-spawnRange, spawnRange);
        Vector3 ramdonPos = new Vector3(spawnPositionX, y: 0, z: spawnPositionz);
        return ramdonPos; //Genera posicion - (Los void no devuelven nada solo ocurre algo)
    }
    ///<summary>
    ///Metodo que genera un numero odeterminado de enemigo en pantalla
    ///<param name=" numberOfEnemies ">Numero de enemigos a crear</param>
    ///<summary>
    private void SpawnEnemyWave(int numberOfEnemies)
    {

        for (int i = 0; i < numberOfEnemies; i++)
        {
            Instantiate(enemyPrefabs, GenerateSpawnPosition(), enemyPrefabs.transform.rotation);
        }
    }
}

