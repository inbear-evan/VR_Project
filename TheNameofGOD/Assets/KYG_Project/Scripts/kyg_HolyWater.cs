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
        //오른쪽 컨트롤러를 기준으로 던지는 곳을 보여준다.
        //오른쪽 컨트롤러의 조이스틱으로 던지는 곳을 조절한다.
        //오른쪽 컨트롤러의 앞부분 버튼?을 누르면 발사한다.
        
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
