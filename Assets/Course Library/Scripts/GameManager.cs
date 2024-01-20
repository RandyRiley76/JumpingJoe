using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {
    /// UI
    public GameObject startMenu;
    public GameObject scoreViewer;//show level and money in left
    public TextMeshProUGUI walletText;
   // public TextMeshProUGUI levelText;
    public TextMeshProUGUI highScoreText;
    public TextMeshProUGUI tryAgainText;

    public bool isGameActive;
    private int highScore=0;
    private int walletTotal = 0;
    // public GameObject spawnManager;

    /// SPAWN STUFF
    /// 
    public GameObject background;
    public GameObject[] obsticalPrefab;
    public GameObject bomb;
    public GameObject money;
    public GameObject player;
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

    private void Update()
    {
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
    private void SetHighScore(int wallet) {
        if (wallet > highScore) { highScore = wallet; }
    highScoreText.text ="HIGH SCORE $"+ highScore;
    }
    private void Start()
    {
        isGameActive = false;
        GetMoney(0);
        SetHighScore(0);
        //
        
        //NEW SPAWN SYSTEM-runs on Update() per frame basis
        spawnInterval = Random.Range(spawnIntervalMin, spawnIntervalMax);

        moreMoneySpawned = 2;
        Physics.gravity *= 3;
    }
    /// <summary>
    public void SpawnStuff()
    {
       // GameObject.
        Instantiate(player, new Vector3(0, 0, 0), player.transform.rotation);
        isGameActive = true;
        tileBackgroundReset();

        // Debug.Log("Spawing Stuff");

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

public void GameOver() {
     
        isGameActive = false;
       startMenu.SetActive(true);
        tryAgainText.text = "Do you want to try again?";
    }
 
    public void RestartGame()
    {

        RemoveAllGameObjects();
        SetHighScore(walletTotal);
        walletTotal = 0;
        isGameActive = true;
        //highScoreText.text = "LEVEL 1";

        GetMoney(0);
        timesBackgroundTilled = 0;
        //Debug.Log("Game Over " + timesBackgroundTilled);
        //UI
        startMenu.SetActive(false);
        scoreViewer.SetActive(true);
        
        SpawnStuff();
       
    }
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


}
