using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    private const float Offset = 15f;

    public GameObject bulletPrefab;

    public int maxBullets = 1;
    public int bulletCount = 0;

    public float fireRatePerSecond = 1f;
    
    private float _lastShootingTime = 0f;
    
    public void Shoot()
    {
        if (bulletCount >= maxBullets) return;
        if (_lastShootingTime > Time.time - fireRatePerSecond) return;

        _lastShootingTime = Time.time;

        var direction = GetComponent<Move>().direction;
        var position = transform.position;

        var bullet = Instantiate(bulletPrefab,
            new Vector3(position.x + direction.x * Offset, position.y + direction.y * Offset, 0),
            Quaternion.identity);

        bullet.transform.parent = GameObject.Find("Bullets").transform;

        bullet.GetComponent<Bullet>().direction = direction;
        bullet.GetComponent<Bullet>().shooter = this;

        GetComponent<SoundController>().audioShoot.Play();

        bulletCount++;
    }

    public void DestroyBullet(GameObject bullet)
    {
        bulletCount--;

        GetComponent<SoundController>().audioHitSteel.Play();

        Destroy(bullet);
    }
}