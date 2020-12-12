using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour
{
    private Rigidbody _rigibody;
    public float forcetranslate, forwardInput;
    public GameObject focalPoint;
    public bool hasPowerUp;
    public float powerUpForce, powerUpTime = 9;
    public GameObject[] powerUpIndicators;

    // Start is called before the first frame update
    void Start()
    {
        //Es mejor utilizar en el futuro // focalPoint=GameObject.Find("FocalPoint");
        _rigibody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        forwardInput = Input.GetAxis("Vertical");
        //F=m*a
        _rigibody.AddForce(focalPoint.transform.forward * forcetranslate * forwardInput, ForceMode.Force);

        foreach (GameObject indicator in powerUpIndicators)
        {
            indicator.transform.position = this.transform.position + 0.5f * Vector3.up;
        }
        if (this.transform.position.y<-10)
        {
            SceneManager.LoadScene("Prototype 4");
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PowerUp"))
        {
            hasPowerUp = true;
            Destroy(other.gameObject);
            StartCoroutine(routine: PowerUpCountDown());
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy") && (hasPowerUp))
        {
            Rigidbody enemyRigibody = collision.gameObject.GetComponent<Rigidbody>();
            Vector3 awayFromPlayer = collision.gameObject.transform.position - this.transform.position;
            enemyRigibody.AddForce(awayFromPlayer * powerUpForce, ForceMode.Impulse);
        }
    }
    IEnumerator PowerUpCountDown() // Corutina para hacer que dure un tiempo el power up
    {
/*         foreach (GameObject indicator in powerUpIndicators)
        {
            powerUpIndicators[i].gameObject.SetActive(true);
            yield return new WaitForSeconds(powerUpTime / powerUpIndicators.Length);
            powerUpIndicators[i].gameObject.SetActive(false);
        } */  //Se puede hacer con un bucle for o un foreach
        for (int i = 0; i < powerUpIndicators.Length; i++)
        {
            powerUpIndicators[i].gameObject.SetActive(true);
            yield return new WaitForSeconds(powerUpTime / powerUpIndicators.Length);
            powerUpIndicators[i].gameObject.SetActive(false);
        }
        hasPowerUp = false;
    }
}

