using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class playerManager : MonoBehaviour
{
    public HealthBarScript playerHealthBar;
    [SerializeField] enemyManager enemyManager;
    [SerializeField] GameManager gameManager;
    [SerializeField] PlayerPreferences playerPreferences;

    public float playerHealthValue;
    public float playerMaxHealthValue = 100;

    [HideInInspector] public int randomNum;
    
    [SerializeField] float playerDamage;
    [SerializeField] Button Action1;
    [SerializeField] Button Action2;
    [SerializeField] Button Action3;

    [SerializeField] Animator anim;

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

    public GameObject winScreen;
    public GameObject charPlayer;
    public GameObject charEnemy;

    private void Start()
    {
        playerPreferences = GameObject.Find("PlayerData").GetComponent<PlayerPreferences>();
        //Pref 3
        if (playerPreferences.hudTypePref == 3)
        {
            Action1 = GameObject.Find("P3Attack").GetComponent<Button>();
            Action2 = GameObject.Find("P3Action").GetComponent<Button>();
            Action3 = GameObject.Find("P3End").GetComponent<Button>();
            playerHealthBar = GameObject.Find("P1playerHealthBar").GetComponent<HealthBarScript>();

            FireImage = GameObject.Find("EnemyFire3");
            PoisonImage = GameObject.Find("EnemyPoison3");
            StunImage = GameObject.Find("EnemyStun3");
            HealImage = GameObject.Find("EnemyHoT3");
            PowerImage = GameObject.Find("EnemyPowerful3");
        }
        //Pref 2
        else if (playerPreferences.hudTypePref == 2)
        {
            Action1 = GameObject.Find("P2Attack").GetComponent<Button>();
            Action2 = GameObject.Find("P2Action").GetComponent<Button>();
            Action3 = GameObject.Find("P2End").GetComponent<Button>();
            playerHealthBar = GameObject.Find("P2playerHealthBar").GetComponent<HealthBarScript>();

            FireImage = GameObject.Find("EnemyFire2");
            PoisonImage = GameObject.Find("EnemyPoison2");
            StunImage = GameObject.Find("EnemyStun2");
            HealImage = GameObject.Find("EnemyHoT2");
            PowerImage = GameObject.Find("EnemyPowerful2");
        }
        //Pref1
        else
        {
            Action1 = GameObject.Find("P1Attack").GetComponent<Button>();
            Action2 = GameObject.Find("P1Action").GetComponent<Button>();
            Action3 = GameObject.Find("P1End").GetComponent<Button>();
            playerHealthBar = GameObject.Find("P3playerHealthBar").GetComponent<HealthBarScript>();

            FireImage = GameObject.Find("EnemyFire1");
            PoisonImage = GameObject.Find("EnemyPoison1");
            StunImage = GameObject.Find("EnemyStun1");
            HealImage = GameObject.Find("EnemyHoT1");
            PowerImage = GameObject.Find("EnemyPowerful1");
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

    public void playerStart()
    {
        if (gameManager.playerStun == 0)
        {
            Action1.interactable = true;
            Action2.interactable = true;
            Action3.interactable = true;
            if (gameManager.playerHeal > 1)
            {
                playerHealthValue = playerHealthValue + ((playerHealthValue * 0.10f) * gameManager.playerHeal);
                playerHealthBar.UpdateMeter(playerHealthValue, playerMaxHealthValue);
            }

            if (gameManager.playerPoison > 1)
            {
                playerHealthValue -= playerHealthValue - (gameManager.playerPoison * 0.10f);
                playerHealthBar.UpdateMeter(playerHealthValue, playerMaxHealthValue);
            }

            if (gameManager.playerFire > 1)
            {
                playerHealthValue -= playerHealthValue - (gameManager.playerFire + 10);
                playerHealthBar.UpdateMeter(playerHealthValue, playerMaxHealthValue);
            }
        }

        else
        {
            gameManager.EnemyStart();
        }


        if (gameManager.playerFire != 0)
        {
            gameManager.playerFire -= 1;
        }
        if (gameManager.playerPoison != 0)
        {
            gameManager.playerPoison -= 1;
        }
        if (gameManager.playerStun != 0)
        {
            gameManager.playerStun -= 1;
        }
        if (gameManager.playerHeal != 0)
        {
            gameManager.playerHeal -= 1;
        }
        if (gameManager.playerPower != 0)
        {
            gameManager.playerPower -= 1;
        }

        UpdateStatusIcons();
    }
    /*
     void Update()
    {
        if (!PauseMenu.isPaused)
        {
            Action1.interactable = false;
            Action2.interactable = false;
            Action3.interactable = false;
        }
        else
        {
            Action1.interactable = true;
            Action2.interactable = true;
            Action3.interactable = true;
        }
    }
    */
        
    public void NextRound()
    {
        
    }




    public void playerAction(int Button)
    {
       if(Button == 0)
        {
            if (Power == true)
            {
                enemyManager.enemyHealth -= playerDamage + (gameManager.playerPower * (playerDamage * 0.10f));
            }
            else
            {
                enemyManager.enemyHealth -= playerDamage;
            }

            anim.SetTrigger("attack");

        }
       if(Button == 1)
        {
            StatusEffect();
        }
       if(Button== 2)
        {
            Action1.interactable = false;
            Action2.interactable = false;
            Action3.interactable = false;

            gameManager.EnemyStart();
        }
    }

    public void StatusEffect()
    {
        randomNum = Random.Range(0, 5);

        if(randomNum == 0)
        {
            gameManager.enemyFire += 1;
            UpdateStatusIcons();
        }
        else if(randomNum == 1)
        {
            gameManager.enemyPoison += 1;
            UpdateStatusIcons();
        }
        else if(randomNum == 2)
        {
            gameManager.enemyStun += 1;
            UpdateStatusIcons();
        }
        else if(randomNum == 3)
        {
            gameManager.playerHeal += 1;
            UpdateStatusIcons();
        }
        else if(randomNum == 4)
        {
            gameManager.playerPower += 1;
            UpdateStatusIcons();
        }
    }

    private void UpdateStatusIcons()
    {
        if (gameManager.enemyFire >= 1)
        {
            FireImage.GetComponent<Image>().enabled = true;
            FireNum.text = gameManager.enemyFire.ToString();
            enemyManager.Fire = true;
        }
        else
        {
            FireImage.GetComponent<Image>().enabled = false;
            FireNum.text = "";
            enemyManager.Fire = false;
        }

        if (gameManager.enemyPoison >= 1)
        {
            PoisonImage.GetComponent<Image>().enabled = true;
            PoisonNum.text = gameManager.enemyPoison.ToString();
            enemyManager.Poison = true;
        }
        else
        {
            PoisonImage.GetComponent<Image>().enabled = false;
            PoisonNum.text = "";
            enemyManager.Poison = false;
        }

        if (gameManager.enemyStun >= 1)
        {
            StunImage.GetComponent<Image>().enabled = true;
            StunNum.text = gameManager.enemyStun.ToString();
            enemyManager.Stun = true;
        }
        else
        {
            StunImage.GetComponent<Image>().enabled = false;
            StunNum.text = "";
            enemyManager.Stun = false;
        }

        if (gameManager.playerHeal >= 1)
        {
            enemyManager.HealImage.GetComponent<Image>().enabled = true;
            enemyManager.HealNum.text = gameManager.playerHeal.ToString();
            HoT = true;
        }
        else
        {
            enemyManager.HealImage.GetComponent<Image>().enabled = false;
            enemyManager.HealNum.text = "";
            HoT = false;
        }

        if (gameManager.playerPower >= 1)
        {
            enemyManager.PowerImage.GetComponent<Image>().enabled = true;
            enemyManager.PowerNum.text = gameManager.playerPower.ToString();
            Power = true;
        }
        else
        {
            enemyManager.PowerImage.GetComponent<Image>().enabled = false;
            enemyManager.PowerNum.text = "";
            Power = false;
        }
    }
}
