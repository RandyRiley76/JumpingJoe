using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class PlayerSelectManager : MonoBehaviour
{
  //  public ParticleSystem moneyBlast;
    public ParticleSystem dirtParticle;
    //public ParticleSystem explosionParticle;

    public GameObject playerToSelect;
    private GameObject displayPlayer;
    private Animator playerAnim;
    // Start is called before the first frame update
    void Start()
    {
        //SHOW JUMPING JOE AS SELECTED at 2.5x scale and play;
        //create a gameobject var of the player based off player type name
        playerToSelect = GameObject.Find(GameManager.Instance.playerType);
        ChangeDisplayPlayer();
    }
    public void ChangeDisplayPlayer() {


        //Kill the Player Displayed so there are not 2
        if (displayPlayer != null) { Destroy(displayPlayer); }
      
        //PREVIEW PLAYER CREATION
        displayPlayer = Instantiate(playerToSelect, new Vector3(0, -3.52f, 5.31f), Quaternion.Euler(0, 150, 0)) as GameObject;
       //Scale to 2.5x
        displayPlayer.transform.localScale += new Vector3(1.5f, 1.5f, 1.5f);
       //Set the Preview Player to Walk
        displayPlayer.GetComponent<Animator>().SetFloat("Speed_f", 1);
        //dirtParticle.Play();
        GameManager.Instance.playerType = playerToSelect.name;
        //Debug.Log(playerToSelect.name);
        //GameManager.Instance.Test();
    }
    // Update is called once per frame
    void Update()
    {
        //SLOWLY ROTATE PREVIEW PLAYER
        displayPlayer.transform.Rotate(Vector3.up *100* Time.deltaTime);
    }
    public void BackToGame()
    {
            SceneManager.LoadScene(0);
       
    }
}
