using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.UI;

public class Work1Count : MonoBehaviour
{
    public Button countButton;
    public Text scoreText;
    

    void Start()
    {
        if (countButton != null)
        {
            ButtonRegistration(countButton);
        }

        GameManager.score = 0;

    }

    void Update()
    {
        if (Input.GetKeyDown("q"))
        {
            GameManager.GetInstance().EndGame();
        }

        // �e�L�X�g�̕\�������ւ���
        scoreText.text = "Score:" + GameManager.score;
    }

    //�o�^�����֐� OnClick�Ɠ���
    void ButtonProsses()
    {
        GameManager.score++;
        GameManager.GetInstance().PlaySound(0);
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
