using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    private GameObject player1;
    private GameObject player2;

    public float respawnTime;
    private bool respawnFlag1;
    private bool respawnFlag2;
    public AudioClip deathSound;
    public AudioClip respawnSound1;
    public AudioClip respawnSound2;

    public Text player1HealthText;
    public Text player2HealthText;
    // Use this for initialization
    void Start ()
    {
        player1 = GameObject.FindGameObjectWithTag("Player1");
        player2 = GameObject.FindGameObjectWithTag("Player2");
        respawnFlag1 = true;
        respawnFlag2 = true;
        setPlayer1HealthCountText();
        setPlayer2HealthCountText();
    }
	
	// Update is called once per frame
	void Update ()
    {
        setPlayer1HealthCountText();
        setPlayer2HealthCountText();
        respawnCheck();
    }

    void setPlayer1HealthCountText()
    {
        player1HealthText.text = "Player 1 Health: " + player1.GetComponent<Player1>().playerHealth.ToString();
    }

    void setPlayer2HealthCountText()
    {
        //player2HealthText.text = "Player 2 Health: " + player2.GetComponent<Player2>().playerHealth.ToString();
    }

    void respawnCheck()
    {
        if(player1.activeSelf == false && respawnFlag1)
        {
            StartCoroutine(RespawnPlayer1());
        }
        /*
        if (player2.activeSelf == false && respawnFlag2)
        {
            StartCoroutine(RespawnPlayer2());
        }
        */
    }

    IEnumerator RespawnPlayer1()
    {
        respawnFlag1 = false;

        GetComponent<AudioSource>().PlayOneShot(deathSound);

        yield return new WaitForSeconds(respawnTime);

        player1.transform.position = new Vector3(-27f, -20.0f, transform.position.z);
        player1.GetComponent<Player1>().playerHealth = 100;
        player1.SetActive(true);

        if (Random.Range(0.0f, 1.0f) <= 0.5f)
        {
            GetComponent<AudioSource>().PlayOneShot(respawnSound1);
        }
        else
        {
            GetComponent<AudioSource>().PlayOneShot(respawnSound2);
        }

        respawnFlag1 = true;
    }

    IEnumerator RespawnPlayer2()
    {
        respawnFlag2 = false;

        GetComponent<AudioSource>().PlayOneShot(deathSound);

        yield return new WaitForSeconds(respawnTime);

        player2.transform.position = new Vector3(27f, -20.0f, transform.position.z);
        player2.GetComponent<Player2>().playerHealth = 100;
        player2.SetActive(true);

        if (Random.Range(0.0f, 1.0f) <= 0.5f)
        {
            GetComponent<AudioSource>().PlayOneShot(respawnSound1);
        }
        else
        {
            GetComponent<AudioSource>().PlayOneShot(respawnSound2);
        }

        respawnFlag2 = true;
    }
}
