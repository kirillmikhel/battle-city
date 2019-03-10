using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public float speed = 50;

    private Rigidbody2D _rigidbody2D;
    private Animator _animator;

    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        
        Stop();
    }

    public void Up()
    {
        _rigidbody2D.velocity = speed * Vector2.up;
        AlignToGrid("X");
        TriggerAnimation("Up");
    }

    public void Down()
    {
        _rigidbody2D.velocity = speed * Vector2.down;
        AlignToGrid("X");
        TriggerAnimation("Down");
    }


    public void Right()
    {
        _rigidbody2D.velocity = speed * Vector2.right;
        AlignToGrid("Y");
        TriggerAnimation("Right");
    }

    public void Left()
    {
        _rigidbody2D.velocity = speed * Vector2.left;
        AlignToGrid("Y");
        TriggerAnimation("Left");
    }

    public void Stop()
    {
        _rigidbody2D.velocity = Vector2.zero;
        _animator.speed = 0;
    }

    private void TriggerAnimation(string direction)
    {
        _animator.speed = 1f;
        _animator.SetTrigger(direction);
    }

    private void AlignToGrid(string axis)
    {
        var position = new Vector2(_rigidbody2D.position.x, _rigidbody2D.position.y);

        if (axis == "X")
        {
            position.x = Mathf.Round(position.x / 16) * 16;
        }
        else
        {
            position.y = Mathf.Round(position.y / 16) * 16;
        }

        _rigidbody2D.position = position;
    }
}