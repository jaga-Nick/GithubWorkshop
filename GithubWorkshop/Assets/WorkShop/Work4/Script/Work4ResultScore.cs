using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.UI;

public class Work4ResultScore : MonoBehaviour
{
    public GameObject retryButton;
    public GameObject titleButton;

    public Text msgText;
    public Text scoreText;

    void Start()
    {
        GameManager.GetInstance().StopBGM();
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
            msgText.text = "�N���A!!";
            GameManager.GetInstance().PlaySound(2);
        }
        else
        {
            msgText.text = "�Q�[���I�[�o�[";
            GameManager.GetInstance().PlaySound(3);
        }

        // �e�L�X�g�̕\�������ւ���
        scoreText.text = "Score:" + GameManager.score;

    }

    //�o�^�����֐� OnClick�Ɠ���
    void RetryProsses()
    {
        GameManager.GetInstance().Init();
        GameManager.GetInstance().PlayBGM(0);
        GameManager.GetInstance().Work4Game();// Main�V�[���Ɉړ�
    }

    void GoTitle()
    {
        GameManager.GetInstance().Init();
        GameManager.GetInstance().PlayBGM(0);
        GameManager.GetInstance().Work4Title();
    }

    // button��o�^����֐�
    void ButtonRegistration(GameObject _buttonObj)
    {
        //IsNotNull��null�łȂ������m�F����(null�ł���΃G���[���o��)
        Assert.IsNotNull(_buttonObj, "_button��null�ł��I");

        Button button = _buttonObj.GetComponent<Button>();

        if (_buttonObj.name == retryButton.name)
        {
            // button��ButtonProsses��OnClick�Ƃ��ēo�^����D
            button.onClick.AddListener(RetryProsses);
        }
        else if (_buttonObj.name == titleButton.name)
        {
            // button��QuitGame��OnClick�Ƃ��ēo�^����D
            button.onClick.AddListener(GoTitle);
        }
    }
}
