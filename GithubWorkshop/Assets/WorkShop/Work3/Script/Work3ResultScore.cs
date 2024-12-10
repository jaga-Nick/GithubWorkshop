using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.UI;

public class Work3ResultScore : MonoBehaviour
{
    public GameObject retryButton;
    public GameObject titleButton;

    public Text msgText;
    public Text scoreText;

    void Start()
    {
        if (retryButton != null)
        {
            ButtonRegistration(retryButton);
        }
        if (titleButton != null)
        {
            ButtonRegistration(titleButton);
        }

        if (GameManager.isClear)
        {
            msgText.text = "クリア!!";
        }
        else
        {
            msgText.text = "ゲームオーバー";
        }

        // テキストの表示を入れ替える
        scoreText.text = "Score:" + GameManager.score;

    }

    //登録される関数 OnClickと同じ
    void RetryProsses()
    {
        GameManager.GetInstance().Init();
        GameManager.GetInstance().Work3Game();// Mainシーンに移動
    }

    void GoTitle()
    {
        GameManager.GetInstance().Init();
        GameManager.GetInstance().Work3Title();
    }

    // buttonを登録する関数
    void ButtonRegistration(GameObject _buttonObj)
    {
        //IsNotNullはnullでない事を確認する(nullであればエラーを出す)
        Assert.IsNotNull(_buttonObj, "_buttonはnullです！");

        Button button = _buttonObj.GetComponent<Button>();

        if (_buttonObj.name == retryButton.name)
        {
            // buttonにButtonProssesをOnClickとして登録する．
            button.onClick.AddListener(RetryProsses);
        }
        else if (_buttonObj.name == titleButton.name)
        {
            // buttonにQuitGameをOnClickとして登録する．
            button.onClick.AddListener(GoTitle);
        }
    }
}
