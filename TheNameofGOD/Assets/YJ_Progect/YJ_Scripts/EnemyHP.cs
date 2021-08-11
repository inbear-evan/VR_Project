using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//사용자의 입력에 따라 앞뒤ㅣ좌우로 이동하고 싶다.
//사용자가 점프키를 누르면 점프를 뛰고 싶다.
public class EnemyHP : YJEnemyFSM
{
    public int currentEnemyHP = 50;
    int prevEnemyHP;

    internal void DoDamage(int damage)
    {
        if (m_State == EnemyState.Jumped)
        {
            //m_State = EnemyState.Jumped;
            if (prevEnemyHP != currentEnemyHP)
            {
                yVelocity = 0;
            }

        }
        if (currentEnemyHP <= 0)
        {
            m_State = EnemyState.Die;
        }
        else
        {
            currentEnemyHP -= damage;
            m_State = EnemyState.Hit;
        }
        prevEnemyHP = currentEnemyHP;
    }
}