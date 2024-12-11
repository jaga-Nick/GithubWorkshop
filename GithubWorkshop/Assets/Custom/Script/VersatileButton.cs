using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.UI;

public class VersatileButton : MonoBehaviour
{
    public Button button;

    void Start()
    {
        //
        ButtonRegistration(button);

    }

    //�o�^�����֐� OnClick�Ɠ���
    void ButtonProsses()
    {

    }

    // button��o�^����֐�
    void ButtonRegistration(Button _button)
    {
        //IsNotNull��null�łȂ������m�F����(null�ł���΃G���[���o��)
        Assert.IsNotNull(_button, "_button��null�ł��I");
        // button��ButtonProsses��OnClick�Ƃ��ēo�^����D
        button.onClick.AddListener(ButtonProsses);
    }
}
