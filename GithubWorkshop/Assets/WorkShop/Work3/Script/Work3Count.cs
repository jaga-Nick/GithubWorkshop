using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.UI;

public class Work3Count : MonoBehaviour
{
    public Button countButton;
    public Text scoreText;
    public Text timerText;

    [Header("制限時間")]
    public float timer;

    [Header("クリアライン")]
    public int clearScore;


    void Start()
    {
        if (countButton != null)
        {
            ButtonRegistration(countButton);
        }
    }

    void Update()
    {
        if (Input.GetKeyDown("q"))
        {
            GameManager.GetInstance().EndGame();
        }

        timer -= Time.deltaTime;
        // timerの表示の切り替え
        timerText.text = "Time : " + timer.ToString("F0");

        if(timer > 0)
        {
            // テキストの表示を入れ替える
            scoreText.text = "Score:" + GameManager.score;
        }
        else
        {
            if(GameManager.score >= clearScore)
            {
                Debug.Log("ゲームクリア");
                GameManager.isClear = true;
            }
            else
            {
                Debug.Log("ゲームオーバー");
            }
            GameManager.GetInstance().Work3Result();
        }

    }

    //登録される関数 OnClickと同じ
    void ButtonProsses()
    {
        if(timer > 0)
        {
            GameManager.score++;
            GameManager.GetInstance().PlaySound(0);
        }
    }



    // buttonを登録する関数
    void ButtonRegistration(Button _button)
    {
        //IsNotNullはnullでない事を確認する(nullであればエラーを出す)
        Assert.IsNotNull(_button, "_buttonはnullです！");
        // buttonにButtonProssesをOnClickとして登録する．
        _button.onClick.AddListener(ButtonProsses);
    }


}
