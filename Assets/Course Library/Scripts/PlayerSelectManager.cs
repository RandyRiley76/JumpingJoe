using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSelectManager : MonoBehaviour
{
    public GameObject playerToSelect;
    private GameObject displayPlayer;
    private Animator playerAnim;
    // Start is called before the first frame update
    void Start()
    {
        //SHOW JUMPING JOE AS SELECTED at 2.5x scale and play;
        playerToSelect = GameObject.Find("Player0");
        displayPlayer = Instantiate(playerToSelect, new Vector3(0, -3.52f, 5.31f), Quaternion.Euler(0, 150, 0)) as GameObject;
        displayPlayer.transform.localScale += new Vector3(1.5f, 1.5f, 1.5f);
        displayPlayer.GetComponent<Animator>().SetFloat("Speed_f", 1);
    }
    public void ChangeDisplayPlayer() {


        //Kill the Player Displayed so there are not 2
        Destroy(displayPlayer);
      
        //Display the new player
        displayPlayer = Instantiate(playerToSelect, new Vector3(0, -3.52f, 5.31f), Quaternion.Euler(0, 150, 0)) as GameObject;
        displayPlayer.transform.localScale += new Vector3(1.5f, 1.5f, 1.5f);
        displayPlayer.GetComponent<Animator>().SetFloat("Speed_f", 1);
       // playerAnim.SetFloat("Speed_f", 1);
    }
    // Update is called once per frame
    void Update()
    {
        displayPlayer.transform.Rotate(Vector3.up *100* Time.deltaTime);
    }
}
