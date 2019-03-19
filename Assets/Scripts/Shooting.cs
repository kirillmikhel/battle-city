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

    private SoundController _soundController;

    public void Awake()
    {
        _soundController = GetComponent<SoundController>();
    }

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

        if (_soundController != null)
            _soundController.audioShoot.Play();

        bulletCount++;
    }

    public void DestroyBullet(GameObject bullet)
    {
        bulletCount--;

        if (_soundController != null)
            _soundController.audioHitSteel.Play();

        Destroy(bullet);
    }
}