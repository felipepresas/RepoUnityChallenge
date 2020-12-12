using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckCollisions : MonoBehaviour
{

    //On tigger se llamara automaticamente
    //Cuando un objeto fisico entre dentro del trigger del otro

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Animals"))
        {
            //El proyectil choca contra un animal
            Destroy(gameObject);   //destruye el objeto
            Destroy(other.gameObject);   // destruye el otro
        }
       
    }


}
