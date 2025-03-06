using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PauseMode
{
    Unpaused,
    Dialogue,
    Terminal
}

public class PauseModeManager : Singleton<PauseModeManager>
{
    public PauseMode pauseMode;

    public Canvas terminalCanvas;
    public Canvas dialogueCanvas;
    public RPGMovement playerMovement;

    protected override void Initialize()
    {
        base.Initialize();

        SetPauseMode(pauseMode);
    }

    public void SetPauseMode(PauseMode mode)
    {
        switch (mode)
        {
            case PauseMode.Unpaused:

                terminalCanvas.gameObject.SetActive(false);
                dialogueCanvas.gameObject.SetActive(false);
                foreach (CodeableObject o in FindObjectsOfType<CodeableObject>())
                {
                    o.enabled = true;
                }

                playerMovement.enabled = true;


                break;

            case PauseMode.Dialogue:
                dialogueCanvas.gameObject.SetActive(true);
                playerMovement.enabled = false;
                break;

            case PauseMode.Terminal:
                terminalCanvas.gameObject.SetActive(true);
                foreach (CodeableObject o in FindObjectsOfType<CodeableObject>())
                {
                    o.enabled = false;
                }

                playerMovement.enabled = false;
                break;
        }
    }
}
