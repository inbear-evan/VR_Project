using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 카메라위치에서 카메라앞방향으로 시선을 만들고
// 바라본곳에 총알자국을 남기고싶다.
// 적이 있다면 파괴하고싶다.
public class kyg_LPistol : MonoBehaviour
{
    Camera cam;
    public int gunDamage = 20;
    public Transform gun;
    public Transform crossHair;
    public AudioSource FireSound;
    public GameObject BulletImpact;
    public GameObject BloodImpact;
    public GameObject muzzleEffect;
    Vector3 crosshairOriginSize;

    public float kAdjust = 1f;

    // Start is called before the first frame update
    void Start()
    {
        //      ps = bulletImpact.GetComponent<ParticleSystem>();
        cam = Camera.main;
        crosshairOriginSize = crossHair.localScale;
        muzzleEffect.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
         muzzleEffect.SetActive(false);
        Ray ray = new Ray(gun.position, gun.forward);
        RaycastHit hitInfo;
        if (Physics.Raycast(ray, out hitInfo))
        {
            crossHair.position = hitInfo.point;
            crossHair.localScale = (crosshairOriginSize * hitInfo.distance) * kAdjust;
            crossHair.forward = -hitInfo.normal;


            if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger, OVRInput.Controller.LTouch))
            {
                FireSound.Play();
                muzzleEffect.transform.forward = gun.forward;
                muzzleEffect.transform.position = gun.transform.position;
                muzzleEffect.SetActive(true);
                StartCoroutine(Haptics(1, 1, 0.1f, false, true));
                if (hitInfo.transform.gameObject.name.Contains("Enemy"))
                {
                    EnemyHP enemy = hitInfo.transform.GetComponent<EnemyHP>();
                    if (enemy != null)
                    {
                        enemy.DoDamage(gunDamage);
                    }
                    else
                    {
                        Debug.LogError("Enemy게임오브젝트에 Enemy컴포넌트가 없음!!! : " + hitInfo.transform.gameObject.name);
                    }


                    GameObject bloodEffect = Instantiate(BloodImpact);
                    bloodEffect.SetActive(true);
                    bloodEffect.transform.position = hitInfo.point;
                    bloodEffect.transform.forward = hitInfo.normal;
                }
                else
                {
                    print("OTHER");
                    GameObject bulletEffect = Instantiate(BulletImpact);
                    bulletEffect.SetActive(true);
                    bulletEffect.transform.position = hitInfo.point;
                    bulletEffect.transform.forward = hitInfo.normal;
                }
            }
        }
        else
        {
            crossHair.position = ray.origin + ray.direction * 100;
            crossHair.localScale = (crosshairOriginSize * 100) * kAdjust;
            crossHair.LookAt(gun.position);
        }
    }
    IEnumerator Haptics(float frequency, float amplitude, float duration, bool rightHand, bool leftHand)
    {
        if (rightHand) OVRInput.SetControllerVibration(frequency, amplitude, OVRInput.Controller.RTouch);
        if (leftHand) OVRInput.SetControllerVibration(frequency, amplitude, OVRInput.Controller.LTouch);

        yield return new WaitForSeconds(duration);

        if (rightHand) OVRInput.SetControllerVibration(0, 0, OVRInput.Controller.RTouch);
        if (leftHand) OVRInput.SetControllerVibration(0, 0, OVRInput.Controller.LTouch);
    }
}