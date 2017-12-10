using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    private GameObject player1;
    public float respawnTime;
    private bool respawnFlag;
    public AudioClip deathsound1;
    public AudioClip deathsound2;

    public Text playerHealthText;
    // Use this for initialization
    void Start ()
    {
        player1 = GameObject.FindGameObjectWithTag("Player1");
        respawnFlag = true;
        setPlayerHealthCountText(1);
    }
	
	// Update is called once per frame
	void Update ()
    {
        setPlayerHealthCountText(1);
        respawnCheck();
    }

    void setPlayerHealthCountText(int player)
    {
        playerHealthText.text = "Player " + player.ToString() + " Health: " + player1.GetComponent<Player>().playerHealth.ToString();
    }

    void respawnCheck()
    {
        if(player1.activeSelf == false && respawnFlag)
        {
            StartCoroutine(Respawn());
        }
    }

    IEnumerator Respawn()
    {
        respawnFlag = false;
        if (Random.Range(0.0f, 1.0f) >= 0.5f)
        {
            GetComponent<AudioSource>().PlayOneShot(deathsound1);
        }
        else
        {
            GetComponent<AudioSource>().PlayOneShot(deathsound2);
        }
        yield return new WaitForSeconds(respawnTime);
        if (gameObject.tag == "Player1")
        {
            player1.transform.position = new Vector3(-20f, -25.5f, transform.position.z);
            player1.SetActive(true);
        }
        else if (gameObject.tag == "Player2")
        {
            player1.transform.position = new Vector3(-20, -25, transform.position.z);
        }
        respawnFlag = true;
    }
}
