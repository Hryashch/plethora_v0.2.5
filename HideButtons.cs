using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class HideButtons : MonoBehaviour
{

    [SerializeField] Canvas buttons;
    [SerializeField] Toggle chBox;
    static bool showButtons;

    void Start()
    {
        if(chBox!=null)
            chBox.isOn = showButtons;
        if(buttons != null)
        {
            if (showButtons)
            {
                buttons.enabled = true;
            }
            else
            {
                buttons.enabled = false;
            }
        }   
    }
    private void Update()
    {
        Debug.Log(showButtons);
    }

    public void CheckShow()
    {
        showButtons=chBox.isOn;
    }
}
