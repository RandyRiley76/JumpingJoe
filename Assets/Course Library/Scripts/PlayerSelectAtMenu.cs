using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSelectAtMenu : MonoBehaviour
{
    private string selectedPlayer = "Player0";
    public GameObject playerToSelect;
    private Animator playerAnim;
    private GameObject displayPlayer;
    public GameObject playerSelectManager;

    // Start is called before the first frame update
    private void Awake()
    {
        playerAnim = GetComponent<Animator>();
        playerAnim.SetBool("Static_b", true);
        playerAnim.SetFloat("Speed_f", 0);
    }
    void Start()
    {
      
    //  Debug.Log(displayPlayer);

}
    private void OnMouseEnter()
    {
       playerAnim.SetFloat("Speed_f", 1);
    }
    private void OnMouseExit()
    {
        playerAnim.SetFloat("Speed_f", 0);
    }
    private void OnMouseDown()
    {
        // Debug.Log(gameObject.name);
        playerToSelect = GameObject.Find(gameObject.name);
        playerSelectManager.GetComponent<PlayerSelectManager>().playerToSelect = playerToSelect;
        playerSelectManager.GetComponent<PlayerSelectManager>().ChangeDisplayPlayer();
    
      
    }
   private void ShowChosenCharacter()
    {
        if (displayPlayer != null)
        {
          Debug.Log("DESTROY");
          Destroy(displayPlayer);
        }
       
        displayPlayer = Instantiate(playerToSelect, new Vector3(0, -3.52f, 5.31f), Quaternion.Euler(0, 150, 0)) as GameObject;
        displayPlayer.transform.localScale += new Vector3(1.5f, 1.5f, 1.5f);
       // 
       // Debug.Log(displayPlayer);


    }
}

