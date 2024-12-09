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

        // テキストの表示を入れ替える
        scoreText.text = "Score:" + GameManager.score;
    }

    //登録される関数 OnClickと同じ
    void ButtonProsses()
    {
        GameManager.score++;
        GameManager.GetInstance().PlaySound(0);
    }



    // buttonを登録する関数
    void ButtonRegistration(Button _button)
    {
        //IsNotNullはnullでない事を確認する(nullであればエラーを出す)
        Assert.IsNotNull(_button, "_buttonはnullです！");
        // buttonにButtonProssesをOnClickとして登録する．
        _button.onClick.AddListener(ButtonProsses);
    }


}
