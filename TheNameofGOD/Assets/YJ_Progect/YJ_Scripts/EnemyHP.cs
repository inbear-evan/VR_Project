using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//사용자의 입력에 따라 앞뒤ㅣ좌우로 이동하고 싶다.
//사용자가 점프키를 누르면 점프를 뛰고 싶다.
public class EnemyHP : YJEnemyFSM
{
    public int currentEnemyHP = 50;
    internal void DoDamage(int damage)
    {
        currentEnemyHP -= damage;
        Debug.Log("Enemy HP : " + currentEnemyHP);
        // 만약 HP가 0이하라면
        if (currentEnemyHP <= 0)
        {
            // 적이 죽는 상태
            m_State = EnemyState.Die;
            Destroy(gameObject);
        }

    }
}