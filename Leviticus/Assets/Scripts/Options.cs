using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Options : MonoBehaviour
{
    public GameObject videoOptions;
    public GameObject audioOptions;
    public GameObject uiOptions;

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
    }

    public void OptionsAudio()
    {
        videoOptions.SetActive(false);
        audioOptions.SetActive(true);
        uiOptions.SetActive(false);
    }

    public void OptionsUI()
    {
        videoOptions.SetActive(false);
        audioOptions.SetActive(false);
        uiOptions.SetActive(true);
    }
}
