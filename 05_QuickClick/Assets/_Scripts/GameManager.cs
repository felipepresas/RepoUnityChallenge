using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class GameManager : MonoBehaviour
{
    public List<GameObject>targetPrefabs; // esto es hacerlo con una lista es como un array pero se ajusta
    //public GameObject[] targetPrefabs2; esto es hacerlo con un array
    public float spawnRate=1.0f;
    void Start()
    {
        StartCoroutine(routine:SpawnTarget());
    }
  IEnumerator SpawnTarget()
  {
      while (true)
      {
          yield return new WaitForSeconds(spawnRate);
          int idx=Random.Range(0,targetPrefabs.Count);
          Instantiate(targetPrefabs[idx]);
      }
  }    
}