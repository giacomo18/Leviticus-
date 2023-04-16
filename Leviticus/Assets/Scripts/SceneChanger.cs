using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;


public class SceneChanger : MonoBehaviour
{
    public void GoSettingsMenu()
    {
        SceneManager.LoadScene("Settings");
        Debug.Log("Scene Loading: Settings");
    }

    public void GoMainMenu()
    {
        SceneManager.LoadScene("Main Menu");
        Debug.Log("Scene Loading: Main Menu");
    }

    public void GoGameScene()
    {
        SceneManager.LoadScene("Game Scene");
        Debug.Log("Scene Loading: Game Scene");
    }

    public void ExitGame()
    {
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #endif
        Application.Quit();
        Debug.Log("Exiting Game");
    }
}
