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
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            //맨손
            selectedWeapon = 0;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            //검
            selectedWeapon = 1;
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            //총
            selectedWeapon = 2;
        }
        if (Input.GetKey(KeyCode.Alpha4))
        {
            //성수
            selectedWeapon = 3;
        }

        if (previousSelectedWeapon != selectedWeapon)
        {
            SelectedWeapon();
        }
    }

    private void SelectedWeapon()
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