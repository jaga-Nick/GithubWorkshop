using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Assertions;

public class Work3Start : MonoBehaviour
{
    public GameObject startButton;
    public GameObject quitButton;

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
        GameManager.GetInstance().Work3Game();// Mainシーンに移動
    }

    void QuitGame()
    {
        GameManager.GetInstance().EndGame();
    }

    // buttonを登録する関数
    void ButtonRegistration(GameObject _buttonObj)
    {
        //IsNotNullはnullでない事を確認する(nullであればエラーを出す)
        Assert.IsNotNull(_buttonObj, "_buttonはnullです！");

        Button button = _buttonObj.GetComponent<Button>();

        if (_buttonObj.name == startButton.name)
        {
            // buttonにButtonProssesをOnClickとして登録する．
            button.onClick.AddListener(ButtonProsses);
        }
        else if (_buttonObj.name == quitButton.name)
        {
            // buttonにQuitGameをOnClickとして登録する．
            button.onClick.AddListener(QuitGame);
        }
    }
}
