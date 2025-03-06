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
        if (PauseModeManager.Instance.pauseMode == PauseMode.Terminal)
        {
            PauseModeManager.Instance.SetPauseMode(PauseMode.Unpaused);
        }
        else if (PauseModeManager.Instance.pauseMode == PauseMode.Unpaused)
        {
            PauseModeManager.Instance.SetPauseMode(PauseMode.Terminal);
        }
    }
}
