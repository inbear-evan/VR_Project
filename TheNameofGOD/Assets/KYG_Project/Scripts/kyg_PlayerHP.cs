using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class kyg_PlayerHP : MonoBehaviour
{
    public static kyg_PlayerHP instance;
    public int CurrentHp;
    public int maxHP = 100;    

    void Awake()
    {
        instance = this;
        CurrentHp = maxHP;
    }
  
    public int HP
    {
        get { return CurrentHp; }
        set
        {
            CurrentHp = value;
        }
    }
    private void Update()
    {
    }
}
