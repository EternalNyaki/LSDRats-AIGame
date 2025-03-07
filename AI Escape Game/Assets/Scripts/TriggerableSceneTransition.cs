using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TriggerableSceneTransition : MonoBehaviour
{
    public void SetScene(int buildIndex)
    {
        SceneManager.LoadScene(buildIndex);
    }
}
