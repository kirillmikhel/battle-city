using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    private Move _move;

    private bool _isMovingUp = false;
    private bool _isMovingDown = false;
    private bool _isMovingRight = false;
    private bool _isMovingLeft = false;

    private void Awake()
    {
        _move = GetComponent<Move>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxisRaw("Vertical") > 0)
        {
            if (!_isMovingUp)
            {
                _move.Up();
                _isMovingUp = true;
            }
        }

        if (Input.GetAxisRaw("Vertical") < 0)
        {
            if (!_isMovingDown)
            {
                _move.Down();
                _isMovingDown = true;
            }
        }

        if (Input.GetAxisRaw("Horizontal") > 0)
        {
            if (!_isMovingRight)
            {
                _move.Right();
                _isMovingRight = true;
            }
        }

        if (Input.GetAxisRaw("Horizontal") < 0)
        {
            if (!_isMovingLeft)
            {
                _move.Left();
                _isMovingLeft = true;
            }
        }

        if (Input.GetAxisRaw("Vertical") == 0 && Input.GetAxisRaw("Horizontal") == 0)
        {
            if (_isMovingUp || _isMovingDown || _isMovingRight || _isMovingLeft)
            {
                _move.Stop();
                _isMovingUp = false;
                _isMovingDown = false;
                _isMovingRight = false;
                _isMovingLeft = false;
            }
        }
    }
}