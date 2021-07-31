using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kyg_HolyWater : MonoBehaviour
{
    public float force = 10;
    public GameObject holyWaterFac;
    public GameObject ThrownPosition;
    
    private void Update()
    {
        //������ ��Ʈ�ѷ��� �������� ������ ���� �����ش�.
        //������ ��Ʈ�ѷ��� ���̽�ƽ���� ������ ���� �����Ѵ�.
        // -> ���η������� �̿��Ͽ� �ۼ� (�̰� ���شٰ� ����)
        //������ ��Ʈ�ѷ��� �պκ� ��ư?�� ������ �߻��Ѵ�.
        if (Input.GetButtonDown("Fire1"))
        {
            throwHolyWater();
        }
    }
    void throwHolyWater()
    {
        GameObject water = Instantiate(holyWaterFac);
        water.transform.position = ThrownPosition.transform.position;
        water.transform.rotation = ThrownPosition.transform.rotation;
        water.GetComponent<Rigidbody>().velocity = ThrownPosition.transform.forward * force;
    }

    
}
