using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.UI;

public class Count : MonoBehaviour
{
    public Button countButton;
    public Text scoreText;
    public Text timerText;

    [Header("��������")]
    public float timer;

    [Header("�X�R�ASE�Ԋu")]
    public int scoreSpan;

    [Header("�N���A���C��")]
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
        // timer�̕\���̐؂�ւ�
        timerText.text = "Time : " + timer.ToString("F0");

        if(timer > 0)
        {
            // �e�L�X�g�̕\�������ւ���
            scoreText.text = "Score:" + GameManager.score;
        }
        else
        {
            if(GameManager.score >= clearScore)
            {
                Debug.Log("�Q�[���N���A");
                GameManager.isClear = true;
            }
            else
            {
                Debug.Log("�Q�[���I�[�o�[");
            }
            GameManager.GetInstance().CustomResult();
        }

    }

    //�o�^�����֐� OnClick�Ɠ���
    void ButtonProsses()
    {
        if(timer > 0)
        {
            GameManager.score++;
            GameManager.GetInstance().PlaySound(0);

            if(GameManager.score != 0 && GameManager.score % scoreSpan == 0)
            {
                GameManager.GetInstance().PlaySound(1);
            }
        }
    }



    // button��o�^����֐�
    void ButtonRegistration(Button _button)
    {
        //IsNotNull��null�łȂ������m�F����(null�ł���΃G���[���o��)
        Assert.IsNotNull(_button, "_button��null�ł��I");
        // button��ButtonProsses��OnClick�Ƃ��ēo�^����D
        _button.onClick.AddListener(ButtonProsses);
    }


}