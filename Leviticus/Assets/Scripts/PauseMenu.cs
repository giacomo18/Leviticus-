using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public playerManager playerManager;
    public HUDManager HUDManager;
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
                Zelophehad.GetComponent<SpriteRenderer>().enabled = true;
                Skeleton.GetComponent<SpriteRenderer>().enabled = true;


            }
            else
            {
                PauseGame();
                Zelophehad.GetComponent<SpriteRenderer>().enabled = false;
                Skeleton.GetComponent<SpriteRenderer>().enabled = false;

            }
        }
    }

    public void PauseGame()
    {
        pauseMenu.SetActive(true);
        SettingsPanel.SetActive(false);
        Time.timeScale = 0f;
        isPaused = true;
        playerManager.Action1.interactable = false;
        playerManager.Action2.interactable = false;
        playerManager.Action3.interactable = false;

    }

    public void ResumeGame()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
        SettingsPanel.SetActive(false);
        Zelophehad.GetComponent<SpriteRenderer>().enabled = true;
        Skeleton.GetComponent<SpriteRenderer>().enabled = true;
        playerManager.Action1.interactable = true;
        playerManager.Action2.interactable = true;
        playerManager.Action3.interactable = true;
        playerManager.UpdateUI();
        HUDManager.UpdateUI();

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
