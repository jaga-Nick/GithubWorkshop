using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Assertions;

public class Work4Start : MonoBehaviour
{
    [Header("各種ボタン")]
    public GameObject startButton;
    public GameObject quitButton;
    public GameObject settingButton;
    public GameObject backButton;

    [Header("ホームと設定画面")]
    public GameObject titleHome;
    public GameObject titleSetting;

    public static bool isHome;

    void Start()
    {
        isHome = false;
        GameSetting();

        if (startButton != null)
        {
            ButtonRegistration(startButton);
        }
        if (quitButton != null)
        {
            ButtonRegistration(quitButton);
        }
        if(settingButton != null)
        {
            ButtonRegistration(settingButton);
        }
        if(backButton != null)
        {
            ButtonRegistration(backButton);
        }
    }

    private void Update()
    {
        Debug.Log(isHome);
    }

    //登録される関数 OnClickと同じ
    void ButtonProsses()
    {
        GameManager.GetInstance().Work4Game();// Mainシーンに移動
    }

    void QuitGame()
    {
        GameManager.GetInstance().EndGame();
    }

    void GameSetting()
    {
        titleHome.SetActive(!isHome);
        titleSetting.SetActive(isHome);
        isHome = !isHome;
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
        else if(_buttonObj.name == settingButton.name)
        {
            button.onClick.AddListener(GameSetting);
        }
        else if(_buttonObj.name == backButton.name)
        {
            button.onClick.AddListener(GameSetting);
        }
    }
}
