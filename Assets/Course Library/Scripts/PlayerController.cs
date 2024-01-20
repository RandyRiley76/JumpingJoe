using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
   
    private AudioSource playerAudio;
    public AudioClip jumpSound;
    public AudioClip crashSound;
    public AudioClip getMoneySound;
    public ParticleSystem moneyBlast;
    public ParticleSystem dirtParticle;
    public ParticleSystem explosionParticle;
    private Animator playerAnim;
    private Rigidbody playerRb;
    public float jumpForce = 10;
   
    //public float gravityMultiplier = 2;
    public bool isOnGround = true;
    //public bool gameOver = false;
    public GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
        //GET REF TO GAME MANAGER SCRIPT
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        playerAudio = GetComponent<AudioSource>();
        playerRb = GetComponent<Rigidbody>();
        playerAnim = GetComponent<Animator>();
        // Physics.gravity *= gravityMultiplier;

       // playerAudio.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
       // if (Input.GetMouseButtonDown(0)) {
       //     Debug.Log("Click");
       // }

        //Physics jump
        if ((Input.GetKeyDown(KeyCode.Space)|| Input.GetMouseButtonDown(0)) && isOnGround==true && gameManager.isGameActive) {
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isOnGround = false;
            dirtParticle.Stop();
            //play jump animation
            playerAnim.SetTrigger("Jump_trig");
            playerAudio.PlayOneShot(jumpSound, 1f);
        }
    }
    private void OnTriggerEnter(Collider collision)//Moved the collisions to be triggers so that it wouldn't bounce off object when getting powerup
    {
          if (collision.gameObject.CompareTag("Money"))
        {
            // Debug.Log("Its $ Time");
            moneyBlast.Play();
            Destroy(collision.gameObject);
            playerAudio.PlayOneShot(getMoneySound, 1f);
            gameManager.GetMoney(1);
        }
        else if (collision.gameObject.CompareTag("Bomb"))
        {

            Destroy(collision.gameObject);
            GameOver();
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        //IF ON GROUND THEN PLAY THE DIRT PARTICLES
        if (collision.gameObject.CompareTag("Obstical"))
        {
            // Destroy(collision.gameObject);
            GameOver();
        }
        else if (collision.gameObject.CompareTag("Ground")&& gameManager.isGameActive)
        {
            isOnGround = true;
            dirtParticle.Play();
            
        }
  
    }
    private void GameOver() {
        playerAnim.SetBool("Death_b", true);
        playerAnim.SetInteger("Death_b", 1);
        dirtParticle.Stop();
        explosionParticle.Play();
        playerAudio.PlayOneShot(crashSound, 1f);
        // RemoveAllGameObjects();
       
        gameManager.GameOver();
        
    }

}
