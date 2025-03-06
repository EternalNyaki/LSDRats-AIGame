using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UITerminalController : MonoBehaviour
{
    public GameObject[] objectTerminals;
    public TMP_Dropdown objectDropdown;

    private int _activeTerminalIndex = 0;

    // Start is called before the first frame update
    void Start()
    {
        if (objectTerminals.Length <= 0)
        {
            Debug.LogWarning("Terminal Interface must have at least one associated object");
            Destroy(gameObject);
        }

        objectDropdown.ClearOptions();
        List<string> options = new List<string>();
        foreach (GameObject terminal in objectTerminals)
        {
            options.Add(terminal.name);
            terminal.SetActive(false);
        }
        objectDropdown.AddOptions(options);

        objectTerminals[_activeTerminalIndex].SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SetActiveTerminal(int value)
    {
        objectTerminals[_activeTerminalIndex].SetActive(false);
        _activeTerminalIndex = value;
        objectTerminals[_activeTerminalIndex].SetActive(true);
    }
}
