using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIButtonManager : MonoBehaviour
{

    public PlayerMovement playerScript;
    public GUIManager guiManager;

    public void LeftUp()
    {
        playerScript.inputLeft = false;
    }

    public void LeftDown()
    {
        playerScript.inputLeft = true;
    }

    public void RightUp()
    {
        playerScript.inputRight = false;
    }

    public void RightDown()
    {
        playerScript.inputRight = true;
    }

    public void UPButtonUp()
    {
        playerScript.inputUp = false;
    }

    public void UpButtonDown()
    {
        playerScript.inputUp = true;
    }

    public void DownButtonUp()
    {
        playerScript.inputDown = false;
    }

    public void DownButtonDown()
    {
        playerScript.inputDown = true;
    }
    
    public void ConButtonClick()
    {

        if (playerScript.onTrigger == true)
        {         
            guiManager.SendMessage("ChatOpen", null);
        }
        else
            return;

    }
    

}
