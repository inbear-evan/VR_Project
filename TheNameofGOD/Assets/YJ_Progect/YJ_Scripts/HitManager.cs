using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 태어날 때 Image Hit를 끄고 싶다.
// 적이 플레이어를 공격했을 때 Image Hit를 번쩍 거리게 하고싶다.(켰다 끄고싶다.)
public class HitManager : MonoBehaviour
{
    // 싱글톤으로 만들고싶다.
    public static HitManager instance;
    private void Awake()
    {
        instance = this;
    }

    internal void Hit(int damage)
    {
        //플레이어게 데미지를 준다.
        throw new NotImplementedException();
    }
}
