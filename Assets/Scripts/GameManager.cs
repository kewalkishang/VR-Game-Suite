using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;
    public bool InAIR = false;
    public GameObject MainMenu;
    public GameObject StickMen;
    public GameObject RobTheBuilder;
    public GameObject BallBalance;

    public GameObject gun;
    public GameObject bat;
    public GameObject HealthBAR;
    public GameObject GameOverText;
    public GameObject leftButton;
    public GameObject rightButton;
    public GameObject[] Shapes;
    public GameObject[] ShapesGame;
    public Text bbhighscore;
    public Text Zsmhighscore;
    public Text bbscoreTEXT;
    public Text ZsscoreTEXT;
    int ShapesCount;
    public int CurShape = 0;


    public float maxHealth = 100;
    public float currentHealth;

    public Image health;

    int bbscore = 0, stickmanscore = 0;
    // Use this for initialization
    //Awake is always called before any Start functions
    void Awake()
    {
        //Check if instance already exists
        if (instance == null)

            //if not, set instance to this
            instance = this;

        //If instance already exists and it's not this:
        else if (instance != this)

            //Then destroy this. This enforces our singleton pattern, meaning there can only ever be one instance of a GameManager.
            Destroy(gameObject);


    }


    void Start()
    {
        currentHealth = maxHealth;
        ShapesCount = Shapes.Length;
        bbhighscore.text = "HighScore : " + PlayerPrefs.GetInt("bbhighscore").ToString();
        Zsmhighscore.text = "Kill Streak : \n " + PlayerPrefs.GetInt("zshighscore").ToString();
    }


    public void PlayRobTheBuilder()
    {
        MainMenu.SetActive(false);
        RobTheBuilder.SetActive(true);
        foreach (GameObject G in ShapesGame)
            G.SetActive(false);
        ShapesGame[CurShape].SetActive(true);

    }

    public void PlayBallBalance()
    {
        MainMenu.SetActive(false);
        BallBalance.SetActive(true);
        bat.SetActive(true);
    }
    public void PlayZombieStickmen()
    {
        health.fillAmount = 1;
        HealthBAR.SetActive(true);
        MainMenu.SetActive(false);
        StickMen.SetActive(true);
        gun.SetActive(true);
    }

    public void GotoMainMenu()
    {
        GameObject[] stick = GameObject.FindGameObjectsWithTag("stickman");
        if (stick != null)
            foreach (GameObject g in stick)
                Destroy(g);
        MainMenu.SetActive(true);
        SpawnStick SS = StickMen.GetComponent<SpawnStick>();
        SS.enabled = false;
        HealthBAR.SetActive(false);
        StickMen.SetActive(false);
        gun.SetActive(false);
        GameOverText.SetActive(false);
        BallBalance.SetActive(false);
        RobTheBuilder.SetActive(false);
        bat.SetActive(false);
        gun.SetActive(false);
        bbhighscore.text = "HighScore : " + PlayerPrefs.GetInt("bbhighscore").ToString();
        Zsmhighscore.text = "Kill Streak : \n " + PlayerPrefs.GetInt("zshighscore").ToString();
        bbscore = 0;
        stickmanscore = 0;
    }
    public void BBSCORE()
    {
        bbscore += 1;
        if (bbscore > PlayerPrefs.GetInt("bbhighscore"))
            PlayerPrefs.SetInt("bbhighscore", bbscore);
        bbscoreTEXT.text = "Baskets : " + bbscore.ToString();
    }
    public void ZSCORE()
    {    if (currentHealth > 0)
        {
            stickmanscore += 1;
            if (stickmanscore > PlayerPrefs.GetInt("zshighscore"))
                PlayerPrefs.SetInt("zshighscore", stickmanscore);
            ZsscoreTEXT.text = "Kills : " + stickmanscore.ToString();
        }
    }
    public void TakeDamage(int amount)
    {
        currentHealth -= amount;
        health.fillAmount = currentHealth / maxHealth;
        if (currentHealth <= 0)
        {
            GameOverText.SetActive(true);
            currentHealth = 0;
            StartCoroutine(DelayCoroutine());
            Debug.Log("Dead! GAME OVER");
        }

    }

    IEnumerator DelayCoroutine()
    {
        yield return new WaitForSeconds(3);
        GotoMainMenu(); 
    }

    public void RightShape()
    {
        CurShape = CurShape + 1;
        if(CurShape>0)
        {
            leftButton.SetActive(true);
        }
        if (CurShape == ShapesCount - 1)
            rightButton.SetActive(false);
        for (int i = 0; i < ShapesCount; i++)
        {
            if (i != CurShape)
                Shapes[i].SetActive(false);
            else
                Shapes[i].SetActive(true);
        }
    }
    public void LeftShape()
    {
        CurShape = CurShape - 1;
        if (CurShape == 0)
        {
            leftButton.SetActive(false);
        }
        if (CurShape < ShapesCount - 1)
            rightButton.SetActive(true);
        // if (CurShape == ShapesCount - 1)
        //   rightButton.SetActive(true);
        for (int i = 0; i < ShapesCount; i++)
        {
            if (i != CurShape)
                Shapes[i].SetActive(false);
            else
                Shapes[i].SetActive(true);
        }
    }
}