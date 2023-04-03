using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

[RequireComponent(typeof(Image))]
public class Options : MonoBehaviour
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

    public int uiTypePref;

    public GameObject playerPrefObj;


    // Start is called before the first frame update
    void Start()
    {
        OptionsVideo();
        
        playerPrefObj = GameObject.Find("PlayerData");
        PlayerPrefs playerPrefs = playerPrefObj.GetComponent<PlayerPreferences>();

        uiHudImage = hudPanel.GetComponent<Image> ();
        UIType1();
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
        uiTypePref = 1;
        playerPrefs.SaveData();
    }

    public void UIType2()
    {
        uiHudImage.sprite = uiType2;
        hudTypeButton1.interactable = true;
        hudTypeButton2.interactable = false;
        hudTypeButton3.interactable = true;
        uiTypePref = 2;
        playerPrefs.SaveData();
    }

    public void UIType3()
    {
        uiHudImage.sprite = uiType3;
        hudTypeButton1.interactable = true;
        hudTypeButton2.interactable = true;
        hudTypeButton3.interactable = false;
        uiTypePref = 3;
        playerPrefs.SaveData();
    }
}
