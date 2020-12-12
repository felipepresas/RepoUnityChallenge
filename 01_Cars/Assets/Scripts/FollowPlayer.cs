using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public GameObject player;

    public Vector3 offset= new Vector3(x:0,y:5,z:-6);
    

    private void Update()
    {
        transform.position = player.transform.position + offset;
    }
}
