﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class MoveLeft : MonoBehaviour
{
    public float speed = 7;
    private PlayerController playerController;

    // Start is called before the first frame update
    void Start()
    {
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!playerController.GameOver)
        { 
        transform.Translate(Vector3.left * speed * Time.deltaTime);
        }
    }
}
