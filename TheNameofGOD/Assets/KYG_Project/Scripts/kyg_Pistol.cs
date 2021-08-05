using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 카메라위치에서 카메라앞방향으로 시선을 만들고
// 바라본곳에 총알자국을 남기고싶다.
// 적이 있다면 파괴하고싶다.
public class kyg_Pistol : MonoBehaviour
{
    // 카메라
    Camera cam;
    // 총알자국VFX
  //  public GameObject bulletImpact;
    ParticleSystem ps;
    public int gunDamage = 20;
    // Start is called before the first frame update
    void Start()
    {
  //      ps = bulletImpact.GetComponent<ParticleSystem>();
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        // 만약 마우스 왼쪽 버튼이 눌리면
        //if (Input.GetButtonDown("Fire1"))
        if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger, OVRInput.Controller.RTouch))
        {
            print("Tang");
            // 카메라위치에서 카메라앞방향으로 시선을 만들고
            Ray ray = new Ray(cam.transform.position, cam.transform.forward);
            // 만약 바라봤는데 닿은곳이 있다면
            RaycastHit hitInfo;
            int layer = 1 << LayerMask.NameToLayer("Player");
            if (Physics.Raycast(ray, out hitInfo, 100, ~layer))
            {
                print(hitInfo.transform.name);
                // 그곳에 총알자국을 남기고싶다.
  //              bulletImpact.transform.position = hitInfo.point;
                // 총알자국의Forward방향을 부딪힌곳의 Normal방향으로 하고싶다.
  //              bulletImpact.transform.forward = hitInfo.normal;
                // 총알자국연출을 재생하고싶다.
                //ps.Stop();
                //ps.Play();

                // 총알에 맞은 물체가 Enemy 게임오브젝트 라면 
                if (hitInfo.transform.gameObject.name.Contains("Enemy"))
                {
                    // Enemy게임오브젝트의 Enemy컴포넌트에게
                    EnemyHP enemy = hitInfo.transform.GetComponent<EnemyHP>();
                    if (enemy != null)
                    {
                        // Enemy컴포넌트에게 너 총에 맞았어라고 알려주고싶다.
                        enemy.DoDamage(gunDamage);
                    }
                    else
                    {
                        Debug.LogError("Enemy게임오브젝트에 Enemy컴포넌트가 없음!!! : " + hitInfo.transform.gameObject.name);
                    }
                }
            }
        }
    }
}