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

    //“o˜^‚³‚ê‚éŠÖ” OnClick‚Æ“¯‚¶
    void ButtonProsses()
    {

    }

    // button‚ğ“o˜^‚·‚éŠÖ”
    void ButtonRegistration(Button _button)
    {
        //IsNotNull‚Ínull‚Å‚È‚¢–‚ğŠm”F‚·‚é(null‚Å‚ ‚ê‚ÎƒGƒ‰[‚ğo‚·)
        Assert.IsNotNull(_button, "_button‚Ínull‚Å‚·I");
        // button‚ÉButtonProsses‚ğOnClick‚Æ‚µ‚Ä“o˜^‚·‚éD
        button.onClick.AddListener(ButtonProsses);
    }
}
