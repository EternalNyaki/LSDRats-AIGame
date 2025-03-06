using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Canvas terminalUI;

    // Start is called before the first frame update
    void Start()
    {
        terminalUI.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (terminalUI.gameObject.activeInHierarchy)
            {
                terminalUI.gameObject.SetActive(false);
                foreach (CodeableObject o in FindObjectsOfType<CodeableObject>())
                {
                    o.enabled = true;
                }
            }
            else
            {
                terminalUI.gameObject.SetActive(true);
                foreach (CodeableObject o in FindObjectsOfType<CodeableObject>())
                {
                    o.enabled = false;
                }
            }
        }
    }

    private void Die()
    {
        Debug.Log("Critical Error: Program File Does Not Exist. jk lol this functionality doesn't exist yet");
    }
}
