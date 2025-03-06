using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerminalObject : InteractableObject
{
    public Canvas terminalUI;

    void Start()
    {
        terminalUI.gameObject.SetActive(false);
    }

    public override void Interact()
    {
        if (terminalUI.gameObject.activeInHierarchy)
        {
            terminalUI.gameObject.SetActive(false);
            foreach (CodeableObject o in FindObjectsOfType<CodeableObject>())
            {
                o.enabled = true;
            }

            FindObjectOfType<RPGMovement>().enabled = true;
        }
        else
        {
            terminalUI.gameObject.SetActive(true);
            foreach (CodeableObject o in FindObjectsOfType<CodeableObject>())
            {
                o.enabled = false;
            }

            FindObjectOfType<RPGMovement>().enabled = false;
        }
    }
}
