using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kyg_Enemy : MonoBehaviour
{
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public kyg_EnemyHP enemyHP;
    internal void DoDamage(int damage)
    {
 //       agent.isStopped = true;
 //       GetComponent<Collider>().enabled = false;

        // EnemyHP�� ���� HP�� �����ϰ�ʹ�.
        enemyHP.HP -= damage;
        // ���� HP�� 0���϶��
        if (enemyHP.HP <= 0)
        {
            // ���� �״� ����
            Destroy(gameObject);
        }

    }
}
