using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSelectAtMenu : MonoBehaviour
{
    public ParticleSystem moneyBlast;
    public ParticleSystem dirtParticle;
    public ParticleSystem explosionParticle;
    private string selectedPlayer = "Player0";
    public GameObject playerToSelect;
    private Animator playerAnim;
    private GameObject displayPlayer;
    public GameObject playerSelectManager;
    public GameManager GameManager;

    // Start is called before the first frame update
    private void Awake()
    {
        playerAnim = GetComponent<Animator>();
        playerAnim.SetBool("Static_b", true);
        playerAnim.SetFloat("Speed_f", 0);
    }
    void Start()
    {
        dirtParticle.Stop();
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
        moneyBlast.Play();
        //FIGURE OUT WHICH CHARACTER WAS SELECTED AND GIVE NAME
        playerToSelect = GameObject.Find(gameObject.name);
        playerSelectManager.GetComponent<PlayerSelectManager>().playerToSelect = playerToSelect;
        playerSelectManager.GetComponent<PlayerSelectManager>().ChangeDisplayPlayer();
        //GameManager.Instance.player = playerToSelect;
        GameManager.Instance.playerType = gameObject.name;
        GameManager.Instance.playerIndex = GameManager.Instance.GetSelectedCharacter(gameObject.name);
    }
}

