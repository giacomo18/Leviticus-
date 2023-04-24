using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class enemyManager : MonoBehaviour
{
    public playerManager playerManager;
    public HealthBarScript enemyHealthBar;
    public GameManager gameManager;
    [SerializeField] PlayerPreferences playerPreferences;

    public int enemyHealth;
    public int enemyMaxHealth;
    [SerializeField] int enemyMinDamage = 10;
    [SerializeField] int enemyMaxDamage = 10;
    private bool alive = true;
    private bool isCoroutineOn;
    private int Action;

    public int randomNum;

    [SerializeField] Animator Anim;

    [SerializeField] GameObject FireImage;
    [SerializeField] GameObject PoisonImage;
    [SerializeField] GameObject StunImage;
    public GameObject HealImage;
    public GameObject PowerImage;

    [SerializeField] TextMeshProUGUI FireNum;
    [SerializeField] TextMeshProUGUI PoisonNum;
    [SerializeField] TextMeshProUGUI StunNum;
    public TextMeshProUGUI HealNum;
    public TextMeshProUGUI PowerNum;


    private void Start()
    {
        playerPreferences = GameObject.Find("PlayerData").GetComponent<PlayerPreferences>();
        //Pref 3
        if (playerPreferences.hudTypePref == 3)
        {
            enemyHealthBar = GameObject.Find("P1enemyHealthBar").GetComponent<HealthBarScript>();

            FireImage = GameObject.Find("PlayerFire3");
            PoisonImage = GameObject.Find("PlayerPoison3");
            StunImage = GameObject.Find("PlayerStun3");
            HealImage = GameObject.Find("PlayerHoT3");
            PowerImage = GameObject.Find("PlayerPowerful3");

        }
        //Pref 2
        else if (playerPreferences.hudTypePref == 2)
        {
            enemyHealthBar = GameObject.Find("P2enemyHealthBar").GetComponent<HealthBarScript>();

            FireImage = GameObject.Find("PlayerFire2");
            PoisonImage = GameObject.Find("PlayerPoison2");
            StunImage = GameObject.Find("PlayerStun2");
            HealImage = GameObject.Find("PlayerHoT2");
            PowerImage = GameObject.Find("PlayerPowerful2");
        }
        //Pref1
        else
        {
            enemyHealthBar = GameObject.Find("P3enemyHealthBar").GetComponent<HealthBarScript>();

            FireImage = GameObject.Find("PlayerFire1");
            PoisonImage = GameObject.Find("PlayerPoison1");
            StunImage = GameObject.Find("PlayerStun1");
            HealImage = GameObject.Find("PlayerHoT1");
            PowerImage = GameObject.Find("PlayerPowerful1");
        }

        FireImage.GetComponent<Image>().enabled = false;
        PoisonImage.GetComponent<Image>().enabled = false;
        StunImage.GetComponent<Image>().enabled = false;
        HealImage.GetComponent<Image>().enabled = false;
        PowerImage.GetComponent<Image>().enabled = false;

        FireNum = FireImage.GetComponentInChildren<TextMeshProUGUI>();
        PoisonNum = PoisonImage.GetComponentInChildren<TextMeshProUGUI>();
        StunNum = StunImage.GetComponentInChildren<TextMeshProUGUI>();
        HealNum = HealImage.GetComponentInChildren<TextMeshProUGUI>();
        PowerNum = PowerImage.GetComponentInChildren<TextMeshProUGUI>();

        FireNum.text = "";
        PoisonNum.text = "";
        StunNum.text = "";
        HealNum.text = "";
        PowerNum.text = "";
    }
    public void enemyTurn()
    {
        if (alive == true)
        {
            StartCoroutine(Delay(3));
        }
        else
        {
            playerManager.WinCondition();
        }
    }


    IEnumerator Delay(float time)
    {
        if (isCoroutineOn)
            yield break;

        isCoroutineOn = true;

        yield return new WaitForSeconds(time);
        enemyAction();

        gameManager.playerTurn();
        isCoroutineOn = false;


    }

    public void enemyAction()
    {
        Action = Random.Range(0, 3);
        Debug.Log(Action);
        if(Action >= 1)
        {
            playerManager.playerHealthValue -= Random.Range(enemyMinDamage, enemyMaxDamage);
            playerManager.playerHealthBar.UpdateMeter(playerManager.playerHealthValue, playerManager.playerMaxHealthValue);
            Anim.SetTrigger("Attack");
            UpdateStatusIcons();
        }
        if(Action == 0)
        {
            randomNum = Random.Range(0, 5);
            if (randomNum == 0)
            {
                gameManager.playerFire += 1;
            }
            else if (randomNum == 1)
            {
                gameManager.playerPoison += 1;
            }
            else if (randomNum == 2)
            {
                gameManager.playerStun += 1;
            }
            else if (randomNum == 3)
            {
                gameManager.enemyHeal += 1;
            }
            else if (randomNum == 4)
            {
                gameManager.enemyPower += 1;
            }
            UpdateStatusIcons();
        }

    }

    private void UpdateStatusIcons()
    {
        if (gameManager.playerFire >= 1)
        {
            FireImage.GetComponent<Image>().enabled = true;
            FireNum.text = gameManager.playerFire.ToString();
        }
        else
        {
            FireImage.GetComponent<Image>().enabled = false;
            FireNum.text = "";
        }

        if (gameManager.playerPoison >= 1)
        {
            PoisonImage.GetComponent<Image>().enabled = true;
            PoisonNum.text = gameManager.playerPoison.ToString();
        }
        else
        {
            PoisonImage.GetComponent<Image>().enabled = false;
            PoisonNum.text = "";
        }

        if (gameManager.playerStun >= 1)
        {
            StunImage.GetComponent<Image>().enabled = true;
            StunNum.text = gameManager.playerStun.ToString();
        }
        else
        {
            StunImage.GetComponent<Image>().enabled = false;
            StunNum.text = "";
        }

        if (gameManager.playerHeal >= 1)
        {
            playerManager.HealImage.GetComponent<Image>().enabled = true;
            playerManager.HealNum.text = gameManager.enemyHeal.ToString();
        }
        else
        {
            playerManager.HealImage.GetComponent<Image>().enabled = false;
            playerManager.HealNum.text = "";
        }

        if (gameManager.playerPower >= 1)
        {
            playerManager.PowerImage.GetComponent<Image>().enabled = true;
            playerManager.PowerNum.text = gameManager.enemyPower.ToString();
        }
        else
        {
            playerManager.PowerImage.GetComponent<Image>().enabled = false;
            playerManager.PowerNum.text = "";
        }
    }
}
