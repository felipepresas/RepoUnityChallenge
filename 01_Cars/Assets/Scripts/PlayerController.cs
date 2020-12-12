using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //Variables
    //[HideInInspector] para ocultar en el inspector
    [Range(0, 20), SerializeField, Tooltip("Velociadad actual del coche")]
    private float speed = 20f;
    [Range(0, 160), SerializeField, Tooltip("Velociadad de giro")]
    private float turnSpeed = 160f;
    private float horizontalInput, verticalInput;
    // Es llamado antes del primer actualizacion de frame 
    void Start()
    {
        //Debug.Log(message: "Esto es el metodo star del pc");
    }

    // Se actualiza una vez por frame
    // Tenemo que mover el vehiculo
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        // S= S0 + V * T * (direccion)
        transform.Translate(translation: speed * Time.deltaTime * Vector3.forward * verticalInput);
        transform.Rotate(eulers: turnSpeed * Time.deltaTime *4* Vector3.up * horizontalInput);
    }
}
