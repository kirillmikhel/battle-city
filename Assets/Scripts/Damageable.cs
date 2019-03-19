using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damageable : MonoBehaviour
{
    public int hitPoints = 1;

    public void GetDamage(int damage = 1)
    {
        hitPoints = Mathf.Max(0, hitPoints - damage);

        if (hitPoints == 0)
        {
            Destroy(gameObject);
        }
    }
}