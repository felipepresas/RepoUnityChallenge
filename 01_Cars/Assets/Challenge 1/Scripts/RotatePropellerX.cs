using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatePropellerX : MonoBehaviour
{
    private float proppelerSpeed = 800f;

    // Update is called once per frame
    void Update()
    {
         transform.Rotate(Vector3.forward * proppelerSpeed * Time.deltaTime );
    }
}
