using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Animator _animator;
    private Quaternion rotation=Quaternion.identity;
    private Rigidbody _rigibody;
    private AudioSource _audioSourse;
    private Vector3 movement;
    public float turnSpeed;
    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();
        _rigibody = GetComponent<Rigidbody>();
        _audioSourse=GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        movement.Set(horizontal, 0, vertical);
        movement.Normalize();

        bool hasHorizontalInput = !Mathf.Approximately(horizontal, 0f);
        bool hasVerticaltalInput = !Mathf.Approximately(vertical, 0f);
        bool isWalking = hasHorizontalInput || hasVerticaltalInput;

        _animator.SetBool("IsWalk", isWalking);
        
        if (isWalking)
        {
            if (!_audioSourse.isPlaying)
            {
                _audioSourse.Play();
            }
        }
        else
        {
            _audioSourse.Stop();
        }

        Vector3 desiredFoward = Vector3.RotateTowards(transform.forward, movement, turnSpeed * Time.fixedDeltaTime, 0f);

        rotation = Quaternion.LookRotation(desiredFoward);
    }

    private void OnAnimatorMove()
    {
        _rigibody.MovePosition(_rigibody.position + movement * _animator.deltaPosition.magnitude);
        _rigibody.MoveRotation(rotation);

    }
}
