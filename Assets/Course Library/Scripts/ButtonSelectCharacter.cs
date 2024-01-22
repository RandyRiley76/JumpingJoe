using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ButtonSelectCharacter : MonoBehaviour
{

    private Button loadButton;
    private GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

        loadButton = GetComponent<Button>();
        loadButton.onClick.AddListener(gameManager.LoadPlayerSelect);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
