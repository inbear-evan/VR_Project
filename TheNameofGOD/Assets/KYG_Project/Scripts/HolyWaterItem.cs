using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HolyWaterItem : MonoBehaviour
{
    public int holyWaterDamage = 50;

    private void OnCollisionEnter(Collision collision)
    {
        int layer = 1 << LayerMask.NameToLayer("Enemy");
        Collider[] colls = Physics.OverlapSphere(collision.contacts[0].point, 1.5f, layer);
        if (colls.Length > 0)
        {
            for (int i = 0; i < colls.Length; i++)
            {
                colls[i].gameObject.GetComponent<EnemyHP>().DoDamage(holyWaterDamage);
                Destroy(gameObject);
            }
        }
        Destroy(gameObject, 3);
    }
}
