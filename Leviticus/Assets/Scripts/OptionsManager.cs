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

    public Button hudScaleButton1;
    public Button hudScaleButton2;
    public Button hudScaleButton3;

    Image uiHudImage;
    public Sprite hud1a;
    public Sprite hud1b;
    public Sprite hud1c;
    public Sprite hud2a;
    public Sprite hud2b;
    public Sprite hud2c;
    public Sprite hud3a;
    public Sprite hud3b;
    public Sprite hud3c;

    [SerializeField] PlayerPreferences playerPrefs;


    // Start is called before the first frame update
    void Start()
    {
        OptionsVideo();
        uiHudImage = hudPanel.GetComponent<Image>();
        playerPrefs = GameObject.Find("PlayerData").GetComponent<PlayerPreferences>();

        if (playerPrefs.hudTypePref == 3)
        {
            UIType3();
        }
        else if (playerPrefs.hudTypePref == 2)
        {
            UIType2();
        }
        else
        {
            UIType1();
        }

        if (playerPrefs.hudScalePref == 3)
        {
            UIScale3();
        }
        else if (playerPrefs.hudScalePref == 2)
        {
            UIScale2();
        }
        else
        {
            UIScale1();
        }
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
        hudTypeButton1.interactable = false;
        hudTypeButton2.interactable = true;
        hudTypeButton3.interactable = true;
        playerPrefs.SaveType(1);
        if(playerPrefs.hudScalePref == 3)
        {
            uiHudImage.sprite = hud1c;
        }
        else if (playerPrefs.hudScalePref == 2)
        {
            uiHudImage.sprite = hud1b;
        }
        else
        {
            uiHudImage.sprite = hud1a;
        }
    }

    public void UIType2()
    {
        uiHudImage.sprite = hud1b;
        hudTypeButton1.interactable = true;
        hudTypeButton2.interactable = false;
        hudTypeButton3.interactable = true;
        playerPrefs.SaveType(2);
        if (playerPrefs.hudScalePref == 3)
        {
            uiHudImage.sprite = hud2c;
        }
        else if (playerPrefs.hudScalePref == 2)
        {
            uiHudImage.sprite = hud2b;
        }
        else
        {
            uiHudImage.sprite = hud2a;
        }
    }

    public void UIType3()
    {
        uiHudImage.sprite = hud1c;
        hudTypeButton1.interactable = true;
        hudTypeButton2.interactable = true;
        hudTypeButton3.interactable = false;
        playerPrefs.SaveType(3);
        if (playerPrefs.hudScalePref == 3)
        {
            uiHudImage.sprite = hud3c;
        }
        else if (playerPrefs.hudScalePref == 2)
        {
            uiHudImage.sprite = hud3b;
        }
        else
        {
            uiHudImage.sprite = hud3a;
        }
    }

    public void UIScale1()
    {
        hudScaleButton1.interactable = false;
        hudScaleButton2.interactable = true;
        hudScaleButton3.interactable = true;
        playerPrefs.SaveScale(1);
        if (playerPrefs.hudTypePref == 3)
        {
            uiHudImage.sprite = hud3a;
        }
        else if (playerPrefs.hudTypePref == 2)
        {
            uiHudImage.sprite = hud2a;
        }
        else
        {
            uiHudImage.sprite = hud1a;
        }
    }
    public void UIScale2()
    {
        hudScaleButton1.interactable = true;
        hudScaleButton2.interactable = false;
        hudScaleButton3.interactable = true;
        playerPrefs.SaveScale(2);
        if (playerPrefs.hudTypePref == 3)
        {
            uiHudImage.sprite = hud3b;
        }
        else if (playerPrefs.hudTypePref == 2)
        {
            uiHudImage.sprite = hud2b;
        }
        else
        {
            uiHudImage.sprite = hud1b;
        }
    }
    public void UIScale3()
    {
        hudScaleButton1.interactable = true;
        hudScaleButton2.interactable = true;
        hudScaleButton3.interactable = false;
        playerPrefs.SaveScale(3);
        if (playerPrefs.hudTypePref == 3)
        {
            uiHudImage.sprite = hud3c;
        }
        else if (playerPrefs.hudTypePref == 2)
        {
            uiHudImage.sprite = hud2c;
        }
        else
        {
            uiHudImage.sprite = hud1c;
        }
    }

}
