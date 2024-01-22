using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {
    //FOR DATA PERSISTANCE
    public static GameManager Instance;
    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);

        //VAR TO LOAD ONLY ONCE
        Physics.gravity *= 3;
        playerType = "Player0";



    }
    /// UI
    public GameObject startMenu;
    public GameObject scoreViewer;
    public TextMeshProUGUI walletText; 
   // public TextMeshProUGUI levelText;
    public TextMeshProUGUI highScoreText;
    public TextMeshProUGUI tryAgainText;

    public bool isGameActive=false;
    public int highScore;
    private int walletTotal = 0;
    public Vector3 placeHolderPostion;

    /// SPAWN STUFF
    /// 
    public GameObject background;
    public GameObject[] obsticalPrefab;
    public GameObject bomb;
    public GameObject money;
    public string playerType;//Player0
    public  int playerIndex;
    public GameObject[] player; 
    private Vector3 spawnPosMoney = new Vector3(25, 4, 0);
    private Vector3 spawnPosObstical = new Vector3(25, 0, 0);
    private float startDelay = 2;
   
    //version 2 spawn system
    float spawnInterval;
    float spawnIntervalMin = 0.4f; //in seconds
    float spawnIntervalMax = 2f;
    int moreMoneySpawned = 2; // cycles more money vs obsticals
    float randomizer = 1; // puts bombs in with money

    /// <summary>
    /// /LEVEL CHANGE
    /// </summary>
    public int timesBackgroundTilled;


    public void LoadPlayerSelect()
    {
        SceneManager.LoadScene(1);
    }
   // SceneManager.sceneLoaded


    private void Update()
    {
      //  if (highScore > 0) { SetHighScore(0); }
        //SPAWN SYSTEM
        spawnInterval -= Time.deltaTime;
        if(spawnInterval<=0)
        {
           // Debug.Log(moreMoneySpawned);

            if (moreMoneySpawned > 0)
            {
                  SpawnMoney();
                moreMoneySpawned--;
            }
            else {
               SpawnObstacle();
                moreMoneySpawned = 2;
            }
            spawnInterval = Random.Range(spawnIntervalMin, spawnIntervalMax);
        }
    }
    public void SetHighScore(int wallet) {
        highScoreText = GameObject.Find("Canvas/Score/HighScoreText").GetComponent<TextMeshProUGUI>();
        if (wallet > highScore) { highScore = wallet; }
    highScoreText.text ="HIGH SCORE $"+ highScore;
    }


    private void Start()
    {
        //PAUSE AT GAMESTART
        isGameActive = false;
        //playerToSelect = GameObject.Find(GameManager.Instance.playerType);


       // Debug.Log(playerType);
        //NEW SPAWN SYSTEM-runs on Update() per frame basis
        spawnInterval = Random.Range(spawnIntervalMin, spawnIntervalMax);
       // 
        moreMoneySpawned = 2;

        SetHighScore(0);
        //UI NEEDS TO BE REACTIVATED AFTER GETTING GAME CHARACTER CHANGE
        //turn off the scoreboard before playing.
       // GameObject.Find("Canvas/Score").SetActive(false);

    }
    public void OnLevelWasLoaded()
    {
        scoreViewer = GameObject.Find("Canvas/Score");
        //scoreViewer.SetActive(true);
       
        SetHighScore(0);
    }
    
    public void RestartGame()///RESTART
    {
        startMenu = GameObject.Find("Canvas/StartMenu");
       // scoreViewer = GameObject.Find("Canvas/Score");
        scoreViewer.SetActive(true);
        highScoreText = GameObject.Find("Canvas/Score/HighScoreText").GetComponent<TextMeshProUGUI>();
        walletText = GameObject.Find("Canvas/Score/WalletText").GetComponent<TextMeshProUGUI>();
        //highScoreText.text = highScore;
        GetMoney(0);
        SetHighScore(0);
        //UI
        startMenu.SetActive(false);
        // scoreViewer.SetActive(true);
        //
        RemoveAllGameObjects();

        walletTotal = 0;
        SetHighScore(0);
        GetMoney(0);
        isGameActive = true;
        timesBackgroundTilled = 0;
        
        
        SpawnStuff();
    }
    public int GetSelectedCharacter(string PlayerString)
    {   
       //RETURN PLAYER NUMBER FROM STRING
        return System.Convert.ToInt32(PlayerString.Substring(6, 1));
    }
    /// <summary>
    public void SpawnStuff()
    {
       // Debug.Log(playerIndex);
       // GameObject.
       Instantiate(player[playerIndex], new Vector3(0, 0, 0), player[playerIndex].transform.rotation);
      
        isGameActive = true;
        tileBackgroundReset();
    }
    public void tileBackgroundReset()
    {
        timesBackgroundTilled = 0;
    }

    void SpawnObstacle()
    {
        if (isGameActive)
        {
            Instantiate(obsticalPrefab[Random.Range(0, obsticalPrefab.Length)], spawnPosObstical, obsticalPrefab[0].transform.rotation);

        }
    }
    void SpawnMoney()
    {
        
       // Debug.Log("Money From the Sky");
        if (isGameActive)
        {
            randomizer = Random.Range(0f, 5f);
           // Debug.Log("randomizer" + randomizer);
            if (randomizer > 2f) {
                Instantiate(money, spawnPosMoney, obsticalPrefab[0].transform.rotation); }
            else {
                Instantiate(bomb, spawnPosMoney, obsticalPrefab[0].transform.rotation);
            }
        }

    }

    /// </summary>

    


    public void RemoveAllGameObjects()
    {
        //DESTROY OBSTICALS 
        GameObject[] gos = GameObject.FindGameObjectsWithTag("Obstical");
        foreach (GameObject go in gos) { Destroy(go); }
        //DESTROY MONEY
        GameObject[] moneyArray = GameObject.FindGameObjectsWithTag("Money");
        foreach (GameObject go in moneyArray) { Destroy(go); }
        //DESTROY BOMB
        GameObject[] bombArray = GameObject.FindGameObjectsWithTag("Bomb");
        foreach (GameObject go in bombArray) { Destroy(go); }
        //DESTROY PLAYER
        GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
        foreach (GameObject go in players) { Destroy(go); }
    }
    public void GetMoney(int moneyCollected)
    {
        walletTotal += moneyCollected;
        SetHighScore(walletTotal);
        walletText.text = "You've got $" + walletTotal;
    }
    public void GameOver()
    {

        isGameActive = false;
        startMenu.SetActive(true);
        tryAgainText = GameObject.Find("Canvas/StartMenu/About").GetComponent<TextMeshProUGUI>();
        tryAgainText.text = "Do you want to try again?";
    }
    public void Test() {
        Debug.Log("IT WORKS");
    }

}
