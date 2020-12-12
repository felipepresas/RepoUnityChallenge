using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float horizontalInput,verticalInput;
    public float speed,xRange=19.0f,zRange=10.0f;

    public GameObject projectilePrefab;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        transform.Translate(Vector3.right * Time.deltaTime * speed * horizontalInput);
        transform.Translate(Vector3.forward * Time.deltaTime * speed * verticalInput);

        if (transform.position.x < -xRange)
        {
            //Evita salirse del mapa
            transform.position = new Vector3(x: -xRange, transform.position.y, z: transform.position.z);
        }

        if (transform.position.x > xRange)
        {
            transform.position = new Vector3(x: xRange, transform.position.y, transform.position.z);
        }
        if (transform.position.z < -zRange)
        {
            //Evita salirse del mapa
            transform.position = new Vector3(transform.position.x, transform.position.y, z: -10);
        }

        if (transform.position.z > zRange)
        {
            //Evita salirse del mapa
            transform.position = new Vector3(transform.position.x, transform.position.y, z: 10);
        }


        //Acciones del personaje

        if (Input.GetKeyDown(KeyCode.Space))
        {
            //Si entramos aqui, hau que lanzar un proyectil instamtiate invoca un objeto a pantalla
            Instantiate(projectilePrefab, transform.position, projectilePrefab.transform.rotation);

        }
    }
}
