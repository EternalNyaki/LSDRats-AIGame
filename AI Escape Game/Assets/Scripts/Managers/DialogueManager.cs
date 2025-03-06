using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ink.Runtime;
using TMPro;

public class DialogueManager : Singleton<DialogueManager>
{
    public TextAsset inkAsset;
    public TMP_Text mainText;

    private Story story;

    private int _selectedChoice = 0;
    private bool _inDialogueChoices = false;

    protected override void Initialize()
    {
        base.Initialize();

        story = new Story(inkAsset.text);
        mainText.text = story.Continue();
    }

    // Update is called once per frame
    void Update()
    {
        if (story.canContinue)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                mainText.text = story.Continue();
            }
        }
        else if (story.currentChoices.Count > 0)
        {
            if (_inDialogueChoices)
            {
                if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
                {
                    _selectedChoice--;
                    _selectedChoice = Mathf.Clamp(_selectedChoice, 0, story.currentChoices.Count - 1);
                }
                if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
                {
                    _selectedChoice++;
                    _selectedChoice = Mathf.Clamp(_selectedChoice, 0, story.currentChoices.Count - 1);
                }

                mainText.text = "";
                for (int i = 0; i < story.currentChoices.Count; i++)
                {
                    if (i == _selectedChoice)
                    {
                        mainText.text += "> ";
                    }
                    mainText.text += story.currentChoices[i].text + "\n";
                }

                if (Input.GetKeyDown(KeyCode.Space))
                {
                    story.ChooseChoiceIndex(_selectedChoice);
                    mainText.text = story.Continue();
                    _inDialogueChoices = false;
                }
            }
            else
            {
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    mainText.text = "";
                    for (int i = 0; i < story.currentChoices.Count; i++)
                    {
                        if (i == _selectedChoice)
                        {
                            mainText.text += "> ";
                        }
                        mainText.text += story.currentChoices[i].text + "\n";
                    }

                    _inDialogueChoices = true;
                    _selectedChoice = 0;
                }
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                PauseModeManager.Instance.SetPauseMode(PauseMode.Unpaused);
                story.ResetState();
            }
        }
    }
}
