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
    RectTransform rt;


    private void Awake()
    {
        rt = hoverBox.GetComponent<RectTransform>();

    }

    // Start is called before the first frame update
    void Start()
    {
        hoverBox.SetActive(false);
        poisonActive = false;
        hoverText.text = "";
        titleText.text = "";

        
        rt.sizeDelta = new Vector2(800, 150);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            if(poisonActive == true)
            {
                hoverText.text = "Drains life at the end of turn";
            }
            else if (stunActive == true)
            {
                hoverText.text = "Miss a turn";
            }
            else if (burnActive == true)
            {
                hoverText.text = "Take additional damage at the end of turn";
            }
            else if (healActive == true)
            {
                hoverText.text = "Heals the player at the end of the turn.";
            }
            else if (powerfulActive == true)
            {
                hoverText.text = "Deal more damage.";
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

    public void PlayerHealthText()
    {
        hoverBox.SetActive(true);
        titleText.text = "<b>HP:</b> ##/##";
        rt.sizeDelta = new Vector2(250, 80);
    }
    public void EnemyHealthText()
    {
        hoverBox.SetActive(true);
        rt.sizeDelta = new Vector2(250, 80);
        titleText.text = "<b>HP:</b> ##/##";
    }

    public void ManaText()
    {
        hoverBox.SetActive(true);
        rt.sizeDelta = new Vector2(250, 80);
        titleText.text = "<b>Mana:</b> ##";
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
        rt.sizeDelta = new Vector2(800, 150);
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
