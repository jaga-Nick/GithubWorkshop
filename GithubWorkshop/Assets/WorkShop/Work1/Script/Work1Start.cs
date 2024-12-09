using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Assertions;

public class Work1Start : MonoBehaviour
{
    public Button startButton;
    public Button quitButton;

    void Start()
    {
        if (startButton != null)
        {
            ButtonRegistration(startButton);
        }
        if (quitButton != null)
        {
            ButtonRegistration(quitButton);
        }
    }

    //登録される関数 OnClickと同じ
    void ButtonProsses()
    {
        GameManager.GetInstance().Work1Game();// Mainシーンに移動
    }

    void QuitGame()
    {
        GameManager.GetInstance().EndGame();
    }

    // buttonを登録する関数
    void ButtonRegistration(Button _button)
    {
        //IsNotNullはnullでない事を確認する(nullであればエラーを出す)
        Assert.IsNotNull(_button, "_buttonはnullです！");
        // buttonにButtonProssesをOnClickとして登録する．
        _button.onClick.AddListener(ButtonProsses);
    }

    void OnClick()
    {
        GameManager.GetInstance().Work1Game();// Mainシーンに移動
    }
}
