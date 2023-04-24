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
    public StatusEffectEffect statusEffectEffect;

    public float enemyHealth;
    private float enemyDamage;
    [HideInInspector] public float enemyMaxHealth;
    private int enemyMinDamage = 10;
    private int enemyMaxDamage = 10;
    private bool alive = true;
    private bool isCoroutineOn;
    private int Action;

    [HideInInspector] public int randomNum;

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


    public bool Fire = false;
    public bool Poison = false;
    public bool Stun = false;
    public bool HoT = false;
    public bool Power = false;

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
        if(alive == true)
        {
            if (gameManager.enemyStun < 1)
            {
                if (gameManager.enemyHeal > 1)
                {
                    enemyHealth = enemyHealth * 0.10f;
                    enemyHealthBar.UpdateMeter(enemyHealth, enemyMaxHealth);
                }

                if (gameManager.enemyPoison > 1)
                {
                    enemyHealth = enemyHealth - (gameManager.enemyPoison * 0.10f);
                    enemyHealthBar.UpdateMeter(enemyHealth, enemyMaxHealth);
                }

                if (gameManager.enemyFire > 1)
                {
                    enemyHealth = enemyHealth - (gameManager.enemyFire + 10);
                    enemyHealthBar.UpdateMeter(enemyHealth, enemyMaxHealth);
                }

                StartCoroutine(Delay(3));
            }
            else
            {
                
                gameManager.playerTurn();
            }
            StartCoroutine(Delay(1));
        }
        else
        {
            gameManager.Won();
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
            enemyDamage = (Random.Range(enemyMinDamage, enemyMaxDamage));
            if (gameManager.enemyPower > 1)
            {
                playerManager.playerHealthValue -=  enemyDamage + (gameManager.enemyPower + (enemyDamage * 0.10f));
                playerManager.playerHealthBar.UpdateMeter(playerManager.playerHealthValue, playerManager.playerMaxHealthValue);
            }
            else
            {
                playerManager.playerHealthValue -= enemyDamage;
                playerManager.playerHealthBar.UpdateMeter(playerManager.playerHealthValue, playerManager.playerMaxHealthValue);
            }
           
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
            playerManager.Fire = true;
        }
        else
        {
            FireImage.GetComponent<Image>().enabled = false;
            FireNum.text = "";
            playerManager.Fire = false;
        }

        if (gameManager.playerPoison >= 1)
        {
            PoisonImage.GetComponent<Image>().enabled = true;
            PoisonNum.text = gameManager.playerPoison.ToString();
            playerManager.Poison = true;
        }
        else
        {
            PoisonImage.GetComponent<Image>().enabled = false;
            PoisonNum.text = "";
            playerManager.Poison = false;
        }

        if (gameManager.playerStun >= 1)
        {
            StunImage.GetComponent<Image>().enabled = true;
            StunNum.text = gameManager.playerStun.ToString();
            playerManager.Stun = true;
        }
        else
        {
            StunImage.GetComponent<Image>().enabled = false;
            StunNum.text = "";
            playerManager.Stun = false;
        }

        if (gameManager.playerHeal >= 1)
        {
            playerManager.HealImage.GetComponent<Image>().enabled = true;
            playerManager.HealNum.text = gameManager.enemyHeal.ToString();
            playerManager.HoT = true;
        }
        else
        {
            playerManager.HealImage.GetComponent<Image>().enabled = false;
            playerManager.HealNum.text = "";
            HoT = false;
        }

        if (gameManager.playerPower >= 1)
        {
            playerManager.PowerImage.GetComponent<Image>().enabled = true;
            playerManager.PowerNum.text = gameManager.enemyPower.ToString();
            Power = true;
        }
        else
        {
            playerManager.PowerImage.GetComponent<Image>().enabled = false;
            playerManager.PowerNum.text = "";
            Power = false;
        }
    }
}
