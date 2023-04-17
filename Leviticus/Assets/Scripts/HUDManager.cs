using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HUDManager : MonoBehaviour
{
    [SerializeField] Canvas CanvasOne;
    [SerializeField] Canvas CanvasTwo;
    [SerializeField] Canvas CanvasThree;

    [SerializeField] PlayerPreferences playerPrefs;

    void Awake()
    {
        playerPrefs = GameObject.Find("PlayerData").GetComponent<PlayerPreferences>();
    }
   
    public void Start()
    {
        CanvasOne.enabled = false;
        CanvasTwo.enabled = false;
        CanvasThree.enabled = false;

        if (playerPrefs.hudTypePref == 3)
        {
            CanvasThree.enabled = true;
        }
        else if (playerPrefs.hudTypePref == 2)
        {
            CanvasTwo.enabled = true;
        }
        else
        {
            CanvasOne.enabled = true;
        }
    }
   
    public void ButtonEffect(int Interact)
    {
        if (Interact == 1)
        {
            CanvasOne.enabled = true;
            CanvasTwo.enabled = false;
            CanvasThree.enabled = false;

        }
        if (Interact == 2)
        {
            CanvasOne.enabled = false;
            CanvasTwo.enabled = true;
            CanvasThree.enabled = false;

        }
        if (Interact == 3)
        {
            CanvasOne.enabled = false;
            CanvasTwo.enabled = false;
            CanvasThree.enabled = true; ;
        }
    }
}
