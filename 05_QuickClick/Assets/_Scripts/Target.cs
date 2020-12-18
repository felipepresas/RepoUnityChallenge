using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Target : MonoBehaviour
{
    private float minForce = 12, maxForce = 16, speedTorque = 10, SpawnPosRange = 4;
    private GameManager gameManager;
    public int pointValue;
    private Rigidbody _rigibody;
    public ParticleSystem explosionParticle;
    // Start is called before the first frame update
    void Start()
    {
        _rigibody = GetComponent<Rigidbody>();
        _rigibody.AddForce(RamdonForce(), ForceMode.Impulse);
        _rigibody.AddTorque(x: RamdonTorque(), y: RamdonTorque(), z: RamdonTorque(), ForceMode.Impulse);
        transform.position = RamdomSpawnPos();
        //gameManager=GameObject.Find("Game Manager").GetComponent<GameManager>();
        gameManager=GameObject.FindObjectOfType<GameManager>();
    }
    ///<summary>
    ///Genera un vector aleatorio en 3D
    ///<summary>
    ///<returns> Fuerza aleatoria para arriba <returns>
    private Vector3 RamdonForce()
    {
        return Vector3.up * Random.Range(minForce, maxForce);
    }
    ///<summary>
    ///Genera un numero aleatorio
    ///<summary>
    ///<returns> Valor aleatorio entre speedtorque <returns>
    private float RamdonTorque()
    {
        return Random.Range(-speedTorque, speedTorque);
    }
    ///<summary>
    ///Genera un posicion aleatorio
    ///<summary>
    ///<returns> posicion aleatoria en 3D con la coordenada z=0 <returns>
    private Vector3 RamdomSpawnPos()
    {
        return new Vector3(x: Random.Range(-SpawnPosRange, SpawnPosRange), y: -SpawnPosRange);
    }
    private void OnMouseDown()
    {
        if (gameManager.gameState==GameManager.GameState.inGame)
        {
        Destroy(gameObject);
        Instantiate(explosionParticle,transform.position,explosionParticle.transform.rotation);
        gameManager.UpdateScore(pointValue);
         if (gameObject.CompareTag("bad") )
        {
            gameManager.GameOver();
        } 
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        
        if (other.CompareTag("KillZone"))
        {
            Destroy(gameObject);
            if (gameObject.CompareTag("good"))
            {
                gameManager.GameOver();
                //gameManager.UpdateScore(-10);
            }
        }
        
    }
}
