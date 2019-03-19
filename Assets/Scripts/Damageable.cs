using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damageable : MonoBehaviour
{
    public GameObject explosionPrefab;

    public int hitPoints = 1;

    public void GetDamage(int damage = 1)
    {
        hitPoints = Mathf.Max(0, hitPoints - damage);

        if (hitPoints > 0) return;

        
        if (explosionPrefab)
        {
            var explosion = Instantiate(explosionPrefab, new Vector3(transform.position.x, transform.position.y, -1.0f),
                Quaternion.identity);

            explosion.transform.parent = GameObject.Find("Explosions").transform;
        }
        
        Destroy(gameObject);
    }
}