using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ButtonLevelMenu : MonoBehaviour
{

    private Button startButton;
    private GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

        startButton = GetComponent<Button>();
        startButton.onClick.AddListener(gameManager.NextLevel);
    }

}
