using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kyg_LWeaponSwitching : MonoBehaviour
{
    //  public GameObject FakeHolyWater;
    public Transform HMD;
    public int LselectedWeapon = 0;
    public GameObject holyWater;
    public GameObject holyWaterHand;
    public float force = 5;
    bool sheildState = false;
    GameObject grabObject;

    // Start is called before the first frame update
    void Start()
    {
        LSelectedWeapon();
    }
    // Update is called once per frame
    void Update()
    {
        int previousSelectedWeapon = LselectedWeapon;
        if (OVRInput.GetDown(OVRInput.Button.PrimaryThumbstick, OVRInput.Controller.LTouch))
        {
            //맨손
            LselectedWeapon = 0;
        }
        if (OVRInput.GetDown(OVRInput.Button.Two, OVRInput.Controller.LTouch))
        {
            //총
            LselectedWeapon = 1;
        }
        if (OVRInput.GetDown(OVRInput.Button.One, OVRInput.Controller.LTouch))
        {
            //성수
            //Grip예제로 변경
            LselectedWeapon = 2;
            float distance = Vector3.Distance(transform.position, HMD.position);
            if(distance <= 1)
            {
                GameObject bomb = Instantiate(holyWater);
                bomb.transform.parent = holyWaterHand.transform;
                bomb.transform.position = holyWaterHand.transform.position;
                bomb.GetComponent<Rigidbody>().useGravity = false;
                bomb.GetComponent<Rigidbody>().isKinematic = true;
                grabObject = bomb;
            }
        }
        else if (OVRInput.GetUp(OVRInput.Button.One, OVRInput.Controller.LTouch))
        {
            if (grabObject != null)
            {
                grabObject.transform.parent = null;

                Rigidbody grabRB = grabObject.GetComponent<Rigidbody>();
                grabRB.velocity = OVRInput.GetLocalControllerVelocity(OVRInput.Controller.LTouch) * force;
                grabRB.angularVelocity = OVRInput.GetLocalControllerAngularVelocity(OVRInput.Controller.LTouch);
                grabRB.useGravity = true;
                grabRB.isKinematic = false;

                grabObject = null;
            }
        }
        if (OVRInput.GetDown(OVRInput.Button.PrimaryHandTrigger, OVRInput.Controller.LTouch))
        {
            //방패
            //Vector3 LeftPoint = OVRInput.GetLocalControllerPosition(OVRInput.Controller.LHand);
            //print(LeftPoint);
            //if (LeftPoint.y <= -0.1f)
            {
                //if (!sheildState)
                {
                    sheildState = true;
                    LselectedWeapon = 3;
                }
                //else
                //{
                //    sheildState = false;
                //    LselectedWeapon = 0;
                //}
            }
        }

        if (previousSelectedWeapon != LselectedWeapon)
        {
            LSelectedWeapon();
        }
    }

    public void LSelectedWeapon()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            //transform.GetChild(i).gameObject.SetActive(selectedWeapon == i);
            if (LselectedWeapon == i)
            {
                transform.GetChild(i).gameObject.SetActive(true);
            }
            else
            {
                transform.GetChild(i).gameObject.SetActive(false);
            }
        }
    }


}