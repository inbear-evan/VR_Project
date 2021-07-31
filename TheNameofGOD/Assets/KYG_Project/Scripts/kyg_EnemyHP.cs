using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// 태어날 때 현재체력을 최대체력으로 가득 채우고싶다.
// 체력이 변경될 때 UI도 함께 변경되게 하고싶다.
public class kyg_EnemyHP : MonoBehaviour
{
    int hp;
    public int maxHP = 10;

    public int HP
    {
        get { return hp; }
        set
        {
            hp = value;
            print("hp : " + hp);
        }
    }
    void Start()
    {
        // 체력을 최대체력으로 초기화 하고싶다.
        HP = maxHP;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
