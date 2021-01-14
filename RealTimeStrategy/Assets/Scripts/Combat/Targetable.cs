using System.Collections;
using System.Collections.Generic;
using Mirror;
using UnityEngine;

public class Targetable : NetworkBehaviour
{
    [SerializeField] private Transform aimAtPoint=null;
    public Transform GetAimiAtPoint(){
        return aimAtPoint;
    }
}
