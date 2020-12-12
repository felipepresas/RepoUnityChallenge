using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour
{
    public int contadorTime = 1;
    private const string SPEED_MULTIPLIER = "SpeedMulti";
    private const string JUMP_TRIG = "Jump_trig";
    private const string DEATH_B = "Death_b";
    private const string DEATH_TYPE = "DeathType_int";
    private Rigidbody playerRB;
    public float jumpForce = 500;
    public bool isOnGround = true;
    private bool _gameOver = false;
    public bool GameOver
    {
        get => _gameOver;
    }
    private Animator _animator;
    public ParticleSystem explosion, rocks;
    public AudioClip jumpSound, CrashSound;
    private AudioSource _audioSource;
    [Range(0, 1)]
    public float auidioVolumen;

    void Start()
    {
        playerRB = GetComponent<Rigidbody>();
        _animator = GetComponent<Animator>();
        _audioSource = GetComponent<AudioSource>();
    }
    void Update()
    {
        _animator.SetFloat(name: SPEED_MULTIPLIER, contadorTime);


        if (Input.GetKeyDown(KeyCode.Space) && isOnGround && !GameOver)
        {
            playerRB.AddForce(Vector3.up * jumpForce, ForceMode.Impulse); //F=m*a
            //playerRB.AddForce(Vector3.right * jumpForce, ForceMode.Impulse);
            isOnGround = false;
            _animator.SetTrigger(name: JUMP_TRIG);
            contadorTime++;
            rocks.Stop();
            _audioSource.PlayOneShot(jumpSound);
        }
    }
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            if(!GameOver){

            isOnGround = true;
            rocks.Play();
            }
        }
        else if (other.gameObject.CompareTag("Obstacle"))
        {
            _gameOver = true;
            // Debug.Log(message: "Game Over!!!!!");
            explosion.Play();
            _animator.SetBool(name: DEATH_B, true);
            _animator.SetInteger(name: DEATH_TYPE, Random.Range(1, 3));
            _audioSource.PlayOneShot(CrashSound);
            rocks.Stop();
            Invoke(methodName: "RestartGame", time: 3.0f);
        }
    }

    void RestartGame()
    {
        SceneManager.LoadScene("Prototype 3");

    }
}
