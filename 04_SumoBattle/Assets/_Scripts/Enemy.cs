using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody))]
public class Enemy : MonoBehaviour
{
    private Rigidbody _rigibody;
    public float moveForce;
    private GameObject playerPosition;
    void Start()
    {
        _rigibody = GetComponent<Rigidbody>();
        playerPosition = GameObject.Find("Player");
    }
    void Update()
    {
        // Vector direccion =Destino - Origen   para que el enemigo busque al player
        Vector3 enemyDirection = (playerPosition.transform.position - this.transform.position).normalized;
        _rigibody.AddForce(enemyDirection*moveForce);
        if (this.transform.position.y<-10)
        {
            Destroy(gameObject);
        }
    }
}
