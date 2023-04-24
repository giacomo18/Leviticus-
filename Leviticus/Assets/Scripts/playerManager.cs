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

    public int randomNum;
    
    [SerializeField] int playerDamage;
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

        winScreen.SetActive(false);
        charPlayer.SetActive(true);
        charEnemy.SetActive(true);
    }

    public void playerStart()
    {
        Action1.interactable = true;
        Action2.interactable = true;
        Action3.interactable = true;
    }

    public void WinCondition()
    {
        winScreen.SetActive(true);
        charPlayer.SetActive(false);
        charEnemy.SetActive(false);
    }

    public void LoseCondition()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }


    public void playerAction(int Button)
    {
       if(Button == 0)
        {
            enemyManager.enemyHealth -= playerDamage;
            enemyManager.enemyHealthBar.UpdateMeter(enemyManager.enemyHealth, enemyManager.enemyMaxHealth);
            anim.SetTrigger("attack");

        }
       if(Button == 1)
        {
            StatusEffect();
        }
       if(Button== 2)
        {
            if (enemyManager.enemyHealth > 0 && playerHealthValue > 0)
            {
                Action1.interactable = false;
                Action2.interactable = false;
                Action3.interactable = false;

                gameManager.EnemyStart();
            }
            else if (enemyManager.enemyHealth == 0)
            {
                WinCondition();
            }
            else if (playerHealthValue == 0)
            {
                LoseCondition();
            }
        }
    }

    public void StatusEffect()
    {
        randomNum = Random.Range(0, 5);
        Debug.Log(randomNum);
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
        }
        else
        {
            FireImage.GetComponent<Image>().enabled = false;
            FireNum.text = "";
        }

        if (gameManager.enemyPoison >= 1)
        {
            PoisonImage.GetComponent<Image>().enabled = true;
            PoisonNum.text = gameManager.enemyPoison.ToString();
        }
        else
        {
            PoisonImage.GetComponent<Image>().enabled = false;
            PoisonNum.text = "";
        }

        if (gameManager.enemyStun >= 1)
        {
            StunImage.GetComponent<Image>().enabled = true;
            StunNum.text = gameManager.enemyStun.ToString();
        }
        else
        {
            StunImage.GetComponent<Image>().enabled = false;
            StunNum.text = "";
        }

        if (gameManager.playerHeal >= 1)
        {
            enemyManager.HealImage.GetComponent<Image>().enabled = true;
            enemyManager.HealNum.text = gameManager.playerHeal.ToString();
        }
        else
        {
            enemyManager.HealImage.GetComponent<Image>().enabled = false;
            enemyManager.HealNum.text = "";
        }

        if (gameManager.playerPower >= 1)
        {
            enemyManager.PowerImage.GetComponent<Image>().enabled = true;
            enemyManager.PowerNum.text = gameManager.playerPower.ToString();
        }
        else
        {
            enemyManager.PowerImage.GetComponent<Image>().enabled = false;
            enemyManager.PowerNum.text = "";
        }
    }
}
