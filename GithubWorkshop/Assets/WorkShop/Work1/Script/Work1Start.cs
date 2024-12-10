using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Assertions;

public class Work1Start : MonoBehaviour
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
    void ButtonRegistration(GameObject _buttonObj)
    {
        //IsNotNull��null�łȂ������m�F����(null�ł���΃G���[���o��)
        Assert.IsNotNull(_buttonObj, "_button��null�ł��I");

        Button button = _buttonObj.GetComponent<Button>();

        if(_buttonObj.name == startButton.name)
        {
            // button��ButtonProsses��OnClick�Ƃ��ēo�^����D
            button.onClick.AddListener(ButtonProsses);
        }else if(_buttonObj.name == quitButton.name)
        {
            // button��QuitGame��OnClick�Ƃ��ēo�^����D
            button.onClick.AddListener(QuitGame);
        }
    }


}
