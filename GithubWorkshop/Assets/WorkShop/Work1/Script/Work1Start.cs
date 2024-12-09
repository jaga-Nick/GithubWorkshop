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

    //�o�^�����֐� OnClick�Ɠ���
    void ButtonProsses()
    {
        GameManager.GetInstance().Work1Game();// Main�V�[���Ɉړ�
    }

    void QuitGame()
    {
        GameManager.GetInstance().EndGame();
    }

    // button��o�^����֐�
    void ButtonRegistration(Button _button)
    {
        //IsNotNull��null�łȂ������m�F����(null�ł���΃G���[���o��)
        Assert.IsNotNull(_button, "_button��null�ł��I");
        // button��ButtonProsses��OnClick�Ƃ��ēo�^����D
        _button.onClick.AddListener(ButtonProsses);
    }

    void OnClick()
    {
        GameManager.GetInstance().Work1Game();// Main�V�[���Ɉړ�
    }
}
