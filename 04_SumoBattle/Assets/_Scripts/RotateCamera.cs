using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateCamera : MonoBehaviour
{
    public float rottatingSpeed=120;
    private float horizontalInput;

    // Update is called once per frame
    void Update()
    {
        horizontalInput=Input.GetAxis("Horizontal");
        transform.Rotate(Vector3.up*horizontalInput*rottatingSpeed*Time.deltaTime);
    }
}
