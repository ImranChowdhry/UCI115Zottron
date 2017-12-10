using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class HillLogic : MonoBehaviour
{
    private GameObject player1;
    private Color player1OriginalColor;

    public Text hillTimerText;

    // Use this for initialization
    void Start ()
    {
        player1 = GameObject.FindGameObjectWithTag("Player1");
        player1OriginalColor = player1.GetComponent<SpriteRenderer>().color;
        setPlayerHillCountText(1);
    }
	
	// Update is called once per frame
	void Update ()
    {
        winner(player1);
    }

    private void winner(GameObject player)
    {
        if (player.GetComponent<Player>().hillTimer >= 1.00)
        {
            print("Hello");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player1")
        {
            player1.GetComponent<Player>().hillTimer += Time.deltaTime;
            setPlayerHillCountText(1);
            player1.GetComponent<SpriteRenderer>().color = new Color(1f, 0.30196078f, 0.30196078f);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player1")
        {
            player1.GetComponent<Player>().hillTimer += Time.deltaTime;
            setPlayerHillCountText(1);
            player1.GetComponent<SpriteRenderer>().color = new Color(1f, 0.30196078f, 0.30196078f);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player1")
        {
            player1.GetComponent<SpriteRenderer>().color = player1OriginalColor;
        }
    }

    void setPlayerHillCountText(int player)
    {
        hillTimerText.text = "Player " + player.ToString() + " time in hill: " + player1.GetComponent<Player>().hillTimer.ToString("F2");
    }
}
