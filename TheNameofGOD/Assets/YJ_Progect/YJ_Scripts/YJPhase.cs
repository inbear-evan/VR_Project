using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YJPhase : MonoBehaviour
{
    public Transform[] spawnPoint;
    public GameObject[] monsterFactory;
    public int maxMonsterNums = 3;
    public int currentMonsterNums = 0;
    public float monsterSpwanTime = 1;
    public bool passCheck = false;
    bool once = false;
    int spawnNums;
    // Start is called before the first frame update
    void Start()
    {
        spawnNums = spawnPoint.Length;
    }
    // Update is called once per frame
    void Update()
    {
        if (passCheck && once)
        {
            once = false;
            StartCoroutine("IEspwanTime", monsterSpwanTime);
        }

        if(currentMonsterNums >= maxMonsterNums)
        {
            StopCoroutine("IEspwanTime");
            GetComponent<BoxCollider>().gameObject.SetActive(false);
        }
    }
    IEnumerator IEspwanTime(float time)
    {
        yield return new WaitForSeconds(1);
        while (true)
        {
            yield return new WaitForSeconds(time);
            currentMonsterNums++;
            int index = Random.Range(0, monsterFactory.Length);
            int index2 = Random.Range(0, spawnNums);
            GameObject enemy = Instantiate(monsterFactory[index]);
            enemy.transform.position = spawnPoint[index2].position;
        }
    }

    private void OnTriggerEnter(Collider other)
    { 
        if (other.gameObject.name.Contains("Player"))
        {
            passCheck = true;
            once = true;
        }
    }
}
