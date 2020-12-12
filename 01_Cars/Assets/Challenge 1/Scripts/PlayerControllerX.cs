using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerX : MonoBehaviour
{
    public float speed;
    public float rotationSpeed;
    public float verticalInput, horizontalInput, spaceInput;

    // Update is called once per frame
    void FixedUpdate()
    {
        // get the user's vertical input
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        spaceInput = Input.GetAxis("Jump");
        // move the plane forward at a constant rate
        transform.Translate(Vector3.forward * Time.deltaTime * speed * spaceInput);
        // move the plane forward at a constant rate
        transform.Rotate(Vector3.right * rotationSpeed * Time.deltaTime * verticalInput);

        // tilt the plane up/down based on up/down arrow keys
        transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime * horizontalInput);
    }
}
