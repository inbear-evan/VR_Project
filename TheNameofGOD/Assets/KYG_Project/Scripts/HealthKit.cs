using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthKit : MonoBehaviour
{
    public int healValue = 1;
    private void OnTriggerEnter(Collider other)
    {
        if (other.name.Contains("Player"))
        {
            kyg_PlayerHP.instance.CurrentHp = kyg_PlayerHP.instance.CurrentHp + healValue;
            HpImageUI.instance.OnHealing(healValue);
            Destroy(this.gameObject);
        }
    }
}
