using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerX : MonoBehaviour
{
    public GameObject dogPrefab;
    private float fireRate = 1f; //cada 1 segundo se dispara
    private float timeSinceLastFire = 0f; //Tiempo desde el ultimo disparo

    // Update is called once per frame
    void Update()
    {
        timeSinceLastFire += Time.deltaTime;
        // On spacebar press, send dog
        if (Input.GetKeyDown(KeyCode.Space) && timeSinceLastFire>fireRate)
        {
            timeSinceLastFire = 0f;
            Instantiate(dogPrefab, transform.position, dogPrefab.transform.rotation);
        }
    }
}
