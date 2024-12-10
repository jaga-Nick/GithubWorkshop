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

    //“o˜^‚³‚ê‚éŠÖ” OnClick‚Æ“¯‚¶
    void ButtonProsses()
    {
        GameManager.GetInstance().Work1Game();// MainƒV[ƒ“‚ÉˆÚ“®
    }

    void QuitGame()
    {
        GameManager.GetInstance().EndGame();
    }

    // button‚ğ“o˜^‚·‚éŠÖ”
    void ButtonRegistration(GameObject _buttonObj)
    {
        //IsNotNull‚Ínull‚Å‚È‚¢–‚ğŠm”F‚·‚é(null‚Å‚ ‚ê‚ÎƒGƒ‰[‚ğo‚·)
        Assert.IsNotNull(_buttonObj, "_button‚Ínull‚Å‚·I");

        Button button = _buttonObj.GetComponent<Button>();

        if(_buttonObj.name == startButton.name)
        {
            // button‚ÉButtonProsses‚ğOnClick‚Æ‚µ‚Ä“o˜^‚·‚éD
            button.onClick.AddListener(ButtonProsses);
        }else if(_buttonObj.name == quitButton.name)
        {
            // button‚ÉQuitGame‚ğOnClick‚Æ‚µ‚Ä“o˜^‚·‚éD
            button.onClick.AddListener(QuitGame);
        }
    }


}
