using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HolyWaterItem : MonoBehaviour
{
    public int holyWaterDamage = 50;
    public float hotlWaterArea = 2f;

    private void OnCollisionStay(Collision collision)
    {
        int layer = 1 << LayerMask.NameToLayer("Enemy");
        Collider[] colls = Physics.OverlapSphere(collision.contacts[0].point, hotlWaterArea, layer);

        for (int i = 0; i < colls.Length; i++)
        {
            colls[i].gameObject.GetComponent<EnemyHP>().DoDamage(holyWaterDamage);
        }
        Destroy(gameObject);
        HolyWaterSound.instance.soundPlayCheck = true;
    }
}
