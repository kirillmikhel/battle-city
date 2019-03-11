using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public AudioClip soundIdle;
    public AudioClip soundMoving;

    private Move _move;
    private AudioSource _audioSource;

    private bool _isMovingUp = false;
    private bool _isMovingDown = false;
    private bool _isMovingRight = false;
    private bool _isMovingLeft = false;

    private void Awake()
    {
        _move = GetComponent<Move>();
        _audioSource = GetComponent<AudioSource>();
        PlaySound(soundIdle);
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetAxisRaw("Vertical") > 0)
        {
            if (!_isMovingUp)
            {
                _move.Up();

                PlaySound(soundMoving);

                _isMovingUp = true;
            }
        }

        if (Input.GetAxisRaw("Vertical") < 0)
        {
            if (!_isMovingDown)
            {
                _move.Down();

                PlaySound(soundMoving);

                _isMovingDown = true;
            }
        }

        if (Input.GetAxisRaw("Horizontal") > 0)
        {
            if (!_isMovingRight)
            {
                _move.Right();

                PlaySound(soundMoving);

                _isMovingRight = true;
            }
        }

        if (Input.GetAxisRaw("Horizontal") < 0)
        {
            if (!_isMovingLeft)
            {
                _move.Left();

                PlaySound(soundMoving);

                _isMovingLeft = true;
            }
        }

        if (Input.GetAxisRaw("Vertical") == 0 && Input.GetAxisRaw("Horizontal") == 0)
        {
            if (_isMovingUp || _isMovingDown || _isMovingRight || _isMovingLeft)
            {
                _move.Stop();

                PlaySound(soundIdle);

                _isMovingUp = false;
                _isMovingDown = false;
                _isMovingRight = false;
                _isMovingLeft = false;
            }
        }
    }

    private void PlaySound(AudioClip clip)
    {
        if (!_audioSource.enabled) return;

        _audioSource.clip = clip;
        _audioSource.Play();
    }
}