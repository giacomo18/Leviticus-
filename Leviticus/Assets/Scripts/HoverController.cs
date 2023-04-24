using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine.UI;
using UnityEngine;

public class HoverController : MonoBehaviour
{

    [SerializeField] enemyManager enemyManager;
    [SerializeField] playerManager playerManager;

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

        enemyManager = GameObject.Find("Skeleton").GetComponent<enemyManager>();
        playerManager = GameObject.Find("Zelophehad").GetComponent<playerManager>();

        rt.sizeDelta = new Vector2(800, 150);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            if(poisonActive == true)
            {
                hoverText.text = "Drains life at the end of turn";
                rt.sizeDelta = new Vector2(450, 100);
            }
            else if (stunActive == true)
            {
                hoverText.text = "Miss a turn";
                rt.sizeDelta = new Vector2(200, 100);
            }
            else if (burnActive == true)
            {
                hoverText.text = "Take additional damage at the end of turn";
                rt.sizeDelta = new Vector2(600, 100);
            }
            else if (healActive == true)
            {
                hoverText.text = "Heals the player at the end of the turn";
                rt.sizeDelta = new Vector2(550, 100);
            }
            else if (powerfulActive == true)
            {
                hoverText.text = "Deal more damage";
                rt.sizeDelta = new Vector2(260, 100);

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
        rt.sizeDelta = new Vector2(800, 85);
        titleText.text = "<b>HP:</b>" + playerManager.playerHealthValue.ToString() + "/" + playerManager.playerMaxHealthValue.ToString();
        Debug.Log("<b>HP:</b>" + playerManager.playerHealthValue.ToString() + "/" + playerManager.playerMaxHealthValue.ToString());
        //titleText.text = "<b>HP:</b> 10/10";
    }
    public void EnemyHealthText()
    {
        hoverBox.SetActive(true);
        rt.sizeDelta = new Vector2(250, 85);
        titleText.text = "<b>HP:</b>" + enemyManager.enemyHealth.ToString() + "/" + enemyManager.enemyMaxHealth.ToString();
        //titleText.text = "<b>HP:</b> 10/10";
    }

    public void ManaText()
    {
        hoverBox.SetActive(true);
        rt.sizeDelta = new Vector2(250, 85);
        titleText.text = "<b>Mana: </b>" + playerManager.manaValue.ToString() + "/" + playerManager.manaMaxValue.ToString();
    }

    public void PoisonTxt()
    {
        hoverBox.SetActive(true);
        rt.sizeDelta = new Vector2(175, 120);
        poisonActive = true;
        titleText.text = "Poison";
        hoverText.text = "<i>[Shift]</i>";
    }

    public void StunTxt()
    {
        hoverBox.SetActive(true);
        rt.sizeDelta = new Vector2(150, 120);
        stunActive = true;
        titleText.text = "Stun";
        hoverText.text = "<i>[Shift]</i>";
    }

    public void BurnTxt()
    {
        hoverBox.SetActive(true);
        rt.sizeDelta = new Vector2(150, 120);
        burnActive = true;
        titleText.text = "Burn";
        hoverText.text = "<i>[Shift]</i>";
    }

    public void HealTxt()
    {
        hoverBox.SetActive(true);
        rt.sizeDelta = new Vector2(150, 120);
        healActive = true;
        titleText.text = "Heal";
        hoverText.text = "<i>[Shift]</i>";
    }

    public void PowerfulTxt()
    {
        hoverBox.SetActive(true);
        rt.sizeDelta = new Vector2(215, 120);
        powerfulActive = true;
        titleText.text = "Powerful";
        hoverText.text = "<i>[Shift]</i>";
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
