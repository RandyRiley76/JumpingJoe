using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class RepeatBackground : MonoBehaviour
{
    public TextMeshProUGUI levelText;
    public SpriteRenderer spriteRenderer;
    public Sprite bgCity ;
    public Sprite bgTown ;
    public Sprite bgNature;
    //public int timesTilled;


    public GameManager gameManager;

   private int timesForLevel_1 = 2;
    private int timesForLevel_2 = 6;



    private Vector3 startPos;
    private float repeatWidth;
    // Start is called before the first frame update
    void Start()
    {
        // gameManager = GetComponent<GameManager>();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

        // gameManager.timesBackgroundTilled = 0;
        startPos = transform.position;
        repeatWidth = GetComponent<BoxCollider>().size.x / 2;

        //THIS WORKS spriteRenderer.sprite = bgNature;
       // spriteRenderer.sprite = bgCity;
    }


    // Update is called once per frame
    void Update()
    { 
       // Debug.Log(gameManager.timesBackgroundTilled);
        //Reset the Background to city 
        if (gameManager.timesBackgroundTilled == 0)
        {
           
            spriteRenderer.sprite = bgCity;
        }
        //REPEAT BACKGROUND
        if (transform.position.x < startPos.x - repeatWidth) {
            transform.position = startPos;
            gameManager.timesBackgroundTilled++;
            //CHANGE BACKGROUND SPRITE
            
                if (gameManager.timesBackgroundTilled == timesForLevel_1)
            {
                spriteRenderer.sprite = bgTown;
                gameManager.GoToLevelMenu();
               // levelText.text = "LEVEL 2";
            }
            else if (gameManager.timesBackgroundTilled == timesForLevel_1+timesForLevel_2) {
                spriteRenderer.sprite = bgNature;
               // levelText.text = "LEVEL 3";
            }
        }
    }
}
