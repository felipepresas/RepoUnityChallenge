using System.Collections;
using System.Collections.Generic;
using Mirror;
using UnityEngine;

public class UnitFiring : NetworkBehaviour
{
    [SerializeField] private Targeter targeter = null;
    [SerializeField] private GameObject projectilePrefab = null;
    [SerializeField] private Transform projectileSpawnPoint = null;
    [SerializeField] private float fireRange = 6f;
    [SerializeField] private float fireRate = 1f;
    [SerializeField] private float rotationSpeed = 20f;
    private float lastFireTime;

    [ServerCallback]
    private void Update()
    {   
         Targetable target =targeter.GetTarget();

        //Condicion si no tienes nada targeteado 
        if(target==null){ return;}

        //condicion de si esta en distancion de disparo rotar al objetivo
        if (!CanFireAtTarget()) { return; }
        Quaternion targetRotation = Quaternion.LookRotation(target.transform.position - transform.position);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);

        //Condicion velocidad entre cada disparo
        if (Time.time > (1 / fireRate)+lastFireTime)
        {
            Quaternion projectileRotation = Quaternion.LookRotation(target.GetAimiAtPoint().position-projectileSpawnPoint.position);

            // Instancia al projectil de disparo
            GameObject projectileInstance =Instantiate(projectilePrefab,projectileSpawnPoint.position,projectileRotation);

            NetworkServer.Spawn(projectileInstance,connectionToClient);
            lastFireTime = Time.time;
        }
    }
    [Server]
    // Condicion si se encuentra en distancia para disparo
    private bool CanFireAtTarget()
    {
        return (targeter.GetTarget().transform.position - transform.position).sqrMagnitude <= fireRange * fireRange;
    }
}