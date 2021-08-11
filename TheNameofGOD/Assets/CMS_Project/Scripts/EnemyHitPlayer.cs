using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHitPlayer : MonoBehaviour
{
    EnemyHP enemyHit;
    Material mat;
    float dissolveValue = 0;
    public GameObject dieEffectFac;
    // Start is called before the first frame update
    void Start()
    {
        enemyHit = transform.parent.GetComponent<EnemyHP>();
        //mat = transform.GetChild(0).GetChild(0).GetComponent<Renderer>().material;
        //mat.SetFloat("_DissolveAmount", 0);
    }
    public void AttackPlayer()
    {
        print("ANiMation Attack !!!!!!!!!!!!!");
        enemyHit.Attack();
    }
    public void DieDissolve()
    {
        if (dissolveValue >= 1)
        {
            StopCoroutine("IEDissolve");
        }
        else if (dissolveValue == 0)
        {
            StartCoroutine("IEDissolve");
        }
    }
    public void DieAction()
    {
        GameObject effect = Instantiate(dieEffectFac);
        effect.transform.position = transform.position;
        Destroy(gameObject);
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator IEDissolve()
    {
        float time = 0.5f;
        yield return new WaitForSeconds(time);
        dissolveValue += time;
        //mat.SetFloat("_DissolveAmount", dissolveValue / 10);
    }
}
