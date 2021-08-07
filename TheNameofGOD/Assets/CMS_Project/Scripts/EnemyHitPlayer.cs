using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHitPlayer : MonoBehaviour
{
    EnemyHP enemyHit;
    // Start is called before the first frame update
    void Start()
    {
        enemyHit = transform.parent.GetComponent<EnemyHP>();
    }
    public void AttackPlayer()
    {
        print("ANiMation Attack !!!!!!!!!!!!!");
        enemyHit.Attack();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
