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
    public bool stunActive;
    public bool burnActive;
    public bool healActive;
    public bool powerfulActive;

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
                hoverText.text = "Drains 10% of health at the end of the turn.";
            }
            else if (stunActive == true)
            {
                hoverText.text = "Prevents attacking for a turn.";
            }
            else if (burnActive == true)
            {
                hoverText.text = "Takes 10% extra damage when attacked";
            }
            else if (healActive == true)
            {
                hoverText.text = "Heals the player for 10% of health at the end of the turn.";
            }
            else if (powerfulActive == true)
            {
                hoverText.text = "Drains 10% of health at end of turn.";
            }
            Debug.Log("Left Shift Pressed");
        }

        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            if (poisonActive == true)
            {
                PoisonTxt();
            }
            else if (stunActive == true)
            {
                StunTxt();
            }
            else if (burnActive == true)
            {
                BurnTxt();
            }
            else if (healActive == true)
            {
                HealTxt();
            }
            else if (powerfulActive == true)
            {
                PowerfulTxt();
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

    public void StunTxt()
    {
        hoverBox.SetActive(true);
        stunActive = true;
        titleText.text = "Stun";
        hoverText.text = "<i>Press <b>SHIFT</b> for more info</i>";
    }

    public void BurnTxt()
    {
        hoverBox.SetActive(true);
        burnActive = true;
        titleText.text = "Burn";
        hoverText.text = "<i>Press <b>SHIFT</b> for more info</i>";
    }

    public void HealTxt()
    {
        hoverBox.SetActive(true);
        healActive = true;
        titleText.text = "Heal";
        hoverText.text = "<i>Press <b>SHIFT</b> for more info</i>";
    }

    public void PowerfulTxt()
    {
        hoverBox.SetActive(true);
        powerfulActive = true;
        titleText.text = "Powerful";
        hoverText.text = "<i>Press <b>SHIFT</b> for more info</i>";
    }

    public void HoverExit()
    {
        hoverBox.SetActive(false);
        poisonActive = false;
        stunActive = false;
        burnActive = false;
        healActive = false;
        powerfulActive = false;
        hoverText.text = "";
        titleText.text = "";
    }
}
