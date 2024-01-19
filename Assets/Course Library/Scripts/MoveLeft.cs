using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    //PlayerController allows us to get to another variable on a game object
    //private PlayerController playerControllerScript;
    public GameManager gameManager;
    private float speed = 15;
    private float leftBounds = -15;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
       // playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        //Move Left
        // if(playerControllerScript.gameOver == false)
        if (gameManager.isGameActive) { 
        transform.Translate(Vector3.left * Time.deltaTime * speed);}
        //Remove off screen obsticals
        if(transform.position.x < leftBounds )//&& gameObject.CompareTag("Obstical")) 
        {
            Destroy(gameObject);
        }

    }
}
