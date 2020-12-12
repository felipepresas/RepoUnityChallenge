using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    private PlayerController audioController;
    private AudioSource _audioSource2;
    // Start is called before the first frame update
    void Start()
    {
        _audioSource2=GetComponent<AudioSource>();
         audioController = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if(audioController.GameOver){
            _audioSource2.Stop();
        }
    }
}
