using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Assertions;

public class Work4Start : MonoBehaviour
{
    [Header("�e��{�^��")]
    public GameObject startButton;
    public GameObject quitButton;
    public GameObject settingButton;
    public GameObject backButton;

    [Header("�z�[���Ɛݒ���")]
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

    //�o�^�����֐� OnClick�Ɠ���
    void ButtonProsses()
    {
        GameManager.GetInstance().Work4Game();// Main�V�[���Ɉړ�
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

    // button��o�^����֐�
    void ButtonRegistration(GameObject _buttonObj)
    {
        //IsNotNull��null�łȂ������m�F����(null�ł���΃G���[���o��)
        Assert.IsNotNull(_buttonObj, "_button��null�ł��I");

        Button button = _buttonObj.GetComponent<Button>();

        if (_buttonObj.name == startButton.name)
        {
            // button��ButtonProsses��OnClick�Ƃ��ēo�^����D
            button.onClick.AddListener(ButtonProsses);
        }
        else if (_buttonObj.name == quitButton.name)
        {
            // button��QuitGame��OnClick�Ƃ��ēo�^����D
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
