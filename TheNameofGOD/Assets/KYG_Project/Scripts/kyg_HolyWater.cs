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
        //오른쪽 컨트롤러를 기준으로 던지는 곳을 보여준다.
        //오른쪽 컨트롤러의 조이스틱으로 던지는 곳을 조절한다.
        // -> 라인렌더러를 이용하여 작성 (이건 해준다고 했음)
        //오른쪽 컨트롤러의 앞부분 버튼?을 누르면 발사한다.
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
