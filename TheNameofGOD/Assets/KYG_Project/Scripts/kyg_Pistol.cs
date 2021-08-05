using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ī�޶���ġ���� ī�޶�չ������� �ü��� �����
// �ٶ󺻰��� �Ѿ��ڱ��� �����ʹ�.
// ���� �ִٸ� �ı��ϰ�ʹ�.
public class kyg_Pistol : MonoBehaviour
{
    // ī�޶�
    Camera cam;
    // �Ѿ��ڱ�VFX
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
        // ���� ���콺 ���� ��ư�� ������
        //if (Input.GetButtonDown("Fire1"))
        if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger, OVRInput.Controller.RTouch))
        {
            print("Tang");
            // ī�޶���ġ���� ī�޶�չ������� �ü��� �����
            Ray ray = new Ray(cam.transform.position, cam.transform.forward);
            // ���� �ٶ�ôµ� �������� �ִٸ�
            RaycastHit hitInfo;
            int layer = 1 << LayerMask.NameToLayer("Player");
            if (Physics.Raycast(ray, out hitInfo, 100, ~layer))
            {
                print(hitInfo.transform.name);
                // �װ��� �Ѿ��ڱ��� �����ʹ�.
  //              bulletImpact.transform.position = hitInfo.point;
                // �Ѿ��ڱ���Forward������ �ε������� Normal�������� �ϰ�ʹ�.
  //              bulletImpact.transform.forward = hitInfo.normal;
                // �Ѿ��ڱ������� ����ϰ�ʹ�.
                //ps.Stop();
                //ps.Play();

                // �Ѿ˿� ���� ��ü�� Enemy ���ӿ�����Ʈ ��� 
                if (hitInfo.transform.gameObject.name.Contains("Enemy"))
                {
                    // Enemy���ӿ�����Ʈ�� Enemy������Ʈ����
                    EnemyHP enemy = hitInfo.transform.GetComponent<EnemyHP>();
                    if (enemy != null)
                    {
                        // Enemy������Ʈ���� �� �ѿ� �¾Ҿ��� �˷��ְ�ʹ�.
                        enemy.DoDamage(gunDamage);
                    }
                    else
                    {
                        Debug.LogError("Enemy���ӿ�����Ʈ�� Enemy������Ʈ�� ����!!! : " + hitInfo.transform.gameObject.name);
                    }
                }
            }
        }
    }
}