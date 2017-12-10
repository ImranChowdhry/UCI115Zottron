using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class HillLogic : MonoBehaviour
{
    private GameObject player1;
    private GameObject player2;

    private Color player1OriginalColor;

    public Text hillTimer1Text;
    public Text hillTimer2Text;

    // Use this for initialization
    void Start ()
    {
        player1 = GameObject.FindGameObjectWithTag("Player1");
        player2 = GameObject.FindGameObjectWithTag("Player2");
        player1OriginalColor = player1.GetComponent<SpriteRenderer>().color;
        setPlayer1HillCountText();
        setPlayer2HillCountText();
    }
	
	// Update is called once per frame
	void Update ()
    {
        winner(player1);
    }

    private void winner(GameObject player)
    {
        setPlayer1HillCountText();
        setPlayer2HillCountText();
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
            setPlayer1HillCountText();
            player1.GetComponent<SpriteRenderer>().color = new Color(1f, 0.30196078f, 0.30196078f);
        }
        if (collision.tag == "Player2")
        {
            player2.GetComponent<Player>().hillTimer += Time.deltaTime;
            setPlayer2HillCountText();
            player2.GetComponent<SpriteRenderer>().color = new Color(1f, 0.30196078f, 0.30196078f);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player1")
        {
            player1.GetComponent<Player>().hillTimer += Time.deltaTime;
            setPlayer1HillCountText();
            player1.GetComponent<SpriteRenderer>().color = new Color(1f, 0.30196078f, 0.30196078f);
        }
        if (collision.tag == "Player2")
        {
            player2.GetComponent<Player>().hillTimer += Time.deltaTime;
            setPlayer2HillCountText();
            player2.GetComponent<SpriteRenderer>().color = new Color(1f, 0.30196078f, 0.30196078f);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player1")
        {
            player1.GetComponent<SpriteRenderer>().color = player1OriginalColor;
        }
        if (collision.tag == "Player2")
        {
            player2.GetComponent<SpriteRenderer>().color = player1OriginalColor;
        }
    }

    void setPlayer1HillCountText()
    {
        hillTimer1Text.text = "Player 1 time in hill: " + player1.GetComponent<Player>().hillTimer.ToString("F2");
    }

    void setPlayer2HillCountText()
    {
        hillTimer2Text.text = "Player 2 time in hill: " + player2.GetComponent<Player>().hillTimer.ToString("F2");
    }
}
