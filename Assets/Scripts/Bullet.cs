﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public GameObject explosionPrefab;

    public Sprite[] sprites;
    public float speed;
    public Vector2 direction;
    public Shooting shooter;

    public void Start()
    {
        GetComponent<Rigidbody2D>().velocity = direction * speed;

        if (direction == Vector2.up)
            GetComponent<SpriteRenderer>().sprite = sprites[0];
        if (direction == Vector2.right)
            GetComponent<SpriteRenderer>().sprite = sprites[1];
        if (direction == Vector2.down)
            GetComponent<SpriteRenderer>().sprite = sprites[2];
        if (direction == Vector2.left)
            GetComponent<SpriteRenderer>().sprite = sprites[3];
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.GetComponent<Shooting>() == shooter) return;

        var damageable = other.gameObject.GetComponent<Damageable>();

        if (damageable != null)
        {
            damageable.GetDamage();
        }
        else if (explosionPrefab)
        {
            var explosion = Instantiate(explosionPrefab, new Vector3(transform.position.x, transform.position.y, -1.0f),
                Quaternion.identity);

            explosion.transform.parent = GameObject.Find("Explosions").transform;
        }

        shooter.DestroyBullet(gameObject);
    }
}