using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spin : MonoBehaviour
{
    public float rotateSpeed = 60;
    public float translateSpeed = 30;

    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        //transform.Translate(Vector3.left*translateSpeed* Time.deltaTime); // posicion del universo
        transform.localPosition+=(Vector3.left*translateSpeed* Time.deltaTime); //Posicion local
        transform.Rotate(eulers: Vector3.up * rotateSpeed * Time.deltaTime);
    }
}
