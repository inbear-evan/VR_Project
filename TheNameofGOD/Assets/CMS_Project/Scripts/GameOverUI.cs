using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// HP가 0이 되면 화면 회색빛?으로 하고
// 천천히 까만색으로 바꾸고 싶다.
// 그 후 Text(ex GameOver)를 띄우고 싶다.
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
        //추후에 캐릭터의 HP를 직접 받아도 될것 같음
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
