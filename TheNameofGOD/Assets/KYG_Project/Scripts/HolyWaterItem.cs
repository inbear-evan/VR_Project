using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HolyWaterItem : MonoBehaviour
{
    public int holyWaterDamage = 50;
    public float hotlWaterArea = 2f;
    public GameObject expfac;
    GameObject exp;
    private void Start()
    {
       
    }
    private void Update()
    {
        if (transform.position.y < -500) Destroy(gameObject);
    }
    private void OnCollisionStay(Collision collision)
    {
        exp = Instantiate(expfac);
        int layer = 1 << LayerMask.NameToLayer("Enemy");
        Collider[] colls = Physics.OverlapSphere(collision.contacts[0].point, hotlWaterArea, layer);

        for (int i = 0; i < colls.Length; i++)
        {
            colls[i].gameObject.GetComponent<EnemyHP>().DoDamage(holyWaterDamage);
        }
        HolyWaterSound.instance.soundPlayCheck = true;
        exp = Instantiate(expfac);
        exp.SetActive(true);
        exp.transform.position = transform.position;
        Destroy(gameObject);
      
    }
}
