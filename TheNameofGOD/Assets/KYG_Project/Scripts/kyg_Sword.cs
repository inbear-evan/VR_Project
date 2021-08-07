using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kyg_Sword : MonoBehaviour
{
    public GameObject sparkFac;
    public Transform sparkPoint;
    public int swordDamage = 10;
    bool upperAttack = false;
    public AudioSource sound;
    public AudioSource attackSound;

    Vector3 upperSwordPrev;
    float checkSwing;

    int soundNumPrev;
    private void Update()
    {
        //int soundNum = Random.Range(0, sound.Length);
        Vector3 upperSword = OVRInput.GetLocalControllerPosition(OVRInput.Controller.RHand);
        Quaternion upperSwordRot = OVRInput.GetLocalControllerRotation(OVRInput.Controller.RHand);
        print("position : " + upperSword); //y -0.6
        print("Rotation : " + upperSwordRot); // z 0.2

        if(upperSword.y <= -0.6f && upperSwordRot.x <= -0.2f)
        //if (Input.GetKeyDown(KeyCode.K))
        {
            print("UPPER ChkChange");
            upperAttack = true;
        }
        checkSwing = (upperSwordPrev.x - upperSword.x);
        //soundNumPrev = soundNum;
        if (Mathf.Abs(checkSwing) >= 0.05)
        {
            //sound[soundNumPrev].Stop();
            //if(!sound[soundNum].isPlaying)
            //sound[soundNum].Play();

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
                if (upperAttack)
                {
                    print("UPPER Send");
                    kygEnemy.UpperState();
                    upperAttack = false;
                }

                kygEnemy.DoDamage(swordDamage);
            }
        }
        
    }
}
