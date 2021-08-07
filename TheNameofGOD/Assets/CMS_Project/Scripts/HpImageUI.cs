using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// 맞았을 때, 깜빡한다.
// 오른쪽 부터 순서대로 HP가 줄어든다.

public class HpImageUI : MonoBehaviour
{
    public static HpImageUI instance;
    private void Awake()
    {
        instance = this;
    }
    public GameObject damageUI;
    public GameObject healingUI;
    /// <summary>
    /// 오른쪽 부터 순서대로
    /// </summary>
    public Slider[] HpUI;
    public float toggleTime = 0.2f;
    public int MaxHpValue = 1;
    public int totalHp = 0;
    public int damageValue = 10;
    public int healValue = 5;
    public bool playerDamage = true;
    // Start is called before the first frame update
    void Start()
    {
        MaxHpValue = kyg_PlayerHP.instance.CurrentHp / 4;
        for (int i = 0; i < HpUI.Length; i++)
        {
            HpUI[i].maxValue = MaxHpValue;
            HpUI[i].gameObject.SetActive(false);
            totalHp += MaxHpValue;
        }
        damageUI.SetActive(true);
        healingUI.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetKeyDown(KeyCode.K))
        //{
        //    OnDamaged(damageValue);
        //}
        //if (Input.GetKeyDown(KeyCode.L))
        //{
        //    OnHealing(healValue);
        //}
    }
    public void OnHealing(int heal)
    {
        StopCoroutine("IEHealing");
        StartCoroutine("IEHealing", toggleTime);
        totalHp += heal;
        kyg_PlayerHP.instance.CurrentHp = totalHp;
        int totalHpBuf = totalHp;
        for (int i = HpUI.Length - 1; i >= 0; i--)
        {
            if (totalHpBuf >= MaxHpValue)
            {
                HpUI[i].value = MaxHpValue;
            }
            else if (totalHpBuf > MaxHpValue)
            {
                HpUI[i].value = MaxHpValue;
            }
            else
            {
                HpUI[i].value = totalHpBuf;
            }
            totalHpBuf -= MaxHpValue;
        }
        if (totalHp >= MaxHpValue * HpUI.Length)
        {
            totalHp = MaxHpValue * HpUI.Length;
        }
    }

    //Q_Vignette_Split
    //skyScale, mainScale;
    public void OnDamaged(int damage)
    {
        //HP를 줄인다.
        //Player HP상태 가져옴
        float sliderCnt = 1;
        StopCoroutine("IEDamage");
        StartCoroutine("IEDamage", toggleTime);
        totalHp -= damage;
        kyg_PlayerHP.instance.CurrentHp = totalHp;

        Debug.Log("Damage");
        if (!playerDamage)
        {
            return;
        }
        if (totalHp <= 0)
        {
            playerDamage = false;
            
        }
        int totalHpBuf = totalHp;
        for (int i = HpUI.Length - 1; i >= 0; i--)
        {
            if (totalHpBuf >= MaxHpValue)
            {
                HpUI[i].value = MaxHpValue;
            }
            else if (totalHpBuf <= 0)
            {
                HpUI[i].value = 0;
                sliderCnt+=1.5f;
            }
            else
            {
                HpUI[i].value = totalHpBuf;
            }
            totalHpBuf -= MaxHpValue;
        }
        damageUI.GetComponent<Q_Vignette_Split>().skyScale = sliderCnt;
        damageUI.GetComponent<Q_Vignette_Split>().mainScale = sliderCnt;
    }

    IEnumerator IEDamage(float time)
    {
        for (int i = 0; i < HpUI.Length; i++)
        {
            HpUI[i].gameObject.SetActive(true);
        }
        damageUI.SetActive(true);
        yield return new WaitForSeconds(time);
        damageUI.SetActive(false);
        for (int i = 0; i < HpUI.Length; i++)
        {
            HpUI[i].gameObject.SetActive(false);
        }
    }

    IEnumerator IEHealing(float time)
    {
        for (int i = 0; i < HpUI.Length; i++)
        {
            HpUI[i].gameObject.SetActive(true);
        }
        healingUI.SetActive(true);
        yield return new WaitForSeconds(time);
        healingUI.SetActive(false);
        for (int i = 0; i < HpUI.Length; i++)
        {
            HpUI[i].gameObject.SetActive(false);
        }
    }
}
