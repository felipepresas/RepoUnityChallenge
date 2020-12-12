using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayerX : MonoBehaviour
{
    public GameObject plane;
    // private Vector3 offset= new Vector3(x:0,y:6,z:-12);
    private Vector3 playerPreviusPos = Vector3.zero;
    private float distance = 12f;

    // Update is called once per frame
    void Update()
    {
        Vector3 offset = plane.transform.position - playerPreviusPos;
        if (offset.magnitude < 0.2f)
        { return; }
        offset.Normalize();
        transform.position = plane.transform.position - offset * distance;

        transform.LookAt(plane.transform.position);
        playerPreviusPos = plane.transform.position;
    }
}
