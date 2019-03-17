using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    private Move _move;
    private Shooting _shooting;
    private AudioSource _audioSource;
    private SoundController _soundController;

    private bool _isMovingUp = false;
    private bool _isMovingDown = false;
    private bool _isMovingRight = false;
    private bool _isMovingLeft = false;

    private void Awake()
    {
        _soundController = GetComponent<SoundController>();
        _move = GetComponent<Move>();
        _shooting = GetComponent<Shooting>();
        _audioSource = GetComponent<AudioSource>();
        
//        _soundController.audioIdle.Play();
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetButton("Shoot"))
        {
            _shooting.Shoot();
        }

        if (Input.GetAxisRaw("Vertical") > 0)
        {
            if (!_isMovingUp)
            {
                _move.Up();

//                _soundController.audioMoving.Play();

                _isMovingUp = true;
            }
        }

        if (Input.GetAxisRaw("Vertical") < 0)
        {
            if (!_isMovingDown)
            {
                _move.Down();

//                _soundController.audioMoving.Play();

                _isMovingDown = true;
            }
        }

        if (Input.GetAxisRaw("Horizontal") > 0)
        {
            if (!_isMovingRight)
            {
                _move.Right();

//                _soundController.audioMoving.Play();

                _isMovingRight = true;
            }
        }

        if (Input.GetAxisRaw("Horizontal") < 0)
        {
            if (!_isMovingLeft)
            {
                _move.Left();

//                _soundController.audioMoving.Play();

                _isMovingLeft = true;
            }
        }

        if (Input.GetAxisRaw("Vertical") == 0 && Input.GetAxisRaw("Horizontal") == 0)
        {
            if (_isMovingUp || _isMovingDown || _isMovingRight || _isMovingLeft)
            {
                _move.Stop();

//                _soundController.audioMoving.Play();

                _isMovingUp = false;
                _isMovingDown = false;
                _isMovingRight = false;
                _isMovingLeft = false;
            }
        }
    }
}