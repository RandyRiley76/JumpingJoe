using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyPlaceholder : MonoBehaviour
{
    public GameObject playerToDisplay;
    private int indexOfPlayer;
    // Start is called before the first frame update
    private void Start()
    {
        indexOfPlayer = GameManager.Instance.playerIndex;
         //  Instantiate(obsticalPrefab[Random.Range(0, obsticalPrefab.Length)], spawnPosObstical, obsticalPrefab[0].transform.rotation);
         // playerToDisplay = GameObject.Find(GameManager.Instance.playerType);

        // playerToDisplay = GameManager.Instance.player[];
        //playerToDisplay = GameManager.Instance.player[4];
        playerToDisplay = GameManager.Instance.player[indexOfPlayer];

        Instantiate(playerToDisplay, this.gameObject.transform.position, this.gameObject.transform.rotation);
       // Instantiate(GameManager.Instance.player[6], this.gameObject.transform.position, this.gameObject.transform.rotation);
       // Debug.Log(indexOfPlayer);
        Destroy(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
