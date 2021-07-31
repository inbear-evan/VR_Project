using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// HP�� 0�� �Ǹ� ȭ�� ȸ����?���� �ϰ�
// õõ�� ������� �ٲٰ� �ʹ�.
// �� �� Text(ex GameOver)�� ���� �ʹ�.
public class GameOverUI : MonoBehaviour
{
    public GameObject gameOverImage;
    bool dieChk = false;
    private void Awake()
    {
        GetComponent<OldCinemaEffect>().enabled = false;
        gameOverImage.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {
        //���Ŀ� ĳ������ HP�� ���� �޾Ƶ� �ɰ� ����
        if(HpImageUI.instance.totalHp < 0)
        {
            GetComponent<OldCinemaEffect>().enabled = true;
            Time.timeScale = 0.5f;
            Vector3 zeroAngle = Vector3.Lerp(transform.rotation.eulerAngles, new Vector3(0,0,0), Time.deltaTime);
            transform.eulerAngles -= new Vector3(Time.deltaTime * 15, 0, 0);
            //Debug.Log(transform.eulerAngles.x);
            
            if (transform.eulerAngles.x <= 350)
            {
                gameOverImage.SetActive(true);
                if (gameOverImage.transform.GetChild(0).localScale.x >= 10)
                {
                    //Restart -> PlayMap
                    //Exit -> StartMap
                    Time.timeScale = 0;
                }
                else
                {
                    gameOverImage.transform.GetChild(0).localScale += new Vector3(0.03f, 0.03f, 0);
                }

            }
        }   
    }
}
