using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutOfBound : MonoBehaviour
{
    private float topBound=30f;
    private float botBound = -30f;
    private float rightBound = 30f;
    private float leftBound = -30f;

    
    void Update()
    {   //Declarando condicion como variable boleanas
        bool cond1 = (this.transform.position.z > topBound);
        bool cond2 = (this.transform.position.z < botBound);
        if (cond1)
        {
            Destroy(this.gameObject);
        }
        if (cond2)
        {
            Debug.Log("Game Over");
            Destroy(this.gameObject);
            Time.timeScale = 0;
        }

        if ((this.transform.position.x > rightBound) || (this.transform.position.x < leftBound))
        {
            Destroy(this.gameObject);
        }

    }
}
