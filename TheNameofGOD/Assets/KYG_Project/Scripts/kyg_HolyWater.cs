using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kyg_HolyWater : MonoBehaviour
{
    public float force = 10;
    public GameObject holyWaterFac;
    public GameObject ThrownPosition;
    GameObject water;
    private void Start()
    {
        
    }
    private void Update()
    {
        //������ ��Ʈ�ѷ��� �������� ������ ���� �����ش�.
        //������ ��Ʈ�ѷ��� ���̽�ƽ���� ������ ���� �����Ѵ�.
        //������ ��Ʈ�ѷ��� �պκ� ��ư?�� ������ �߻��Ѵ�.
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        int layer = 1 << LayerMask.NameToLayer("Enemy");
        Collider[] colls = Physics.OverlapSphere(collision.contacts[0].point, 1.5f, layer);
        if (colls.Length > 0)
        {
            for (int i = 0; i < colls.Length; i++)
            {
                colls[i].gameObject.GetComponent<EnemyHP>().DoDamage(3);
            }
        }
    }
}
