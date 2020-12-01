using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionButton : MonoBehaviour
{
    public CheckoutMinigame checkoutMinigame;
    // Start is called before the first frame update

    private void OnMouseDown()
    {
        checkoutMinigame.NextDialogue();
    }
}
