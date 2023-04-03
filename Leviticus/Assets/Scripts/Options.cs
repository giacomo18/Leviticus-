using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Options : MonoBehaviour
{
    public GameObject videoOptions;
    public GameObject audioOptions;
    public GameObject uiOptions;
    public Button videoButton;
    public Button audioButton;
    public Button uiButton;


    // Start is called before the first frame update
    void Start()
    {
        OptionsVideo();
    }

    public void OptionsVideo()
    {
        videoOptions.SetActive(true);
        audioOptions.SetActive(false);
        uiOptions.SetActive(false);
        videoButton.interactable = false;
        audioButton.interactable = true;
        uiButton.interactable = true;
    }

    public void OptionsAudio()
    {
        videoOptions.SetActive(false);
        audioOptions.SetActive(true);
        uiOptions.SetActive(false);
        videoButton.interactable = true;
        audioButton.interactable = false;
        uiButton.interactable = true;
    }

    public void OptionsUI()
    {
        videoOptions.SetActive(false);
        audioOptions.SetActive(false);
        uiOptions.SetActive(true);
        videoButton.interactable = true;
        audioButton.interactable = true;
        uiButton.interactable = false;
    }
}
