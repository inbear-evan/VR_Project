using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kyg_Sword : MonoBehaviour
{
    public int swordDamage = 10;
    bool upperAttack = false;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {

            upperAttack = true;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name.Contains("Enemy"))
        {
            EnemyHP kygEnemy = other.gameObject.GetComponent<EnemyHP>();
            if (kygEnemy != null)
            {
                if (upperAttack)
                {
                    kygEnemy.UpperState();
                    upperAttack = false;
                }
                kygEnemy.DoDamage(swordDamage);
            }
        }
    }
}
