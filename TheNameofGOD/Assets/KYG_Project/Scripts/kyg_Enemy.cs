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

        // EnemyHP가 가진 HP를 감소하고싶다.
        enemyHP.HP -= damage;
        // 만약 HP가 0이하라면
        if (enemyHP.HP <= 0)
        {
            // 적이 죽는 상태
            Destroy(gameObject);
        }

    }
}
