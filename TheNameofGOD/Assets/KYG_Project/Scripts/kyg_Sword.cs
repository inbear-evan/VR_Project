using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kyg_Sword : MonoBehaviour
{
    public int swordDamage = 10;
    bool upperAttack = false;

    private void Update()
    {

        Vector3 upperSword = OVRInput.GetLocalControllerPosition(OVRInput.Controller.RHand);
        Quaternion upperSwordRot = OVRInput.GetLocalControllerRotation(OVRInput.Controller.RHand);
        print("position : " + upperSword); //y -0.6
        print("Rotation : " + upperSwordRot); // z 0.2

        if(upperSword.y <= -0.8f && upperSwordRot.z <= -0.8f)
        //if (Input.GetKeyDown(KeyCode.K))
        {
            upperAttack = true;
        }

/*        if (OVRInput.GetDown(OVRInput.Button.One,OVRInput.Controller.RTouch))
        {
        
        }*/
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name.Contains("Enemy"))
        {
            EnemyHP kygEnemy = other.gameObject.GetComponent<EnemyHP>();
            if (kygEnemy != null)
            {
                if (upperAttack)
                {
                    kygEnemy.UpperState();
                    upperAttack = false;
                }
                kygEnemy.DoDamage(swordDamage);
            }
        }
    }
}
