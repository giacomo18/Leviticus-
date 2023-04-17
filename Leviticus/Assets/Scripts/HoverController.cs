using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine.UI;
using UnityEngine;

public class HoverController : MonoBehaviour
{
    public GameObject hoverBox;
    public TextMeshProUGUI hoverText;
    public TextMeshProUGUI titleText;
    public bool poisonActive;

    // Start is called before the first frame update
    void Start()
    {
        hoverBox.SetActive(false);
        poisonActive = false;
        hoverText.text = "";
        titleText.text = "";
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            if(poisonActive == true)
            {
                hoverText.text = "Drains 10% of health at end of turn. \n<i>Press <b>SHIFT</b> for more info</i>";
            }
            Debug.Log("Left Shift Pressed");
        }

        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            if (poisonActive == true)
            {
                PoisonTxt();
            }
            Debug.Log("Left Shift Unpressed");
        }
    }

    public void PoisonTxt()
    {
        hoverBox.SetActive(true);
        poisonActive = true;
        titleText.text = "Poison";
        hoverText.text = "<i>Press <b>SHIFT</b> for more info</i>";
    }

    public void HoverExit()
    {
        hoverBox.SetActive(false);
        poisonActive = false;
        hoverText.text = "";
        titleText.text = "";
    }
}
