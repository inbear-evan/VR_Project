using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// �¾ �� ����ü���� �ִ�ü������ ���� ä���ʹ�.
// ü���� ����� �� UI�� �Բ� ����ǰ� �ϰ�ʹ�.
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
        // ü���� �ִ�ü������ �ʱ�ȭ �ϰ�ʹ�.
        HP = maxHP;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
