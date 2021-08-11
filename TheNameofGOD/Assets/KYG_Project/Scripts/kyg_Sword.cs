using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kyg_Sword : MonoBehaviour
{

    public static kyg_Sword instance;
    private void Awake()
    {
        instance = this;
    }
    public GameObject sparkFac;
    public Transform sparkPoint;
    public int swordDamage = 10;
    public bool upperAttack = false;
    public AudioSource sound;
    public AudioSource attackSound;

    Vector3 upperSwordPrev;
    float checkSwing;
    
    private void Update()
    {
        //int soundNum = Random.Range(0, sound.Length);
        Vector3 upperSword = OVRInput.GetLocalControllerPosition(OVRInput.Controller.RHand);
        Quaternion upperSwordRot = OVRInput.GetLocalControllerRotation(OVRInput.Controller.RHand);
        //print("position : " + upperSword); //y -0.6
        //print("Rotation : " + upperSwordRot); // z 0.2
        
        checkSwing = (upperSwordPrev.x - upperSword.x);
        if (Mathf.Abs(checkSwing) >= 0.06)
        {
            if (!sound.isPlaying) sound.Play();
        }
        upperSwordPrev = upperSword;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name.Contains("Enemy"))
        {
            GameObject spark = Instantiate(sparkFac);
            if (!attackSound.isPlaying) attackSound.Play();
            spark.SetActive(true);
            spark.transform.position = sparkPoint.position;
            spark.transform.forward = other.transform.forward;
            EnemyHP kygEnemy = other.gameObject.GetComponent<EnemyHP>();
            if (kygEnemy != null)
            {
                if (OVRInput.Get(OVRInput.Button.PrimaryIndexTrigger, OVRInput.Controller.RTouch))
                {
                    other.gameObject.GetComponent<EnemyHP>().jumpAttack = true;
                    print("Upper True");
                    //upperAttack = true;
                }
                kygEnemy.DoDamage(swordDamage);
            }
        }    
    }
}
