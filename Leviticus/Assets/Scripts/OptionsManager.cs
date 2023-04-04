using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class OptionsManager : MonoBehaviour
{
    public GameObject videoOptions;
    public GameObject audioOptions;
    public GameObject uiOptions;
    public GameObject hudPanel;

    public Button videoButton;
    public Button audioButton;
    public Button uiButton;

    public Button hudTypeButton1;
    public Button hudTypeButton2;
    public Button hudTypeButton3;

    public Image uiHudImage;
    public Sprite uiType1;
    public Sprite uiType2;
    public Sprite uiType3;


    // Start is called before the first frame update
    void Start()
    {
        OptionsVideo();
        uiHudImage = hudPanel.GetComponent<Image>();
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

    public void UIType1()
    {
        uiHudImage.sprite = uiType1;
        hudTypeButton1.interactable = false;
        hudTypeButton2.interactable = true;
        hudTypeButton3.interactable = true;
    }

    public void UIType2()
    {
        uiHudImage.sprite = uiType2;
        hudTypeButton1.interactable = true;
        hudTypeButton2.interactable = false;
        hudTypeButton3.interactable = true;
    }

    public void UIType3()
    {
        uiHudImage.sprite = uiType3;
        hudTypeButton1.interactable = true;
        hudTypeButton2.interactable = true;
        hudTypeButton3.interactable = false;
    }
}
