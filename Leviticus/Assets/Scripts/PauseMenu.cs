using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenu;
    public static bool isPaused;
    public GameObject SettingsPanel;
    public GameObject Zelophehad;
    public GameObject Skeleton;


    // Start is called before the first frame update
    void Start()
    {
        pauseMenu.SetActive(false);
        SettingsPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                ResumeGame();
                Debug.Log("LMAO");
                Zelophehad.GetComponent<SpriteRenderer>().enabled = true;
                Skeleton.GetComponent<SpriteRenderer>().enabled = true;


            }
            else
            {
                PauseGame();
                Debug.Log("Fuck");
                Zelophehad.GetComponent<SpriteRenderer>().enabled = false;
                Skeleton.GetComponent<SpriteRenderer>().enabled = false;

            }
        }
    }

    public void PauseGame()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
    }

    public void ResumeGame()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
        SettingsPanel.SetActive(false);
    }
    public void Settings()
    {
        Time.timeScale = 0f;
        SettingsPanel.SetActive(true);
        isPaused = true;

    }
    public void MainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Main Menu");
    }
}
