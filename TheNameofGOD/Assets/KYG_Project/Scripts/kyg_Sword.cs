using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kyg_Sword : MonoBehaviour
{
    public int swordDamage = 10;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name.Contains("Enemy"))
        {
            EnemyHP kygEnemy = other.gameObject.GetComponent<EnemyHP>();
            print("Eneny Sw");

            if (kygEnemy != null)
            {
                kygEnemy.DoDamage(swordDamage);
            }
        }
    }
}
