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
            msgText.text = "�N���A!!";
        }
        else
        {
            msgText.text = "�Q�[���I�[�o�[";
        }

        // �e�L�X�g�̕\�������ւ���
        scoreText.text = "Score:" + GameManager.score;

    }

    //�o�^�����֐� OnClick�Ɠ���
    void RetryProsses()
    {
        GameManager.GetInstance().Init();
        GameManager.GetInstance().Work3Game();// Main�V�[���Ɉړ�
    }

    void GoTitle()
    {
        GameManager.GetInstance().Init();
        GameManager.GetInstance().Work3Title();
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
