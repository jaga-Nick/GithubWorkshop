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

    //登録される関数 OnClickと同じ
    void ButtonProsses()
    {

    }

    // buttonを登録する関数
    void ButtonRegistration(Button _button)
    {
        //IsNotNullはnullでない事を確認する(nullであればエラーを出す)
        Assert.IsNotNull(_button, "_buttonはnullです！");
        // buttonにButtonProssesをOnClickとして登録する．
        button.onClick.AddListener(ButtonProsses);
    }
}
