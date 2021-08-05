using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kyg_WeaponSwitching : MonoBehaviour
{
    //  public GameObject FakeHolyWater;
    public int selectedWeapon = 0;
    // Start is called before the first frame update
    void Start()
    {
        SelectedWeapon();
    }
    // Update is called once per frame
    void Update()
    {
        int previousSelectedWeapon = selectedWeapon;
        //if (Input.GetKeyDown(KeyCode.Alpha1))
        if(OVRInput.GetDown(OVRInput.Button.PrimaryThumbstick,OVRInput.Controller.RTouch))
        {
            //¸Ç¼Õ
            selectedWeapon = 0;
        }

        if (OVRInput.GetDown(OVRInput.Button.One, OVRInput.Controller.RTouch))
        {
            //°Ë
            selectedWeapon = 1;

        }
        if (OVRInput.GetDown(OVRInput.Button.Two,OVRInput.Controller.RTouch))
        {
            //ÃÑ
            selectedWeapon = 2;
        }

        if (previousSelectedWeapon != selectedWeapon)
        {
            SelectedWeapon();
        }
    }

    public void SelectedWeapon()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            //transform.GetChild(i).gameObject.SetActive(selectedWeapon == i);
            if (selectedWeapon == i)
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